using System.Management;
using System.Collections.Generic;
namespace lib;

public class TaskManager
{
    public static void ShowCPUInfo()
    {
        using var cpuSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
        foreach (var obj in cpuSearcher.Get())
        {
            Console.WriteLine($"Модель {obj["Name"]}");
            Console.WriteLine($"Ядер {obj["NumberOfCores"]}");
        }
    }

    public static List<Process> GetProcesses()
    {
        var proccesses = System.Diagnostics.Process.GetProcesses();
        proccesses.Sort((a, b) => (int)(b.WorkingSet64 - a.WorkingSet64));
        return proccesses.Select((it) =>
        {
            return new Process
            {
                Id = it.Id,
                Name = it.ProcessName,
                MemorySizeInMb = it.WorkingSet64 / 1024.0 / 1024.0,
            };
        }).ToList();
    }
}