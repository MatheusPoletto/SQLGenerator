using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLGenerator.GlobalConfiguration
{
    public class ObjectMappingConfiguration
    {
        public bool ReplacePascalCaseWithUnderscore { get; set; } = true;
        public string AliasPrefix { get; set; } = "As";
    }
}
