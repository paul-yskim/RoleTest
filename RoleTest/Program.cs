// See https://aka.ms/new-console-template for more information

using System.Reflection.Metadata;
using RoleTest;
using Document = RoleTest.Document;

Console.WriteLine("Hello, World!");



// var d = new Document(new User()
//                      {
//                           FuncValue = 1<<2
//                      });
// d.Do100();


var results = PermissionChecker.GetCallableMethod(1<<2);

foreach (var r in results)
{
    Console.WriteLine(r);
}