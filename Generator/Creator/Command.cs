using Generator.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Generator.Creator
{
    public abstract class Command
    {
        protected SGBDType SGBD { get; set; }
        protected DMLType Type { get; set; }
        protected XmlNode CommandSchema { get; set; }

        private Dictionary<InstructionType, string> Commands = new Dictionary<InstructionType, string>();

        public Command(SGBDType SGBD)
        {
            this.SGBD = SGBD;
            LoadCommandSchema();
        }

        public override string ToString()
        {
            string output = "";
            foreach (XmlNode node in CommandSchema.ChildNodes)
            {
                InstructionType type;
                Enum.TryParse(node.Name.ToUpper(), out type);

                if (Commands.ContainsKey(type))
                {
                    output += Commands[type] + " ";
                }
            }

            return output;
        }

        public void AddCommand(InstructionType type, string command)
        {
            Commands.Add(type, command);
        }

        protected string GetResourceSchemaFromSGBD()
        {
            switch (SGBD)
            {
                case SGBDType.SQLServer:
                    return Resources.SQLServerSchema;
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
            return CommandSchema.SelectSingleNode(instruction.ToString().ToLower()).InnerText;
        }
    }
}
