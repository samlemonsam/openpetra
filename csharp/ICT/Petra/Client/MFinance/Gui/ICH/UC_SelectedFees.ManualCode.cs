﻿// DO NOT REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
//
// @Authors:
//       Tim Ingham
//
// Copyright 2004-2014 by OM International
//
// This file is part of OpenPetra.org.
//
// OpenPetra.org is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// OpenPetra.org is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with OpenPetra.org.  If not, see <http://www.gnu.org/licenses/>.
//

using Ict.Petra.Client.App.Core;
using Ict.Petra.Client.CommonForms;
using Ict.Petra.Client.MReporting.Gui;
using Ict.Petra.Client.MReporting.Logic;
using Ict.Petra.Shared.MFinance.Account.Data;
using Ict.Petra.Shared.MReporting;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Ict.Petra.Client.MFinance.Gui.ICH
{
    public partial class TFrmUC_SelectedFees
    {
        private ListBox lstDoPrint;
        private ListBox lstDontPrint;
        private String[] FSelectedFees;
        private Int32 FLedgerNumber = -1;

        /// <summary>How many fee columns can I fit on a page</summary>
        public Int32 MAX_FEE_COUNT = 11;
        /// <summary>
        ///
        /// </summary>
        /// <param name="Utils"></param>
        public void InitialiseData(TFrmPetraUtils Utils)
        {
        }

        /// <summary>
        ///
        /// </summary>
        public Int32 LedgerNumber
        {
            set
            {
                FLedgerNumber = value;
            }
        }

        private void InitializeManualCode()
        {
            lstDoPrint = new ListBox();
            lstDoPrint.Location = new System.Drawing.Point(0, 0);
            lstDoPrint.Size = pnlDoPrint.Size;
            lstDoPrint.SelectionMode = SelectionMode.MultiExtended;
            lstDoPrint.SelectedIndexChanged += new System.EventHandler(EnableAddRemoveButtons);
            lstDoPrint.DisplayMember = "Descr";
            pnlDoPrint.Controls.Add(lstDoPrint);

            lstDontPrint = new ListBox();
            lstDontPrint.Location = new System.Drawing.Point(0, 0);
            lstDontPrint.Size = pnlDontPrint.Size;
            lstDontPrint.SelectionMode = SelectionMode.MultiExtended;
            lstDontPrint.SelectedIndexChanged += new System.EventHandler(EnableAddRemoveButtons);
            lstDontPrint.DisplayMember = "Descr";
            pnlDontPrint.Controls.Add(lstDontPrint);
        }

        private void EnableAddRemoveButtons(Object Sender, EventArgs e)
        {
            btnAdd.Enabled = (lstDontPrint.SelectedIndices.Count > 0) && (lstDoPrint.Items.Count < MAX_FEE_COUNT);
            btnRemove.Enabled = (lstDoPrint.SelectedIndices.Count > 0);
        }

        private void RefreshDoList()
        {
            lstDoPrint.BeginUpdate();
            lstDoPrint.Items.Clear();
            lstDoPrint.Items.AddRange(FSelectedFees);
            lstDoPrint.EndUpdate();
        }

        private void AddSelected(Object Sender, EventArgs e)
        {
            ListBox.SelectedIndexCollection Selections = lstDontPrint.SelectedIndices;

            foreach (Int32 SelNum in Selections)
            {
                String Itm = lstDontPrint.Items[SelNum].ToString();

                if (((IList)FSelectedFees).IndexOf(Itm) < 0)
                {
                    Array.Resize(ref FSelectedFees, FSelectedFees.Length + 1);

                    for (Int32 Idx = FSelectedFees.Length - 1; Idx > 0; Idx--)
                    {
                        FSelectedFees[Idx] = FSelectedFees[Idx - 1];
                    }

                    FSelectedFees[0] = Itm;
                }
            }

            RefreshDoList();
        }

        private void RemoveSelected(Object Sender, EventArgs e)
        {
            ListBox.SelectedIndexCollection Selections = lstDoPrint.SelectedIndices;

            foreach (Int32 SelNum in Selections)
            {
                Int32 NewLength = FSelectedFees.Length - 1;
                String Itm = lstDoPrint.Items[SelNum].ToString();

                for (Int32 Idx = ((IList)FSelectedFees).IndexOf(Itm); Idx < NewLength; Idx++)
                {
                    FSelectedFees[Idx] = FSelectedFees[Idx + 1];
                }

                Array.Resize(ref FSelectedFees, NewLength);
            }

            RefreshDoList();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="ACalc"></param>
        /// <param name="AReportAction"></param>
        public void ReadControls(TRptCalculator ACalc, TReportActionEnum AReportAction)
        {
            lstDoPrint.Items.CopyTo(FSelectedFees, 0);
            ACalc.AddParameter("param_fee_codes", String.Join(",", FSelectedFees));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="AParameters"></param>
        public void SetControls(TParameterList AParameters)
        {
            //
            // If LedgerNumber hasn't been set yet, do nothing:
            if (FLedgerNumber < 0)
            {
                return;
            }

            lstDontPrint.BeginUpdate();
            lstDontPrint.Items.Clear();

            AFeesReceivableTable FeesReceivable = new AFeesReceivableTable();
            Type DataTableType;
            DataTable CacheDT = TDataCache.GetSpecificallyFilteredCacheableDataTableFromCache("FeesReceivableList",
                "Ledger",
                FLedgerNumber,
                out DataTableType);
            FeesReceivable.Merge(CacheDT);

            foreach (AFeesReceivableRow Row in FeesReceivable.Rows)
            {
                lstDontPrint.Items.Add(Row.FeeCode);
            }

            AFeesPayableTable FeesPayable = new AFeesPayableTable();
            CacheDT = TDataCache.GetSpecificallyFilteredCacheableDataTableFromCache("FeesPayableList", "Ledger", FLedgerNumber, out DataTableType);
            FeesPayable.Merge(CacheDT);

            foreach (AFeesPayableRow Row in FeesPayable.Rows)
            {
                lstDontPrint.Items.Add(Row.FeeCode);
            }

            lstDontPrint.EndUpdate();

            String FeeStr = AParameters.Get("param_fee_codes").ToString();

            //
            // If there's no fees selected, it's perhaps because the installation is new.
            // Add all the fees from the "Don't Print" box, up to the maximum number allowed.
            if (FeeStr == "")
            {
                Array.Resize(ref FSelectedFees, lstDontPrint.Items.Count);
                lstDontPrint.Items.CopyTo(FSelectedFees, 0);

                if (lstDontPrint.Items.Count > MAX_FEE_COUNT)
                {
                    Array.Resize(ref FSelectedFees, MAX_FEE_COUNT);
                }
            }
            else
            {
                FSelectedFees = FeeStr.Split(',');
            }

            RefreshDoList();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="Functions"></param>
        public void SetAvailableFunctions(ArrayList Functions)
        {
        }
    }
}