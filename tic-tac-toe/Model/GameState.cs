using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
    internal class GameState : PropertyChangedClass
    {
        private BoardCell[] board;
        public BoardCell[] Board
        {
            get
            {
                return board;
            }
            set
            {
                board = value;
                OnPropertyChanged("Board");
            }
        }

        public int TurnNumber { get; set; }
        public char Winner { get; set; }
        private bool gameRunning;
        public bool GameRunning
        {
            get
            {
                return gameRunning;
            }
            set
            {
                gameRunning = value;
                OnPropertyChanged("GameRunning");
            }
        }
        public GameState()
        {
            Board = new BoardCell[9] { new BoardCell(), new BoardCell(), new BoardCell(), new BoardCell(), new BoardCell(), new BoardCell(), new BoardCell(), new BoardCell(), new BoardCell() };
            TurnNumber = 1;
            Winner = ' ';
            GameRunning = true;
        }
        public char WinCheck()
        {
            if ((Board[0].State != ' ') && (Board[0].State == Board[4].State) && (Board[4].State == Board[8].State))
            {
                Winner = Board[0].State;
                GameRunning = false;
                return Board[0].State;
            }

            if ((Board[2].State != ' ') && (Board[2].State == Board[4].State) && (Board[4].State == Board[6].State))
            {
                Winner = Board[2].State;
                GameRunning = false;
                return Board[2].State;
            }

            for(int i = 0; i < 3; i++)
            {
                if ((Board[i].State != ' ') && (Board[i].State == Board[i + 3].State) && (Board[i+3].State == Board[i + 6].State))
                {
                    Winner = Board[i].State;
                    GameRunning = false;
                    return Board[i].State;
                }

                if ((Board[i*3].State != ' ') && (Board[i * 3].State == Board[(i * 3) + 1].State) && (Board[(i * 3) + 1].State == Board[(i * 3) + 2].State))
                {
                    Winner = Board[i * 3].State;
                    GameRunning = false;
                    return Board[i*3].State;
                }
            }
            return ' ';
        }
    }
}
