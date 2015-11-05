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
        public FrmEditPos(int _posId)
        {
            
            posId = _posId;
            
                         
            InitializeComponent();
            
       
           
            
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

            var dealers = db.Dealers.Local.ToBindingList();

            dealersBindingSource.DataSource = db.Dealers.Select(x => new { x.ID, x.dealerZovName, parentName=x.DealerParent.dealerZovName }).OrderBy(x=>x.parentName).ThenBy(x=>x.dealerZovName).ToList();
            posBindingSource.DataSource = db.Pos.Local.ToBindingList();
            splashScreenManager1.CloseWaitForm();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
        }
    }
}