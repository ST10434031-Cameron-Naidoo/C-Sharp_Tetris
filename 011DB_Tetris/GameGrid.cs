using System;
using System.Collections.Generic;
using System.Text;

namespace _011DB_Tetris
{
    class GameGrid
    {

        private readonly int[,] grid;
        public int rows;
        public int columns;

        // traditional getter and setter methods
        public int getRows()
        {
            return rows;
        }

        public int getColumns()
        {
            return columns;
        }

        public int getValue(int r, int c)
        {
            return grid[r, c];
        }


        //constructor for mini or maxi versions of the game
        public GameGrid(int r, int c)
        {
            rows = r;
            columns = c;
            grid = new int[rows, columns];
        }
    }
}
