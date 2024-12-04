using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
        //Gamemode 0 - no game
        //Gamemode 1 - pvp
        //Gamemode 2 - pvc player 1st
        //Gamemode 3 - pvc player 2nd
        private int gameMode = 0;
        public int GameMode 
        {
            get
            {
                return gameMode;
            }
            set
            {
                gameMode = value;
            }
        }
        private int turnNumber;
        public int TurnNumber 
        {
            get
            {
                return turnNumber;
            } 
            set
            {
                turnNumber = value;
                if (turnNumber % 2 == 0)
                    CurrentTurn = 'X';
                else
                    CurrentTurn = 'O';
                OnPropertyChanged("TurnNumber");
            }
        }

        private char currentTurn;
        public char CurrentTurn 
        {
            get
            {
                return currentTurn;
            }
            set
            {
                currentTurn = value;
                OnPropertyChanged("CurrentTurn");
            }
            
        }

        private char winner;
        public char Winner 
        { 
            get
            {
                return winner;
            } 
            set
            {
                winner = value;
                WinText = $"{value} won!";
                OnPropertyChanged("Winner");
            }
        }

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

        private string winText;
        public string WinText
        {
            get
            {
                return winText;
            }
            set
            {
                winText = value;
                OnPropertyChanged("WinText");
            }
        }

        public GameState()
        {
            Board = new BoardCell[9] { new BoardCell(), new BoardCell(), new BoardCell(), new BoardCell(), new BoardCell(), new BoardCell(), new BoardCell(), new BoardCell(), new BoardCell() };
            TurnNumber = 1;
            //Winner = ' ';
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
            bool tie = true;
            foreach(var cell in Board)
            {
                if (cell.State == ' ') 
                    tie = false;
            }
            if (tie)
            {
                GameRunning = false;
                WinText = "Game tied";
                return 'T';
            }
            return ' ';
        }
    }
}
