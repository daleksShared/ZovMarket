namespace ZovTrade
{
    partial class loginform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginform));
            this.btnOK = new System.Windows.Forms.Button();
            this.lPW = new System.Windows.Forms.Label();
            this.lUser = new System.Windows.Forms.Label();
            this.tbPW = new System.Windows.Forms.TextBox();
            this.cbUser = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(80, 61);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lPW
            // 
            this.lPW.Location = new System.Drawing.Point(12, 35);
            this.lPW.Name = "lPW";
            this.lPW.Size = new System.Drawing.Size(100, 23);
            this.lPW.TabIndex = 7;
            this.lPW.Text = "Пароль";
            // 
            // lUser
            // 
            this.lUser.Location = new System.Drawing.Point(12, 9);
            this.lUser.Name = "lUser";
            this.lUser.Size = new System.Drawing.Size(100, 23);
            this.lUser.TabIndex = 6;
            this.lUser.Text = "Пользователь";
            // 
            // tbPW
            // 
            this.tbPW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPW.Location = new System.Drawing.Point(102, 35);
            this.tbPW.MaxLength = 20;
            this.tbPW.Name = "tbPW";
            this.tbPW.PasswordChar = '*';
            this.tbPW.Size = new System.Drawing.Size(121, 20);
            this.tbPW.TabIndex = 8;
            // 
            // cbUser
            // 
            this.cbUser.FormattingEnabled = true;
            this.cbUser.Location = new System.Drawing.Point(102, 8);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(121, 21);
            this.cbUser.TabIndex = 12;
            // 
            // loginform
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 88);
            this.Controls.Add(this.cbUser);
            this.Controls.Add(this.tbPW);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lPW);
            this.Controls.Add(this.lUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "loginform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выполните вход";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox tbPW;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Label lPW;
        internal System.Windows.Forms.Label lUser;
        internal System.Windows.Forms.ComboBox cbUser;
    }
}