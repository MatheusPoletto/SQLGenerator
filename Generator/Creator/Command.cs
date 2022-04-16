using SQLGenerator.GlobalConfiguration;
using SQLGenerator.Models;
using SQLGenerator.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public ObjectMappingConfiguration MappingConfiguration;

        public Command(SGBDType SGBD, ObjectMappingConfiguration mappingConfiguration = null)
        {
            this.SGBD = SGBD;

            MappingConfiguration = mappingConfiguration == null ?
                    GetDefaultMappingConfiguration()
                    : mappingConfiguration;

        }

        protected void ClearCommands()
        {
            this.Commands.Clear();
        }

        protected ObjectMappingConfiguration GetDefaultMappingConfiguration()
        {
            return new ObjectMappingConfiguration();
        }

        public override string ToString()
        {
            var commandEnd = GetCommandText(InstructionType.END);
            if (commandEnd != null)
                AddCommand(InstructionType.END, commandEnd);

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
            ClearCommands();
            return Regex.Replace(output, @"\t|\n|\r", "");
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
