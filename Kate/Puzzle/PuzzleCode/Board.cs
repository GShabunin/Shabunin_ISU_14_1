using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8Puzzle
{
    class Board
    {

        int[,] blocks;
        int N;
        public Board(int N)
        {
            blocks = new int[N, N];
            int c = 1;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    blocks[i, j] = c++;
                    if (c > blocks.Length - 1) c = 0;
                }
            }

            this.N = N;
        }

        public int[,] getBoard()
        {
            return blocks;
        }

        public void setBoard(int[,] inp)
        {
            blocks = inp;
        }

        public int getBlock(int i, int j)
        {
            return blocks[i, j];
        }

        public void setBlock(int val, int i, int j)
        {
            blocks[i, j] = val;
        }

        public int getDimension()
        {
            return this.N;
        }

        public int[] stringBoard()
        {
            int[] strung = new int[N*N];
            int n = 0;
            foreach (var elem in blocks)
            {
                strung[n] = elem;
                n++;
            }

            return strung;
        }
    }
}
