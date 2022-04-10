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
    public static class InsertExtensions
    {
        public static InsertCommand Insert(this InsertCommand sql)
        {
            InstructionType type = InstructionType.INSERT;
            string command = sql.GetCommandText(type);
            sql.AddCommand(type, command);
            return sql;
        }

        public static InsertCommand Into(this InsertCommand sql, string table)
        {
            InstructionType type = InstructionType.INTO;
            string command = sql
                .GetCommandText(type)
                .Replace(ValueTags.V1, table);

            sql.AddCommand(type, command);
            return sql;
        }
        public static InsertCommand Columns(this InsertCommand sql, List<string> columns)
        {
            InstructionType type = InstructionType.COLUMN;
            string commandColumn = sql.GetCommandText(type);
            string commandValue = sql.GetCommandText(InstructionType.VALUE);

            string result = "";
            string @params = "";
            foreach (var column in columns)
            {
                result += commandColumn
                    .Replace(ValueTags.V1, column);
                result += ", ";


                @params += commandValue
                    .Replace(ValueTags.V1, "@" + column);
                @params += ", ";
            }

            if (result.EndsWith(", "))
            {
                result = result.Substring(0, result.Length - 2);
                @params = @params.Substring(0, @params.Length - 2);
            }

            sql.AddCommand(type, result);
            sql.AddCommand(InstructionType.VALUES, sql.GetCommandText(InstructionType.VALUES));
            sql.AddCommand(InstructionType.VALUE, @params);
            return sql;
        }

      
    }
}
