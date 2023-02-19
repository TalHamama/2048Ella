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
    public partial class GameForm : Form
    {
        public Board board = new Board();
        public Button[,] button = new Button[4, 4];
        public GameForm()
        {
            InitializeComponent();
            Tile[,] mat = board.getMatrix();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    button[i, j] = new Button();
                    button[i, j].Size = new Size(80, 80);
                    button[i, j].Text = mat[i, j].getNum().ToString();
                    this.tableLayoutPanel1.Controls.Add(button[i, j], j, i);
                }
            }
        }
        public void DrawBoard(Board board)
        {
            Tile[,] mat = board.getMatrix();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    button[i, j].Text = mat[i, j].getNum().ToString();
                    button[i, j].BackColor = mat[i, j].getColor();
                    this.tableLayoutPanel1.Controls.Add(button[i, j], j, i);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            board.AddRandomNum();
            DrawBoard(board);
        }

        //private void GameForm_KeyDown(object sender, KeyEventArgs e)
        // {
        //    if (e.KeyCode == Keys.NumPad2)
        //    {
        //        board.Board_keyDown();
        //        DrawBoard(board);
        //    }

        //}

        private void GameForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }


        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad2)
            {
                board.Board_keyDown();
                DrawBoard(board);
            }
            if (e.KeyCode == Keys.NumPad8)
            {
                board.Board_keyUp();
                DrawBoard(board);
            }
            if (e.KeyCode == Keys.NumPad6)
            {
                board.Board_keyRight();
                DrawBoard(board);
            }
            if (e.KeyCode == Keys.NumPad4)
            {
                board.Board_keyLeft();
                DrawBoard(board);
            }
        }
    }
}
