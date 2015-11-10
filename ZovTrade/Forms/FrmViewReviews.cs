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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace ZovTrade.Forms
{
    public partial class FrmViewReviews : DevExpress.XtraEditors.XtraForm
    {
        private DbModel.tradeEntities db =
            new tradeEntities(DbModel.Tools.TradeConnectionString(Properties.Settings.Default.barcodeCS.ToString()));
        public FrmViewReviews()
        {
            InitializeComponent();
            splashScreenManager1.SplashFormStartPosition = DevExpress.XtraSplashScreen.SplashFormStartPosition.Manual;
            ReviewStartDate.EditValue = DateTime.Today.AddDays(-60);
            ReviewEndDate.EditValue = DateTime.Today.AddDays(1);

        }

        private void btnLoadData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }
        private void LoadData() {
            splashScreenManager1.ShowWaitForm();
            var dtStart = (DateTime)ReviewStartDate.EditValue;
            var dtEnd = (DateTime)ReviewEndDate.EditValue;


            var data = db.PosRanks.Where(r => r.DateAdd >= dtStart.Date & r.DateAdd <= dtEnd.Date).Select(r => new
            {
                DateAdd = r.DateAdd,
                DealerZovName = r.Pos.Dealers.dealerZovName,
                PosLegalName = r.Pos.legalName,
                Description = r.Description,
                Rank=r.Rank,
                ActiveRank = r.ActiveRank,
                YandexAdress = r.Pos.yandexAdress,
                DealerContactsList = r.Pos.Dealers.Contacts.Select(c => c.ContactName + ":\n" + c.ContactPhones + "\n").ToList(),
                PosContactsList = r.Pos.Contacts.Select(c => c.ContactName + ":\n" + c.ContactPhones + "\n").ToList(),
                PosId = r.Pos.ID,
                ZovId = r.Pos.Ruby_Id
            }).ToList().Select(d => new
            {
                d.DateAdd,
                d.DealerZovName,
                d.PosLegalName,
                d.Description,
                d.Rank,
                d.ActiveRank,
                d.YandexAdress,
                DealerContacts = d.DealerContactsList.Any() ? d.DealerContactsList.Aggregate((cur, next) => cur + "\n" + next) : "",
                PosContacts = d.PosContactsList.Any() ? d.PosContactsList.Aggregate((cur, next) => cur + "\n" + next) : "",
                d.PosId,
                d.ZovId
            }).OrderByDescending(d=>d.DateAdd).ToList(); 
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
                var dealerID = db.Pos.Where(x => x.ID == posId).Select(x => x.Dealers.ID).FirstOrDefault();
                var frmEditPos = new FrmEditPos(posId, false, dealerID);
               
                frmEditPos.ShowDialog(this);


            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var newReviewForm = new Forms.FrmPosReviewNew();
            var dr = newReviewForm.ShowDialog(this);
            if (dr == DialogResult.OK) LoadData();
        }
    }
}