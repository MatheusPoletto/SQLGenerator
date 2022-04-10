using SQLGenerator.Creator;
using SQLGenerator.Models;
using SQLGenerator.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLGenerator.Extensions
{
    public static class UpdateExtensions
    {
        public static UpdateCommand Update(this UpdateCommand sql)
        {
            InstructionType type = InstructionType.UPDATE;
            string command = sql
                .GetCommandText(type);

            sql.AddCommand(type, command);
            return sql;
        }

        public static UpdateCommand Table(this UpdateCommand sql, string tableName)
        {
            InstructionType type = InstructionType.TABLE;
            string command = sql
                .GetCommandText(type)
                .Replace(ValueTags.V1, tableName);

            sql.AddCommand(type, command);
            return sql;
        }

        public static UpdateCommand SetColumns(this UpdateCommand sql, List<string> columns)
        {
            InstructionType type = InstructionType.COLUMN;
            string commandColumn = sql.GetCommandText(type);

            string result = "";
            foreach (var column in columns)
            {
                result += commandColumn
                    .Replace(ValueTags.V1, column)
                    .Replace(ValueTags.V2, "@" + column);
                result += ", ";

            }

            if (result.EndsWith(", "))
                result = result.Substring(0, result.Length - 2);
            

            sql.AddCommand(type, result);
            return sql;
        }

      
    }
}
