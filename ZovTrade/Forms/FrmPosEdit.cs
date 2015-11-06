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

namespace ZovTrade
{
    public partial class FrmEditPos : DevExpress.XtraEditors.XtraForm
    {
        private DbModel.tradeEntities db =
            new tradeEntities(DbModel.Tools.TradeConnectionString(Properties.Settings.Default.barcodeCS.ToString()));
     //   private SplashScreenManager splashScreenManager = new SplashScreenManager();
        private int posId = 0;
        public FrmEditPos(int _posId,bool isNewPos=false)
        {
            
            posId = _posId;
            
                         
            InitializeComponent();

            layoutControlItem17.Visibility = isNewPos ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never : DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
           
            
        }

        private void FrmEditPos_Load(object sender, EventArgs e)
        {
//splashScreenManager.
        //    splashScreenManager.ShowWaitForm();
            splashScreenManager1.ShowWaitForm();
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
             db.Dealers.Where(x=>x.Pos.FirstOrDefault(p=>p.ID==posId).Dealers.ID==x.ID).Load();
            db.Pos.Where(x => x.ID == posId).Load();


            var dealerId = db.Dealers.Local.First().ID;


            //  gridLookUpEdit2.Properties.DataSource = 


            //db.DealerLegalNames.Where(x => x.Dealers.ID == dealerId).Select(x => new { x.ID, x.LegalAddress, x.LegalName }).ToList();
            //db.DealerLegalNames.Where(x => x.Dealers.ID == dealerId).Load();
            Nullable<int> parentDealerId = db.Dealers.Where(x => x.ID == dealerId).Select(x => x.DealerParent).First().ID;
            


            var dealerLegalNames = db.DealerLegalNames.Where(x => x.Dealers.ID == dealerId || (parentDealerId!=null && x.Dealers.ID == parentDealerId)).Select(x => new { x.ID, x.LegalAddress, x.LegalName }).ToList();
            //var dealerLegalNamesParent = db.DealerLegalNames.Where(x => x.Dealers.ID == parentDealerId || x.Dealers.ID == x.Dealers.DealerParent.ID).Select(x => new { x.ID, x.LegalAddress, x.LegalName }).ToList();

            dealerLegalNamesBindingSource.DataSource = dealerLegalNames;
            //var pos =
            //    db.Pos.Where(x => x.ID == posId)
            //        .Include(x => x.PosTypes)
            //        .Include(x => x.Dealers)
            //        .Include(x => x.DealerLegalNames)
            //        .Include(x => x.Certifications)
            //        .Include(x => x.PosEmails)
            //        .Include(x => x.PosPhones).Include(x => x.Samples).Select(x=>x);
            //  if (!pos.Any()){return;}
            posTypesBindingSource.DataSource = db.PosTypes.Local.Select(x => new {x.ID, x.posTypeName}).ToList();
            
            //var dealers = db.Dealers.Local.ToBindingList();

            dealersBindingSource.DataSource = db.Dealers.Select(x => new { x.ID, x.dealerZovName, parentName=x.DealerParent.dealerZovName }).OrderBy(x=>x.parentName).ThenBy(x=>x.dealerZovName).ToList();
            posBindingSource.DataSource = db.Pos.Local.ToBindingList();
            splashScreenManager1.CloseWaitForm();
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
            if (MessageBox.Show(this,"Точно удалить???") == DialogResult.Yes)
                {
                var curPos = db.Pos.Where(x => x.ID == posId).Select(x => x).ToList();
                if (curPos.Any())
                {
                    db.Pos.Remove(curPos.First());
                    db.SaveChanges();
                    this.Close();
                }
            }
        }
    }
}