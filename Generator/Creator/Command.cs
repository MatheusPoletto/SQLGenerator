using SQLGenerator.Models;
using SQLGenerator.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SQLGenerator.Creator
{
    public abstract class Command
    {
        protected SGBDType SGBD { get; set; }
        protected DMLType Type { get; set; }
        protected XmlNode CommandSchema { get; set; }

        private List<CommandItem> Commands = new List<CommandItem>();

        public Command(SGBDType SGBD)
        {
            this.SGBD = SGBD;            
        }

        public override string ToString()
        {
            string output = "";
            foreach (XmlNode node in CommandSchema.ChildNodes)
            {
                InstructionType type;
                Enum.TryParse(node.Name.ToUpper(), out type);

                foreach (var item in Commands.Where(c => c.Type == type))
                {
                    output += item.Command + " ";
                }

            }



            return output;
        }

        public void AddCommand(InstructionType type, string command)
        {
            Commands.Add(new CommandItem(type, command));
        }

        protected string GetResourceSchemaFromSGBD()
        {
            switch (SGBD)
            {
                case SGBDType.SQLServer:
                    return Resources.SQLServerSchema;
                case SGBDType.PostgreSQL:
                    return Resources.PostgreSQLSchema;
                default:
                    throw new Exception("GetResourceSchemaFromSGBD with invalid SGBD");
            }
        }

        protected void LoadCommandSchema()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(GetResourceSchemaFromSGBD());
            XmlNodeList nodes = doc.SelectNodes("//commands/command");
            foreach (XmlNode node in nodes)
            {
                if (node.Attributes["type"].Value.Equals(Type.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    CommandSchema = node;
                    return;
                }
            }
        }

        public string GetCommandText(InstructionType instruction)
        {
            string instructionDef = instruction.ToString().ToLower().Replace("_", "/");
            var node = CommandSchema.SelectSingleNode(instructionDef);
            if (node == null)
                return null;
            return node.FirstChild.InnerText;
        }
    }
}
