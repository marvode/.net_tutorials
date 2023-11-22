// See https://aka.ms/new-console-template for more information

using NamespacesLecture.Models;

Console.WriteLine("Hello, World!");

var pay = new PayRoll(20, 200, 0.02);

Console.WriteLine(pay.GrossPay);
Console.WriteLine(pay.NetPay);