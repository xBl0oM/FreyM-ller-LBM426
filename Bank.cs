using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    internal class Bank
    {
        private int _bankCredits;
        public int BankCredits
        {
            get { return _bankCredits; }
            set { _bankCredits = value; }
        }

        public Bank(int bankCredits)
        {
            _bankCredits = bankCredits;
        }
    }
}
