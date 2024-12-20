﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace tic_tac_toe
{
    internal class TTTVM : PropertyChangedClass
    {
        public GameState GS { get; set; }

        private RelayCommand placeComm;
        public RelayCommand PlaceComm
        {
            get
            {
                return placeComm ?? (placeComm = new RelayCommand(obj =>
                {
                    int i = Convert.ToInt32(obj);
                    if (GS.Board[i].State == ' ')
                    {
                        GS.Board[i].State = GS.CurrentTurn;
                        GS.WinCheck();
                        if (GS.GameRunning)
                            GS.TurnNumber++;
                    }
                }));
            }
        }

        private RelayCommand resetComm;
        public RelayCommand ResetComm
        {
            get
            {
                return resetComm ?? (resetComm = new RelayCommand(obj =>
                {
                    GS = new GameState(GS.GameMode);
                    OnPropertyChanged("GS");
                }));
            }
        }

        private RelayCommand changeGameModeComm;
        public RelayCommand ChangeGameModeComm
        {
            get
            {
                return changeGameModeComm ?? (changeGameModeComm = new RelayCommand(obj =>
                {
                    int gamemode = Convert.ToInt32(obj);
                    GS = new GameState(gamemode);

                    OnPropertyChanged("GS");
                }));
            }
        }
        public TTTVM() 
        {
            GS = new GameState(1);
        }
    }
}
