using System.Diagnostics;
using lib;

// var array = new [] {"Абваы", "Яячяя", "ШШшШ"};
// array.Sort((a, b) => a.CompareTo(b));
// foreach (var item in array)
// {
//     Console.WriteLine(item);
// }

var processes = TaskManager.GetProcesses();
// PageMemorySize
foreach (var process in processes.Take(10))
{
    Console.WriteLine($"{process.Id} {process.Name} {process.MemorySizeInMb}");
}
// TaskManager.ShowCPUInfo();