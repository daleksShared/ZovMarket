using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ZovTrade
{
    public partial class loginform : Form
    {
       
        public loginform()
        {
            InitializeComponent();
            cbUser.Focus();
            SqlConnectionStringBuilder sqlCStr =new SqlConnectionStringBuilder(Properties.Settings.Default.barcodeCS);
            string defUser = Properties.Settings.Default.cs_user;
            sqlCStr.UserID = "getAuthData";
            sqlCStr.Password = "zow";
            sqlCStr.IntegratedSecurity = false;

            ComboboxItem selecteditem = new ComboboxItem();
            selecteditem.Text = string.Empty;
            selecteditem.Value = string.Empty;
            using (SqlConnection con=new SqlConnection(sqlCStr.ToString()))
            using (SqlCommand cmd = new SqlCommand("sborka_getUserList", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
               
                try
                {
                con.Open();
                SqlDataReader dr=cmd.ExecuteReader();

                while (dr.Read())
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = dr[1].ToString();
                    item.Value = dr[0].ToString();
                    if (item.Value.ToString() == defUser)
                    {
                        selecteditem.Text = item.Text;
                        selecteditem.Value = item.Value;
                    }
                    cbUser.Items.Add(item);

                    
                }
                    if (selecteditem.Value.ToString() != string.Empty){
                        foreach (ComboboxItem item in cbUser.Items)
                        {
                            if (item.Value.ToString() == selecteditem.Value.ToString())
                            {
                             cbUser.SelectedIndex=cbUser.Items.IndexOf(item);
                             break;
                            }
                           
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString());
                }
            }
 

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //private void loginform_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //   // Environment.Exit(0);
        //}

      
    }
}
