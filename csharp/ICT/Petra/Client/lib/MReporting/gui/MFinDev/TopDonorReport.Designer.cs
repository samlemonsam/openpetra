// auto generated with nant generateWinforms from TopDonorReport.yaml
//
// DO NOT edit manually, DO NOT edit with the designer
//
//
// DO NOT REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
//
// @Authors:
//       auto generated
//
// Copyright 2004-2010 by OM International
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
using System.Windows.Forms;
using Mono.Unix;
using Ict.Common.Controls;
using Ict.Petra.Client.CommonControls;

namespace Ict.Petra.Client.MReporting.Gui.MFinDev
{
    partial class TFrmTopDonorReport
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFrmTopDonorReport));

            this.tabReportSettings = new Ict.Common.Controls.TTabVersatile();
            this.tpgGeneralSettings = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLedger = new System.Windows.Forms.Label();
            this.grpLevel = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rbtTopDonor = new System.Windows.Forms.RadioButton();
            this.rbtMiddleDonor = new System.Windows.Forms.RadioButton();
            this.rbtBottomDonor = new System.Windows.Forms.RadioButton();
            this.txtPercentage = new Ict.Common.Controls.TTxtNumericTextBox();
            this.lblPercent1 = new System.Windows.Forms.Label();
            this.txtToPercentage = new Ict.Common.Controls.TTxtNumericTextBox();
            this.lblToPercentage = new System.Windows.Forms.Label();
            this.lblPercent2 = new System.Windows.Forms.Label();
            this.cmbCurrency = new Ict.Common.Controls.TCmbAutoComplete();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.grpDateSelection = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpStartDate = new Ict.Petra.Client.CommonControls.TtxtPetraDate();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new Ict.Petra.Client.CommonControls.TtxtPetraDate();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.txtMotivationGroup = new System.Windows.Forms.TextBox();
            this.lblMotivationGroup = new System.Windows.Forms.Label();
            this.txtMotivationDetail = new System.Windows.Forms.TextBox();
            this.lblMotivationDetail = new System.Windows.Forms.Label();
            this.txtRecipient = new Ict.Petra.Client.CommonControls.TtxtAutoPopulatedButtonLabel();
            this.rbtAllPartners = new System.Windows.Forms.RadioButton();
            this.rbtExtract = new System.Windows.Forms.RadioButton();
            this.txtExtract = new Ict.Petra.Client.CommonControls.TtxtAutoPopulatedButtonLabel();
            this.tbrMain = new System.Windows.Forms.ToolStrip();
            this.tbbGenerateReport = new System.Windows.Forms.ToolStripButton();
            this.tbbSaveSettings = new System.Windows.Forms.ToolStripButton();
            this.tbbSaveSettingsAs = new System.Windows.Forms.ToolStripButton();
            this.tbbLoadSettingsDialog = new System.Windows.Forms.ToolStripButton();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mniFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mniLoadSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mniLoadSettingsDialog = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSeparator0 = new System.Windows.Forms.ToolStripSeparator();
            this.mniLoadSettings1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mniLoadSettings2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mniLoadSettings3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mniLoadSettings4 = new System.Windows.Forms.ToolStripMenuItem();
            this.mniLoadSettings5 = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSaveSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSaveSettingsAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mniMaintainSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mniWrapColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mniGenerateReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mniClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mniHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mniHelpPetraHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mniHelpBugReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mniHelpAboutPetra = new System.Windows.Forms.ToolStripMenuItem();
            this.mniHelpDevelopmentTeam = new System.Windows.Forms.ToolStripMenuItem();
            this.stbMain = new Ict.Common.Controls.TExtStatusBarHelp();

            this.tabReportSettings.SuspendLayout();
            this.tpgGeneralSettings.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpLevel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.grpDateSelection.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tbrMain.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.stbMain.SuspendLayout();

            //
            // tpgGeneralSettings
            //
            this.tpgGeneralSettings.Location = new System.Drawing.Point(2,2);
            this.tpgGeneralSettings.Name = "tpgGeneralSettings";
            this.tpgGeneralSettings.AutoSize = true;
            //
            // tableLayoutPanel1
            //
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.AutoSize = true;
            this.tpgGeneralSettings.Controls.Add(this.tableLayoutPanel1);
            //
            // lblLedger
            //
            this.lblLedger.Location = new System.Drawing.Point(2,2);
            this.lblLedger.Name = "lblLedger";
            this.lblLedger.AutoSize = true;
            this.lblLedger.Text = "Ledger:";
            this.lblLedger.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            //
            // grpLevel
            //
            this.grpLevel.Name = "grpLevel";
            this.grpLevel.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLevel.AutoSize = true;
            //
            // tableLayoutPanel2
            //
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.AutoSize = true;
            this.grpLevel.Controls.Add(this.tableLayoutPanel2);
            //
            // rbtTopDonor
            //
            this.rbtTopDonor.Location = new System.Drawing.Point(2,2);
            this.rbtTopDonor.Name = "rbtTopDonor";
            this.rbtTopDonor.AutoSize = true;
            this.rbtTopDonor.CheckedChanged += new System.EventHandler(this.DonorTypeChanged);
            this.rbtTopDonor.Text = "Top";
            //
            // rbtMiddleDonor
            //
            this.rbtMiddleDonor.Location = new System.Drawing.Point(2,2);
            this.rbtMiddleDonor.Name = "rbtMiddleDonor";
            this.rbtMiddleDonor.AutoSize = true;
            this.rbtMiddleDonor.CheckedChanged += new System.EventHandler(this.DonorTypeChanged);
            this.rbtMiddleDonor.Text = "Middle";
            //
            // rbtBottomDonor
            //
            this.rbtBottomDonor.Location = new System.Drawing.Point(2,2);
            this.rbtBottomDonor.Name = "rbtBottomDonor";
            this.rbtBottomDonor.AutoSize = true;
            this.rbtBottomDonor.CheckedChanged += new System.EventHandler(this.DonorTypeChanged);
            this.rbtBottomDonor.Text = "Bottom";
            //
            // txtPercentage
            //
            this.txtPercentage.Location = new System.Drawing.Point(2,2);
            this.txtPercentage.Name = "txtPercentage";
            this.txtPercentage.Size = new System.Drawing.Size(80, 28);
            this.txtPercentage.ControlMode = TTxtNumericTextBox.TNumericTextBoxMode.Integer;
            this.txtPercentage.DecimalPlaces = 2;
            this.txtPercentage.NullValueAllowed = true;
            //
            // lblPercent1
            //
            this.lblPercent1.Location = new System.Drawing.Point(2,2);
            this.lblPercent1.Name = "lblPercent1";
            this.lblPercent1.AutoSize = true;
            this.lblPercent1.Text = "%:";
            this.lblPercent1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            //
            // txtToPercentage
            //
            this.txtToPercentage.Location = new System.Drawing.Point(2,2);
            this.txtToPercentage.Name = "txtToPercentage";
            this.txtToPercentage.Size = new System.Drawing.Size(80, 28);
            this.txtToPercentage.ControlMode = TTxtNumericTextBox.TNumericTextBoxMode.Integer;
            this.txtToPercentage.DecimalPlaces = 2;
            this.txtToPercentage.NullValueAllowed = true;
            //
            // lblToPercentage
            //
            this.lblToPercentage.Location = new System.Drawing.Point(2,2);
            this.lblToPercentage.Name = "lblToPercentage";
            this.lblToPercentage.AutoSize = true;
            this.lblToPercentage.Text = "To:";
            this.lblToPercentage.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.lblToPercentage.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblToPercentage.TextAlign = System.Drawing.ContentAlignment.TopRight;
            //
            // lblPercent2
            //
            this.lblPercent2.Location = new System.Drawing.Point(2,2);
            this.lblPercent2.Name = "lblPercent2";
            this.lblPercent2.AutoSize = true;
            this.lblPercent2.Text = "%:";
            this.lblPercent2.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            //
            // cmbCurrency
            //
            this.cmbCurrency.Location = new System.Drawing.Point(2,2);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(150, 28);
            this.cmbCurrency.Items.AddRange(new object[] {"Base","International"});
            //
            // lblCurrency
            //
            this.lblCurrency.Location = new System.Drawing.Point(2,2);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Text = "Currency:";
            this.lblCurrency.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.lblCurrency.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCurrency.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Controls.Add(this.rbtTopDonor, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtPercentage, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.rbtMiddleDonor, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblPercent1, 1, 1);
            this.tableLayoutPanel2.SetColumnSpan(this.rbtBottomDonor, 2);
            this.tableLayoutPanel2.Controls.Add(this.rbtBottomDonor, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblToPercentage, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtToPercentage, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblPercent2, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblCurrency, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.cmbCurrency, 6, 1);
            this.grpLevel.Text = "Select Level";
            //
            // grpDateSelection
            //
            this.grpDateSelection.Name = "grpDateSelection";
            this.grpDateSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDateSelection.AutoSize = true;
            //
            // tableLayoutPanel3
            //
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.AutoSize = true;
            this.grpDateSelection.Controls.Add(this.tableLayoutPanel3);
            //
            // dtpStartDate
            //
            this.dtpStartDate.Location = new System.Drawing.Point(2,2);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(94, 28);
            //
            // lblStartDate
            //
            this.lblStartDate.Location = new System.Drawing.Point(2,2);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Text = "Start Date:";
            this.lblStartDate.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.lblStartDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblStartDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            //
            // dtpEndDate
            //
            this.dtpEndDate.Location = new System.Drawing.Point(2,2);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(94, 28);
            //
            // lblEndDate
            //
            this.lblEndDate.Location = new System.Drawing.Point(2,2);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Text = "End date:";
            this.lblEndDate.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.lblEndDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblEndDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            //
            // txtMotivationGroup
            //
            this.txtMotivationGroup.Location = new System.Drawing.Point(2,2);
            this.txtMotivationGroup.Name = "txtMotivationGroup";
            this.txtMotivationGroup.Size = new System.Drawing.Size(150, 28);
            //
            // lblMotivationGroup
            //
            this.lblMotivationGroup.Location = new System.Drawing.Point(2,2);
            this.lblMotivationGroup.Name = "lblMotivationGroup";
            this.lblMotivationGroup.AutoSize = true;
            this.lblMotivationGroup.Text = "Motivation Group:";
            this.lblMotivationGroup.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.lblMotivationGroup.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMotivationGroup.TextAlign = System.Drawing.ContentAlignment.TopRight;
            //
            // txtMotivationDetail
            //
            this.txtMotivationDetail.Location = new System.Drawing.Point(2,2);
            this.txtMotivationDetail.Name = "txtMotivationDetail";
            this.txtMotivationDetail.Size = new System.Drawing.Size(150, 28);
            //
            // lblMotivationDetail
            //
            this.lblMotivationDetail.Location = new System.Drawing.Point(2,2);
            this.lblMotivationDetail.Name = "lblMotivationDetail";
            this.lblMotivationDetail.AutoSize = true;
            this.lblMotivationDetail.Text = "MotivationDetail:";
            this.lblMotivationDetail.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.lblMotivationDetail.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMotivationDetail.TextAlign = System.Drawing.ContentAlignment.TopRight;
            //
            // txtRecipient
            //
            this.txtRecipient.Location = new System.Drawing.Point(2,2);
            this.txtRecipient.Name = "txtRecipient";
            this.txtRecipient.Size = new System.Drawing.Size(370, 28);
            this.txtRecipient.ASpecialSetting = true;
            this.txtRecipient.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtRecipient.ListTable = TtxtAutoPopulatedButtonLabel.TListTableEnum.PartnerKey;
            this.txtRecipient.PartnerClass = "";
            this.txtRecipient.MaxLength = 32767;
            this.txtRecipient.Tag = "CustomDisableAlthoughInvisible";
            this.txtRecipient.TextBoxWidth = 80;
            this.txtRecipient.ButtonWidth = 40;
            this.txtRecipient.ReadOnly = false;
            this.txtRecipient.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.txtRecipient.ButtonText = "Find";
            //
            // rbtAllPartners
            //
            this.rbtAllPartners.Location = new System.Drawing.Point(2,2);
            this.rbtAllPartners.Name = "rbtAllPartners";
            this.rbtAllPartners.AutoSize = true;
            this.rbtAllPartners.Text = "All Partners";
            //
            // rbtExtract
            //
            this.rbtExtract.Location = new System.Drawing.Point(2,2);
            this.rbtExtract.Name = "rbtExtract";
            this.rbtExtract.AutoSize = true;
            this.rbtExtract.Text = "From Extract";
            //
            // txtExtract
            //
            this.txtExtract.Location = new System.Drawing.Point(2,2);
            this.txtExtract.Name = "txtExtract";
            this.txtExtract.Size = new System.Drawing.Size(370, 28);
            this.txtExtract.ASpecialSetting = true;
            this.txtExtract.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtExtract.ListTable = TtxtAutoPopulatedButtonLabel.TListTableEnum.Extract;
            this.txtExtract.PartnerClass = "";
            this.txtExtract.MaxLength = 32767;
            this.txtExtract.Tag = "CustomDisableAlthoughInvisible";
            this.txtExtract.TextBoxWidth = 80;
            this.txtExtract.ButtonWidth = 40;
            this.txtExtract.ReadOnly = false;
            this.txtExtract.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.txtExtract.ButtonText = "Find";
            this.rbtExtract.CheckedChanged += new System.EventHandler(this.rbtExtractCheckedChanged);
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Controls.Add(this.lblStartDate, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblEndDate, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblMotivationGroup, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblMotivationDetail, 0, 3);
            this.tableLayoutPanel3.SetColumnSpan(this.txtRecipient, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtRecipient, 0, 4);
            this.tableLayoutPanel3.SetColumnSpan(this.rbtAllPartners, 2);
            this.tableLayoutPanel3.Controls.Add(this.rbtAllPartners, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.rbtExtract, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.dtpStartDate, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.dtpEndDate, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtMotivationGroup, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtMotivationDetail, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtExtract, 1, 6);
            this.grpDateSelection.Text = "Selection";
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblLedger, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grpLevel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grpDateSelection, 0, 2);
            this.tpgGeneralSettings.Text = "GeneralSettings";
            this.tpgGeneralSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            // tabReportSettings
            //
            this.tabReportSettings.Name = "tabReportSettings";
            this.tabReportSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabReportSettings.Controls.Add(this.tpgGeneralSettings);
            this.tabReportSettings.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            //
            // tbbGenerateReport
            //
            this.tbbGenerateReport.Name = "tbbGenerateReport";
            this.tbbGenerateReport.AutoSize = true;
            this.tbbGenerateReport.Click += new System.EventHandler(this.actGenerateReport);
            this.tbbGenerateReport.Image = ((System.Drawing.Bitmap)resources.GetObject("tbbGenerateReport.Glyph"));
            this.tbbGenerateReport.ToolTipText = "Generate the report";
            this.tbbGenerateReport.Text = "&Generate";
            //
            // tbbSaveSettings
            //
            this.tbbSaveSettings.Name = "tbbSaveSettings";
            this.tbbSaveSettings.AutoSize = true;
            this.tbbSaveSettings.Click += new System.EventHandler(this.actSaveSettings);
            this.tbbSaveSettings.Image = ((System.Drawing.Bitmap)resources.GetObject("tbbSaveSettings.Glyph"));
            this.tbbSaveSettings.Text = "&Save Settings";
            //
            // tbbSaveSettingsAs
            //
            this.tbbSaveSettingsAs.Name = "tbbSaveSettingsAs";
            this.tbbSaveSettingsAs.AutoSize = true;
            this.tbbSaveSettingsAs.Click += new System.EventHandler(this.actSaveSettingsAs);
            this.tbbSaveSettingsAs.Image = ((System.Drawing.Bitmap)resources.GetObject("tbbSaveSettingsAs.Glyph"));
            this.tbbSaveSettingsAs.Text = "Save Settings &As...";
            //
            // tbbLoadSettingsDialog
            //
            this.tbbLoadSettingsDialog.Name = "tbbLoadSettingsDialog";
            this.tbbLoadSettingsDialog.AutoSize = true;
            this.tbbLoadSettingsDialog.Click += new System.EventHandler(this.actLoadSettingsDialog);
            this.tbbLoadSettingsDialog.Text = "&Open...";
            //
            // tbrMain
            //
            this.tbrMain.Name = "tbrMain";
            this.tbrMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbrMain.AutoSize = true;
            this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                           tbbGenerateReport,
                        tbbSaveSettings,
                        tbbSaveSettingsAs,
                        tbbLoadSettingsDialog});
            //
            // mniLoadSettingsDialog
            //
            this.mniLoadSettingsDialog.Name = "mniLoadSettingsDialog";
            this.mniLoadSettingsDialog.AutoSize = true;
            this.mniLoadSettingsDialog.Click += new System.EventHandler(this.actLoadSettingsDialog);
            this.mniLoadSettingsDialog.Text = "&Open...";
            //
            // mniSeparator0
            //
            this.mniSeparator0.Name = "mniSeparator0";
            this.mniSeparator0.AutoSize = true;
            this.mniSeparator0.Text = "-";
            //
            // mniLoadSettings1
            //
            this.mniLoadSettings1.Name = "mniLoadSettings1";
            this.mniLoadSettings1.AutoSize = true;
            this.mniLoadSettings1.Click += new System.EventHandler(this.actLoadSettings);
            this.mniLoadSettings1.Text = "RecentSettings";
            //
            // mniLoadSettings2
            //
            this.mniLoadSettings2.Name = "mniLoadSettings2";
            this.mniLoadSettings2.AutoSize = true;
            this.mniLoadSettings2.Click += new System.EventHandler(this.actLoadSettings);
            this.mniLoadSettings2.Text = "RecentSettings";
            //
            // mniLoadSettings3
            //
            this.mniLoadSettings3.Name = "mniLoadSettings3";
            this.mniLoadSettings3.AutoSize = true;
            this.mniLoadSettings3.Click += new System.EventHandler(this.actLoadSettings);
            this.mniLoadSettings3.Text = "RecentSettings";
            //
            // mniLoadSettings4
            //
            this.mniLoadSettings4.Name = "mniLoadSettings4";
            this.mniLoadSettings4.AutoSize = true;
            this.mniLoadSettings4.Click += new System.EventHandler(this.actLoadSettings);
            this.mniLoadSettings4.Text = "RecentSettings";
            //
            // mniLoadSettings5
            //
            this.mniLoadSettings5.Name = "mniLoadSettings5";
            this.mniLoadSettings5.AutoSize = true;
            this.mniLoadSettings5.Click += new System.EventHandler(this.actLoadSettings);
            this.mniLoadSettings5.Text = "RecentSettings";
            //
            // mniLoadSettings
            //
            this.mniLoadSettings.Name = "mniLoadSettings";
            this.mniLoadSettings.AutoSize = true;
            this.mniLoadSettings.Click += new System.EventHandler(this.actLoadSettings);
            this.mniLoadSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                           mniLoadSettingsDialog,
                        mniSeparator0,
                        mniLoadSettings1,
                        mniLoadSettings2,
                        mniLoadSettings3,
                        mniLoadSettings4,
                        mniLoadSettings5});
            this.mniLoadSettings.Text = "&Load Settings";
            //
            // mniSaveSettings
            //
            this.mniSaveSettings.Name = "mniSaveSettings";
            this.mniSaveSettings.AutoSize = true;
            this.mniSaveSettings.Click += new System.EventHandler(this.actSaveSettings);
            this.mniSaveSettings.Image = ((System.Drawing.Bitmap)resources.GetObject("mniSaveSettings.Glyph"));
            this.mniSaveSettings.Text = "&Save Settings";
            //
            // mniSaveSettingsAs
            //
            this.mniSaveSettingsAs.Name = "mniSaveSettingsAs";
            this.mniSaveSettingsAs.AutoSize = true;
            this.mniSaveSettingsAs.Click += new System.EventHandler(this.actSaveSettingsAs);
            this.mniSaveSettingsAs.Image = ((System.Drawing.Bitmap)resources.GetObject("mniSaveSettingsAs.Glyph"));
            this.mniSaveSettingsAs.Text = "Save Settings &As...";
            //
            // mniMaintainSettings
            //
            this.mniMaintainSettings.Name = "mniMaintainSettings";
            this.mniMaintainSettings.AutoSize = true;
            this.mniMaintainSettings.Click += new System.EventHandler(this.actMaintainSettings);
            this.mniMaintainSettings.Text = "&Maintain Settings...";
            //
            // mniSeparator1
            //
            this.mniSeparator1.Name = "mniSeparator1";
            this.mniSeparator1.AutoSize = true;
            this.mniSeparator1.Text = "-";
            //
            // mniWrapColumn
            //
            this.mniWrapColumn.Name = "mniWrapColumn";
            this.mniWrapColumn.AutoSize = true;
            this.mniWrapColumn.Click += new System.EventHandler(this.actWrapColumn);
            this.mniWrapColumn.Text = "&Wrap Columns";
            //
            // mniSeparator2
            //
            this.mniSeparator2.Name = "mniSeparator2";
            this.mniSeparator2.AutoSize = true;
            this.mniSeparator2.Text = "-";
            //
            // mniGenerateReport
            //
            this.mniGenerateReport.Name = "mniGenerateReport";
            this.mniGenerateReport.AutoSize = true;
            this.mniGenerateReport.Click += new System.EventHandler(this.actGenerateReport);
            this.mniGenerateReport.Image = ((System.Drawing.Bitmap)resources.GetObject("mniGenerateReport.Glyph"));
            this.mniGenerateReport.ToolTipText = "Generate the report";
            this.mniGenerateReport.Text = "&Generate";
            //
            // mniSeparator3
            //
            this.mniSeparator3.Name = "mniSeparator3";
            this.mniSeparator3.AutoSize = true;
            this.mniSeparator3.Text = "-";
            //
            // mniClose
            //
            this.mniClose.Name = "mniClose";
            this.mniClose.AutoSize = true;
            this.mniClose.Click += new System.EventHandler(this.actClose);
            this.mniClose.Image = ((System.Drawing.Bitmap)resources.GetObject("mniClose.Glyph"));
            this.mniClose.ToolTipText = "Closes this window";
            this.mniClose.Text = "&Close";
            //
            // mniFile
            //
            this.mniFile.Name = "mniFile";
            this.mniFile.AutoSize = true;
            this.mniFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                           mniLoadSettings,
                        mniSaveSettings,
                        mniSaveSettingsAs,
                        mniMaintainSettings,
                        mniSeparator1,
                        mniWrapColumn,
                        mniSeparator2,
                        mniGenerateReport,
                        mniSeparator3,
                        mniClose});
            this.mniFile.Text = "&File";
            //
            // mniHelpPetraHelp
            //
            this.mniHelpPetraHelp.Name = "mniHelpPetraHelp";
            this.mniHelpPetraHelp.AutoSize = true;
            this.mniHelpPetraHelp.Text = "&Petra Help";
            //
            // mniSeparator4
            //
            this.mniSeparator4.Name = "mniSeparator4";
            this.mniSeparator4.AutoSize = true;
            this.mniSeparator4.Text = "-";
            //
            // mniHelpBugReport
            //
            this.mniHelpBugReport.Name = "mniHelpBugReport";
            this.mniHelpBugReport.AutoSize = true;
            this.mniHelpBugReport.Text = "Bug &Report";
            //
            // mniSeparator5
            //
            this.mniSeparator5.Name = "mniSeparator5";
            this.mniSeparator5.AutoSize = true;
            this.mniSeparator5.Text = "-";
            //
            // mniHelpAboutPetra
            //
            this.mniHelpAboutPetra.Name = "mniHelpAboutPetra";
            this.mniHelpAboutPetra.AutoSize = true;
            this.mniHelpAboutPetra.Text = "&About Petra";
            //
            // mniHelpDevelopmentTeam
            //
            this.mniHelpDevelopmentTeam.Name = "mniHelpDevelopmentTeam";
            this.mniHelpDevelopmentTeam.AutoSize = true;
            this.mniHelpDevelopmentTeam.Text = "&The Development Team...";
            //
            // mniHelp
            //
            this.mniHelp.Name = "mniHelp";
            this.mniHelp.AutoSize = true;
            this.mniHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                           mniHelpPetraHelp,
                        mniSeparator4,
                        mniHelpBugReport,
                        mniSeparator5,
                        mniHelpAboutPetra,
                        mniHelpDevelopmentTeam});
            this.mniHelp.Text = "&Help";
            //
            // mnuMain
            //
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.mnuMain.AutoSize = true;
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                           mniFile,
                        mniHelp});
            //
            // stbMain
            //
            this.stbMain.Name = "stbMain";
            this.stbMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.stbMain.AutoSize = true;

            //
            // TFrmTopDonorReport
            //
            this.Font = new System.Drawing.Font("Verdana", 8.25f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize = new System.Drawing.Size(650, 500);

            this.Controls.Add(this.tabReportSettings);
            this.Controls.Add(this.tbrMain);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = mnuMain;
            this.Controls.Add(this.stbMain);
            this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");

            this.Name = "TFrmTopDonorReport";
            this.Text = "Top Donor Report";

            this.Activated += new System.EventHandler(this.TFrmPetra_Activated);
            this.Load += new System.EventHandler(this.TFrmPetra_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.TFrmPetra_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.Closed += new System.EventHandler(this.TFrmPetra_Closed);

            this.stbMain.ResumeLayout(false);
            this.mnuMain.ResumeLayout(false);
            this.tbrMain.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.grpDateSelection.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.grpLevel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tpgGeneralSettings.ResumeLayout(false);
            this.tabReportSettings.ResumeLayout(false);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Ict.Common.Controls.TTabVersatile tabReportSettings;
        private System.Windows.Forms.TabPage tpgGeneralSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblLedger;
        private System.Windows.Forms.GroupBox grpLevel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton rbtTopDonor;
        private System.Windows.Forms.RadioButton rbtMiddleDonor;
        private System.Windows.Forms.RadioButton rbtBottomDonor;
        private Ict.Common.Controls.TTxtNumericTextBox txtPercentage;
        private System.Windows.Forms.Label lblPercent1;
        private Ict.Common.Controls.TTxtNumericTextBox txtToPercentage;
        private System.Windows.Forms.Label lblToPercentage;
        private System.Windows.Forms.Label lblPercent2;
        private Ict.Common.Controls.TCmbAutoComplete cmbCurrency;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.GroupBox grpDateSelection;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Ict.Petra.Client.CommonControls.TtxtPetraDate dtpStartDate;
        private System.Windows.Forms.Label lblStartDate;
        private Ict.Petra.Client.CommonControls.TtxtPetraDate dtpEndDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.TextBox txtMotivationGroup;
        private System.Windows.Forms.Label lblMotivationGroup;
        private System.Windows.Forms.TextBox txtMotivationDetail;
        private System.Windows.Forms.Label lblMotivationDetail;
        private Ict.Petra.Client.CommonControls.TtxtAutoPopulatedButtonLabel txtRecipient;
        private System.Windows.Forms.RadioButton rbtAllPartners;
        private System.Windows.Forms.RadioButton rbtExtract;
        private Ict.Petra.Client.CommonControls.TtxtAutoPopulatedButtonLabel txtExtract;
        private System.Windows.Forms.ToolStrip tbrMain;
        private System.Windows.Forms.ToolStripButton tbbGenerateReport;
        private System.Windows.Forms.ToolStripButton tbbSaveSettings;
        private System.Windows.Forms.ToolStripButton tbbSaveSettingsAs;
        private System.Windows.Forms.ToolStripButton tbbLoadSettingsDialog;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mniFile;
        private System.Windows.Forms.ToolStripMenuItem mniLoadSettings;
        private System.Windows.Forms.ToolStripMenuItem mniLoadSettingsDialog;
        private System.Windows.Forms.ToolStripSeparator mniSeparator0;
        private System.Windows.Forms.ToolStripMenuItem mniLoadSettings1;
        private System.Windows.Forms.ToolStripMenuItem mniLoadSettings2;
        private System.Windows.Forms.ToolStripMenuItem mniLoadSettings3;
        private System.Windows.Forms.ToolStripMenuItem mniLoadSettings4;
        private System.Windows.Forms.ToolStripMenuItem mniLoadSettings5;
        private System.Windows.Forms.ToolStripMenuItem mniSaveSettings;
        private System.Windows.Forms.ToolStripMenuItem mniSaveSettingsAs;
        private System.Windows.Forms.ToolStripMenuItem mniMaintainSettings;
        private System.Windows.Forms.ToolStripSeparator mniSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mniWrapColumn;
        private System.Windows.Forms.ToolStripSeparator mniSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mniGenerateReport;
        private System.Windows.Forms.ToolStripSeparator mniSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mniClose;
        private System.Windows.Forms.ToolStripMenuItem mniHelp;
        private System.Windows.Forms.ToolStripMenuItem mniHelpPetraHelp;
        private System.Windows.Forms.ToolStripSeparator mniSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mniHelpBugReport;
        private System.Windows.Forms.ToolStripSeparator mniSeparator5;
        private System.Windows.Forms.ToolStripMenuItem mniHelpAboutPetra;
        private System.Windows.Forms.ToolStripMenuItem mniHelpDevelopmentTeam;
        private Ict.Common.Controls.TExtStatusBarHelp stbMain;
    }
}