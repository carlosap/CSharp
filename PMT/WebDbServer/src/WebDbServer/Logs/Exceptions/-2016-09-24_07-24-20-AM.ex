Name:UserClientContext:Get
Exception: System.FormatException: Input string was not in a correct format.
   at System.Number.StringToNumber(String str, NumberStyles options, NumberBuffer& number, NumberFormatInfo info, Boolean parseDecimal)
   at System.Number.ParseDecimal(String value, NumberStyles options, NumberFormatInfo numfmt)
   at System.Decimal.Parse(String s)
   at WebDbServer.Controllers.UpdateTemperatureController.<>c__DisplayClass2_0.<<Get>b__0>d.MoveNext() in C:\Users\cperez\Documents\Visual Studio 2015\Projects\WebDbServer\src\WebDbServer\Controllers\Limits\UpdateTemperatureController.cs:line 48