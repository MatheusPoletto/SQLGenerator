using SQLGenerator.Attributes;
using SQLGenerator.Extensions;
using SQLGenerator.GlobalConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLGenerator.Creator
{
    public class ObjectMap
    {
        public string GetAllSelectColumns<T>(ObjectMappingConfiguration mappingConfiguration)
        {
            var proprerties = typeof(T).GetProperties();

            string columnsResult = "";
            foreach(var propertie in proprerties)
            {
                if (propertie.IsDefined(typeof(MapIgnoreSelect), true))
                    continue;

                string columnName = propertie.Name;

                if (mappingConfiguration.ReplacePascalCaseWithUnderscore)                
                    columnName = columnName.ReplacePascalCaseWithUnderscore();                                    

                if (propertie.IsDefined(typeof(TableColumnInfo), true))
                    columnName = propertie.GetAttributValue((TableColumnInfo columnInfo) => columnInfo.Name);

                columnsResult += $"{columnName} {mappingConfiguration.AliasPrefix} {propertie.Name }, ";                
            }

            if (columnsResult.EndsWith(", "))
                columnsResult = columnsResult.Substring(0, columnsResult.Length - 2);

            return columnsResult;
        }
     
    }
}
