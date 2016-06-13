Name:Dictionaries:GetLabelsByPrefixLanguage
Exception: System.InvalidOperationException: Collection was modified; enumeration operation may not execute.
   at System.Collections.Hashtable.HashtableEnumerator.MoveNext()
   at System.Linq.Enumerable.<CastIterator>d__94`1.MoveNext()
   at System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()
   at System.Linq.Enumerable.WhereSelectEnumerableIterator`2.MoveNext()
   at System.Collections.Generic.List`1..ctor(IEnumerable`1 collection)
   at System.Linq.Enumerable.ToList[TSource](IEnumerable`1 source)
   at WebApp.Dictionary.Dictionary.GetByPrefix(String prefix) in C:\Users\cperez\documents\visual studio 2015\Projects\WebApp\src\WebApp\Dictionary\Dictionary.cs:line 63
   at WebApp.Dictionary.Dictionaries.GetLabelsByPrefixLanguage(String prefix, String languageId) in C:\Users\cperez\documents\visual studio 2015\Projects\WebApp\src\WebApp\Dictionary\Dictionaries.cs:line 108