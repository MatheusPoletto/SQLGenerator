using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLGenerator.Models
{
    public class And
    {
        public string OnA;
        public string OnB;

        public And(string onA, string onB)
        {
            OnA = onA;
            OnB = onB;
        }
    }
}
