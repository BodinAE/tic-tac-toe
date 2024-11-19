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
                    char c = (char)obj;
                    if (c == ' ')
                    {
                        if (GS.TurnNumber % 2 == 0)
                        {
                            c = 'X';
                        }
                        else
                        {
                            c = 'O';
                        }
                        obj = c;
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
