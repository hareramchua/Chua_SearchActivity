using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chua_SearchActivity
{
    internal class MazeSolver
    {
        private int[,] m_iMaze;
        private int m_iRows;
        private int m_iCols;
        private int iPath = 100;
        private bool diagonal = false;

        public event MazeChangedHandler OnMazeChangedEvent;

        public MazeSolver(int[,] iMaze)
        {
            this.m_iMaze = iMaze;
            this.m_iRows = iMaze.GetLength(0);
            this.m_iCols = iMaze.GetLength(1);
        }

        public MazeSolver(int iRows, int iCols)
        {
            this.m_iMaze = new int[iRows, iCols];
            this.m_iRows = iRows;
            this.m_iCols = iCols;
        }

        public int Rows => this.m_iRows;

        public int Cols => this.m_iCols;

        public int[,] GetMaze => this.m_iMaze;

        public int PathCharacter
        {
            get => this.iPath;
            set => this.iPath = value != 0 ? value : throw new Exception("Invalid path character specified");
        }

        public bool AllowDiagonals
        {
            get => this.diagonal;
            set => this.diagonal = value;
        }

        public int this[int iRow, int iCol]
        {
            get => this.m_iMaze[iRow, iCol];
            set
            {
                this.m_iMaze[iRow, iCol] = value;
                if (this.OnMazeChangedEvent == null)
                    return;
                this.OnMazeChangedEvent(iRow, iCol);
            }
        }

        private int GetNodeContents(int[,] iMaze, int iNodeNo)
        {
            int length = iMaze.GetLength(1);
            return iMaze[iNodeNo / length, iNodeNo - iNodeNo / length * length];
        }

        private void ChangeNodeContents(int[,] iMaze, int iNodeNo, int iNewValue)
        {
            int length = iMaze.GetLength(1);
            iMaze[iNodeNo / length, iNodeNo - iNodeNo / length * length] = iNewValue;
        }

        public int[,] FindPath(int iFromY, int iFromX, int iToY, int iToX) => this.Search(iFromY * this.Cols + iFromX, iToY * this.Cols + iToX);

        private int[,] Search(int iStart, int iStop)
        {
            int iRows = this.m_iRows;
            int iCols = this.m_iCols;
            int length = iRows * iCols;
            int[] numArray1 = new int[length];
            int[] numArray2 = new int[length];
            int index1 = 0;
            int index2 = 0;
            if (this.GetNodeContents(this.m_iMaze, iStart) != 0 || this.GetNodeContents(this.m_iMaze, iStop) != 0)
                return (int[,])null;
            int[,] iMaze1 = new int[iRows, iCols];
            for (int index3 = 0; index3 < iRows; ++index3)
            {
                for (int index4 = 0; index4 < iCols; ++index4)
                    iMaze1[index3, index4] = 0;
            }
            numArray1[index2] = iStart;
            numArray2[index2] = -1;
            for (int index5 = index2 + 1; index1 != index5 && numArray1[index1] != iStop; ++index1)
            {
                int iNodeNo1 = numArray1[index1];
                int iNodeNo2 = iNodeNo1 - 1;
                if (iNodeNo2 >= 0 && iNodeNo2 / iCols == iNodeNo1 / iCols && this.GetNodeContents(this.m_iMaze, iNodeNo2) == 0 && this.GetNodeContents(iMaze1, iNodeNo2) == 0)
                {
                    numArray1[index5] = iNodeNo2;
                    numArray2[index5] = iNodeNo1;
                    this.ChangeNodeContents(iMaze1, iNodeNo2, 1);
                    ++index5;
                }
                int iNodeNo3 = iNodeNo1 + 1;
                if (iNodeNo3 < length && iNodeNo3 / iCols == iNodeNo1 / iCols && this.GetNodeContents(this.m_iMaze, iNodeNo3) == 0 && this.GetNodeContents(iMaze1, iNodeNo3) == 0)
                {
                    numArray1[index5] = iNodeNo3;
                    numArray2[index5] = iNodeNo1;
                    this.ChangeNodeContents(iMaze1, iNodeNo3, 1);
                    ++index5;
                }
                int iNodeNo4 = iNodeNo1 - iCols;
                if (iNodeNo4 >= 0 && this.GetNodeContents(this.m_iMaze, iNodeNo4) == 0 && this.GetNodeContents(iMaze1, iNodeNo4) == 0)
                {
                    numArray1[index5] = iNodeNo4;
                    numArray2[index5] = iNodeNo1;
                    this.ChangeNodeContents(iMaze1, iNodeNo4, 1);
                    ++index5;
                }
                int iNodeNo5 = iNodeNo1 + iCols;
                if (iNodeNo5 < length && this.GetNodeContents(this.m_iMaze, iNodeNo5) == 0 && this.GetNodeContents(iMaze1, iNodeNo5) == 0)
                {
                    numArray1[index5] = iNodeNo5;
                    numArray2[index5] = iNodeNo1;
                    this.ChangeNodeContents(iMaze1, iNodeNo5, 1);
                    ++index5;
                }
                if (this.diagonal)
                {
                    int iNodeNo6 = iNodeNo1 + iCols + 1;
                    if (iNodeNo6 < length && iNodeNo6 >= 0 && iNodeNo6 / iCols == iNodeNo1 / iCols + 1 && this.GetNodeContents(this.m_iMaze, iNodeNo6) == 0 && this.GetNodeContents(iMaze1, iNodeNo6) == 0)
                    {
                        numArray1[index5] = iNodeNo6;
                        numArray2[index5] = iNodeNo1;
                        this.ChangeNodeContents(iMaze1, iNodeNo6, 1);
                        ++index5;
                    }
                    int iNodeNo7 = iNodeNo1 - iCols + 1;
                    if (iNodeNo7 >= 0 && iNodeNo7 < length && iNodeNo7 / iCols == iNodeNo1 / iCols - 1 && this.GetNodeContents(this.m_iMaze, iNodeNo7) == 0 && this.GetNodeContents(iMaze1, iNodeNo7) == 0)
                    {
                        numArray1[index5] = iNodeNo7;
                        numArray2[index5] = iNodeNo1;
                        this.ChangeNodeContents(iMaze1, iNodeNo7, 1);
                        ++index5;
                    }
                    int iNodeNo8 = iNodeNo1 + iCols - 1;
                    if (iNodeNo8 < length && iNodeNo8 >= 0 && iNodeNo8 / iCols == iNodeNo1 / iCols + 1 && this.GetNodeContents(this.m_iMaze, iNodeNo8) == 0 && this.GetNodeContents(iMaze1, iNodeNo8) == 0)
                    {
                        numArray1[index5] = iNodeNo8;
                        numArray2[index5] = iNodeNo1;
                        this.ChangeNodeContents(iMaze1, iNodeNo8, 1);
                        ++index5;
                    }
                    int iNodeNo9 = iNodeNo1 - iCols - 1;
                    if (iNodeNo9 >= 0 && iNodeNo9 < length && iNodeNo9 / iCols == iNodeNo1 / iCols - 1 && this.GetNodeContents(this.m_iMaze, iNodeNo9) == 0 && this.GetNodeContents(iMaze1, iNodeNo9) == 0)
                    {
                        numArray1[index5] = iNodeNo9;
                        numArray2[index5] = iNodeNo1;
                        this.ChangeNodeContents(iMaze1, iNodeNo9, 1);
                        ++index5;
                    }
                }
                this.ChangeNodeContents(iMaze1, iNodeNo1, 2);
            }
            int[,] iMaze2 = new int[iRows, iCols];
            for (int index6 = 0; index6 < iRows; ++index6)
            {
                for (int index7 = 0; index7 < iCols; ++index7)
                    iMaze2[index6, index7] = this.m_iMaze[index6, index7];
            }
            int iNodeNo = iStop;
            this.ChangeNodeContents(iMaze2, iNodeNo, this.iPath);
            for (int index8 = index1; index8 >= 0; --index8)
            {
                if (numArray1[index8] == iNodeNo)
                {
                    iNodeNo = numArray2[index8];
                    if (iNodeNo == -1)
                        return iMaze2;
                    this.ChangeNodeContents(iMaze2, iNodeNo, this.iPath);
                }
            }
            return (int[,])null;
        }

        private enum Status
        {
            Ready,
            Waiting,
            Processed,
        }
    }
}
