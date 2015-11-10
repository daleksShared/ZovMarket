namespace ZovTrade.Forms
{
    partial class FrmPosReviewNew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPosReviewNew));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.posRanksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ItemForRank = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.DescriptionMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.ActiveRankCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.ItemForActiveRank = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.RankTextEdit = new DevExpress.XtraEditors.RatingControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posRanksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActiveRankCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForActiveRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RankTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.dataLayoutControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(624, 397, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(792, 573);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(792, 573);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.DescriptionMemoEdit);
            this.dataLayoutControl1.Controls.Add(this.ActiveRankCheckEdit);
            this.dataLayoutControl1.Controls.Add(this.lookUpEdit1);
            this.dataLayoutControl1.Controls.Add(this.RankTextEdit);
            this.dataLayoutControl1.DataSource = this.posRanksBindingSource;
            this.dataLayoutControl1.Location = new System.Drawing.Point(12, 12);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(612, 359, 250, 350);
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(768, 507);
            this.dataLayoutControl1.TabIndex = 5;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dataLayoutControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(772, 511);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(768, 507);
            this.Root.TextVisible = false;
            // 
            // posRanksBindingSource
            // 
            this.posRanksBindingSource.DataSource = typeof(DbModel.PosRanks);
            // 
            // ItemForRank
            // 
            this.ItemForRank.Control = this.RankTextEdit;
            this.ItemForRank.Location = new System.Drawing.Point(178, 23);
            this.ItemForRank.Name = "ItemForRank";
            this.ItemForRank.Size = new System.Drawing.Size(99, 43);
            this.ItemForRank.Text = "Рейтинг";
            this.ItemForRank.TextSize = new System.Drawing.Size(41, 13);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForDescription,
            this.ItemForActiveRank,
            this.layoutControlGroup3,
            this.ItemForRank,
            this.emptySpaceItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(748, 487);
            // 
            // DescriptionMemoEdit
            // 
            this.DescriptionMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.posRanksBindingSource, "Description", true));
            this.DescriptionMemoEdit.Location = new System.Drawing.Point(12, 94);
            this.DescriptionMemoEdit.Name = "DescriptionMemoEdit";
            this.DescriptionMemoEdit.Size = new System.Drawing.Size(744, 401);
            this.DescriptionMemoEdit.StyleController = this.dataLayoutControl1;
            this.DescriptionMemoEdit.TabIndex = 5;
            // 
            // ItemForDescription
            // 
            this.ItemForDescription.Control = this.DescriptionMemoEdit;
            this.ItemForDescription.Location = new System.Drawing.Point(0, 66);
            this.ItemForDescription.Name = "ItemForDescription";
            this.ItemForDescription.Size = new System.Drawing.Size(748, 421);
            this.ItemForDescription.StartNewLine = true;
            this.ItemForDescription.Text = "Отзыв";
            this.ItemForDescription.TextLocation = DevExpress.Utils.Locations.Top;
            this.ItemForDescription.TextSize = new System.Drawing.Size(41, 13);
            // 
            // ActiveRankCheckEdit
            // 
            this.ActiveRankCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.posRanksBindingSource, "ActiveRank", true));
            this.ActiveRankCheckEdit.Location = new System.Drawing.Point(235, 12);
            this.ActiveRankCheckEdit.Name = "ActiveRankCheckEdit";
            this.ActiveRankCheckEdit.Properties.Caption = "Active Rank";
            this.ActiveRankCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ActiveRankCheckEdit.Size = new System.Drawing.Size(50, 19);
            this.ActiveRankCheckEdit.StyleController = this.dataLayoutControl1;
            this.ActiveRankCheckEdit.TabIndex = 6;
            // 
            // ItemForActiveRank
            // 
            this.ItemForActiveRank.Control = this.ActiveRankCheckEdit;
            this.ItemForActiveRank.Location = new System.Drawing.Point(178, 0);
            this.ItemForActiveRank.Name = "ItemForActiveRank";
            this.ItemForActiveRank.Size = new System.Drawing.Size(99, 23);
            this.ItemForActiveRank.Text = "Статус";
            this.ItemForActiveRank.TextLocation = DevExpress.Utils.Locations.Left;
            this.ItemForActiveRank.TextSize = new System.Drawing.Size(41, 13);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "innerAutoGeneratedGroup1";
            this.layoutControlGroup3.Size = new System.Drawing.Size(178, 66);
            this.layoutControlGroup3.Text = "Магазин";
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.posRanksBindingSource, "Pos_ID", true));
            this.lookUpEdit1.Location = new System.Drawing.Point(40, 42);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Appearance.Options.UseTextOptions = true;
            this.lookUpEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("dealerZovName", 40, "Дилер"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("legalName", 40, "Магазин"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("yandexAdress", 80, "Адрес")});
            this.lookUpEdit1.Properties.NullText = "";
            this.lookUpEdit1.Size = new System.Drawing.Size(134, 20);
            this.lookUpEdit1.StyleController = this.dataLayoutControl1;
            this.lookUpEdit1.TabIndex = 7;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lookUpEdit1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "ItemForPos.ID";
            this.layoutControlItem3.Size = new System.Drawing.Size(154, 24);
            this.layoutControlItem3.Text = "ID";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(11, 13);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // RankTextEdit
            // 
            this.RankTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.posRanksBindingSource, "Rank", true));
            this.RankTextEdit.Location = new System.Drawing.Point(235, 35);
            this.RankTextEdit.Name = "RankTextEdit";
            this.RankTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.RankTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.RankTextEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.RankTextEdit.Properties.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.RankTextEdit.Rating = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.RankTextEdit.Size = new System.Drawing.Size(89, 18);
            this.RankTextEdit.StyleController = this.dataLayoutControl1;
            this.RankTextEdit.TabIndex = 4;
            this.RankTextEdit.Text = "ratingControl1";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::ZovTrade.Properties.Resources.add_32x32;
            this.simpleButton1.Location = new System.Drawing.Point(624, 523);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(156, 38);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "Сохранить и закрыть";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.simpleButton1;
            this.layoutControlItem1.Location = new System.Drawing.Point(612, 511);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(160, 42);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 511);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(612, 42);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(277, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(471, 66);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // FrmPosReviewNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPosReviewNew";
            this.Text = "Новый отзыв";
            this.Load += new System.EventHandler(this.FrmPosReviewNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posRanksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActiveRankCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForActiveRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RankTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.MemoEdit DescriptionMemoEdit;
        private System.Windows.Forms.BindingSource posRanksBindingSource;
        private DevExpress.XtraEditors.CheckEdit ActiveRankCheckEdit;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraEditors.RatingControl RankTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDescription;
        private DevExpress.XtraLayout.LayoutControlItem ItemForActiveRank;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem ItemForRank;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}