using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    internal class User
    {
        private int _userCredits;

        public int UserCredits
        {
            get { return _userCredits; }
            set { _userCredits = value; }
        }

        public User(int userCredits)
        {
            _userCredits = userCredits;
        }
    }


}
