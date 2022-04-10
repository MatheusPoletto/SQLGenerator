using SQLGenerator.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLGenerator.Creator
{
    public  class DeleteCommand : Command
    {
        public DeleteCommand(SGBDType SGBD) : base(SGBD)
        {
            Type = Models.Enums.DMLType.DELETE;
            LoadCommandSchema();
        }

    
    }
}
