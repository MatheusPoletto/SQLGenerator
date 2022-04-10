using Generator.Creator;
using Generator.Extensions;
using Generator.Models;

var sql = new SelectCommand(Generator.Models.Enums.SGBDType.SQLServer)
    .Select()    
    .Columns(new List<Column>()
    {
        new Column("TestTable", "Id"),
        new Column("TestTable", "Descrition")
    })
    .From("TestTable");

Console.WriteLine(sql);

Console.ReadLine();