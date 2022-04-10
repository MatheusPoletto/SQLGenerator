using Generator.Creator;
using Generator.Models;
using Generator.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator.Extensions
{
    public static class SelectExtensions
    {
        public static SelectCommand Select(this SelectCommand sql)
        {
            InstructionType type = InstructionType.SELECT;
            string command = sql.GetCommandText(type);
            sql.AddCommand(type, command);
            return sql;
        }


        public static SelectCommand Top(this SelectCommand sql, long quantity)
        {
            InstructionType type = InstructionType.TOP;
            string command = sql
                .GetCommandText(type)
                .Replace(ValueTags.V1, quantity.ToString());
            sql.AddCommand(type, command);
            return sql;
        }

        public static SelectCommand Distinct(this SelectCommand sql)
        {
            InstructionType type = InstructionType.DISTINCT;
            string command = sql.GetCommandText(type);
            sql.AddCommand(type, command);
            return sql;
        }

        public static SelectCommand Columns(this SelectCommand sql)
        {
            InstructionType type = InstructionType.ALL;
            string command = sql.GetCommandText(type);
            sql.AddCommand(type, command);
            return sql;
        }

        public static SelectCommand Columns(this SelectCommand sql, List<Column> columns)
        {
            InstructionType type = InstructionType.COLUMN;
            string command = sql.GetCommandText(type);

            string result = "";
            foreach(var column in columns)
            {
                var tableIdentifier = String.IsNullOrEmpty(column.TableName) ? "" : column.TableName + "."; 

                result += command
                    .Replace(ValueTags.V1, tableIdentifier + column.Name)
                    .Replace(ValueTags.V2, String.IsNullOrEmpty(column.Alias) ?  column.Name : column.Alias);
                result += ", ";
            }

            if (result.EndsWith(", "))
                result = result.Substring(0, result.Length - 2);

            sql.AddCommand(type, result);
            return sql;
        }

        public static SelectCommand From(this SelectCommand sql, string table)
        {
            InstructionType type = InstructionType.FROM;
            string command = sql
                .GetCommandText(type)
                .Replace(ValueTags.V1, table);

            sql.AddCommand(type, command);
            return sql;
        }

        public static SelectCommand Join(this SelectCommand sql, string table, string onA, string onB)
        {
            InstructionType type = InstructionType.JOIN;
            string command = sql
                .GetCommandText(type)
                .Replace(ValueTags.V1, table);

            string andCommand = sql
                .GetCommandText(InstructionType.JOIN_AND)
                .Replace(ValueTags.V1, onA)
                .Replace(ValueTags.V2, onB);

            command += andCommand;

            sql.AddCommand(type, command);
            return sql;
        }

        public static SelectCommand Join(this SelectCommand sql, string table, List<And> andItems)
        {
            InstructionType type = InstructionType.JOIN;
            string command = sql
                .GetCommandText(type)
                .Replace(ValueTags.V1, table);

            var andCommand = sql
                    .GetCommandText(InstructionType.JOIN_AND);
            foreach (var and in andItems)
            {
                string item = andCommand
                    .Replace(ValueTags.V1, and.OnA)
                    .Replace(ValueTags.V2, and.OnB);

                command += item + " ";
            }

            if (command.EndsWith(" "))
                command = command.Substring(0, command.Length - 1);

            sql.AddCommand(type, command);
            return sql;
        }



    }
}
