using SQLGenerator.Creator;
using SQLGenerator.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLGenerator.Extensions
{
    public static class CommandExtensions
    {
        public static Command Where(this Command sql, string onA, string onB)
        {
            InstructionType type = InstructionType.WHERE;
            string command = sql
                .GetCommandText(type)
                .Replace(ValueTags.V1, onA)
                .Replace(ValueTags.V2, onB);

            sql.AddCommand(type, command);
            return sql;
        }

        public static Command And(this Command sql, string onA, string onB)
        {
            InstructionType type = InstructionType.AND;
            string command = sql
                .GetCommandText(type)
                .Replace(ValueTags.V1, onA)
                .Replace(ValueTags.V2, onB);

            sql.AddCommand(type, command);
            return sql;
        }
    }
}
