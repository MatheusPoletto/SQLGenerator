using Generator.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator.Models
{
    public class CommandItem
    {
        public InstructionType Type { get; set; }
        public string Command { get; set; }

        public CommandItem(InstructionType type, string command)
        {
            Type = type;
            Command = command;
        }

    }
}
