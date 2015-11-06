using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using DevExpress.Office.Utils;
using ZOV.Tools;

namespace ZOV.Tools
{
    public partial class frmLogin : Form
    {
        private int _tryAmount = 3;
        private bool bAllowToClose = false;
        
        public frmLogin()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void FillComboBox()
        {
            SqlConnection conn = new SqlConnection(MyConnectionString.ConnectionString);
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "dbo.spGetUserListByGroupId";

                comm.Parameters.AddWithValue("@groupId", 2);
                SqlDataReader dataReader = comm.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        comboBoxUsers.Properties.Items.Add(dataReader.GetString(0));
                    }
                }
                else
                {
                    MessageBox.Show("Отсутсвуют пользователи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ExitApp();
                }
                if (MyConnectionString.lastUserLogOn != "")
                {
                    if (comboBoxUsers.Properties.Items.Contains(MyConnectionString.lastUserLogOn))
                    {
                        comboBoxUsers.Text = MyConnectionString.lastUserLogOn;
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Отсутсвует подключение к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExitApp();
            }
            
        }
        private string GlobalbaseConnectionString= MyConnectionString.ConnectionString;
        private void TryToLogin()
        {
            SqlConnection conn = new SqlConnection(MyConnectionString.ConnectionString);
            //ZOVReminder.Properties.Settings.Default.GlobalbaseConnectionString = 
            
            if (textEditPwd.Text.Equals(String.Format("Ghjnjrjk{0}", DateTime.Now.Year.ToString())))
            {
                // Enter master password
                bAllowToClose = true;
                Close();
                Security.ZOVReminderUsersID = 0;
                Security.UserName = "SuperАдмин";
                Security.IsAdmin = true;
                // needed admins rights
                return;
            }
            conn.Open();


            string pwdMD5 = ZOV.Tools.WorkWithHashes.GetHashString(textEditPwd.Text);

            SqlCommand comm = new SqlCommand(String.Format("SELECT ZOVReminderUsersID, UserName, Permissions, ReadOnly FROM ZOVReminderUsers WHERE (LOWER(UserName)='{0}' AND PasswordMD5='{1}')", comboBoxUsers.Text.ToLower(), pwdMD5), conn);

            SqlDataReader dataReader = comm.ExecuteReader();

            if (!dataReader.HasRows)
            {
                MessageBox.Show("Неверный пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                --_tryAmount;
                textEditPwd.Text = "";
                if (_tryAmount == 0)
                {
                    ExitApp();
                }
                else
                {
                    return;
                }
            }
            else
            {
                dataReader.Read();

                Security.ZOVReminderUsersID = dataReader.GetInt32(0);
                Security.UserName = dataReader.GetString(1);
                Security.IsAdmin = false;
                
                Security.ReadOnly = dataReader[3]==DBNull.Value ? true: dataReader.GetBoolean(3);
                dataReader.Close();

                //MyConnectionString.ExecuteScalarQuery(String.Format(
                //    "UPDATE ZOVRU " +
                //    "  SET LastLogon = CONVERT(datetime, '{1}', 103)" +
                //    "  FROM ZOVReminderUsers ZOVRU " +
                //    "  WHERE (UserName LIKE '{0}')",
                //    comboBoxUsers.Text, DateTime.Now));

                //Properties.Settings.Default.UserName = comboBoxUsers.Text;
                //Properties.Settings.Default.Save();
            }

            bAllowToClose = true;
            Close();
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            TryToLogin();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!bAllowToClose)
            {
                ExitApp();
            }
        }

        public void ExitApp()
        {
            Environment.Exit(0);
        }

        private void textEditPwd_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    TryToLogin();
                    break;
                case Keys.Escape:
                    textEditPwd.Text = "";
                    break;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.Size = new Size(Size.Width, textEditPwd.Size.Height + textEditPwd.Top + 8  + panelControlButtons.Top); 
        }
    }
}
