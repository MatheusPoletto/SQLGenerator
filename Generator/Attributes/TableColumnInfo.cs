using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLGenerator.Attributes
{
    public class TableColumnInfo : Attribute
    {
        public string Name { get; set; }    

        public TableColumnInfo(string name)
        {
            Name = name;
        }
    }
}
