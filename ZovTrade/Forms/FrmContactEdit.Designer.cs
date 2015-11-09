namespace ZovTrade.Forms
{
    partial class FrmContactEdit
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ContactNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForContactName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForContactPhones = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForContactOtherData = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForContactDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.ContactPhonesTextEdit = new DevExpress.XtraEditors.MemoEdit();
            this.ContactDescriptionTextEdit = new DevExpress.XtraEditors.MemoEdit();
            this.ContactOtherDataTextEdit = new DevExpress.XtraEditors.MemoEdit();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.contactsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContactNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForContactName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForContactPhones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForContactOtherData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForContactDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContactPhonesTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContactDescriptionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContactOtherDataTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.simpleButton2);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.dataLayoutControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(997, 220, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(729, 414);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(729, 414);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.ContactNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.ContactPhonesTextEdit);
            this.dataLayoutControl1.Controls.Add(this.ContactDescriptionTextEdit);
            this.dataLayoutControl1.Controls.Add(this.ContactOtherDataTextEdit);
            this.dataLayoutControl1.DataSource = this.contactsBindingSource;
            this.dataLayoutControl1.Location = new System.Drawing.Point(12, 12);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(705, 348);
            this.dataLayoutControl1.TabIndex = 4;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dataLayoutControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(709, 352);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(705, 348);
            this.Root.TextVisible = false;
            // 
            // ContactNameTextEdit
            // 
            this.ContactNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.contactsBindingSource, "ContactName", true));
            this.ContactNameTextEdit.Location = new System.Drawing.Point(121, 12);
            this.ContactNameTextEdit.Name = "ContactNameTextEdit";
            this.ContactNameTextEdit.Size = new System.Drawing.Size(572, 20);
            this.ContactNameTextEdit.StyleController = this.dataLayoutControl1;
            this.ContactNameTextEdit.TabIndex = 4;
            // 
            // ItemForContactName
            // 
            this.ItemForContactName.Control = this.ContactNameTextEdit;
            this.ItemForContactName.Location = new System.Drawing.Point(0, 0);
            this.ItemForContactName.Name = "ItemForContactName";
            this.ItemForContactName.Size = new System.Drawing.Size(685, 24);
            this.ItemForContactName.Text = "Имя";
            this.ItemForContactName.TextSize = new System.Drawing.Size(105, 13);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForContactName,
            this.ItemForContactPhones,
            this.ItemForContactOtherData,
            this.ItemForContactDescription});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(685, 328);
            // 
            // ItemForContactPhones
            // 
            this.ItemForContactPhones.Control = this.ContactPhonesTextEdit;
            this.ItemForContactPhones.Location = new System.Drawing.Point(0, 24);
            this.ItemForContactPhones.Name = "ItemForContactPhones";
            this.ItemForContactPhones.Size = new System.Drawing.Size(685, 120);
            this.ItemForContactPhones.Text = "Контактные данные";
            this.ItemForContactPhones.TextSize = new System.Drawing.Size(105, 13);
            // 
            // ItemForContactOtherData
            // 
            this.ItemForContactOtherData.Control = this.ContactOtherDataTextEdit;
            this.ItemForContactOtherData.Location = new System.Drawing.Point(0, 144);
            this.ItemForContactOtherData.Name = "ItemForContactOtherData";
            this.ItemForContactOtherData.Size = new System.Drawing.Size(685, 106);
            this.ItemForContactOtherData.Text = "Доп.Инфо";
            this.ItemForContactOtherData.TextSize = new System.Drawing.Size(105, 13);
            // 
            // ItemForContactDescription
            // 
            this.ItemForContactDescription.Control = this.ContactDescriptionTextEdit;
            this.ItemForContactDescription.Location = new System.Drawing.Point(0, 250);
            this.ItemForContactDescription.Name = "ItemForContactDescription";
            this.ItemForContactDescription.Size = new System.Drawing.Size(685, 78);
            this.ItemForContactDescription.Text = "Описание";
            this.ItemForContactDescription.TextSize = new System.Drawing.Size(105, 13);
            // 
            // ContactPhonesTextEdit
            // 
            this.ContactPhonesTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.contactsBindingSource, "ContactPhones", true));
            this.ContactPhonesTextEdit.Location = new System.Drawing.Point(121, 36);
            this.ContactPhonesTextEdit.Name = "ContactPhonesTextEdit";
            this.ContactPhonesTextEdit.Size = new System.Drawing.Size(572, 116);
            this.ContactPhonesTextEdit.StyleController = this.dataLayoutControl1;
            this.ContactPhonesTextEdit.TabIndex = 5;
            // 
            // ContactDescriptionTextEdit
            // 
            this.ContactDescriptionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.contactsBindingSource, "ContactDescription", true));
            this.ContactDescriptionTextEdit.Location = new System.Drawing.Point(121, 262);
            this.ContactDescriptionTextEdit.Name = "ContactDescriptionTextEdit";
            this.ContactDescriptionTextEdit.Size = new System.Drawing.Size(572, 74);
            this.ContactDescriptionTextEdit.StyleController = this.dataLayoutControl1;
            this.ContactDescriptionTextEdit.TabIndex = 7;
            // 
            // ContactOtherDataTextEdit
            // 
            this.ContactOtherDataTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.contactsBindingSource, "ContactOtherData", true));
            this.ContactOtherDataTextEdit.Location = new System.Drawing.Point(121, 156);
            this.ContactOtherDataTextEdit.Name = "ContactOtherDataTextEdit";
            this.ContactOtherDataTextEdit.Size = new System.Drawing.Size(572, 102);
            this.ContactOtherDataTextEdit.StyleController = this.dataLayoutControl1;
            this.ContactOtherDataTextEdit.TabIndex = 6;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 352);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(485, 42);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::ZovTrade.Properties.Resources.save_32x32;
            this.simpleButton1.Location = new System.Drawing.Point(497, 364);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(103, 38);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "Сохранить";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.simpleButton1;
            this.layoutControlItem2.Location = new System.Drawing.Point(485, 352);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(107, 42);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Image = global::ZovTrade.Properties.Resources.close_32x32;
            this.simpleButton2.Location = new System.Drawing.Point(604, 364);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(113, 38);
            this.simpleButton2.StyleController = this.layoutControl1;
            this.simpleButton2.TabIndex = 6;
            this.simpleButton2.Text = "Закрыть";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.simpleButton2;
            this.layoutControlItem3.Location = new System.Drawing.Point(592, 352);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(117, 42);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // contactsBindingSource
            // 
            this.contactsBindingSource.DataSource = typeof(DbModel.Contacts);
            // 
            // FrmContactEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 414);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FrmContactEdit";
            this.Text = "FrmContactEdit";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContactNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForContactName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForContactPhones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForContactOtherData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForContactDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContactPhonesTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContactDescriptionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContactOtherDataTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.TextEdit ContactNameTextEdit;
        private System.Windows.Forms.BindingSource contactsBindingSource;
        private DevExpress.XtraEditors.MemoEdit ContactPhonesTextEdit;
        private DevExpress.XtraEditors.MemoEdit ContactDescriptionTextEdit;
        private DevExpress.XtraEditors.MemoEdit ContactOtherDataTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForContactName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForContactPhones;
        private DevExpress.XtraLayout.LayoutControlItem ItemForContactOtherData;
        private DevExpress.XtraLayout.LayoutControlItem ItemForContactDescription;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}