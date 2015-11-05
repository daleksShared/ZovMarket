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
using System.IO;
using System.Diagnostics;

namespace ZovTrade.Forms
{
    public partial class FrmAppReport : DevExpress.XtraEditors.XtraForm
    {
        private DbModel.tradeEntities db = new tradeEntities(DbModel.Tools.TradeConnectionString(Properties.Settings.Default.barcodeCS.ToString()));
        public FrmAppReport()
        {
            InitializeComponent();
        }

        private void FrmAppReport_Load(object sender, EventArgs e)
        {
            try
            {
                appReportsBindingSource.DataSource = db.AppReports.Where(x => x.Closed.Value == null).Select(x => new { x.ID, x.AddTime, x.UserName, x.Message,hasFile= x.FileName==null || x.FileName==string.Empty ? false:true }).ToList();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
            }
          
        }
    }
}