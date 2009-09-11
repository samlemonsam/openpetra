﻿/*************************************************************************
 *
 * DO NOT REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
 *
 * @Authors:
 *       timop
 *
 * Copyright 2004-2009 by OM International
 *
 * This file is part of OpenPetra.org.
 *
 * OpenPetra.org is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * OpenPetra.org is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with OpenPetra.org.  If not, see <http://www.gnu.org/licenses/>.
 *
 ************************************************************************/
using System;
using System.Data;
using System.Collections.Specialized;
using System.Collections.Generic;
using Mono.Unix;
using Ict.Petra.Shared;
using Ict.Common;
using Ict.Common.DB;
using Ict.Common.Data;
using Ict.Common.Verification;
using Ict.Petra.Server.MFinance;
using Ict.Petra.Server.MFinance.GL;
using Ict.Petra.Shared.MFinance;
using Ict.Petra.Shared.MFinance.GL.Data;
using Ict.Petra.Shared.MFinance.AP.Data;
using Ict.Petra.Server.MFinance.AP.Data.Access;
using Ict.Petra.Server.MFinance.Account.Data.Access;
using Ict.Petra.Server.MPartner.Partner.ServerLookups;
using Ict.Petra.Shared.MFinance.Account.Data;
using Ict.Petra.Shared.Interfaces.MFinance.AccountsPayable.WebConnectors;

namespace Ict.Petra.Server.MFinance.AccountsPayable.WebConnectors
{
    ///<summary>
    /// This connector provides data for the finance Accounts Payable screens
    ///</summary>
    public class TTransactionWebConnector
    {
        /// <summary>
        /// Passes data as a Typed DataSet to the Transaction Edit Screen
        /// </summary>
        public static AccountsPayableTDS LoadAApDocument(Int32 ALedgerNumber, Int32 AAPNumber)
        {
            // create the DataSet that will later be passed to the Client
            AccountsPayableTDS MainDS = new AccountsPayableTDS();

            AApDocumentAccess.LoadByPrimaryKey(MainDS, ALedgerNumber, AAPNumber, null);
            AApDocumentDetailAccess.LoadViaAApDocument(MainDS, ALedgerNumber, AAPNumber, null);
            AApSupplierAccess.LoadByPrimaryKey(MainDS, MainDS.AApDocument[0].PartnerKey, null);

            // Accept row changes here so that the Client gets 'unmodified' rows
            MainDS.AcceptChanges();

            // Remove all Tables that were not filled with data before remoting them.
            MainDS.RemoveEmptyTables();

            return MainDS;
        }

        /// <summary>
        /// create a new AP document (invoice or credit note) and fill with default values from the supplier
        /// </summary>
        /// <param name="ALedgerNumber"></param>
        /// <param name="APartnerKey">the supplier</param>
        /// <param name="ACreditNoteOrInvoice">true: credit note; false: invoice</param>
        /// <returns></returns>
        public static AccountsPayableTDS CreateAApDocument(Int32 ALedgerNumber, Int64 APartnerKey, bool ACreditNoteOrInvoice)
        {
            // create the DataSet that will later be passed to the Client
            AccountsPayableTDS MainDS = new AccountsPayableTDS();

            AApDocumentRow NewDocumentRow = MainDS.AApDocument.NewRowTyped();

            NewDocumentRow.ApNumber = -1; // ap number will be set in SubmitChanges
            NewDocumentRow.LedgerNumber = ALedgerNumber;
            NewDocumentRow.PartnerKey = APartnerKey;
            NewDocumentRow.CreditNoteFlag = ACreditNoteOrInvoice;
            NewDocumentRow.DocumentStatus = MFinanceConstants.AP_DOCUMENT_OPEN;
            NewDocumentRow.LastDetailNumber = -1;

            // get the supplier defaults
            AApSupplierTable tempTable;
            tempTable = AApSupplierAccess.LoadByPrimaryKey(APartnerKey, null);

            if (tempTable.Rows.Count == 1)
            {
                MainDS.AApSupplier.Merge(tempTable);

                AApSupplierRow Supplier = MainDS.AApSupplier[0];

                if (!Supplier.IsDefaultCreditTermsNull())
                {
                    NewDocumentRow.CreditTerms = Supplier.DefaultCreditTerms;
                }

                if (!Supplier.IsDefaultDiscountDaysNull())
                {
                    NewDocumentRow.DiscountDays = Supplier.DefaultDiscountDays;
                }

                if (!Supplier.IsDefaultDiscountPercentageNull())
                {
                    NewDocumentRow.DiscountPercentage = Supplier.DefaultDiscountPercentage;
                }

                if (!Supplier.IsDefaultApAccountNull())
                {
                    NewDocumentRow.ApAccount = Supplier.DefaultApAccount;
                }
            }

            MainDS.AApDocument.Rows.Add(NewDocumentRow);

            // Remove all Tables that were not filled with data before remoting them.
            MainDS.RemoveEmptyTables();

            return MainDS;
        }

        /// <summary>
        /// store the AP Document (and document details)
        ///
        /// All DataTables contained in the Typed DataSet are inspected for added,
        /// changed or deleted rows by submitting them to the DataStore.
        ///
        /// </summary>
        /// <param name="AInspectDS">Typed DataSet that needs to contain known DataTables</param>
        /// <param name="AVerificationResult">Null if all verifications are OK and all DB calls
        /// succeded, otherwise filled with 1..n TVerificationResult objects
        /// (can also contain DB call exceptions)</param>
        /// <returns>true if all verifications are OK and all DB calls succeeded, false if
        /// any verification or DB call failed
        /// </returns>
        public static TSubmitChangesResult SaveAApDocument(ref AccountsPayableTDS AInspectDS,
            out TVerificationResultCollection AVerificationResult)
        {
            TDBTransaction SubmitChangesTransaction;
            TSubmitChangesResult SubmissionResult = TSubmitChangesResult.scrError;

            AVerificationResult = null;

            if (AInspectDS != null)
            {
                AVerificationResult = new TVerificationResultCollection();
                SubmitChangesTransaction = DBAccess.GDBAccessObj.BeginTransaction(IsolationLevel.Serializable);
                try
                {
                    // set AP Number if it has not been set yet
                    if (AInspectDS.AApDocument[0].ApNumber == -1)
                    {
                        StringCollection fieldlist = new StringCollection();
                        ALedgerTable myLedgerTable;
                        fieldlist.Add(ALedgerTable.GetLastApInvNumberDBName());
                        myLedgerTable = ALedgerAccess.LoadByPrimaryKey(
                            AInspectDS.AApDocument[0].LedgerNumber,
                            fieldlist,
                            SubmitChangesTransaction);
                        myLedgerTable[0].LastApInvNumber++;
                        AInspectDS.AApDocument[0].ApNumber = myLedgerTable[0].LastApInvNumber;

                        foreach (AApDocumentDetailRow detailrow in AInspectDS.AApDocumentDetail.Rows)
                        {
                            detailrow.ApNumber = AInspectDS.AApDocument[0].ApNumber;
                        }

                        ALedgerAccess.SubmitChanges(myLedgerTable, SubmitChangesTransaction, out AVerificationResult);
                    }

                    if (AApDocumentAccess.SubmitChanges(AInspectDS.AApDocument, SubmitChangesTransaction,
                            out AVerificationResult))
                    {
                        if (AApDocumentDetailAccess.SubmitChanges(AInspectDS.AApDocumentDetail, SubmitChangesTransaction,
                                out AVerificationResult))
                        {
                            SubmissionResult = TSubmitChangesResult.scrOK;
                        }
                        else
                        {
                            SubmissionResult = TSubmitChangesResult.scrError;
                        }
                    }
                    else
                    {
                        SubmissionResult = TSubmitChangesResult.scrError;
                    }

                    if (SubmissionResult == TSubmitChangesResult.scrOK)
                    {
                        DBAccess.GDBAccessObj.CommitTransaction();
                    }
                    else
                    {
                        DBAccess.GDBAccessObj.RollbackTransaction();
                    }
                }
                catch (Exception e)
                {
                    TLogging.Log("after submitchanges: exception " + e.Message);

                    DBAccess.GDBAccessObj.RollbackTransaction();

                    throw new Exception(e.ToString() + " " + e.Message);
                }
            }

            return SubmissionResult;
        }

        /// <summary>
        /// create a new AP document detail for an existing AP document;
        /// attention: need to modify the LastDetailNumber on the client side!
        /// </summary>
        /// <param name="ALedgerNumber"></param>
        /// <param name="AApNumber"></param>
        /// <param name="AApSupplier_DefaultExpAccount"></param>
        /// <param name="AApSupplier_DefaultCostCentre"></param>
        /// <param name="AAmount">the amount that is still missing from the total amount of the invoice</param>
        /// <param name="ALastDetailNumber">AApDocument.LastDetailNumber</param>
        /// <returns>the new AApDocumentDetail row</returns>
        public static AccountsPayableTDS CreateAApDocumentDetail(Int32 ALedgerNumber,
            Int32 AApNumber,
            string AApSupplier_DefaultExpAccount,
            string AApSupplier_DefaultCostCentre,
            double AAmount,
            Int32 ALastDetailNumber)
        {
            // create the DataSet that will later be passed to the Client
            AccountsPayableTDS MainDS = new AccountsPayableTDS();

            AApDocumentDetailRow NewRow = MainDS.AApDocumentDetail.NewRowTyped();

            NewRow.ApNumber = AApNumber;
            NewRow.LedgerNumber = ALedgerNumber;
            NewRow.DetailNumber = ALastDetailNumber;
            NewRow.Amount = AAmount;
            NewRow.CostCentreCode = AApSupplier_DefaultCostCentre;
            NewRow.AccountCode = AApSupplier_DefaultExpAccount;

            MainDS.AApDocumentDetail.Rows.Add(NewRow);

            // Remove all Tables that were not filled with data before remoting them.
            MainDS.RemoveEmptyTables();

            return MainDS;
        }

        /// <summary>
        /// Find AP Documents
        /// TODO: date
        /// </summary>
        public static AccountsPayableTDS FindAApDocument(Int32 ALedgerNumber, Int64 ASupplierKey,
            string ADocumentStatus,
            bool IsCreditNoteNotInvoice,
            bool AHideAgedTransactions)
        {
            // create the DataSet that will later be passed to the Client
            AccountsPayableTDS MainDS = new AccountsPayableTDS();

            AApSupplierAccess.LoadByPrimaryKey(MainDS, ASupplierKey, null);

            // TODO: filters for documents
            // TODO: filter by ledger number
            AApDocumentAccess.LoadViaAApSupplier(MainDS, ASupplierKey, null);

            return MainDS;
        }

        /// <summary>
        /// load the AP documents and see if they are ready to be posted
        /// </summary>
        /// <param name="ALedgerNumber"></param>
        /// <param name="AAPDocumentNumbers"></param>
        /// <param name="APostingDate"></param>
        /// <param name="AVerifications"></param>
        /// <returns></returns>
        private static AccountsPayableTDS LoadDocumentsAndCheck(Int32 ALedgerNumber,
            List <Int32>AAPDocumentNumbers,
            DateTime APostingDate,
            out TVerificationResultCollection AVerifications)
        {
            AccountsPayableTDS MainDS = new AccountsPayableTDS();

            AVerifications = new TVerificationResultCollection();

            // collect the AP documents from the database
            foreach (Int32 APDocumentNumber in AAPDocumentNumbers)
            {
                AApDocumentAccess.LoadByPrimaryKey(MainDS, ALedgerNumber, APDocumentNumber, null);
                AApDocumentDetailAccess.LoadViaAApDocument(MainDS, ALedgerNumber, APDocumentNumber, null);
            }

            // do some checks on state of AP documents
            foreach (AApDocumentRow row in MainDS.AApDocument.Rows)
            {
                if (row.DocumentStatus != MFinanceConstants.AP_DOCUMENT_APPROVED)
                {
                    AVerifications.Add(new TVerificationResult(
                            Catalog.GetString("error during posting of AP document"),
                            String.Format(Catalog.GetString("Document with Number {0} cannot be posted since the status is {1}."),
                                row.ApNumber, row.DocumentStatus), TResultSeverity.Resv_Critical));
                }

                // TODO: also check if details are filled, and they each have a costcentre and account? totals match sum of details

                // TODO: check for document.apaccount, if not set, get the default apaccount from the supplier, and save the ap document
            }

            // is APostingDate inside the valid posting periods?
            Int32 DateEffectivePeriodNumber;
            TDBTransaction Transaction = DBAccess.GDBAccessObj.BeginTransaction(IsolationLevel.ReadCommitted);

            if (!TFinancialYear.IsValidPeriod(ALedgerNumber, APostingDate, out DateEffectivePeriodNumber, Transaction))
            {
                AVerifications.Add(new TVerificationResult(
                        String.Format(Catalog.GetString("Cannot post the AP documents in Ledger {0}"), ALedgerNumber),
                        String.Format(Catalog.GetString("The Date Effective {0:d-MMM-yyyy} does not fit any open accounting period."),
                            APostingDate),
                        TResultSeverity.Resv_Critical));
            }

            DBAccess.GDBAccessObj.RollbackTransaction();

            // TODO: check if the amount of the document equals the totals of details

            return MainDS;
        }

        /// <summary>
        /// creates the GL batch needed for posting the AP Documents
        /// </summary>
        /// <param name="ALedgerNumber"></param>
        /// <param name="APostingDate"></param>
        /// <param name="APDataset"></param>
        /// <returns></returns>
        private static GLBatchTDS CreateGLBatchAndTransactions(Int32 ALedgerNumber, DateTime APostingDate, ref AccountsPayableTDS APDataset)
        {
            // create one GL batch
            GLBatchTDS GLDataset = Ict.Petra.Server.MFinance.GL.WebConnectors.TTransactionWebConnector.CreateABatch(ALedgerNumber);

            ABatchRow batch = GLDataset.ABatch[0];

            batch.BatchDescription = Catalog.GetString("Accounts Payable Batch");
            batch.DateEffective = APostingDate;
            batch.BatchStatus = MFinanceConstants.BATCH_UNPOSTED;

            // since the AP documents can be for several suppliers, the currency might be different; group by currency first
            SortedList <string, List <AApDocumentRow>>DocumentsByCurrency = new SortedList <string, List <AApDocumentRow>>();
            TDBTransaction Transaction = DBAccess.GDBAccessObj.BeginTransaction(IsolationLevel.ReadCommitted);

            foreach (AApDocumentRow row in APDataset.AApDocument.Rows)
            {
                DataView findSupplier = APDataset.AApSupplier.DefaultView;
                findSupplier.RowFilter = AApSupplierTable.GetPartnerKeyDBName() + " = " + row.PartnerKey.ToString();

                if (findSupplier.Count == 0)
                {
                    AApSupplierAccess.LoadByPrimaryKey(APDataset, row.PartnerKey, Transaction);
                }

                string CurrencyCode = ((AApSupplierRow)findSupplier[0].Row).CurrencyCode;

                DocumentsByCurrency.Add(CurrencyCode, new List <AApDocumentRow>());
                DocumentsByCurrency[CurrencyCode].Add(row);
            }

            Int32 CounterJournals = 1;

            // add journal for each currency and the transactions
            foreach (string CurrencyCode in DocumentsByCurrency.Keys)
            {
                AJournalRow journal = GLDataset.AJournal.NewRowTyped();
                journal.LedgerNumber = batch.LedgerNumber;
                journal.BatchNumber = batch.BatchNumber;
                journal.JournalNumber = CounterJournals++;
                journal.DateEffective = batch.DateEffective;
                journal.TransactionCurrency = CurrencyCode;
                journal.JournalDescription = "TODO"; // TODO: journal description for posting AP documents
                journal.TransactionTypeCode = MFinanceConstants.TRANSACTION_STD;
                journal.SubSystemCode = MFinanceConstants.SUB_SYSTEM_AP;
                journal.DateOfEntry = DateTime.Now;

                // TODO journal.ExchangeRateToBase
                journal.ExchangeRateToBase = 1.0;

                // TODO journal.ExchangeRateTime
                GLDataset.AJournal.Rows.Add(journal);

                Int32 TransactionCounter = 1;

                foreach (AApDocumentRow document in DocumentsByCurrency[CurrencyCode])
                {
                    ATransactionRow transaction = null;
                    DataView DocumentDetails = APDataset.AApDocumentDetail.DefaultView;
                    DocumentDetails.RowFilter = AApDocumentDetailTable.GetApNumberDBName() + " = " + document.ApNumber.ToString();

                    string SupplierShortName;
                    TPartnerClass SupplierPartnerClass;
                    TPartnerServerLookups.GetPartnerShortName(document.PartnerKey, out SupplierShortName, out SupplierPartnerClass);

                    foreach (DataRowView rowview in DocumentDetails)
                    {
                        AApDocumentDetailRow documentDetail = (AApDocumentDetailRow)rowview.Row;

                        // TODO: analysis attributes

                        transaction = GLDataset.ATransaction.NewRowTyped();
                        transaction.LedgerNumber = journal.LedgerNumber;
                        transaction.BatchNumber = journal.BatchNumber;
                        transaction.JournalNumber = journal.JournalNumber;
                        transaction.TransactionNumber = TransactionCounter++;
                        transaction.TransactionAmount = documentDetail.Amount;

                        // TODO: support foreign currencies
                        transaction.AmountInBaseCurrency = documentDetail.Amount;

                        if (document.CreditNoteFlag)
                        {
                            transaction.AmountInBaseCurrency *= -1;
                        }

                        transaction.DebitCreditIndicator = (transaction.AmountInBaseCurrency > 0);

                        if (transaction.AmountInBaseCurrency < 0)
                        {
                            transaction.AmountInBaseCurrency *= -1;
                        }

                        transaction.AccountCode = documentDetail.AccountCode;
                        transaction.CostCentreCode = documentDetail.CostCentreCode;
                        transaction.Narrative = "AP:" + document.ApNumber.ToString() + " - " + documentDetail.Narrative + " - " + SupplierShortName;
                        transaction.Reference = documentDetail.ItemRef;

                        // TODO transaction.DetailNumber

                        GLDataset.ATransaction.Rows.Add(transaction);
                    }

                    // create one transaction for the AP account
                    transaction = GLDataset.ATransaction.NewRowTyped();
                    transaction.LedgerNumber = journal.LedgerNumber;
                    transaction.BatchNumber = journal.BatchNumber;
                    transaction.JournalNumber = journal.JournalNumber;
                    transaction.TransactionNumber = TransactionCounter++;
                    transaction.TransactionAmount = document.TotalAmount;

                    // TODO: support foreign currencies
                    transaction.AmountInBaseCurrency = document.TotalAmount;

                    if (document.CreditNoteFlag)
                    {
                        transaction.AmountInBaseCurrency *= -1;
                    }

                    transaction.DebitCreditIndicator = (transaction.AmountInBaseCurrency > 0);

                    if (transaction.AmountInBaseCurrency < 0)
                    {
                        transaction.AmountInBaseCurrency *= -1;
                    }

                    transaction.DebitCreditIndicator = false;

                    // TODO: if document.ApAccount is empty, look for supplier default ap account?
                    transaction.AccountCode = document.ApAccount;
                    transaction.CostCentreCode = Ict.Petra.Server.MFinance.GL.WebConnectors.TTransactionWebConnector.GetStandardCostCentre(
                        ALedgerNumber);
                    transaction.Narrative = "AP:" + document.ApNumber.ToString() + " - " + document.DocumentCode + " - " + SupplierShortName;
                    transaction.Reference = "AP" + document.ApNumber.ToString();

                    // TODO transaction.DetailNumber

                    GLDataset.ATransaction.Rows.Add(transaction);
                }

                journal.LastTransactionNumber = TransactionCounter - 1;
            }

            batch.LastJournal = CounterJournals - 1;

            DBAccess.GDBAccessObj.RollbackTransaction();

            return GLDataset;
        }

        /// <summary>
        /// creates GL transactions for the selected AP documents,
        /// and posts those GL transactions,
        /// and marks the AP documents as Posted
        /// </summary>
        /// <param name="ALedgerNumber"></param>
        /// <param name="AAPDocumentNumbers"></param>
        /// <param name="APostingDate"></param>
        /// <param name="AVerifications"></param>
        /// <returns></returns>
        public static bool PostAPDocuments(Int32 ALedgerNumber,
            List <Int32>AAPDocumentNumbers,
            DateTime APostingDate,
            out TVerificationResultCollection AVerifications)
        {
            AccountsPayableTDS MainDS = LoadDocumentsAndCheck(ALedgerNumber, AAPDocumentNumbers, APostingDate, out AVerifications);

            if (AVerifications.HasCriticalError())
            {
                return false;
            }

            GLBatchTDS GLDataset = CreateGLBatchAndTransactions(ALedgerNumber, APostingDate, ref MainDS);

            ABatchRow batch = GLDataset.ABatch[0];

            // save the batch
            if (Ict.Petra.Server.MFinance.GL.WebConnectors.TTransactionWebConnector.SaveGLBatchTDS(ref GLDataset,
                    out AVerifications) != TSubmitChangesResult.scrOK)
            {
                return false;
            }

            // post the batch
            if (!Ict.Petra.Server.MFinance.GL.TGLPosting.PostGLBatch(ALedgerNumber, batch.BatchNumber, out AVerifications))
            {
                // TODO: what if posting fails? do we have an orphaned batch lying around? can this be put into one single transaction? probably not
                // TODO: we should cancel that batch
                return false;
            }

            // change status of AP documents and save to database
            foreach (AApDocumentRow row in MainDS.AApDocument.Rows)
            {
                row.DocumentStatus = MFinanceConstants.AP_DOCUMENT_POSTED;
            }

            TDBTransaction SubmitChangesTransaction;

            try
            {
                SubmitChangesTransaction = DBAccess.GDBAccessObj.BeginTransaction(IsolationLevel.Serializable);

                if (AApDocumentAccess.SubmitChanges(MainDS.AApDocument, SubmitChangesTransaction,
                        out AVerifications))
                {
                    DBAccess.GDBAccessObj.CommitTransaction();
                }
                else
                {
                    DBAccess.GDBAccessObj.RollbackTransaction();
                }
            }
            catch (Exception e)
            {
                // we should not get here; how would the database get broken?
                // TODO do we need a bigger transaction around everything?

                TLogging.Log("after submitchanges: exception " + e.Message);

                DBAccess.GDBAccessObj.RollbackTransaction();

                throw new Exception(e.ToString() + " " + e.Message);
            }

            return true;
        }
    }
}