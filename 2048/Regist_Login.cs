using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace _2048
{
    public partial class Regist_Login : Form
    {
        public Regist_Login()
        {
            InitializeComponent();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\IMOE001\source\repos\2048\2048\database\Database1.mdf;Integrated Security=True";
            SqlConnection conection = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conection;
            cmd.CommandText = $"SELECT COUNT (*) FROM usersData  WHERE username = '{txtUserName_login.Text}'";
            conection.Open();
            int x = (int)cmd.ExecuteScalar();
            conection.Close();
            if (x > 0)
            {
                MessageBox.Show("Login is ok:)");
                GameForm g = new GameForm();
                g.ShowDialog();
                Visible = false;

            }
            else
            {
                MessageBox.Show("Login is not ok: please try again");
            }
        }

        private void registbtn_Click(object sender, EventArgs e)
        {
            string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\IMOE001\source\repos\2048\2048\database\Database1.mdf;Integrated Security=True";
            SqlConnection conection = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conection;
            conection.Open();
            cmd.CommandText = "INSERT INTO usersData VALUES('" + txtUderName_register.Text + "', '" + textBox2.Text + "')";
            int x = cmd.ExecuteNonQuery();
            conection.Close();
            if (x > 0)
            {
                MessageBox.Show("regist ok");
            }
            else
            {
                MessageBox.Show("regist not ok");
            }
        }

        private void Regist_Login_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}