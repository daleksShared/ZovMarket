using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Data.Entity;

namespace ZovTrade.Forms
{
    public partial class FrmSendAppReport : DevExpress.XtraEditors.XtraForm
    {
        DbModel.tradeEntities db = new DbModel.tradeEntities(DbModel.Tools.TradeConnectionString(Properties.Settings.Default.barcodeCS.ToString()));
        public FrmSendAppReport()
        {
            InitializeComponent();
            layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            db.AppReports.Add(db.AppReports.Create());
            db.AppReports.Local.First().UserName = ZOV.Tools.Security.UserName;
            appReportsBindingSource.DataSource = db.AppReports.Local.ToBindingList();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception) { };
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                splashScreenManager1.ShowWaitForm();
                try
                {
                    Stream stream = null;
                    if ((stream = openFileDialog1.OpenFile()) != null)
                    {
                        byte[] fileBytes = new byte[stream.Length];

                        stream.Read(fileBytes, 0, fileBytes.Length);
                        stream.Close();
                        stream.Dispose();
                        db.AppReports.Local.First().FileData = fileBytes;
                        db.AppReports.Local.First().FileName = openFileDialog1.FileName;
                        layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка чтения файла: " + ex.Message);
                }
            }
            if (splashScreenManager1.IsSplashFormVisible) {
                splashScreenManager1.CloseWaitForm();
            };
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            db.AppReports.First().FileData = null;
            db.AppReports.First().FileName = "";
            layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }
    }
}