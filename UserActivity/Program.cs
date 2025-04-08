// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using UserActivity;

Console.WriteLine("Hello, World!");

var tp = new TimeProvider();
var a = new ActivityCheck(5, tp);