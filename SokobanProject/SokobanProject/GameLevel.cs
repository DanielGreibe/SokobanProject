using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanLocal
{
    class GameLevel
    {
        BoardField[,] board;
        public int xPos { get; private set; }
        public int yPos { get; private set; }
        public int LevelNumber { get; private set; }

        public GameLevel(int RowNumber, int ColumnNumber, BoardField[,] board, int LevelNumber)
        {
            this.board = board;
            this.xPos = RowNumber;
            this.yPos = ColumnNumber;
            this.LevelNumber = LevelNumber;
            SetInitialState();
        }

        public GameLevel(int LevelNumber)
        {
            this.LevelNumber = LevelNumber;
            SetInitialState();
        }

        private void SetInitialState()
        {
            board = new BoardField[15, 15];
            for (int i = board.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j <= board.GetLength(1) - 1; j++)
                {
                    board[j, i] = new RegularField();  
                }
            }
            board[7, 6].PlayerIsHere = true;
            board[5, 6].IsWallField = true;
            board[5, 7].IsWallField = true;
            board[6, 6].BoxIsHere = true;
            board[10, 6].BoxIsHere = true;
            board[7, 7].IsWallField = true;
            board[2, 0].IsGoalField = true;
            board[3, 0].IsWallField = true;
            for (int i = board.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j <= board.GetLength(1) - 1; j++)
                {
                    if(board[j, i].PlayerIsHere)
                    {
                        xPos = j;
                        yPos = i;
                    }
                }
            }
        }

        public void PrintBoard()
        {
            for (int i = board.GetLength(0)-1; i >= 0; i--)
            {
                Console.WriteLine();
                for (int j = 0; j <= board.GetLength(1)-1; j++)
                {
                    Console.Write(board[j, i]);
                }
            }
            Console.WriteLine();
        }

        public void Move(int direction)
        {
            //Going up
            if (direction == 0)
            {
                if (yPos == board.GetLength(0) - 2)
                {
                    if (!board[xPos, yPos + 1].BoxIsHere && !board[xPos, yPos + 1].IsWallField)
                    {
                        board[xPos, yPos + 1].PlayerIsHere = true;
                        board[xPos, yPos].PlayerIsHere = false;
                        yPos++;
                    }
                }
                else if(yPos < board.GetLength(0)-2)
                {
                    if (board[xPos, yPos + 1].BoxIsHere && board[xPos, yPos + 2].BoxIsHere == false && !board[xPos, yPos + 2].IsWallField && board[xPos, yPos + 1].IsWallField == false)
                    {
                        board[xPos, yPos + 2].BoxIsHere = true;
                        board[xPos, yPos + 1].PlayerIsHere = true;
                        board[xPos, yPos + 1].BoxIsHere = false;
                        board[xPos, yPos].PlayerIsHere = false;
                        yPos++;
                    }
                    else if (!(board[xPos, yPos + 1].BoxIsHere == true && (board[xPos, yPos + 2].IsWallField == true || board[xPos, yPos + 2].BoxIsHere == true)) && board[xPos, yPos + 1].IsWallField == false )
                    {
                        board[xPos, yPos].PlayerIsHere = false;
                        board[xPos, yPos + 1].PlayerIsHere = true;
                        yPos++;
                    }
                }
            }
            //Going down
            if (direction == 2)
            {
                if (yPos == 1)
                {
                    if (!board[xPos, yPos - 1].BoxIsHere && !board[xPos, yPos - 1].IsWallField)
                    {
                        board[xPos, yPos - 1].PlayerIsHere = true;
                        board[xPos, yPos].PlayerIsHere = false;
                        yPos--;
                    }
                }
                else if (yPos > 1)
                {
                    if (board[xPos, yPos - 1].BoxIsHere && (board[xPos, yPos - 2].BoxIsHere == false && !board[xPos, yPos - 2].IsWallField))
                    {
                        board[xPos, yPos - 2].BoxIsHere = true;
                        board[xPos, yPos - 1].PlayerIsHere = true;
                        board[xPos, yPos - 1].BoxIsHere = false;
                        board[xPos, yPos].PlayerIsHere = false;
                        yPos--;
                    }
                    else if (!(board[xPos, yPos - 1].BoxIsHere == true && (board[xPos, yPos - 2].IsWallField == true || board[xPos, yPos - 2].BoxIsHere == true)) && board[xPos, yPos - 1].IsWallField == false)
                    {
                        board[xPos, yPos].PlayerIsHere = false;
                        board[xPos, yPos - 1].PlayerIsHere = true;
                        yPos--;
                    }
                }
            }

            //Going left
            if (direction == 1)
            {
                if (xPos == 1)
                {
                    if (!board[xPos - 1, yPos].BoxIsHere && !board[xPos - 1, yPos].IsWallField)
                    {
                        board[xPos - 1, yPos].PlayerIsHere = true;
                        board[xPos, yPos].PlayerIsHere = false;
                        xPos--;
                    }
                }
                else if (xPos > 1)
                {
                    if (board[xPos - 1, yPos].BoxIsHere && (board[xPos - 2, yPos].BoxIsHere == false && !board[xPos - 2, yPos].IsWallField))
                    {
                        board[xPos - 2, yPos].BoxIsHere = true;
                        board[xPos - 1, yPos].PlayerIsHere = true;
                        board[xPos - 1, yPos].BoxIsHere = false;
                        board[xPos, yPos].PlayerIsHere = false;
                        xPos--;
                    }
                    else if (!(board[xPos - 1, yPos].BoxIsHere == true && (board[xPos - 2, yPos].IsWallField == true || board[xPos - 2, yPos].BoxIsHere == true)) && board[xPos - 1, yPos].IsWallField == false)
                    {
                        board[xPos, yPos].PlayerIsHere = false;
                        board[xPos - 1, yPos].PlayerIsHere = true;
                        xPos--;
                    }
                }
            }
            //Going right
            if (direction == 3)
            {
                if (xPos == board.GetLength(1)-2)
                {
                    if (!board[xPos + 1, yPos].BoxIsHere && !board[xPos + 1, yPos].IsWallField)
                    {
                        board[xPos + 1, yPos].PlayerIsHere = true;
                        board[xPos, yPos].PlayerIsHere = false;
                        xPos++;
                    }
                }
                else if (xPos < board.GetLength(1) - 2)
                {
                    if (board[xPos + 1, yPos].BoxIsHere && (board[xPos + 2, yPos].BoxIsHere == false && !board[xPos + 2, yPos].IsWallField))
                    {
                        board[xPos + 2, yPos].BoxIsHere = true;
                        board[xPos + 1, yPos].PlayerIsHere = true;
                        board[xPos + 1, yPos].BoxIsHere = false;
                        board[xPos, yPos].PlayerIsHere = false;
                        xPos++;
                    }
                    else if (!(board[xPos + 1, yPos].BoxIsHere == true && (board[xPos + 2, yPos].IsWallField == true || board[xPos + 2, yPos].BoxIsHere == true)) && board[xPos + 1, yPos].IsWallField == false)
                    {
                        board[xPos, yPos].PlayerIsHere = false;
                        board[xPos + 1, yPos].PlayerIsHere = true;
                        xPos++;
                    }
                }
            }
        }
        public Boolean IsGameWon()
        {
            for (int i = board.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j <= board.GetLength(1) - 1; j++)
                {
                    if (board[j, i].IsGoalField)
                    {
                        if (!board[j, i].BoxIsHere)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
