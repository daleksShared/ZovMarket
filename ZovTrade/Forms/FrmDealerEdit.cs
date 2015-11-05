using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DbModel;
using System.Data.Entity;

namespace ZovTrade
{
    
    public partial class FrmEditDealer : DevExpress.XtraEditors.XtraForm
    {
        private DbModel.tradeEntities db =
              new tradeEntities(DbModel.Tools.TradeConnectionString(Properties.Settings.Default.barcodeCS.ToString()));
        private int dealerId = 0;
        private bool isNewDealer = false;
        public FrmEditDealer(int _dealerId, bool _isNewDealer, string dealerName = "")
        {
            dealerId = _dealerId;
            isNewDealer = _isNewDealer;
            InitializeComponent();
            if (isNewDealer)
            {
                this.Text = "Новый дилер...";
            }
            else
            {
                this.Text = dealerName;
            }
        }

        private void FrmEditDealer_Load(object sender, EventArgs e)
        {
            if (isNewDealer)
            {
                db.Dealers.Add(db.Dealers.Create());
            }
            else
            {
                db.Dealers.Where(x => x.ID==dealerId).Load();
                db.Sites.Where(x => x.Dealers.ID == dealerId).Load();
                db.DealerLegalNames.Where(x => x.Dealers.ID == dealerId).Load();
            }
            bsParentDealers.DataSource = db.Dealers.Select(x => new { x.ID, x.dealerName, x.dealerZovName }).ToList();
            dealersBindingSource.DataSource = db.Dealers.Local.ToBindingList();
            dealerLegalNamesBindingSource.DataSource = db.DealerLegalNames.Local.ToBindingList();
            sitesBindingSource.DataSource = db.Sites.Local.ToBindingList();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (db.Sites.Local.Any(x => x.Dealers == null))
            {
                foreach (var site in db.Sites.Local.Where(x => x.Dealers == null))
                {
                    site.Dealers = db.Dealers.First();
                }
            }
            if (db.DealerLegalNames.Local.Any(x => x.Dealers == null))
            {
                foreach (var legalName in db.DealerLegalNames.Local.Where(x => x.Dealers == null))
                {
                    legalName.Dealers = db.Dealers.First();
                }
            }
            db.SaveChanges();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            var legalName = db.DealerLegalNames.Create();
            legalName.Dealers = db.Dealers.Local.First();
            db.DealerLegalNames.Add(legalName);
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            var site = db.Sites.Create();
            site.Dealers = db.Dealers.Local.First();
            db.Sites.Add(site);
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}