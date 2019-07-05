# Ormico SQL GO Splitter
## Intro
Split SQL files on GO statements in a string and comment safe manner.

SQL files used in tools such as Microsoft&reg; SSMS use the keyword GO as a delimiter between execution blocks. Tools that recognize this keyword can correctly parse the file along these delimiters and execute each block correctly, but these same SQL statements cannot be executed through tools that do not recognize the GO keyword, such as ADO .NET.

SQL GO Splitter can break a SQL script containing GO keywords into seperate scripts while respecting comments and strings.

The purpose of this project is to provide an easy to use package for splitting SQL files in this manner.

## Examples
```
select getdate()
GO
select NewId()
GO
```
Will parse into 2 SQL Scripts.

```
declare @x='Hello!
GO'
select @x
GO
```
Will parse into 1 SQL statement. The GO inside the quoted string is recognized as part of the string and will not cause a script break.

```
select getdate()
--GO
select NewId()
GO
```
Will parse into 1 SQL Script. The first GO is commented out and will not cause a script break.

```
select getdate()
/*GO*/
select NewId()
GO
```
Will parse into 1 SQL Script. The first GO is commented out and will not cause a script break.

```
/*select getdate()
GO*/
select NewId()
GO
```
Will parse into 1 SQL Script. The first section of code including the first GO is commented out and will not cause a script break.

## How to get
NuGet Package is coming...

# Attribution
This code originated as part of [Subtext](https://github.com/haacked/Subtext) and all credit for it's origin go to that team. Blame for any modifications can go to me.