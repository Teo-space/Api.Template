global using System;
global using System.IO;
global using System.Data;
global using System.Text;
global using System.Collections;
global using System.Collections.Generic;
global using System.Collections.Concurrent;
global using System.Linq;
global using System.Threading;
global using System.Threading.Tasks;
global using System.Reflection;
global using System.Text.RegularExpressions;
global using Microsoft.Extensions.DependencyInjection;
////////////////////////////////////////////////////////////////////






































/// <summary>
/// Класс нужен только чтобы все юзинги были активны и при очистке кода их не удаляло
/// </summary>
static class DontRemoveUsings
{
    static Exception Exception {  get; set; }
    static bool Exists { get; set; } = File.Exists("");
    static DataTable DataTable { get; set; }
    static Encoding Encoding { get; set; }
    static ICollection collection { get; set; }
    static ICollection<string> stringCollection { get; set;}
    static ConcurrentBag<string> stringBag { get; set;}
    static bool Linq {  get; set; }= Enumerable.Empty<string>().Any();
    static Thread Thread { get; set; }
    static Task Task { get; set; }
    static MethodInfo MethodInfo { get; set; }
    static Regex Regex { get; set; }
    static IServiceCollection ServiceCollection { get; set; }
}