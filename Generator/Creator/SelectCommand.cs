using SQLGenerator.GlobalConfiguration;
using SQLGenerator.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLGenerator.Creator
{
    public  class SelectCommand : Command
    {
        public SelectCommand(SGBDType SGBD, ObjectMappingConfiguration mappingConfiguration = null) : base(SGBD, mappingConfiguration)
        {
            Type = Models.Enums.DMLType.SELECT;
            LoadCommandSchema();
        }

    
    }
}
