﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DbModel;
using DevExpress.Data.WcfLinq.Helpers;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Diagnostics;

namespace ZovTrade
{
    public partial class FrmEditPos : DevExpress.XtraEditors.XtraForm
    {
        private DbModel.tradeEntities db =
            new tradeEntities(DbModel.Tools.TradeConnectionString(Properties.Settings.Default.barcodeCS.ToString()));
        //   private SplashScreenManager splashScreenManager = new SplashScreenManager();
        private int posId = 0;
        bool isNewPos = false;
        int dealerId = 0;

        public FrmEditPos(int _posId, bool _isNewPos = false, int _dealerId = 0)
        {

            posId = _posId;
            isNewPos = _isNewPos;
            dealerId = _dealerId;

            InitializeComponent();

            layoutControlItem17.Visibility = isNewPos ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never : DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            if (dealerId == 0)
            {
                var frmSelectDealer = new Forms.FrmDealerChoose();
                if (frmSelectDealer.ShowDialog(this) == DialogResult.OK)
                {
                    dealerId = frmSelectDealer.DealerId;
                }

            }
        }

        private void FrmEditPos_Load(object sender, EventArgs e)
        {
            if (dealerId == 0)
            {
                this.Close();
            }
            //splashScreenManager.
            //    splashScreenManager.ShowWaitForm();
            splashScreenManager1.ShowWaitForm();




            if (!isNewPos)
            {
                var curpos = from p in db.Pos
                             where p.ID == posId
                             select new { p.legalName, p.Dealers.dealerZovName };

                var firstOrDefault = curpos.FirstOrDefault();
                if (firstOrDefault != null)
                    this.Text = firstOrDefault.dealerZovName + " \\ " + firstOrDefault.legalName;

                var posRating =
                    db.Pos.Where(x => x.ID == posId)
                        .Select(
                            x =>
                                new
                                {
                                    posRating =
                                        x.PosRanks.Any(r => r.ActiveRank == true)
                                            ? x.PosRanks.Where(r => r.ActiveRank == true).Average(r => r.Rank) : 0
                                });
                posRatingTextEdit.EditValue = posRating.First();
                db.PosTypes.Load();
                db.Dealers.Where(x => x.Pos.FirstOrDefault(p => p.ID == posId).Dealers.ID == x.ID).Load();
                db.Pos.Where(x => x.ID == posId).Load();


                db.PosRanks.Where(x => x.Pos.ID == posId).Load();
                db.Certifications.Where(x => x.Pos.ID == posId).Load();
                db.Samples.Where(x => x.Pos.ID == posId).Load();
                dealerId = db.Dealers.Local.First().ID;

                db.Contacts.Where(x => x.Pos.Where(p => p.ID == posId).Any()).Load();

                db.Attachments.Where(x => x.Certifications.Where(c => c.Pos_ID == posId).Any()).Load();

            }
            else
            {
               
                    this.Text = db.Dealers.Where(x => x.ID == dealerId).Select(x => x.dealerZovName).First() + " \\ Новый магазин";
                    db.Dealers.Where(x => x.ID == dealerId).Load();
              
               

                posRatingTextEdit.EditValue = 0;
                db.PosTypes.Load();


                var newPos = db.Pos.Create();
                if (dealerId > 0)
                {
                    newPos.dealer_ID = dealerId;
                }
                db.Pos.Add(newPos);


            }


            db.CertTypes.Load();
            certTypesBindingSource.DataSource = db.CertTypes.Local.Select(x => new { x.ID, x.DocType }).ToList();

            int parentDealerId = 0;

            if (db.Dealers.Where(x => x.ID == dealerId && x.DealerParent != null).Select(x => x.DealerParent).Any())
            {
                parentDealerId = db.Dealers.Where(x => x.ID == dealerId && x.DealerParent != null).Select(x => x.DealerParent).First().ID;
            }

            var dealerLegalNames = db.DealerLegalNames.Where(x => x.Dealers.ID == dealerId || (parentDealerId != 0 && x.Dealers.ID == parentDealerId)).Select(x => new { x.ID, x.LegalAddress, x.LegalName }).ToList();

            dealerLegalNamesBindingSource.DataSource = dealerLegalNames;

            posTypesBindingSource.DataSource = db.PosTypes.Local.Select(x => new { x.ID, x.posTypeName }).ToList();

            gridLookUpEdit1.Properties.DataSource= db.Dealers.Select(x => new {
                x.ID,
                dealerName = x.Dealer_ID != null ? x.DealerParent.dealerZovName + "/" + x.dealerZovName : x.dealerZovName

            })
            .ToList();
            gridLookUpEdit1.Properties.ValueMember = "ID";
            gridLookUpEdit1.Properties.DisplayMember = "dealerName";

            // dealersBindingSource.DataSource = 

            posBindingSource.DataSource = db.Pos.Local.ToBindingList();

            posRanksBindingSource.DataSource = db.PosRanks.Local.ToBindingList();
            certificationsBindingSource.DataSource = db.Certifications.Local.ToBindingList();
            samplesBindingSource.DataSource = db.Samples.Local.ToBindingList();
            contactsBindingSource.DataSource = db.Contacts.Local.ToBindingList();
            sampleDetailStatusBindingSource.DataSource = db.SampleDetailStatus.Local.ToBindingList();

            db.SampleDetailStatus.Load();
            db.Sites.Where(x => x.Dealer_ID == dealerId | x.Dealer_ID == parentDealerId).Load();

            statusOfPosBindingSource.DataSource = db.StatusOfPos.Select(x => new { x.ID, x.StatusName, x.StatusColor }).ToList();
            db.StatusOfPos.Load();
            LoadPosSites();




            //bsPosSites.Filter = "Pos_ID=" + posId;




            splashScreenManager1.CloseWaitForm();
        }
        private void LoadPosSites()
        {
            var posSites = db.Pos.Local.FirstOrDefault().Sites.ToList();


            sitesBindingSource.DataSource = db.Sites.Local.Except(posSites).Select(x => new { x.ID, x.URL, x.Dealers.dealerZovName }).ToList();
            bsPosSites.DataSource = db.Pos.Local.FirstOrDefault().Sites.ToList();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                db.SaveChanges();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Tools.showDbSaveExceptions(ex);
            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Точно удалить???") == DialogResult.OK)
            {
                try
                {


                    var curPos = db.Pos.Where(x => x.ID == posId).Select(x => x).ToList();
                    if (curPos.Any())
                    {
                        db.Pos.Remove(curPos.First());
                        db.SaveChanges();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    Tools.showDbSaveExceptions(ex);
                }
            }
        }

        private void Добавить_Click(object sender, EventArgs e)
        {
            //var row = gridLookUpEditDealerSites.Properties.View.GetDataRow(gridLookUpEditDealerSites.Properties.View.FocusedRowHandle);
            var curSiteId = gridLookUpEditDealerSites.EditValue;
            if (curSiteId != null)
            {
                var curSite = db.Sites.Where(x => x.ID == (int)curSiteId).FirstOrDefault();
                //var pos = db.Pos.Local.FirstOrDefault();
                var posSites = db.Pos.Local.FirstOrDefault().Sites;
                posSites.Add(curSite);
                LoadPosSites();
            }
        }
        private void remove_siteFromPos(int siteID)
        {
            try
            {
                var curSite = db.Sites.Where(x => x.ID == siteID).FirstOrDefault();
                //var pos = db.Pos.Local.FirstOrDefault();
                var posSites = db.Pos.Local.FirstOrDefault().Sites;
                posSites.Remove(curSite);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            LoadPosSites();
        }
        private void gridControl4_ProcessGridKey(object sender, KeyEventArgs e)
        {
            var grid = sender as GridControl;
            var view = grid.FocusedView as GridView;
            if (e.KeyData == Keys.Delete)
            {
                e.Handled = true;
                int SiteId = (int)view.GetRowCellValue(view.FocusedRowHandle, "ID");

                remove_siteFromPos(SiteId);
            }
        }

        private void BtnAddSample_Click(object sender, EventArgs e)
        {
            var Sample = db.Samples.Create();
            Sample.Pos = db.Pos.Local.FirstOrDefault();
            Sample.sampleStatus = 1;
            db.Samples.Add(Sample);

        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            DeleteFocusedRows(gridViewContacts);
        }
        private void DeleteFocusedRows(DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            if (view.RowCount > 0 && view.IsValidRowHandle(view.FocusedRowHandle) && !view.IsNewItemRow(view.FocusedRowHandle))
            {
                view.BeginSort();
                try
                {
                    view.DeleteRow(view.FocusedRowHandle);

                }
                catch (Exception)
                {
                }
                view.EndSort();
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            var Contact = db.Contacts.Create();
            //Contact.Dealers.Add(db.Dealers.Local.First());
            db.Contacts.Add(Contact);
            db.Pos.Local.FirstOrDefault().Contacts.Add(Contact);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            DeleteFocusedRows(gridViewReviews);
        }

        private void BtnAddReview_Click(object sender, EventArgs e)
        {
            var Review = db.PosRanks.Create();
            //Contact.Dealers.Add(db.Dealers.Local.First());
            Review.Pos = db.Pos.Local.FirstOrDefault();
            Review.Rank = 0;
            db.PosRanks.Add(Review);
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            DeleteFocusedRows(gridViewCerts);
        }

        private void BtnAddSertif_Click(object sender, EventArgs e)
        {
            var Cert = db.Certifications.Create();
            Cert.Pos = db.Pos.Local.FirstOrDefault();
            Cert.CertType_ID = db.CertTypes.Local.Last().ID;
            db.Certifications.Add(Cert);
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            DeleteFocusedRows(gridViewSamples);
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {

            var frmSelectDealer = new Forms.FrmDealerChoose();
            if (frmSelectDealer.ShowDialog(this) == DialogResult.OK)
            {
                try
                {

                var dbNew = new tradeEntities(DbModel.Tools.TradeConnectionString(Properties.Settings.Default.barcodeCS.ToString()));
                var pos2change = dbNew.Pos.Where(x => x.ID == posId).FirstOrDefault();
                pos2change.dealer_ID = frmSelectDealer.DealerId;
                dbNew.SaveChanges();
                this.DialogResult = DialogResult.OK;
                this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    this.Close();
                }
            }


        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            var Contact = db.Contacts.Create();
            Contact.ContactName = "e-mail";
            //Contact.Dealers.Add(db.Dealers.Local.First());
            db.Contacts.Add(Contact);
            db.Pos.Local.FirstOrDefault().Contacts.Add(Contact);
        }
    }
}