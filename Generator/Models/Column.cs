using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator.Models
{
    public class Column
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string TableName { get; set; }

        public Column(string tableName, string columnName, string columnAlias)
        {
            TableName = tableName;
            Name = columnName;
            Alias = columnAlias;
        }

        public Column(string columnName, string columnAlias)
        {
            Name = columnName;
            Alias = columnAlias;
        }
    }
}
