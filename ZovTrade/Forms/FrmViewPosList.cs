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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace ZovTrade.Forms
{
    public partial class FrmViewPosList : DevExpress.XtraEditors.XtraForm
    {
        private DbModel.tradeEntities db =
            new tradeEntities(DbModel.Tools.TradeConnectionString(Properties.Settings.Default.barcodeCS.ToString()));
        public FrmViewPosList()
        {
            InitializeComponent();
            splashScreenManager1.SplashFormStartPosition = DevExpress.XtraSplashScreen.SplashFormStartPosition.Manual;
           

        }

        private void btnLoadData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }
        private void LoadData() {
            splashScreenManager1.ShowWaitForm();
           

            var data = db.Pos.Select(r => new
            {
                DateAdd = r.dateadd,
                DealerZovName = r.Dealers.dealerZovName,
                PosLegalName = r.legalName,
                posRating = r.PosRanks.Any(x => x.ActiveRank == true) ? r.PosRanks.Where(y => y.ActiveRank == true).Average(y => y.Rank) : 0,
                YandexAdress = r.yandexAdress,
                LegalName=r.legalName,
                //DealerContactsList = r.Dealers.Contacts.Select(c => c.ContactName + ":\n" + c.ContactPhones + "\n").ToList(),
                //PosContactsList = r.Contacts.Select(c => c.ContactName + ":\n" + c.ContactPhones + "\n").ToList(),
                PosId = r.ID,
                ZovId = r.Ruby_Id
            }).ToList().Select(d => new
            {
                d.DateAdd,
                d.DealerZovName,
                d.PosLegalName,
                d.posRating,
                d.YandexAdress,
                //DealerContacts = d.DealerContactsList.Any() ? d.DealerContactsList.Aggregate((cur, next) => cur + "\n" + next) : "",
                //PosContacts = d.PosContactsList.Any() ? d.PosContactsList.Aggregate((cur, next) => cur + "\n" + next) : "",
                d.PosId,
                d.ZovId,
                d.LegalName
            }).OrderBy(d=>d.DealerZovName).ThenBy(d=>d.PosLegalName).ToList(); 
            gridControl1.DataSource = data;
            gridView1.BestFitColumns();
            splashScreenManager1.CloseWaitForm();
        }

        private void FrmViewReviews_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            //    DoRowDoubleClick(view, pt);
            GridHitInfo info = view.CalcHitInfo(pt);
            if ((info.InRow || info.InRowCell) && (!gridView1.IsGroupRow(info.RowHandle)))
            {
                string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                //     MessageBox.Show(string.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption));
                int posId = (int)gridView1.GetRowCellValue(info.RowHandle, "PosId");
                var frmEditPos = new FrmEditPos(posId);

                frmEditPos.ShowDialog(this);


            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var newPos = new FrmEditPos(0,true);
            var dr = newPos.ShowDialog(this);
            if (dr == DialogResult.OK) LoadData();
        }
    }
}