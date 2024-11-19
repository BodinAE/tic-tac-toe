using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
    internal class GameState : PropertyChangedClass
    {
        private char[] row1;
        public char[] Row1
        {
            get
            {
                return row1;
            }
            set
            {
                row1 = value;
                OnPropertyChanged("Row1");
            }
        }
        
        private char[] row2;
        public char[] Row2
        {
            get
            {
                return row2;
            }
            set
            {
                row2 = value;
                OnPropertyChanged("Row2");
            }
        }
        
        private char[] row3; 
        public char[] Row3
        {
            get
            {
                return row3;
            }
            set
            {
                row3 = value;
                OnPropertyChanged("Row3");
            }
        }

        public int TurnNumber { get; set; }
        public GameState()
        {
            Row1 = new char[] { ' ', ' ', ' ' };
            Row2 = new char[] { ' ', ' ', ' ' };
            Row3 = new char[] { ' ', ' ', ' ' };
            TurnNumber = 1;
        }
    }
}
