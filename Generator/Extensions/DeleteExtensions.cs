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
    public static class DeleteExtensions
    {
        public static DeleteCommand Delete(this DeleteCommand sql)
        {
            InstructionType type = InstructionType.DELETE;
            string command = sql
                .GetCommandText(type);

            sql.AddCommand(type, command);
            return sql;
        }

        public static DeleteCommand From(this DeleteCommand sql, string tableName)
        {
            InstructionType type = InstructionType.FROM;
            string command = sql
                .GetCommandText(type)
                .Replace(ValueTags.V1, tableName);

            sql.AddCommand(type, command);
            return sql;
        }
      
    }
}
