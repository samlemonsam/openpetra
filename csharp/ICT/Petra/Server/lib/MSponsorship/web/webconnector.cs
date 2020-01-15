//
// DO NOT REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
//
// @Authors:
//       timop
//
// Copyright 2004-2020 by OM International
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
using System;
using System.Data;
using System.Data.Odbc;
using System.Collections.Generic;
using Ict.Common;
using Ict.Common.Data;
using Ict.Common.DB;
using Ict.Common.Verification;
using Ict.Common.Remoting.Server;
using Ict.Petra.Shared;
using Ict.Petra.Shared.MPartner;
using Ict.Petra.Shared.MPartner.Partner.Data;
using Ict.Petra.Shared.MFinance.Gift.Data;
using Ict.Petra.Shared.MSponsorship.Data;
using Ict.Petra.Server.MSponsorship.Data.Access;
using Ict.Petra.Server.MPartner.Partner.Data.Access;
using Ict.Petra.Server.MPartner.Common;
using Ict.Petra.Server.App.Core.Security;

namespace Ict.Petra.Server.MSponsorship.WebConnectors
{

    /// <summary>
    /// webconnector for the sponsorship module
    /// </summary>
    public class TSponsorshipWebConnector
    {
        private const string TYPE_SPONSOREDCHILD = "SPONSOREDCHILD";

        /// <summary>
        /// find children using filters
        /// </summary>
        [RequireModulePermission("OR(SPONSORVIEW,SPONSORADMIN)")]
        public static SponsorshipFindTDSSearchResultTable FindChildren(
            string AFirstName,
            string AFamilyName,
            string APartnerStatus,
            string ASponsorshipStatus,
            string ASponsorAdmin)
        {
            TDBTransaction t = new TDBTransaction();
            TDataBase db = DBAccess.Connect("FindChildren");
            string sql = "SELECT p.p_partner_short_name_c, p.p_status_code_c, p.p_partner_key_n, p.p_user_id_c, " +
                "f.p_first_name_c, f.p_family_name_c " +
                "FROM PUB_p_partner p, PUB_p_family f, PUB_p_partner_type t " +
                "WHERE p.p_partner_key_n = f.p_partner_key_n " +
                "AND p.p_partner_key_n = t.p_partner_key_n " +
                "AND t.p_type_code_c = '" + TYPE_SPONSOREDCHILD + "'";

            int CountParameters = 0;
            CountParameters += (AFirstName != String.Empty ? 1: 0);
            OdbcParameter[] parameters = new OdbcParameter[CountParameters];

            if (AFirstName != String.Empty)
            {
                sql += " AND f.p_first_name_c LIKE ?";
                parameters[0] = new OdbcParameter("FirstName", OdbcType.VarChar);
                parameters[0].Value = AFirstName;
            }

            SponsorshipFindTDSSearchResultTable result = new SponsorshipFindTDSSearchResultTable();

            db.ReadTransaction(ref t,
                delegate
                {
                    db.SelectDT(result, sql, t, parameters);
                });

            db.CloseDBConnection();

            return result;
        }

        /// <summary>
        /// get a partner key for a new partner
        /// </summary>
        /// <param name="AFieldPartnerKey">can be -1, then the default site key is used</param>
        private static Int64 NewPartnerKey(Int64 AFieldPartnerKey = -1)
        {
            Int64 NewPartnerKey = TNewPartnerKey.GetNewPartnerKey(AFieldPartnerKey);

            TNewPartnerKey.SubmitNewPartnerKey(NewPartnerKey - NewPartnerKey % 1000000, NewPartnerKey, ref NewPartnerKey);
            return NewPartnerKey;
        }

        /// <summary>
        /// return the dataset for a new child
        /// </summary>
        [RequireModulePermission("SPONSORADMIN")]
        public static SponsorshipTDS CreateNewChild()
        {
            Int64 SiteKey = DomainManager.GSiteKey;
            SponsorshipTDS MainDS = new SponsorshipTDS();
            Int64 PartnerKey = NewPartnerKey();
            DateTime CreationDate = DateTime.Today;
            string CreationUserID = UserInfo.GetUserInfo().UserID;

	    // Create DataRow for Partner using the default values for all DataColumns
	    // and then modify some.
	    PPartnerRow PartnerRow = MainDS.PPartner.NewRowTyped(true);
	    PartnerRow.PartnerKey = PartnerKey;
	    PartnerRow.DateCreated = CreationDate;
	    PartnerRow.CreatedBy = CreationUserID;
	    PartnerRow.PartnerClass = SharedTypes.PartnerClassEnumToString(TPartnerClass.FAMILY);
	    PartnerRow.StatusCode = SharedTypes.StdPartnerStatusCodeEnumToString(TStdPartnerStatusCode.spscACTIVE);
	    PartnerRow.UserId = CreationUserID;
            MainDS.PPartner.Rows.Add(PartnerRow);

            PFamilyRow FamilyRow = MainDS.PFamily.NewRowTyped(true);
            FamilyRow.PartnerKey = PartnerKey;
            FamilyRow.DateCreated = CreationDate;
            FamilyRow.CreatedBy = CreationUserID;
            MainDS.PFamily.Rows.Add(FamilyRow);

            PPartnerTypeRow PartnerTypeRow = MainDS.PPartnerType.NewRowTyped(true);
            PartnerTypeRow.PartnerKey = PartnerKey;
            PartnerTypeRow.TypeCode = TYPE_SPONSOREDCHILD;
            MainDS.PPartnerType.Rows.Add(PartnerTypeRow);

            return MainDS;
        }

        /// <summary>
        /// return the existing data of a child
        /// </summary>
        [RequireModulePermission("OR(SPONSORVIEW,SPONSORADMIN)")]
        public static SponsorshipTDS GetChildDetails(Int64 APartnerKey,
            out string ASponsorshipStatus)
        {
            SponsorshipTDS MainDS = new SponsorshipTDS();

            TDBTransaction Transaction = new TDBTransaction();

            DBAccess.ReadTransaction( ref Transaction,
                delegate
                {
                    PPartnerAccess.LoadByPrimaryKey(MainDS, APartnerKey, Transaction);
                    PFamilyAccess.LoadByPrimaryKey(MainDS, APartnerKey, Transaction);
                    PPartnerTypeAccess.LoadViaPPartner(MainDS, APartnerKey, Transaction);
                });

            bool isSponsoredChild = false;
            ASponsorshipStatus = "TODO";

            foreach (PPartnerTypeRow type in MainDS.PPartnerType.Rows)
            {
                if (type.TypeCode == TYPE_SPONSOREDCHILD)
                {
                    isSponsoredChild = true;
                }
            }

            MainDS.PPartnerType.Clear();

            if (!isSponsoredChild)
            {
                return new SponsorshipTDS();
            }

            return MainDS;
        }

        /// <summary>
        /// store the currently edited child
        /// </summary>
        [RequireModulePermission("SPONSORADMIN")]
        public static bool SaveChild(SponsorshipTDS AMainDS,
            string ASponsorshipStatus,
            out TVerificationResultCollection AVerificationResult)
        {
            SponsorshipTDS SaveDS;
            AVerificationResult = new TVerificationResultCollection();

            if (AMainDS.PPartner[0].ModificationId == DateTime.MinValue)
            {
                // this is a new partner
                SaveDS = AMainDS;

                if (SaveDS.PPartner[0].PartnerKey == -1)
                {
                    SaveDS.PPartner[0].PartnerKey = NewPartnerKey();
                }

                if (SaveDS.PFamily.Count > 0)
                {
                    SaveDS.PFamily[0].PartnerKey = SaveDS.PPartner[0].PartnerKey;
                }
            }
            else
            {
                SaveDS = AMainDS;
/*
                List<string> Dummy1, Dummy2;
                string Dummy3, Dummy4, Dummy5;
                // TODO
                SaveDS = GetPartnerDetails(AMainDS.PPartner[0].PartnerKey, out Dummy1, out Dummy2, out Dummy3, out Dummy4, out Dummy5);
                DataUtilities.CopyDataSet(AMainDS, SaveDS);
*/
            }

            SaveDS.PPartner[0].PartnerShortName =
                    Calculations.DeterminePartnerShortName(
                        SaveDS.PFamily[0].FamilyName,
                        SaveDS.PFamily[0].Title,
                        SaveDS.PFamily[0].FirstName);

            try
            {
                SponsorshipTDSAccess.SubmitChanges(SaveDS);
                return true;
            }
            catch (Exception e)
            {
                TLogging.Log(e.ToString());
                AVerificationResult.Add(new TVerificationResult("error", e.Message, TResultSeverity.Resv_Critical));
                return false;
            }
        }
    }
}
