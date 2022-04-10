using SQLGenerator.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLGenerator.Creator
{
    public  class UpdateCommand : Command
    {
        public UpdateCommand(SGBDType SGBD) : base(SGBD)
        {
            Type = Models.Enums.DMLType.UPDATE;
            LoadCommandSchema();

            var commandSet = GetCommandText(InstructionType.SET);
            if (commandSet != null)
                AddCommand(InstructionType.SET, commandSet);

        }

       
    }
}
