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
        private tradeEntities db;
        public FrmAppReport()
        {
            InitializeComponent();
        }

        private void FrmAppReport_Load(object sender, EventArgs e)
        {

            LoadData();
        }
        private void LoadData() {
            try
            {
                db = new tradeEntities(DbModel.Tools.TradeConnectionString(Properties.Settings.Default.barcodeCS.ToString()));
                appReportsBindingSource.DataSource = db.AppReports.Select(x => new { x.ID, x.AddTime, x.UserName, x.Message, hasFile = x.FileName == null || x.FileName == string.Empty ? false : true, x.ClosedTime }).OrderByDescending(x => x.ClosedTime).ThenByDescending(x => x.AddTime).Take(500).ToList();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (gridView1.RowCount > 0 && gridView1.IsValidRowHandle(gridView1.FocusedRowHandle) && !gridView1.IsNewItemRow(gridView1.FocusedRowHandle))
            {
                int rowHandle = gridView1.FocusedRowHandle;
                int apprId = (int)gridView1.GetRowCellValue(rowHandle,"ID");
                var rep = db.AppReports.Find(apprId);
                if (rep != null)
                {

                    if (rep.CloseAction == null || !(bool)rep.CloseAction)
                    {
                        rep.CloseAction = true;
                        db.SaveChanges();
                        db.Dispose();
                        LoadData();
                    }
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }
    }
}