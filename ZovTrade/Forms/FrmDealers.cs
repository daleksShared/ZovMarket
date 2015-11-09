using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DbModel;
using DevExpress.XtraBars.Docking2010.Base;
using DevExpress.XtraTreeList;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.Data.Entity.Validation;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTreeList.Columns;

namespace ZovTrade
{
    public partial class FrmDealers : Form
    {
        private DbModel.tradeEntities db;

        //  private DbModel.tradeEntities dbTree = new tradeEntities(DbModel.Tools.TradeConnectionString(Properties.Settings.Default.barcodeCS.ToString()));

        public FrmDealers()
        {
            InitializeComponent();


            #region treeDealersListinit

            treeDealersList.KeyFieldName = "ID";
            treeDealersList.ParentFieldName = "Dealer_ID";


            var treeDealersListColumn1 = treeDealersList.Columns.Add();

            treeDealersListColumn1.Name = "colId";
            treeDealersListColumn1.Caption = "ID";
            treeDealersListColumn1.FieldName = "ID";
            treeDealersListColumn1.Visible = false;

            var treeDealersListColumn2 = treeDealersList.Columns.Add();

            treeDealersListColumn2.Name = "colDealerID";
            treeDealersListColumn2.Caption = "Dealer_ID";
            treeDealersListColumn2.FieldName = "Dealer_ID";
            treeDealersListColumn2.Visible = false;

            var treeDealersListColumn3 = treeDealersList.Columns.Add();

            treeDealersListColumn3.Name = "coldealerZovName";
            treeDealersListColumn3.Caption = "Дилер";
            treeDealersListColumn3.FieldName = "dealerZovName";
            treeDealersListColumn3.SortOrder = SortOrder.Ascending;
            treeDealersListColumn3.OptionsColumn.AllowEdit = false;
            treeDealersListColumn3.Visible = true;

            #endregion

            //listBoxSubDealers.ValueMember = "ID";
            //listBoxSubDealers.DisplayMember = "dealerZovName";




        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
           db = new tradeEntities(DbModel.Tools.TradeConnectionString(Properties.Settings.Default.barcodeCS.ToString()));
            db.StatusOfPos.Load();
            GetDealersTree();
            splashScreenManager1.CloseWaitForm();


        }

        private int TreeListFocusedId = -1;
        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            var row = treeDealersList.GetDataRecordByNode(treeDealersList.FocusedNode);
            if (row == null)
            {
                TreeListFocusedId = -1;
                GetDealerInfo(0);

            }
            else
            {
                dynamic treeDealer = new {ID = 0, Dealer_ID = 0, dealerZovName = ""};
                treeDealer = row;
                TreeListFocusedId = treeDealer.ID;
                GetDealerInfo(treeDealer.ID);
            }
            

        }

        private void GetDealersTree()

        {

            treeDealersList.BeginUpdate();
            try
            {


                //treeDealersList.DataSource = dbContext.Dealers.Local.ToBindingList();

                treeDealersList.BeginSort();
                treeDealersList.DataSource = db.Dealers.Select(x => new {x.ID, x.Dealer_ID, x.dealerZovName}).ToList();
                ;
                treeDealersList.EndSort();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Application.Exit();
            }
            treeDealersList.EndUpdate();
           
            
            treeDealersList.ExpandAll();
          

        }

        private int dealerId;

        private void cleanDealerData()
        {
            DealerViewDateAdd.EditValue = "";
            DealerViewId.EditValue = "";
            DealerViewDescription.EditValue = "";
            DealerViewFabricName.EditValue = "";
            DealerViewZovName.EditValue = "";
            DealerViewPosCount.EditValue = "";
            DealerViewSubDealersCount.EditValue = "";
            gridControl1.DataSource = null;
        }
        private void GetDealerInfo(int _dealerId)
        {
            //db.Dealers.Local.Clear();
            //db.Dealers.Where(x=>x.Dealer_ID==dealerId).Load();
            dealerId = _dealerId;
            cleanDealerData();
            if (dealerId == 0)
            {
                
                return;
            }
            var curDealer =
                db.Dealers.Where(x => x.ID == dealerId)
                    .Select(
                        x =>
                            new
                            {
                                x.ID,
                                x.dateadd,
                                x.dealerName,
                                x.dealerZovName,
                                x.dealerDescription,
                                posCount = x.Pos.Count,
                                subDealersCount = x.DealerChilds.Count
                            }).FirstOrDefault();
            if (curDealer != null)
            {
                DealerViewDateAdd.EditValue = curDealer.dateadd;
                DealerViewId.EditValue = curDealer.ID;
                DealerViewDescription.EditValue = curDealer.dealerDescription;
                DealerViewFabricName.EditValue = curDealer.dealerZovName;
                DealerViewZovName.EditValue = curDealer.dealerName;
                DealerViewPosCount.EditValue = curDealer.posCount;
                DealerViewSubDealersCount.EditValue = curDealer.subDealersCount;
            }



            var poss =
                db.Pos.Where(x => x.dealer_ID == dealerId).Include(p => p.PosTypes).Select(x =>
                    new
                    {
                        x.ID,
                        x.dateadd,
                        x.posArea,
                        x.legalName,
                        posRating = x.PosRanks.Any(r => r.ActiveRank == true) ? x.PosRanks.Where(y => y.ActiveRank == true).Average(y => y.Rank) : 0,
                        //x.posRating,
                        x.locationDescription,
                        x.yandexAdress,
                        x.brand,
                        x.PosTypes.posTypeName,
                        x.Ruby_Id,
                        x.DealerLegalNames.LegalName,
                        posStatus = x.StatusOfPos.StatusName,
                        colorRow = x.StatusOfPos.StatusColor,
                        listPosSites=x.Sites.Select(s=>s.URL).ToList()
        }).ToList().Select(p=> new
        {
            p.ID,
            p.dateadd,
            p.posArea,
            p.legalName,
            p.posRating,
            p.locationDescription,
            p.yandexAdress,
            p.brand,
            p.posTypeName,
            p.Ruby_Id,
            p.LegalName,
            p.posStatus ,
            p.colorRow ,
            PosSites = p.listPosSites.Any() ? p.listPosSites.Aggregate((cur,next)=> cur+"\n"+next) : ""
        }        
                    );

            //listBoxSubDealers.DataSource =
            //    db.Dealers.Where(x => x.Dealer_ID == dealerId).Select(d => new {d.ID, d.dealerZovName}).ToList();
            gridControl2.DataSource = db.Contacts.Where(x => x.Dealers.Where(d => d.ID == dealerId).Any()).Select(x => new { x.ContactName, x.ContactPhones, x.ContactOtherData, x.ContactDescription }).ToList();
            gridControl1.DataSource = poss;
            gridViewPos.ExpandAllGroups();
            // точки продаж
            //treeListDealerPOSs.KeyFieldName = "ID";
            //treeListDealerPOSs.DataSource = db.sp_getPOSs(dealerId).ToList();
            //treeListDealerPOSs.OptionsView.ShowColumns = false;
            //foreach (DevExpress.XtraTreeList.Columns.TreeListColumn column in treeListDealerPOSs.Columns)
            //{
            //    switch (column.FieldName)
            //    {
            //        case "posSiteAddress":
            //            column.Visible = true;
            //            break;
            //        default:
            //            column.Visible = false;
            //            break;
            //    }
            //    column.OptionsColumn.AllowEdit = false;
            //}
            //treeListDealerPOSs.ResetBindings();
            //// суб-дилеры
            //treeListSubDealers.KeyFieldName = "ID";
            //treeListSubDealers.DataSource = db.sp_getSubDealers(dealerId).ToList();
            //treeListSubDealers.OptionsView.ShowColumns = false;
            //foreach (DevExpress.XtraTreeList.Columns.TreeListColumn column in treeListSubDealers.Columns)
            //{
            //    switch (column.FieldName)
            //    {
            //        case "dealerName":
            //            column.Visible = true;
            //            break;//        default:
            //            column.Visible = false;
            //            break;
            //    }
            //    column.OptionsColumn.AllowEdit = false;
            //}
            //treeListSubDealers.ResetBindings();
        }

        private void treeList1_AfterCheckNode(object sender, NodeEventArgs e)
        {
            Debug.WriteLine(treeDealersList.Nodes.IndexOf(treeDealersList.FocusedNode).ToString());
        }

        private void layoutControlItem4_DoubleClick(object sender, EventArgs e)
        {

        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var dict= new List<string>();
            db.Dealers.Load();
            db.DealerLegalNames.Load();
            db.PosTypes.Load();
            if (!db.PosTypes.Any(x => x.posTypeName == "не указан"))
            {
                var postType = db.PosTypes.Create();
                postType.posTypeName = "не указан";
                db.PosTypes.Add(postType);
            }
            var oExcelApp =
                (Excel.Application) System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");

            foreach (Excel.Workbook excelworkbook in oExcelApp.Workbooks)
            {
                if (!excelworkbook.Name.StartsWith("Map.New")) continue;
                foreach (Excel.Worksheet excelsheet in excelworkbook.Worksheets)
                {
                    if (excelsheet.Name.ToString() != "Объекты") continue;
                    int global_row = 2;
                    var r = excelsheet.Cells[global_row, 1] as Excel.Range;
                    var r2 = excelsheet.Cells[global_row, 3] as Excel.Range;
                    while (r != null && r.Value != null)
                    {
                        if (r2 != null && r2.Value != null)
                        {
                            var rRubyId = ((Excel.Range) excelsheet.Cells[global_row, 1]).Value2 == null
                                ? ""
                                : ((Excel.Range) excelsheet.Cells[global_row, 1]).Value2.ToString(); //Дилер
                            var rDealer = ((Excel.Range) excelsheet.Cells[global_row, 3]).Value2 == null
                                ? ""
                                : ((Excel.Range) excelsheet.Cells[global_row, 3]).Value2.ToString(); //Дилер
                            var rFabricName = ((Excel.Range) excelsheet.Cells[global_row, 4]).Value2 == null
                                ? ""
                                : ((Excel.Range) excelsheet.Cells[global_row, 4]).Value2.ToString();
                            //Название на фабрике                        
                            var rLegalName = ((Excel.Range) excelsheet.Cells[global_row, 2]).Value2 == null
                                ? ""
                                : ((Excel.Range) excelsheet.Cells[global_row, 2]).Value2.ToString();
                            //Юридическое наименование клиента
                            var rYandexAddress = ((Excel.Range) excelsheet.Cells[global_row, 5]).Value2 == null
                                ? ""
                                : ((Excel.Range) excelsheet.Cells[global_row, 5]).Value2.ToString(); //Адрес для Яндекса
                            var rCity = ((Excel.Range) excelsheet.Cells[global_row, 6]).Value2 == null
                                ? ""
                                : ((Excel.Range) excelsheet.Cells[global_row, 6]).Value2.ToString(); //Город
                            var rStreetAddress = ((Excel.Range) excelsheet.Cells[global_row, 7]).Value2 == null
                                ? ""
                                : ((Excel.Range) excelsheet.Cells[global_row, 7]).Value2.ToString();
                            //Улица и номер дома
                            var rCoordinates = ((Excel.Range) excelsheet.Cells[global_row, 8]).Value2 == null
                                ? ""
                                : ((Excel.Range) excelsheet.Cells[global_row, 8]).Value2.ToString(); //Координаты точки
                            var rPosAddress = ((Excel.Range) excelsheet.Cells[global_row, 9]).Value2 == null
                                ? ""
                                : ((Excel.Range) excelsheet.Cells[global_row, 9]).Value2.ToString(); //Адрес
                            var rPosName = ((Excel.Range) excelsheet.Cells[global_row, 10]).Value2 == null
                                ? ""
                                : ((Excel.Range) excelsheet.Cells[global_row, 10]).Value2.ToString();
                            //Название магазина
                            var rPosPhones = ((Excel.Range) excelsheet.Cells[global_row, 11]).Value2 == null
                                ? ""
                                : ((Excel.Range) excelsheet.Cells[global_row, 11]).Value2.ToString(); //Телефоны
                            var rPosArea = ((Excel.Range) excelsheet.Cells[global_row, 12]).Value2 == null
                                ? ""
                                : ((Excel.Range) excelsheet.Cells[global_row, 12]).Value2.ToString();
                            //Площадь торговой точки
                            var rPosBrend = ((Excel.Range) excelsheet.Cells[global_row, 13]).Value2 == null
                                ? ""
                                : ((Excel.Range) excelsheet.Cells[global_row, 13]).Value2.ToString(); //Бренд
                            var rPosType = ((Excel.Range) excelsheet.Cells[global_row, 14]).Value2 == null
                                ? ""
                                : ((Excel.Range) excelsheet.Cells[global_row, 14]).Value2.ToString(); //Тип салона
                            var rPosImagesPath = ((Excel.Range) excelsheet.Cells[global_row, 15]).Value2 == null
                                ? ""
                                : ((Excel.Range) excelsheet.Cells[global_row, 15]).Value2.ToString();
                            //Путь к изображениям
                            var rPosSite = ((Excel.Range) excelsheet.Cells[global_row, 16]).Value2 == null
                                ? ""
                                : ((Excel.Range) excelsheet.Cells[global_row, 16]).Value2.ToString(); //Сайт
                            var rPosMail = ((Excel.Range) excelsheet.Cells[global_row, 17]).Value2 == null
                                ? ""
                                : ((Excel.Range) excelsheet.Cells[global_row, 17]).Value2.ToString(); //Почта
                            var rPosRating = ((Excel.Range) excelsheet.Cells[global_row, 18]).Value2 == null
                                ? ""
                                : ((Excel.Range) excelsheet.Cells[global_row, 18]).Value2.ToString(); //Рейтинг
                            var rPosEnable = ((Excel.Range) excelsheet.Cells[global_row, 19]).Value2 == null
                                ? ""
                                : ((Excel.Range) excelsheet.Cells[global_row, 19]).Value2.ToString(); //Вкл/Выкл
                            var rPosSorting = ((Excel.Range) excelsheet.Cells[global_row, 20]).Value2 == null
                                ? ""
                                : ((Excel.Range) excelsheet.Cells[global_row, 20]).Value2.ToString();
                            //Порядок сортировки



                            //if (!db.Dealers.Any(x => x.dealerName == rDealer) && !dict.Contains(rDealer))
                            //{

                            //if (db.PosTypes.Any(x => x.posTypeName == rPosType) && rPosType != String.Empty)
                            //{
                            //    var postType = db.PosTypes.First(x => x.posTypeName == rPosType);
                            //}
                            //else
                            if (!db.PosTypes.Any(x => x.posTypeName == rPosType) && rPosType != String.Empty)
                            {
                                var postType = db.PosTypes.Create();
                                postType.posTypeName = rPosType;
                                db.PosTypes.Add(postType);
                            }
                            //else if (!db.PosTypes.Any(x => x.posTypeName == "не указан"))
                            //{
                            //    var postType = db.PosTypes.Create();
                            //    postType.posTypeName = "не указан";
                            //    db.PosTypes.Add(postType);
                            //}
                            //dict.Add(rDealer);




                            var dealer = db.Dealers.Any(x => x.dealerZovName == rFabricName)
                                ? db.Dealers.FirstOrDefault(x => x.dealerZovName == rFabricName)
                                : db.Dealers.Create();
                            if (dealer.dealerZovName == null)
                            {
                               
                                if (rDealer.ToUpper().Trim() != rFabricName.ToUpper().Trim())
                                {
                                    var parDealer = db.Dealers.FirstOrDefault(x => x.dealerName == rDealer);
                                    if (parDealer == null)
                                    {
                                        parDealer= db.Dealers.FirstOrDefault(x => x.dealerZovName == rDealer);
                                    }
                                    dealer.Dealer_ID = parDealer.ID;
                                }
                                dealer.dealerName = rDealer;
                                dealer.dealerZovName = rFabricName;
                                db.Dealers.Add(dealer);
                            }



                            //db.SaveChanges();

                            var legalName = db.DealerLegalNames.Any(x => x.LegalName == rLegalName)
                                ? db.DealerLegalNames.FirstOrDefault(x => x.LegalName == rLegalName)
                                : db.DealerLegalNames.Create();
                            if (legalName.Dealers == null)
                            {
                                legalName.Dealers = dealer;
                                legalName.LegalName = rLegalName;
                                //legalName.LegalAddress = rStreetAddress;
                                db.DealerLegalNames.Add(legalName);
                            }
                            int refInt = 0;
                            var rubyId = int.TryParse(rRubyId, out refInt) ? refInt : 0;
                            if (!db.Pos.Any(x => x.Ruby_Id == rubyId && rubyId > 0))
                            {


                                var pos = db.Pos.Create();
                                pos.Dealers = dealer;
                                pos.yandexAdress = rYandexAddress;
                                pos.legalName = rPosName;
                                pos.city = rCity;
                                pos.DealerLegalNames=(legalName);
                                pos.Ruby_Id = rubyId;

                                pos.locationDescription = rStreetAddress;
                                //pos.DealerLegalNames.Add(legalName);

                                pos.brand = rPosBrend;
                                pos.posStatus_ID = rPosEnable == "0" ? 3 : 4;

                                pos.street = rPosAddress;
                                pos.PosTypes = db.PosTypes.Any(x => x.posTypeName == rPosType)
                                    ? db.PosTypes.FirstOrDefault(x => x.posTypeName == rPosType)
                                    : db.PosTypes.FirstOrDefault(x => x.posTypeName == "не указан");
                                var tempInt = 0;

                                if (Int32.TryParse(rPosArea, out tempInt))
                                {
                                    pos.posArea = tempInt;
                                }

                                if (rCoordinates != "" || rCoordinates.Contains(","))
                                {
                                    pos.coordstextdata = rCoordinates.Trim();
                                    try
                                    {


                                        pos.longitude =
                                            Double.Parse(
                                                rCoordinates.Substring(0,
                                                    rCoordinates.IndexOf(",", StringComparison.InvariantCulture))
                                                    .Trim()
                                                    .Replace(".", ","));
                                        pos.attitude =
                                            Double.Parse(
                                                rCoordinates.Substring(
                                                    rCoordinates.IndexOf(",", StringComparison.InvariantCulture) + 1,
                                                    rCoordinates.Length -
                                                    rCoordinates.IndexOf(",", StringComparison.InvariantCulture) - 1)
                                                    .Trim()
                                                    .Replace(".", ","));


                                    }


                                    catch (Exception)
                                    {
                                        // ignored
                                    }
                                }

                                db.Pos.Add(pos);

                                foreach (
                                    var mail in
                                        rPosMail.Split(new string[] {","}, StringSplitOptions.RemoveEmptyEntries))
                                {
                                    if (mail.Trim() != String.Empty)
                                    {
                                        var posMail = db.PosEmails.Create();
                                        posMail.Email = mail;
                                        posMail.Pos = pos;
                                        db.PosEmails.Add(posMail);
                                    }
                                }

                                foreach (
                                    var site in
                                        rPosSite.Split(new string[] {","}, StringSplitOptions.RemoveEmptyEntries))
                                {
                                    if (site.Trim() != String.Empty)
                                    {

                                        var possite = db.Sites.Create();
                                        possite.URL = site.Trim();
                                        //possite.Pos = pos;
                                        possite.Dealers = dealer;
                                        db.Sites.Add(possite);
                                    }
                                }

                               

                                foreach (
                                    var phone in
                                        rPosPhones.Split(new string[] {","}, StringSplitOptions.RemoveEmptyEntries)
                                    )
                                {
                                    if (phone.Trim() != String.Empty)
                                    {
                                        var posPhone = db.PosPhones.Create();
                                        posPhone.PhoneNumber = phone;
                                        posPhone.Pos = pos;
                                        db.PosPhones.Add(posPhone);
                                    }
                                }
                            }

                            try
                            {
                                db.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                               Tools.showDbSaveExceptions(ex);

                            }
                            r2.Cells.Interior.Color = ColorTranslator.ToOle(Color.LightGreen);



                        }
                        r = excelsheet.Cells[global_row++, 1] as Excel.Range;
                        r2 = excelsheet.Cells[global_row, 3] as Excel.Range;
                    }




                }
            }
        }
        
        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            GetDealersTree();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!db.Pos.Where(x => x.dealer_ID == dealerId).Include(p => p.PosTypes).Any()) return;


            var dir = Path.GetDirectoryName(Application.ExecutablePath.ToString());
            using (var tradeHtml = File.Open(dir + @"\web\trade.html", FileMode.Truncate))
            {
                tradeHtml.Close();
            }
            var tradeHtmlString = @"<!DOCTYPE html>" +
                                  @"<html>" +
                                  @"<head>" +
                                  @"    <title>ЗовРеклама</title>" +
                                  @"    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />" +
                                  @"    <script src=""https://api-maps.yandex.ru/2.1/?lang=ru_RU"" type=""text/javascript""></script>" +
                                  @"    <script src=""data.js"" type=""text/javascript""></script>" +
                                  @"    <script src=""https://yandex.st/jquery/1.8.0/jquery.min.js"" type=""text/javascript""></script>"+
                                  @"    <link href=""https://yandex.st/bootstrap/2.2.2/css/bootstrap.min.css"" rel=""stylesheet"">" +
                                  @"	<style>" +
                                  @"        html, body, #map {" +
                                  @"            width: 100%; height: 100%; padding: 0; margin: 0;" +
                                  @"        }" +
                                  @"        #my-listbox {            top: auto;            left: auto;        }" +
                                  @"    </style>" +
                                  @"</head>" +
                                  @"<body>" +
                                  @"<div id=""map""></div>" +
                                  @"</body>" +
                                  @"</html>";

            using (StreamWriter outputFile = new StreamWriter(dir + @"\web\trade.html"))
            {
                outputFile.Write(tradeHtmlString);
            }




            var dataJsString = @"ymaps.ready(init);" + Environment.NewLine +
                               @"function init () {" + Environment.NewLine +
                               @"var myMap = new ymaps.Map(""map"", {" + Environment.NewLine +
                               @"center: [55.76, 37.64]," + Environment.NewLine +
                               @"zoom: 10," + Environment.NewLine +
                               @"controls: []"+Environment.NewLine +
                               @"}, {" + Environment.NewLine +
                               @"searchControlProvider: 'yandex#search'" + Environment.NewLine +
                               @"});" + Environment.NewLine +
                               // Создадим собственный макет выпадающего списка." + Environment.NewLine + 
                               @"var ListBoxLayout = ymaps.templateLayoutFactory.createClass(" + Environment.NewLine +
                               @"    ""<button id='my-listbox-header' class='btn btn-success dropdown-toggle' data-toggle='dropdown'>"" +" +
                               Environment.NewLine +
                               @"        ""{{data.title}} <span class='caret'></span>"" +" + Environment.NewLine +
                               @"    ""</button>"" +" + Environment.NewLine +
                               @"    // Этот элемент будет служить контейнером для элементов списка." +
                               Environment.NewLine +
                               @"    // В зависимости от того, свернут или развернут список, этот контейнер будет" +
                               Environment.NewLine +
                               @"    // скрываться или показываться вместе с дочерними элементами." +
                               Environment.NewLine +
                               @"    ""<ul id='my-listbox'"" +" + Environment.NewLine +
                               @"        "" class='dropdown-menu' role='menu' aria-labelledby='dropdownMenu'"" +" +
                               Environment.NewLine +
                               @"        "" style='display: {% if state.expanded %}block{% else %}none{% endif %};'></ul>"", {" +
                               Environment.NewLine +
                               @"" + Environment.NewLine +
                               @"    build: function() {" + Environment.NewLine +
                               @"        // Вызываем метод build родительского класса перед выполнением" +
                               Environment.NewLine +
                               @"        // дополнительных действий." + Environment.NewLine +
                               @"        ListBoxLayout.superclass.build.call(this);" + Environment.NewLine +
                               @"" + Environment.NewLine +
                               @"        this.childContainerElement = $('#my-listbox').get(0);" + Environment.NewLine +
                               @"        // Генерируем специальное событие, оповещающее элемент управления" +
                               Environment.NewLine +
                               @"        // о смене контейнера дочерних элементов." + Environment.NewLine +
                               @"        this.events.fire('childcontainerchange', {" + Environment.NewLine +
                               @"            newChildContainerElement: this.childContainerElement," +
                               Environment.NewLine +
                               @"            oldChildContainerElement: null" + Environment.NewLine +
                               @"        });" + Environment.NewLine +
                               @"    }," + Environment.NewLine +
                               @"" + Environment.NewLine +
                               @"    // Переопределяем интерфейсный метод, возвращающий ссылку на" + Environment.NewLine +
                               @"    // контейнер дочерних элементов." + Environment.NewLine +
                               @"    getChildContainerElement: function () {" + Environment.NewLine +
                               @"        return this.childContainerElement;" + Environment.NewLine +
                               @"    }," + Environment.NewLine +
                               @"" + Environment.NewLine +
                               @"    clear: function () {" + Environment.NewLine +
                               @"        // Заставим элемент управления перед очисткой макета" + Environment.NewLine +
                               @"        // откреплять дочерние элементы от родительского." + Environment.NewLine +
                               @"        // Это защитит нас от неожиданных ошибок," + Environment.NewLine +
                               @"        // связанных с уничтожением dom-элементов в ранних версиях ie." +
                               Environment.NewLine +
                               @"        this.events.fire('childcontainerchange', {" + Environment.NewLine +
                               @"            newChildContainerElement: null," + Environment.NewLine +
                               @"            oldChildContainerElement: this.childContainerElement" + Environment.NewLine +
                               @"        });" + Environment.NewLine +
                               @"        this.childContainerElement = null;" + Environment.NewLine +
                               @"        // Вызываем метод clear родительского класса после выполнения" +
                               Environment.NewLine +
                               @"        // дополнительных действий." + Environment.NewLine +
                               @"        ListBoxLayout.superclass.clear.call(this);" + Environment.NewLine +
                               @"    }" + Environment.NewLine +
                               @"})," + Environment.NewLine +
                               @"" + Environment.NewLine +
                               @"// Также создадим макет для отдельного элемента списка." + Environment.NewLine +
                               @"ListBoxItemLayout = ymaps.templateLayoutFactory.createClass(" + Environment.NewLine +
                               @"    ""<li><a>{{data.content}}</a></li>""" + Environment.NewLine +
                               @");" + Environment.NewLine +
                               @"listBoxItems = [" + Environment.NewLine;
            var poss =
                db.Pos.Where(x => x.dealer_ID == dealerId ).Include(p => p.PosTypes).Select(x =>
                    new { ballonInfo = x.Ruby_Id + " " + x.legalName, ballonDescription = x.yandexAdress, x.longitude,x.attitude })
                    .ToList();

            foreach (var pos in poss)
            {
                
                    dataJsString +=
                        @"    new ymaps.control.ListBoxItem({" + Environment.NewLine +
                        @"        data: {" + Environment.NewLine +
                        @"            content: '"+pos.ballonInfo+" "+pos.ballonDescription+"'," + Environment.NewLine +
                        @"            center: ["+pos.longitude.ToString().Replace(",", ".") + @", " + pos.attitude.ToString().Replace(",", ".") +"]" + Environment.NewLine +
                        @"        }" + Environment.NewLine +
                        @"    })," + Environment.NewLine;

//                                        @"            zoom: 9" + Environment.NewLine +

                
            }

            dataJsString = dataJsString.Substring(0, dataJsString.Length - 1);

            dataJsString += @"]," + Environment.NewLine +
                            @"" + Environment.NewLine +

                            @"// Теперь создадим список" + Environment.NewLine +
                            @"listBox = new ymaps.control.ListBox({" + Environment.NewLine +
                            @"        items: listBoxItems," + Environment.NewLine +
                            @"        data: {" + Environment.NewLine +
                            @"            title: 'Выберите магазин'" + Environment.NewLine +
                            @"        }," + Environment.NewLine +
                            @"        options: {" + Environment.NewLine +
                            @"            // С помощью опций можно задать как макет непосредственно для списка," +
                            Environment.NewLine +
                            @"            layout: ListBoxLayout," + Environment.NewLine +
                            @"            // так и макет для дочерних элементов списка. Для задания опций дочерних" +
                            Environment.NewLine +
                            @"            // элементов через родительский элемент необходимо добавлять префикс" +
                            Environment.NewLine +
                            @"            // 'item' к названиям опций." + Environment.NewLine +
                            @"            itemLayout: ListBoxItemLayout" + Environment.NewLine +
                            @"        }" + Environment.NewLine +
                            @"    });" + Environment.NewLine +
                            @"" + Environment.NewLine +
                            @"listBox.events.add('click', function (e) {" + Environment.NewLine +
                            @"    // Получаем ссылку на объект, по которому кликнули." + Environment.NewLine +
                            @"    // События элементов списка пропагируются" + Environment.NewLine +
                            @"    // и их можно слушать на родительском элементе." + Environment.NewLine +
                            @"    var item = e.get('target');" + Environment.NewLine +
                            @"    // Клик на заголовке выпадающего списка обрабатывать не надо." + Environment.NewLine +
                            @"    if (item != listBox) {" + Environment.NewLine +
                            @"        myMap.setCenter(" + Environment.NewLine +
                            @"            item.data.get('center')," + Environment.NewLine +
                            @"            item.data.get('zoom')" + Environment.NewLine +
                            @"        );" + Environment.NewLine +
                            @"    }" + Environment.NewLine +
                            @"});" + Environment.NewLine +
                            @"" + Environment.NewLine +
                            @"myMap.controls.add(listBox, {float: 'left'});" +
                            Environment.NewLine;

            
            dataJsString += @" myMap.panTo([" + Environment.NewLine +
                poss.First().longitude.ToString().Replace(",", ".")+
                            @"," +
                poss.First().attitude.ToString().Replace(",", ".") +
                            Environment.NewLine +
                            @"], {" + Environment.NewLine +
                            @"  delay: 1500" + Environment.NewLine +
                            @"});";
            foreach (var pos in poss)
            {
                    dataJsString += @"myMap.geoObjects.add(new ymaps.Placemark([" +
                                    pos.longitude.ToString().Replace(",", ".") + @", " + pos.attitude.ToString().Replace(",", ".") + @"], {" + Environment.NewLine +
                                    @"iconContent: '" + pos.ballonInfo + "'," + Environment.NewLine +
                                    @"hintContent: '" + pos.ballonInfo + @"'," + Environment.NewLine +
                                    @"balloonContent: '"+pos.ballonDescription +@"'" + Environment.NewLine +
                                    @"}, {" + Environment.NewLine +
                                    @"preset: 'islands#icon'," + Environment.NewLine +
                                    @"iconColor: '#0095b6'" + Environment.NewLine +
                                    @"}));" + Environment.NewLine;
            }
            dataJsString += @"}";
            using (var dataJs = File.Open(dir + @"\web\data.js", FileMode.Truncate))
            {
                dataJs.Close();
            }
            using (StreamWriter outputFile = new StreamWriter(dir + @"\web\data.js"))
            {
                outputFile.Write(dataJsString);
            }
            Process.Start(dir + @"\web\trade.html");
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridViewPos_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
        //    DoRowDoubleClick(view, pt);
            GridHitInfo info = view.CalcHitInfo(pt);
            if ((info.InRow || info.InRowCell) && (!gridViewPos.IsGroupRow(info.RowHandle)))
            {
                string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
           //     MessageBox.Show(string.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption));
                int posId = (int)gridViewPos.GetRowCellValue(info.RowHandle, "ID");
                var frmEditPos = new FrmEditPos(posId);
               
                    frmEditPos.Show();
                

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            treeList1_FocusedNodeChanged(null, null);
        }

        private void treeDealersList_LayoutUpdated(object sender, EventArgs e)
        {
        
            
        }

        private void treeDealersList_EndSorting(object sender, EventArgs e)
        {
            treeDealersList.SetFocusedNode(treeDealersList.Nodes.FirstNode);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            treeDealersList.MakeNodeVisible(treeDealersList.FocusedNode);
            //treeDealersList.SetFocusedNode(treeDealersList.FocusedNode);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            var row = treeDealersList.GetDataRecordByNode(treeDealersList.FocusedNode);
            if (row == null)
            {
                TreeListFocusedId = -1;
            }
            else
            {
                dynamic treeDealer = new { ID = 0, Dealer_ID = 0, dealerZovName = "" };
                treeDealer = row;
                var dId = treeDealer.ID;
                var dName = treeDealer.dealerZovName;
                var frmEdit = new FrmEditDealer(dId, false, dName);
                frmEdit.Show();
            }

        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frmEdit = new FrmEditDealer(0, true);
            frmEdit.Show();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frmSendReport = new Forms.FrmSendAppReport();
            frmSendReport.ShowDialog();
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frmShowReport = new Forms.FrmAppReport();
            frmShowReport.ShowDialog();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            var row = treeDealersList.GetDataRecordByNode(treeDealersList.FocusedNode);
            if (row == null)
            {
                return;
            }
            else
            {
                dynamic treeDealer = new { ID = 0, Dealer_ID = 0, dealerZovName = "" };
                treeDealer = row;
                var dId = treeDealer.ID;
                var dName = treeDealer.dealerZovName;
                var frmEdit = new FrmEditPos(0,true, dId);
                frmEdit.Show();
            }
        }
    }
}