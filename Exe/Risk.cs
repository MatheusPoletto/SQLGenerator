using SQLGenerator.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exe
{
    public class Risk
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [MapIgnoreSelect]
        public string TestValue { get; set; }
        public string DepSetValue { get; set; }
        [TableColumnInfo("Teste")]
        public string DepIgnore { get; set; }
    }
}
