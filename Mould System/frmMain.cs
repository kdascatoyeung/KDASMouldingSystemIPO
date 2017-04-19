using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.menu;
using Mould_System.forms._1.quotation;
using Mould_System.functions.quotation;
using Mould_System.services;
using Mould_System.forms._2.transfer;
using Mould_System.forms._3.disposal;
using Mould_System.forms._6.data;
using Mould_System.forms._4.file;
using Mould_System.forms._5.reporting;
using Mould_System.forms._7.setting;
using Mould_System.functions.ringi;
using Mould_System.functions.others;
using System.Diagnostics;

namespace Mould_System
{
    public partial class frmMain : Form
    {
        string currentGroup = "";

        #region
        ucQuotationMenu menuQuotation = new ucQuotationMenu();
        ucTransferMenu menuTransfer = new ucTransferMenu();
        ucDisposalMenu menuDisposal = new ucDisposalMenu();
        ucFileMenu menuFile = new ucFileMenu();
        ucReportingMenu menuReporting = new ucReportingMenu();
        ucDataMenu menuData = new ucDataMenu();
        ucSettingMenu menuSetting = new ucSettingMenu();
        #endregion

        #region Quotation Group
        ucApplyRingi waitRingi = new ucApplyRingi();
        ucCustomView customview = new ucCustomView();
        ucFac fac = new ucFac();
        ucFacOnHold faconhold = new ucFacOnHold();
        ucIssuePO issuepo = new ucIssuePO();
        ucMouldViewer mouldviewer = new ucMouldViewer();
        ucQuotation quotation = new ucQuotation();
        ucPoCancel pocancel = new ucPoCancel();
        ucInStock3 instock3 = new ucInStock3();
        ucExpenseTransfer expensetransfer = new ucExpenseTransfer();
        ucTestFa test = new ucTestFa();
        ApprovalView app = new ApprovalView();
        ucCustomViewCn cnview = new ucCustomViewCn();
        #endregion

        #region Transfer Group
        //ucTransferVendor transferVendor = new ucTransferVendor();
        ucTransferVendor2 transferVendor = new ucTransferVendor2();
        ucTransferOwner transferOwner = new ucTransferOwner();
        ucTransferHold transferHold = new ucTransferHold();
        ucTransferHistory transferHistory = new ucTransferHistory();
        #endregion

        #region Disposal Group
        ucDisposalHistory disposalHistory = new ucDisposalHistory();
        ucDisposalRequest disposalRequest = new ucDisposalRequest();
        ucDisposal disposalProcess = new ucDisposal();
        ucDisposalConfirm disposalConfirm = new ucDisposalConfirm();
        ucDisposalView disposalView;
        #endregion

        #region File Group
        ucFileKdc fileKdc = new ucFileKdc();
        ucFileUL fileUl = new ucFileUL();
        #endregion

        #region Reporting Group
        ucCdReport cdReport = new ucCdReport();
        ucModifyCheck modifyCheck = new ucModifyCheck();
        ucPaymentList paymentList = new ucPaymentList();
        ucPoCollection poCollection = new ucPoCollection();
        ucDisposalReport disposalReport = new ucDisposalReport();
        ucVnOnly vnOnlyReport = new ucVnOnly();
        ucCnVnOnly cnVnOnlyReport = new ucCnVnOnly();
        ucModelReport modelReport = new ucModelReport();
        #endregion

        #region Data Group
        ucMasterRingi masterRingi = new ucMasterRingi();
        ucMasterVendor masterVendor = new ucMasterVendor();
        ucMasterMouldCode masterMouldCode = new ucMasterMouldCode();
        ucMasterOem masterOem = new ucMasterOem();
        ucMasterRingiDetail masterRingiDetail = new ucMasterRingiDetail();
        ucMasterModelDetail masterMouldDetail = new ucMasterModelDetail();
        ucMasterCost masterMouldCost = new ucMasterCost();
        #endregion

        #region Settings Group
        ucCurrency settingCurrency = new ucCurrency();
        ucDirectory settingDirectory = new ucDirectory();
        ucSystemLog settingLog = new ucSystemLog();
        ucJpyMonthly settingJpy = new ucJpyMonthly();
        ucCriteria settingCriteria = new ucCriteria();
        #endregion

        #region Function Group
        ucQuotationInput ucInput = new ucQuotationInput();
        ucQuotationEdit ucEdit = new ucQuotationEdit(GlobalService.selectedId);
        ucQuotationSet ucSet = new ucQuotationSet(GlobalService.gMouldNo, GlobalService.gItemCode);
        ucQuotationCommon ucCommon = new ucQuotationCommon(GlobalService.gMouldNo, GlobalService.gItemCode);
        ucToRingi ucAssignRingi = new ucToRingi(GlobalService.toRingiList);
        ucQuotationModify ucModify = new ucQuotationModify(GlobalService.selectedChaseno);
        ucQuotationRelation ucRelation = new ucQuotationRelation(GlobalService.gMouldNo, GlobalService.gItemCode);
        #endregion

        public frmMain()
        {
            InitializeComponent();

            GlobalService.toRingiList = new List<string>();
            Debug.WriteLine("Ringi List Initialized");
            GlobalService.ToFacList = new List<ToFacContent>();
            GlobalService.fileUlList = new List<string>();
            GlobalService.ChaseNoList = new List<string>();

            this.formload();

            quotation.buttonClick -= new EventHandler(quotation_buttonClick);
            quotation.buttonClick += new EventHandler(quotation_buttonClick);
        }

        private void LoadControl(UserControl uc)
        {
            panelMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }

        private void formload()
        {
            menuQuotation.clickEvent -= new EventHandler(quotation_clickEvent);

            this.transparentButton();

            this.btnQuotation.BackColor = Color.DarkOrange;

            currentGroup = "quotation";

            panelLeft.Controls.Clear();

            menuQuotation = new ucQuotationMenu();

            menuQuotation.Dock = DockStyle.Fill;

            panelLeft.Controls.Add(menuQuotation);

            panelMain.Controls.Clear();

            menuQuotation.clickEvent += new EventHandler(quotation_clickEvent);
        }

        private void resize()
        {
            #region Menu Size
            int panelLeftWidth = panelLeft.Width;
            int panelLeftHeight = panelLeft.Height;

            menuQuotation.Location = new Point(1, 1);
            menuQuotation.Size = new Size(panelLeftWidth, panelLeftHeight);
            menuTransfer.Size = new Size(panelLeftWidth, panelLeftHeight);
            menuDisposal.Size = new Size(panelLeftWidth, panelLeftHeight);
            menuFile.Size = new Size(panelLeftWidth, panelLeftHeight);
            menuReporting.Size = new Size(panelLeftWidth, panelLeftHeight);
            menuData.Size = new Size(panelLeftWidth, panelLeftHeight);
            menuSetting.Size = new Size(panelLeftWidth, panelLeftHeight);
            #endregion

            int width = panelMain.Width;
            int height = panelMain.Height;

            #region Quotation Group
            if (currentGroup == "quotation")
            {
                quotation.Size = new Size(width, height);
                waitRingi.Size = new Size(width, height);
                fac.Size = new Size(width, height);
                issuepo.Size = new Size(width, height);
                pocancel.Size = new Size(width, height);
                ucInput.Size = new Size(width, height);
                ucAssignRingi.Size = new Size(width, height);
                ucEdit.Size = new Size(width, height);
                ucSet.Size = new Size(width, height);
                ucCommon.Size = new Size(width, height);
                mouldviewer.Size = new Size(width, height);
                customview.Size = new Size(width, height);
                faconhold.Size = new Size(width, height);
                ucModify.Size = new Size(width, height);
                instock3.Size = new Size(width, height);
                expensetransfer.Size = new Size(width, height);
                ucRelation.Size = new Size(width, height);
            }
            else if (currentGroup == "transfer")
            {
                transferVendor.Size = new Size(width, height);
                transferOwner.Size = new Size(width, height);
                transferHistory.Size = new Size(width, height);
                transferHold.Size = new Size(width, height);
            }
            else if (currentGroup == "disposal")
            {
                disposalHistory.Size = new Size(width, height);
                disposalRequest.Size = new Size(width, height);
                disposalProcess.Size = new Size(width, height);
                disposalConfirm.Size = new Size(width, height);
            }
            else if (currentGroup == "file")
            {
                fileUl.Size = new Size(width, height);
                fileKdc.Size = new Size(width, height);
            }
            else if (currentGroup == "reporting")
            {
                cdReport.Size = new Size(width, height);
                modifyCheck.Size = new Size(width, height);
                paymentList.Size = new Size(width, height);
                poCollection.Size = new Size(width, height);
                disposalReport.Size = new Size(width, height);
                vnOnlyReport.Size = new Size(width, height);
                cnVnOnlyReport.Size = new Size(width, height);
            }
            else if (currentGroup == "data")
            {
                masterRingi.Size = new Size(width, height);
                masterVendor.Size = new Size(width, height);
                masterMouldCode.Size = new Size(width, height);
                masterRingiDetail.Size = new Size(width, height);
                masterOem.Size = new Size(width, height);
            }
            else if (currentGroup == "setting")
            {
                settingCurrency.Size = new Size(width, height);
                settingDirectory.Size = new Size(width, height);
                settingLog.Size = new Size(width, height);
                settingJpy.Size = new Size(width, height);
                settingCriteria.Size = new Size(width, height);
            }
            else
                MessageBox.Show("Error occured!!");
            #endregion
        }

        private void clearControl()
        {
            panelMain.Controls.Clear();

            this.resize();
        }

        private void transparentButton()
        {
            foreach (Control control in customPanel1.Controls)
            {
                if (control is Button)
                    control.BackColor = Color.Transparent;
            }
        }

        private void loadUserControl(string tag)
        {
            //panelMain.SuspendLayout();

            #region Quotation Group
            if (tag == "quotation")
            {
                // quotation = new ucQuotation();
                this.clearControl();
                panelMain.Controls.Add(quotation);
                quotation.menuClick += new EventHandler(quotation_menuClick);
                quotation.setClick += new EventHandler(quotation_setClick);
                quotation.commonClick += new EventHandler(quotation_commonClick);
                quotation.modifyClick += new EventHandler(quotation_modifyClick);
            }

            if (tag == "ringi")
            {
                //waitRingi = new ucWaitForRingi();
                this.clearControl();
                panelMain.Controls.Add(waitRingi);

                waitRingi.toRingiEvent += new EventHandler(waitRingi_toRingiEvent);
            }

            if (tag == "fac")
            {
                //fixedAssetCode = new ucFac();
                this.clearControl();
                panelMain.Controls.Add(fac);
            }

            if (tag == "issuepo")
            {
                //issuePo = new ucIssuePo();
                this.clearControl();
                panelMain.Controls.Add(issuepo);
            }

            if (tag == "instock")
            {
                //inStock = new ucInStock();
                instock3 = new ucInStock3();
                this.clearControl();
                //panelMain.Controls.Add(instock);
                //panelMain.Controls.Add(instock2);
                panelMain.Controls.Add(instock3);
            }

            if (tag == "pocancel")
            {
                //cancelPo = new ucPoCancel();
                this.clearControl();
                panelMain.Controls.Add(pocancel);
            }

            if (tag == "mouldviewer")
            {
                //relationSet = new ucRelationshipSet();
                this.clearControl();
                panelMain.Controls.Add(mouldviewer);
            }

            if (tag == "customview")
            {
                //customView = new ucCustomView();
                this.clearControl();
                panelMain.Controls.Add(customview);
            }

            if (tag == "onholdfac")
            {
                //facList = new ucFacList();
                this.clearControl();
                panelMain.Controls.Add(faconhold);
            }

            if (tag == "expensetransfer")
            {
                this.clearControl();
                panelMain.Controls.Add(expensetransfer);
            }

            if (tag == "test")
            {
                this.clearControl();
                test.Dock = DockStyle.Fill;
                panelMain.Controls.Add(test);
            }

            if (tag == "approval")
            {
                this.clearControl();
                app.Dock = DockStyle.Fill;
                panelMain.Controls.Add(app);
            }

            if (tag == "cnview")
            {
                this.clearControl();
                cnview.Dock = DockStyle.Fill;
                panelMain.Controls.Add(cnview);
            }
            #endregion

            #region Transfer Group
            if (tag == "transfervendor")
            {
                //transferVendor = new ucTransferVendor();
                transferVendor = new ucTransferVendor2();
                this.clearControl();
                panelMain.Controls.Add(transferVendor);
            }

            if (tag == "transferowner")
            {
                transferOwner = new ucTransferOwner();
                this.clearControl();
                panelMain.Controls.Add(transferOwner);
            }

            if (tag == "transferhistory")
            {
                transferHistory = new ucTransferHistory();
                this.clearControl();
                panelMain.Controls.Add(transferHistory);
            }

            if (tag == "transferonhold")
            {
                transferHold = new ucTransferHold();
                this.clearControl();
                panelMain.Controls.Add(transferHold);
            }
            #endregion

            #region Disposal Group

            if (tag == "disposalhistory")
            {
                disposalHistory = new ucDisposalHistory();
                this.clearControl();
                panelMain.Controls.Add(disposalHistory);
            }

            if (tag == "disposalrequest")
            {
                //disposalRequest = new ucDisposalRequest();
                disposalView = new ucDisposalView();
                this.clearControl();
                disposalView.Dock = DockStyle.Fill;
                panelMain.Controls.Add(disposalView);
            }

            if (tag == "disposalprocess")
            {
                disposalProcess = new ucDisposal();
                this.clearControl();
                panelMain.Controls.Add(disposalProcess);
            }

            if (tag == "disposalconfirm")
            {
                disposalConfirm = new ucDisposalConfirm();
                this.clearControl();
                panelMain.Controls.Add(disposalConfirm);
            }
            #endregion

            #region File Group
            if (tag == "r3ulfile")
            {
                fileUl = new ucFileUL();
                this.clearControl();
                panelMain.Controls.Add(fileUl);
            }

            if (tag == "kdcfile")
            {
                fileKdc = new ucFileKdc();
                this.clearControl();
                panelMain.Controls.Add(fileKdc);
            }
            #endregion

            #region Reporting Group
            if (tag == "cdreport")
            {
                cdReport = new ucCdReport();
                this.clearControl();
                panelMain.Controls.Add(cdReport);
            }

            if (tag == "modifycheck")
            {
                modifyCheck = new ucModifyCheck();
                this.clearControl();
                panelMain.Controls.Add(modifyCheck);
            }

            if (tag == "paymentlist")
            {
                paymentList = new ucPaymentList();
                this.clearControl();
                panelMain.Controls.Add(paymentList);
            }

            if (tag == "pocollection")
            {
                poCollection = new ucPoCollection();
                this.clearControl();
                panelMain.Controls.Add(poCollection);
            }

            if (tag == "disposalreport")
            {
                disposalReport = new ucDisposalReport();
                this.clearControl();
                panelMain.Controls.Add(disposalReport);
            }

            if (tag == "vnonly")
            {
                vnOnlyReport = new ucVnOnly();
                this.clearControl();
                panelMain.Controls.Add(vnOnlyReport);
            }

            if (tag == "cnvnonly")
            {
                cnVnOnlyReport = new ucCnVnOnly();
                this.clearControl();
                panelMain.Controls.Add(cnVnOnlyReport);
            }

            if (tag == "modelreport")
            {
                modelReport = new ucModelReport();
                this.clearControl();
                modelReport.Dock = DockStyle.Fill;
                panelMain.Controls.Add(modelReport);
            }
            #endregion

            #region Data Group
            if (tag == "ringimaster")
            {
                masterRingi = new ucMasterRingi();
                this.clearControl();
                panelMain.Controls.Add(masterRingi);
            }

            if (tag == "mouldcodemaster")
            {
                masterMouldCode = new ucMasterMouldCode();
                this.clearControl();
                panelMain.Controls.Add(masterMouldCode);
            }

            if (tag == "vendormaster")
            {
                masterVendor = new ucMasterVendor();
                this.clearControl();
                panelMain.Controls.Add(masterVendor);
            }

            if (tag == "ringidetail")
            {
                masterRingiDetail = new ucMasterRingiDetail();
                this.clearControl();
                panelMain.Controls.Add(masterRingiDetail);
            }

            if (tag == "oem")
            {
                masterOem = new ucMasterOem();
                this.clearControl();
                panelMain.Controls.Add(masterOem);
            }

            if (tag == "modeldetail")
            {
                masterMouldDetail = new ucMasterModelDetail();
                this.clearControl();
                masterMouldDetail.Dock = DockStyle.Fill;
                panelMain.Controls.Add(masterMouldDetail);
            }

            if (tag == "mouldcost")
            {
                masterMouldCost = new ucMasterCost();
                this.clearControl();
                masterMouldCost.Dock = DockStyle.Fill;
                panelMain.Controls.Add(masterMouldCost);
            }
            #endregion

            #region Setting Group
            if (tag == "currency")
            {
                settingCurrency = new ucCurrency();
                this.clearControl();
                panelMain.Controls.Add(settingCurrency);
            }

            if (tag == "directory")
            {
                settingDirectory = new ucDirectory();
                this.clearControl();
                panelMain.Controls.Add(settingDirectory);
            }

            if (tag == "systemlog")
            {
                settingLog = new ucSystemLog();
                this.clearControl();
                panelMain.Controls.Add(settingLog);
            }

            if (tag == "jpymonth")
            {
                settingJpy = new ucJpyMonthly();
                this.clearControl();
                panelMain.Controls.Add(settingJpy);
            }

            if (tag == "criteria")
            {
                settingCriteria = new ucCriteria();
                this.clearControl();
                panelMain.Controls.Add(settingCriteria);

            }
            #endregion

            //panelMain.ResumeLayout(true);
        }

        private void quotation_buttonClick(object sender, EventArgs e)
        {
            ucInput = new ucQuotationInput();
            this.clearControl();
            panelMain.Controls.Add(ucInput);
            ucInput.formClose += new EventHandler(input_formClose);
        }

        private void input_formClose(object sender, EventArgs e)
        {
            //quotation = new ucQuotation();
            this.clearControl();
            panelMain.Controls.Add(quotation);
            quotation.buttonClick -= new EventHandler(quotation_buttonClick);
            quotation.buttonClick += new EventHandler(quotation_buttonClick);
            quotation.menuClick -= new EventHandler(quotation_menuClick);
            quotation.menuClick += new EventHandler(quotation_menuClick);
            quotation.setClick -= new EventHandler(quotation_setClick);
            quotation.setClick += new EventHandler(quotation_setClick);
            quotation.commonClick -= new EventHandler(quotation_commonClick);
            quotation.commonClick += new EventHandler(quotation_commonClick);
            quotation.modifyClick -= new EventHandler(quotation_modifyClick);
            quotation.modifyClick += new EventHandler(quotation_modifyClick);
        }

        private void quotation_modifyClick(object sender, EventArgs e)
        {
            ucModify = new ucQuotationModify(GlobalService.selectedChaseno);
            this.clearControl();
            panelMain.Controls.Add(ucModify);
            ucModify.formClose += new EventHandler(ucModify_formClose);
        }

        private void quotation_menuClick(object sender, EventArgs e)
        {
            ucEdit = new ucQuotationEdit(GlobalService.selectedId);
            this.clearControl();
            panelMain.Controls.Add(ucEdit);
            ucEdit.formClose += new EventHandler(mouldDetail_formClose);
        }

        private void quotation_setClick(object sender, EventArgs e)
        {
            //ucSet = new ucQuotationSet(GlobalService.gMouldNo, GlobalService.gItemCode);
            ucRelation = new ucQuotationRelation(GlobalService.gMouldNo, GlobalService.gItemCode);
            this.clearControl();
            //panelMain.Controls.Add(ucSet);
            panelMain.Controls.Add(ucRelation);
            //ucSet.formClose += new EventHandler(mouldset_formClose);
            ucRelation.formClose += new EventHandler(ucRelation_formClose);
        }

        private void quotation_commonClick(object sender, EventArgs e)
        {
            ucCommon = new ucQuotationCommon(GlobalService.gMouldNo, GlobalService.gItemCode);
            this.clearControl();
            panelMain.Controls.Add(ucCommon);
            ucCommon.formClose += new EventHandler(mouldcommon_formClose);
        }

        private void ucModify_formClose(object sender, EventArgs e)
        {
            this.loadQuotation();
        }

        private void mouldDetail_formClose(object sender, EventArgs e)
        {
            this.loadQuotation();
        }

        private void mouldset_formClose(object sender, EventArgs e)
        {
            this.loadQuotation();
        }

        private void mouldcommon_formClose(object sender, EventArgs e)
        {
            this.loadQuotation();
        }

        private void ucRelation_formClose(object sender, EventArgs e)
        {
            this.loadQuotation();
        }

        private void loadQuotation()
        {
            //quotation = new ucQuotation();
            this.clearControl();
            panelMain.Controls.Add(quotation);
            quotation.menuClick -= new EventHandler(quotation_menuClick);
            quotation.menuClick += new EventHandler(quotation_menuClick);
            quotation.setClick -= new EventHandler(quotation_setClick);
            quotation.setClick += new EventHandler(quotation_setClick);
            quotation.commonClick -= new EventHandler(quotation_commonClick);
            quotation.commonClick += new EventHandler(quotation_commonClick);
            quotation.modifyClick -= new EventHandler(quotation_modifyClick);
            quotation.modifyClick += new EventHandler(quotation_modifyClick);
        }

        private void waitRingi_toRingiEvent(object sender, EventArgs e)
        {
            ucAssignRingi = new ucToRingi(GlobalService.toRingiList);
            this.clearControl();
            panelMain.Controls.Add(ucAssignRingi);
            ucAssignRingi.formClose += new EventHandler(toRingi_formClose);
        }

        private void toRingi_formClose(object sender, EventArgs e)
        {
            waitRingi = new ucApplyRingi();
            this.clearControl();
            panelMain.Controls.Add(waitRingi);
            waitRingi.toRingiEvent += new EventHandler(waitRingi_toRingiEvent);
        }

        private void btnQuotation_Click(object sender, EventArgs e)
        {
            this.formload();
        }

        private void quotation_clickEvent(object sender, EventArgs e)
        {
            string tag = menuQuotation.selectedTag;

            this.loadUserControl(tag);

            quotation.buttonClick -= new EventHandler(quotation_buttonClick);
            quotation.buttonClick += new EventHandler(quotation_buttonClick);
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            this.transparentButton();

            this.btnTransfer.BackColor = Color.DarkOrange;

            currentGroup = "transfer";

            panelLeft.Controls.Clear();

            menuTransfer = new ucTransferMenu();

            panelLeft.Controls.Add(menuTransfer);

            panelMain.Controls.Clear();

            menuTransfer.clickEvent += new EventHandler(transfer_clickEvent);
        }

        private void transfer_clickEvent(object sender, EventArgs e)
        {
            string tag = menuTransfer.selectedTag;

            this.loadUserControl(tag);
        }

        private void btnDisposal_Click(object sender, EventArgs e)
        {
            this.transparentButton();

            this.btnDisposal.BackColor = Color.DarkOrange;

            currentGroup = "disposal";

            panelLeft.Controls.Clear();

            menuDisposal = new ucDisposalMenu();

            panelLeft.Controls.Add(menuDisposal);

            panelMain.Controls.Clear();

            menuDisposal.clickEvent += new EventHandler(disposal_clickEvent);
        }

        private void disposal_clickEvent(object sender, EventArgs e)
        {
            string tag = menuDisposal.selectedTag;

            this.loadUserControl(tag);
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            this.transparentButton();

            this.btnFile.BackColor = Color.DarkOrange;

            currentGroup = "file";

            panelLeft.Controls.Clear();

            menuFile = new ucFileMenu();

            panelLeft.Controls.Add(menuFile);

            panelMain.Controls.Clear();

            menuFile.clickEvent += new EventHandler(file_clickEvent);
        }

        private void file_clickEvent(object sender, EventArgs e)
        {
            string tag = menuFile.selectedTag;

            this.loadUserControl(tag);
        }

        private void btnReporting_Click(object sender, EventArgs e)
        {
            this.transparentButton();

            this.btnReporting.BackColor = Color.DarkOrange;

            currentGroup = "reporting";

            panelLeft.Controls.Clear();

            menuReporting = new ucReportingMenu();

            panelLeft.Controls.Add(menuReporting);

            panelMain.Controls.Clear();

            menuReporting.clickEvent += new EventHandler(reporting_clickEvent);
        }

        private void reporting_clickEvent(object sender, EventArgs e)
        {
            string tag = menuReporting.selectedTag;

            this.loadUserControl(tag);
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            this.transparentButton();

            this.btnData.BackColor = Color.DarkOrange;

            currentGroup = "data";

            panelLeft.Controls.Clear();

            menuData = new ucDataMenu();

            panelLeft.Controls.Add(menuData);

            panelMain.Controls.Clear();

            menuData.clickEvent += new EventHandler(data_clickEvent);
        }

        private void data_clickEvent(object sender, EventArgs e)
        {
            string tag = menuData.selectedTag;

            this.loadUserControl(tag);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            this.transparentButton();

            this.btnSetting.BackColor = Color.DarkOrange;

            currentGroup = "setting";

            panelLeft.Controls.Clear();

            menuSetting = new ucSettingMenu();

            panelLeft.Controls.Add(menuSetting);

            panelMain.Controls.Clear();

            menuSetting.clickEvent += new EventHandler(setting_clickEvent);
        }

        private void setting_clickEvent(object sender, EventArgs e)
        {
            string tag = menuSetting.selectedTag;

            this.loadUserControl(tag);
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            this.resize();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ApprovalForm form = new ApprovalForm();
            form.ShowDialog();
        }
    }
}
