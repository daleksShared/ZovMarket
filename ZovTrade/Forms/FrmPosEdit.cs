using System;
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

        public FrmEditPos(int _posId,bool _isNewPos=false,int _dealerId=0)
        {
            
            posId = _posId;
            isNewPos = _isNewPos;
            dealerId = _dealerId;

            InitializeComponent();

            layoutControlItem17.Visibility = isNewPos ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never : DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
           
            
        }

        private void FrmEditPos_Load(object sender, EventArgs e)
        {
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
                    this.Text = firstOrDefault.dealerZovName + "\\" + firstOrDefault.legalName;

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


                dealerId = db.Dealers.Local.First().ID;


               
            }
            else
            {
                
                this.Text = db.Dealers.Where(x=>x.ID== dealerId).Select(x=>x.dealerZovName).First() + " \\ Новый магазин";


                posRatingTextEdit.EditValue = 0;
                db.PosTypes.Load();
                db.Dealers.Where(x => x.ID == dealerId).Load();

                var newPos = db.Pos.Create();
                newPos.dealer_ID = dealerId;

                db.Pos.Add(newPos);
                
               
            }

            int parentDealerId = 0;
            if (db.Dealers.Where(x => x.ID == dealerId && x.DealerParent != null).Select(x => x.DealerParent).Any())
            {
                parentDealerId = db.Dealers.Where(x => x.ID == dealerId && x.DealerParent != null).Select(x => x.DealerParent).First().ID;
            }
            
            var dealerLegalNames = db.DealerLegalNames.Where(x => x.Dealers.ID == dealerId || (parentDealerId != 0 && x.Dealers.ID == parentDealerId)).Select(x => new { x.ID, x.LegalAddress, x.LegalName }).ToList();

            dealerLegalNamesBindingSource.DataSource = dealerLegalNames;

            posTypesBindingSource.DataSource = db.PosTypes.Local.Select(x => new { x.ID, x.posTypeName }).ToList();



            dealersBindingSource.DataSource = db.Dealers.Select(x => new { x.ID, x.dealerZovName, parentName = x.DealerParent.dealerZovName }).OrderBy(x => x.parentName).ThenBy(x => x.dealerZovName).ToList();
            
            posBindingSource.DataSource = db.Pos.Local.ToBindingList();
            db.Sites.Where(x => x.Dealer_ID == dealerId).Load();
            statusOfPosBindingSource.DataSource = db.StatusOfPos.Select(x => new { x.ID, x.StatusName, x.StatusColor }).ToList();
            db.StatusOfPos.Load();
            LoadPosSites();



            //bsPosSites.Filter = "Pos_ID=" + posId;




            splashScreenManager1.CloseWaitForm();
        }
        private void LoadPosSites()
        {
            var posSites = db.Pos.Local.FirstOrDefault().Sites.ToList();
            sitesBindingSource.DataSource = db.Pos.Local.FirstOrDefault().Dealers.Sites.Except(posSites).ToList();
            bsPosSites.DataSource = db.Pos.Local.FirstOrDefault().Sites.ToList();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                db.SaveChanges();
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
            if (MessageBox.Show(this,"Точно удалить???") == DialogResult.OK)
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
    }
}