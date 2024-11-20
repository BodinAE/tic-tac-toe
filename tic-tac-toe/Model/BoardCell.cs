using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
    class BoardCell : PropertyChangedClass
    {
        private char state;
        public char State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                OnPropertyChanged("State");
            }
        }
        public BoardCell()
        {
            State = ' ';
        }
    }
}
