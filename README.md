# Klinkby.PeepingEnum

Decorator for IEnumerable<T> that peeps the first element to see if the underlying IEnumerator<T> 
has any elements, in a non-greedy fashion where a pending enumeration does not have to restart.

## Example

``` csharp
var arr = new [] { 1, 2, 3 };
var pArr = arr.Peep();
if (!pArr.Any) return;
foreach(var x in pArr)
{
    Console.WriteLine(x); // write 1, 2, 3
}
```

## Facts

- .NET Standard 1.0 compatible
- No external dependencies
- MIT licensed
- Complete public documentation
- Complete unit test coverage 

## Package
Available as Nuget from https://www.nuget.org/packages/Klinkby.PeepingEnum