using Generator.Creator;
using Generator.Extensions;

var sql = new SelectCommand(Generator.Models.Enums.SGBDType.SQLServer)
    .Select()    
    .Columns(new List<Generator.Models.Column>()
    {
        new Generator.Models.Column()
        {
            Name = "TT.ID",            
        },
        new Generator.Models.Column()
        {
            Name = "TT.Description",
            Alias = "Ds"
        }
    })
    .From("TestTable TT");

Console.WriteLine(sql);

Console.ReadLine();