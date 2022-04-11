# SQLGenerator 

![GitHub repo size](https://img.shields.io/github/repo-size/MatheusPoletto/SQLGenerator)
![GitHub language count](https://img.shields.io/github/languages/count/MatheusPoletto/SQLGenerator)

<img src="./Resources/database.png" alt="exemplo imagem" width="20%">

<hr>

### Description

Service for generating DML commands across multiple banks using the C# language.
This project is currently developed using .NET CORE 6.

Releases are distributed through NuGet packages available in the ./Generator/Releases folder.

💡<br>
<b>Remember: We just build the command by the query.
Give preference to passing parameters like @ID instead of providing the final value.<br>This will protect your database from SQL injection  .</b>

### Current SGBD supported

- PostgreSQL
- SQLServer

### Available commands and examples

&#8594; SelectCommand;<br>
&#8594; InsertCommand;<br>
&#8594; UpdateCommand;<br>
&#8594; DeleteCommand;<br>

See the available definitions and methods:

&#8594; SelectCommand:

Initialize with <i>new SelectCommand(SGBDType.SQLServer)</i>.<br>
.Select() - Does not receive any parameters, starts the query;<br>
.Distinct() - Does not receive any parameters;<br>
.Top() - Receives the number of rows to return;<br>
.Columns() - It has method overload, without passing a parameter all columns are returned from the table (*), passing a List<Column> it will be necessary to specify the name of the table and the column, see the examples;<br>
.From() - Receives the table name as a parameter;<br>
.Where() / .And() - Receives the name of the field and parameter where the query will be performed;<br>
.OrderBy() - Receives a list of fields to sort with the ordering type, standard ASC.<br>
.GroupBy() - Gets a list of fields to group.<br>
 
Examples:

Simple SELECT example:
```
string sql = 
    new SelectCommand(SGBDType.SQLServer)
    .Select()    
    .Columns(new List<Column>()
    {
        new Column("TestTable", "Id"),
        new Column("TestTable", "Description")
    })
    .From("TestTable");
```

SELECT with filters:
```
string sql = 
    new SelectCommand(SGBDType.PostgreSQL)
    .Select()
    .Distinct()
    .Top(10)
    .Columns(new List<Column>()
    {
        new Column("TestTable", "Id"),
        new Column("TestTable", "Descrition")
    })
    .From("TestTable")
    .Where("CD_ID", "@CD_ID")
    .And("ENABLED", "@ENABLED");
```

SELECT with JOIN:
```
string sql = 
    new SelectCommand(SGBDType.SQLServer)
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
```

SELECT with ORDER:

```
string sql = 
    new SelectCommand(SGBDType.PostgreSQL)
    .Select()
    .Distinct()
    .Top(10)
    .Columns(new List<Column>()
    {
        new Column("TestTable", "Id"),
        new Column("TestTable", "Descrition")
    })
    .From("TestTable")
    .OrderBy(new List<OrderBy>()
    {
        new OrderBy("Id"),
        new OrderBy("Description", OrderType.Desc)
    });
```

&#8594; InsertCommand:

Initialize with <i>new InsertCommand(SGBDType.SQLServer)</i>.<br>
.Insert() - Does not receive any parameters, starts the query;<br>
.Into() - Receives the table name as a parameter;<br>
.Columns() - List of columns to update, it will generate a @PARAM_NAME in each item of sql result;

Examples:

```
string sql = 
    new InsertCommand(SGBDType.SQLServer)
    .Insert()
    .Into("TestTable")
    .Columns(new List<string>()
    {
        "Id",
        "Name"
    });
```
 
&#8594; UpdateCommand:

Initialize with <i>new UpdateCommand(SGBDType.SQLServer)</i>.<br>
.Update() - Does not receive any parameters, starts the query;<br>
.Table() - Receives the table name as a parameter;<br>
.Set() - Does not receive any parameters;<br>
.SetColumns() - List of columns to update, it will generate a @PARAM_NAME in each item of sql result;
.Where() / .And() - Receives the name of the field and parameter where the query will be performed;<br>

Examples:

```
string sql = 
    new UpdateCommand(SGBDType.SQLServer)
    .Update()
    .Table("TestTable")
    .SetColumns(new List<string>()
    {
        "Id",
        "Name"
    })
    .Where("Id", "@Id")
    .And("Enabled", "@Enabled");
```
 
&#8594; DeleteCommand:

Initialize with <i>new DeleteCommand(SGBDType.SQLServer)</i>.<br>
.Delete() - Does not receive any parameters, starts the query;<br>
.From() - Receives the table name as a parameter;<br>
.Where() / .And() - Receives the name of the field and parameter where the query will be performed;<br>

Examples:
 
```
string sql = 
    new DeleteCommand(SGBDType.SQLServer)
    .Delete()
    .From("TestTable")
    .Where("Id", "@Id")
    .And("Enabled", "@Enabled");
```

### Adjustments and improvements

The project is still under development and the next updates will focus on the following tasks:

- [ ] SELECT with pagination.
- [ ] Improvements in command generation
- [ ] Exit code identification
- [ ] Availability of commands through API
- [ ] Expand support for Oracle and MySQL
- [ ] Implement update command with join.

## 💻 Requirements

- Visual Studio or Visual Studio Code
- .NET CORE 6

## 📝 Permission

 Copyright (c) 2022 SQLGenerator - Matheus Poletto
 MIT License

 Permission is hereby granted, free of charge, to any person obtaining a copy
 of this software and associated documentation files (the "Software"), to deal
 in the Software without restriction, including without limitation the rights
 to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 copies of the Software, and to permit persons to whom the Software is
 furnished to do so, subject to the following conditions:

 The above copyright notice and this permission notice shall be included in
 all copies or substantial portions of the Software.

 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 THE SOFTWARE.
