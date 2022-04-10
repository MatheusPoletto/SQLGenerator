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

var sql2 = new SelectCommand(Generator.Models.Enums.SGBDType.SQLServer)
    .Select()
    .Columns(new List<Column>()
    {
        new Column("TestTable", "Id"),
        new Column("TestTable", "Descrition")
    })
    .From("TestTable")
    .Join("OtherTable", "OtherTable.Id", "TestTable.Id")
    .Join("AnotherTable", "AnotherTable.Id", "TestTable.Id")
    .Join("Multiple", new List<And>() { 
        new And("Multiple.Id", "1"),
        new And("Multiple.Id", "AnotherTable.Id")
    });

var sql3 = new SelectCommand(Generator.Models.Enums.SGBDType.SQLServer)
    .Select()
    .Columns(new List<Column>()
    {
        new Column("TestTable", "Id"),
        new Column("TestTable", "Descrition")
    })
    .From("TestTable")
    .Where("CD_ID", "@CD_ID")
    .And("ENABLED", "@ENABLED");

Console.WriteLine(sql3);

Console.ReadLine();