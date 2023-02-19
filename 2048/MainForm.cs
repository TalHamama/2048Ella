using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class MainForm : Form
    {
        Board board;
        public MainForm()
        {
            //  board= new Board();
            InitializeComponent();
        }
        private void OnLoad(object sender, EventArgs e)
        {
            //DrawBoard(board);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regist_Login f = new Regist_Login();
            f.Show();
            Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
