using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chua_SearchActivity
{
    public partial class MainForm : Form
    {
        private MazeSolver m_Maze;
        private int[,] m_iMaze;
        private int m_iSize = 20;
        private int m_iRowDimensions = 16;
        private int m_iColDimensions = 20;
        private int iSelectedX;
        private int iSelectedY;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.m_Maze = new MazeSolver(this.m_iRowDimensions, this.m_iColDimensions);
            this.pictureBox1.Size = new Size(this.m_iColDimensions * this.m_iSize + 3, this.m_iRowDimensions * this.m_iSize + 3);
            this.m_iMaze = this.m_Maze.GetMaze;
            this.lblPath.Visible = false;
            this.lblPathCaption.Visible = false;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            for (int index1 = 0; index1 < this.m_iRowDimensions; ++index1)
            {
                for (int index2 = 0; index2 < this.m_iColDimensions; ++index2)
                {
                    graphics.DrawRectangle(new Pen(Color.Black), index2 * this.m_iSize, index1 * this.m_iSize, this.m_iSize, this.m_iSize);
                    if (this.m_iMaze[index1, index2] == 1)
                        graphics.FillRectangle((Brush)new SolidBrush(Color.LightSeaGreen), index2 * this.m_iSize + 1, index1 * this.m_iSize + 1, this.m_iSize - 1, this.m_iSize - 1);
                    if (this.m_iMaze[index1, index2] == 100)
                        graphics.FillRectangle((Brush)new SolidBrush(Color.Black), index2 * this.m_iSize + 1, index1 * this.m_iSize + 1, this.m_iSize - 1, this.m_iSize - 1);
                }
            }
            graphics.FillEllipse((Brush)new SolidBrush(Color.White), this.iSelectedX * this.m_iSize + 5, this.iSelectedY * this.m_iSize + 5, this.m_iSize - 10, this.m_iSize - 10);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int index1 = e.X / this.m_iSize;
            int index2 = e.Y / this.m_iSize;
            if (index1 >= this.m_iColDimensions || index1 < 0 || index2 >= this.m_iRowDimensions || index2 < 0)
                return;
            if (this.bDraw.Checked)
            {
                this.m_iMaze = this.m_Maze.GetMaze;
                this.m_iMaze[index2, index1] = this.m_iMaze[index2, index1] != 0 ? 0 : 1;
                this.Refresh();
            }
            else if (this.m_iMaze[index2, index1] == 100)
            {
                while (this.iSelectedX != index1 || this.iSelectedY != index2)
                {
                    this.m_iMaze[this.iSelectedY, this.iSelectedX] = 0;
                    if (this.iSelectedX - 1 >= 0 && this.iSelectedX - 1 < this.m_iColDimensions && this.m_iMaze[this.iSelectedY, this.iSelectedX - 1] == 100)
                        --this.iSelectedX;
                    else if (this.iSelectedX + 1 >= 0 && this.iSelectedX + 1 < this.m_iColDimensions && this.m_iMaze[this.iSelectedY, this.iSelectedX + 1] == 100)
                        ++this.iSelectedX;
                    else if (this.iSelectedY - 1 >= 0 && this.iSelectedY - 1 < this.m_iRowDimensions && this.m_iMaze[this.iSelectedY - 1, this.iSelectedX] == 100)
                        --this.iSelectedY;
                    else if (this.iSelectedY + 1 >= 0 && this.iSelectedY + 1 < this.m_iRowDimensions && this.m_iMaze[this.iSelectedY + 1, this.iSelectedX] == 100)
                        ++this.iSelectedY;
                    else if (this.iSelectedY + 1 >= 0 && this.iSelectedY + 1 < this.m_iRowDimensions && this.iSelectedX + 1 >= 0 && this.iSelectedX + 1 < this.m_iColDimensions && this.m_iMaze[this.iSelectedY + 1, this.iSelectedX + 1] == 100)
                    {
                        ++this.iSelectedX;
                        ++this.iSelectedY;
                    }
                    else if (this.iSelectedY - 1 >= 0 && this.iSelectedY - 1 < this.m_iRowDimensions && this.iSelectedX + 1 >= 0 && this.iSelectedX + 1 < this.m_iColDimensions && this.m_iMaze[this.iSelectedY - 1, this.iSelectedX + 1] == 100)
                    {
                        ++this.iSelectedX;
                        --this.iSelectedY;
                    }
                    else if (this.iSelectedY + 1 >= 0 && this.iSelectedY + 1 < this.m_iRowDimensions && this.iSelectedX - 1 >= 0 && this.iSelectedX - 1 < this.m_iColDimensions && this.m_iMaze[this.iSelectedY + 1, this.iSelectedX - 1] == 100)
                    {
                        --this.iSelectedX;
                        ++this.iSelectedY;
                    }
                    else if (this.iSelectedY - 1 >= 0 && this.iSelectedY - 1 < this.m_iRowDimensions && this.iSelectedX - 1 >= 0 && this.iSelectedX - 1 < this.m_iColDimensions && this.m_iMaze[this.iSelectedY - 1, this.iSelectedX - 1] == 100)
                    {
                        --this.iSelectedX;
                        --this.iSelectedY;
                    }
                    this.Refresh();
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int iToY = e.Y / this.m_iSize;
            int iToX = e.X / this.m_iSize;
            if (iToX >= this.m_iColDimensions || iToX < 0 || iToY >= this.m_iRowDimensions || iToY < 0)
                return;
            this.m_iMaze = this.m_Maze.GetMaze;
            if (!this.bDraw.Checked)
            {
                int[,] path = this.m_Maze.FindPath(this.iSelectedY, this.iSelectedX, iToY, iToX);
                if (path != null)
                {
                    this.m_iMaze = path;
                    this.lblPath.Text = "" + (object)this.iSelectedY + "," + (object)this.iSelectedX + " to " + (object)iToY + "," + (object)iToX;
                }
                else
                    this.lblPath.Text = "No Path Found";
                this.Refresh();
            }
        }

        private void bDraw_CheckedChanged(object sender, EventArgs e)
        {
            this.m_iMaze = this.m_Maze.GetMaze;
            this.lblPath.Visible = false;
            this.lblPathCaption.Visible = false;
            this.Refresh();
        }

        private void bFind_CheckedChanged(object sender, EventArgs e)
        {
            this.lblPath.Visible = true;
            this.lblPathCaption.Visible = true;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            this.m_Maze = new MazeSolver(this.m_iRowDimensions, this.m_iColDimensions);
            this.m_iMaze = this.m_Maze.GetMaze;
            this.Refresh();
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            int num = (int)MessageBox.Show("Maze Solver Demo v.ChuaH");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
