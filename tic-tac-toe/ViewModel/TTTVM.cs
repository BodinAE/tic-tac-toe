using System;
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
                        if (GS.TurnNumber % 2 == 0)
                        {
                            GS.Board[i].State = 'X';
                        }
                        else
                        {
                            GS.Board[i].State = 'O';
                        }
                        GS.WinCheck();
                        if (GS.GameRunning)
                            GS.TurnNumber++;
                    }
                }));
            }
        }
        public TTTVM() 
        {
            GS = new GameState();
        }
    }
}
