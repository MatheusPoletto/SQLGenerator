using Exe;
using SQLGenerator.Creator;
using SQLGenerator.Extensions;
using SQLGenerator.GlobalConfiguration;
using SQLGenerator.Models;
using SQLGenerator.Models.Enums;

var sql = new SelectCommand(SQLGenerator.Models.Enums.SGBDType.SQLServer)
    .Select()    
    .Columns<Risk>()    
    .From("TestTable");


var sql3 = new SelectCommand(SQLGenerator.Models.Enums.SGBDType.PostgreSQL)
    .Select()
    .Distinct()
    .Top(10)
    .Columns(new List<Column>()
    {
        new Column("Id"),
        new Column("Descrition")
    })
    .From("TestTable")
    .Where("CD_ID", "@CD_ID")
    .And("ENABLED", "@ENABLED");

var sql4 = new SelectCommand(SQLGenerator.Models.Enums.SGBDType.PostgreSQL)
    .Select()
    .Distinct()
    .Top(10)
    .Columns(new List<Column>()
    {
        new Column("Id"),
        new Column("Descrition")
    })
    .From("TestTable")
    .OrderBy("TestTable.Id");

var sql5 = new SelectCommand(SQLGenerator.Models.Enums.SGBDType.PostgreSQL)
    .Select()
    .Distinct()
    .Top(10)
    .Columns(new List<Column>()
    {
        new Column("Id"),
        new Column("Descrition")
    })
    .From("TestTable")
    .OrderBy(new List<OrderBy>()
    {
        new OrderBy("Id"),
        new OrderBy("Description", OrderType.Desc)
    });

Console.WriteLine(sql5);

var sql6 = new InsertCommand(SGBDType.SQLServer)
    .Insert()
    .Into("TestTable")
    .Columns(new List<string>()
    {
        "Id",
        "Name"
    });

Console.WriteLine(sql6);

var sql7 = new UpdateCommand(SGBDType.SQLServer)
    .Update()
    .Table("TestTable")
    .SetColumns(new List<string>()
    {
        "Id",
        "Name"
    })
    .Where("Id", "@Id")
    .And("Enabled", "@Enabled");

Console.WriteLine(sql7);

var sql8 = new DeleteCommand(SGBDType.SQLServer)
    .Delete()
    .From("TestTable")
    .Where("Id", "@Id")
    .And("Enabled", "@Enabled");

Console.WriteLine(sql8);

Console.ReadLine();