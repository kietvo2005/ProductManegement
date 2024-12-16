﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductManegement
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

       // Hàm kiểm tra đăng nhập

        private SqlConnection ConnectToDatabase()
        {
            string connectionString = "Data Source=LAPTOP-D8SMQUCI\\VOTUANKIETBTEC;Initial Catalog=ManageProduct ;Integrated Security=True";
            return new SqlConnection(connectionString);
        }

        // Hàm kiểm tra đăng nhập
        private bool CheckLogin(string username, string password)
        {
            using (SqlConnection conn = ConnectToDatabase())
            {
                conn.Open();
                string query = "SELECT * FROM [UserName] WHERE name = @Name AND pass = @Pass";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", username);
                cmd.Parameters.AddWithValue("@Pass", password);

                SqlDataReader reader = cmd.ExecuteReader();
                return reader.HasRows;
            }
        }
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;

            if (CheckLogin(username, password))
            {
               // MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Mở form frmMain khi đăng nhập thành công
                frmMain mainForm = new frmMain();
                 mainForm.Show();

                // Ẩn form đăng nhập (LoginForm)
                this.Hide();
                //this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
    

