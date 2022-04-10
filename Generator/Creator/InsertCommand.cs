﻿using SQLGenerator.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLGenerator.Creator
{
    public  class InsertCommand : Command
    {
        public InsertCommand(SGBDType SGBD) : base(SGBD)
        {
            Type = Models.Enums.DMLType.INSERT;
            LoadCommandSchema();

          
        }

    
    }
}
