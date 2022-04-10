using Generator.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator.Creator
{
    public  class SelectCommand : Command
    {
        public SelectCommand(SGBDType SGBD) : base(SGBD)
        {
            Type = Models.Enums.DMLType.SELECT;
        }

    
    }
}
