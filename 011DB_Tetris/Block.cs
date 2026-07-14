using System;
using System.Collections.Generic;
using System.Text;

namespace _011DB_Tetris
{
    public abstract class Block
    {
        //2D array that contains tile positions and rotation states
        protected abstract Position[][] tiles { get; }
        //decides where block spawns in the grid
        protected abstract Position startOffset { get; }

        //int ID to distinguish blocks
        public abstract int ID { get; }

        //current rotation state and offset
        private int rotationState;
        private Position offset;


        //offset is set to start offset
        public Block()
        {
            offset = new Position(startOffset.row, startOffset.column);
        }

        //returns the grid positions occupied by the block, factoring rotationState and offset
        public IEnumerable<Position> tilePositions()
        {
            //loops through each tile position in the current rotation state
            foreach (Position p in tiles[rotationState])
            {
                //adds row and col offset and returns
                yield return new Position(p.row + offset.row, p.column + offset.column);
            }
        }

        //rotates the block 90 degrees clockwise
        public void rotateCW()
        {
            rotationState = (rotationState + 1) % tiles.Length;
        }

        //rotates the block 90 degrees-counter clockwise
        public void rotateCCW()
        {
            if (rotationState == 0)
            {
                rotationState = tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }
        // method to move by altering offset values
        public void Move(int r, int c)
        {
            offset.row += r;
            offset.column += c;

        }

        //method to reset
        public void Reset()
        {
            rotationState = 0;
            offset.row = startOffset.row;
            offset.column = startOffset.column;

        }
    }
}