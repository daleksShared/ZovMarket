namespace ZOV.Tools
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.panelControlLeft = new DevExpress.XtraEditors.PanelControl();
            this.pictureEdit = new DevExpress.XtraEditors.PictureEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.comboBoxUsers = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panelControlButtons = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControlUserName = new DevExpress.XtraEditors.LabelControl();
            this.textEditPwd = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlLeft)).BeginInit();
            this.panelControlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxUsers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlButtons)).BeginInit();
            this.panelControlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPwd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControlLeft
            // 
            this.panelControlLeft.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControlLeft.Controls.Add(this.pictureEdit);
            this.panelControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControlLeft.Location = new System.Drawing.Point(0, 0);
            this.panelControlLeft.Name = "panelControlLeft";
            this.panelControlLeft.Size = new System.Drawing.Size(97, 103);
            this.panelControlLeft.TabIndex = 2;
            // 
            // pictureEdit
            // 
            this.pictureEdit.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.False;
            this.pictureEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEdit.EditValue = ((object)(resources.GetObject("pictureEdit.EditValue")));
            this.pictureEdit.Location = new System.Drawing.Point(0, 0);
            this.pictureEdit.Margin = new System.Windows.Forms.Padding(2);
            this.pictureEdit.Name = "pictureEdit";
            this.pictureEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit.Properties.ReadOnly = true;
            this.pictureEdit.Properties.ShowMenu = false;
            this.pictureEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit.Size = new System.Drawing.Size(97, 103);
            this.pictureEdit.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.comboBoxUsers);
            this.panelControl1.Controls.Add(this.panelControlButtons);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControlUserName);
            this.panelControl1.Controls.Add(this.textEditPwd);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(97, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(299, 103);
            this.panelControl1.TabIndex = 3;
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.Location = new System.Drawing.Point(102, 12);
            this.comboBoxUsers.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxUsers.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxUsers.Size = new System.Drawing.Size(186, 20);
            this.comboBoxUsers.TabIndex = 11;
            // 
            // panelControlButtons
            // 
            this.panelControlButtons.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControlButtons.Controls.Add(this.btnCancel);
            this.panelControlButtons.Controls.Add(this.btnLogin);
            this.panelControlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControlButtons.Location = new System.Drawing.Point(2, 64);
            this.panelControlButtons.Name = "panelControlButtons";
            this.panelControlButtons.Size = new System.Drawing.Size(295, 37);
            this.panelControlButtons.TabIndex = 10;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(19, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(141, 6);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Вход";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(59, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(37, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Пароль";
            // 
            // labelControlUserName
            // 
            this.labelControlUserName.Location = new System.Drawing.Point(24, 15);
            this.labelControlUserName.Name = "labelControlUserName";
            this.labelControlUserName.Size = new System.Drawing.Size(72, 13);
            this.labelControlUserName.TabIndex = 9;
            this.labelControlUserName.Text = "Пользователь";
            // 
            // textEditPwd
            // 
            this.textEditPwd.EditValue = "";
            this.textEditPwd.Location = new System.Drawing.Point(102, 38);
            this.textEditPwd.Name = "textEditPwd";
            this.textEditPwd.Properties.PasswordChar = '*';
            this.textEditPwd.Size = new System.Drawing.Size(186, 20);
            this.textEditPwd.TabIndex = 6;
            this.textEditPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textEditPwd_KeyDown);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(396, 103);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControlLeft);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLogin_FormClosing);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlLeft)).EndInit();
            this.panelControlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxUsers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlButtons)).EndInit();
            this.panelControlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditPwd.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControlLeft;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControlUserName;
        private DevExpress.XtraEditors.TextEdit textEditPwd;
        private DevExpress.XtraEditors.PanelControl panelControlButtons;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.PictureEdit pictureEdit;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxUsers;

    }
}