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

namespace ZovTrade.Forms
{
    public partial class FrmPosReviewNew : DevExpress.XtraEditors.XtraForm
    {
        private tradeEntities db =
            new tradeEntities(DbModel.Tools.TradeConnectionString(Properties.Settings.Default.barcodeCS.ToString()));
        public FrmPosReviewNew()
        {
            InitializeComponent();
        }

        private void FrmPosReviewNew_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.DataSource = db.Pos.Select(x => new
            {
                x.ID,
                x.Dealers.dealerZovName,
                x.legalName,
                x.yandexAdress
            }
            ).OrderBy(x=>x.dealerZovName).ThenBy(x=>x.legalName).ToList();
            lookUpEdit1.Properties.DisplayMember = "legalName";
            lookUpEdit1.Properties.ValueMember = "ID";


            var Rank = db.PosRanks.Create();
            Rank.ActiveRank = true;
            
            db.PosRanks.Add(Rank);

            posRanksBindingSource.DataSource = db.PosRanks.Local.ToBindingList();
            posRanksBindingSource.MoveFirst();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (db.PosRanks.Local.First().Pos_ID == null) {
                MessageBox.Show("Не все поля определены!!!!");
                return; }
        }
    }
}