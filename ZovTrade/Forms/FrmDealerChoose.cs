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

namespace ZovTrade.Forms
{
    public partial class FrmDealerChoose : DevExpress.XtraEditors.XtraForm
    {
        private DbModel.tradeEntities db =
              new tradeEntities(DbModel.Tools.TradeConnectionString(Properties.Settings.Default.barcodeCS.ToString()));

public int DealerId = 0;
        public FrmDealerChoose()
        {
            InitializeComponent();
        }
        
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var row = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");
            if (row == null)
            {
                DealerId = 0;
                MessageBox.Show("Дилер не выбран!!!!");
                return;
            }
            else
            {
                DealerId = (int)row;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DealerId = 0;
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void FrmDealerChoose_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.Dealers.Select(x => new
            {
                x.ID,
                dealerName = x.Dealer_ID != null ? x.DealerParent.dealerZovName + "/" + x.dealerZovName : x.dealerZovName
                
            }).ToList();
            gridView1.BestFitColumns();
        }
    }
}