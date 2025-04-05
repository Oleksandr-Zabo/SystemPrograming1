namespace SystemPrograming1;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter time for update in seconds:");
        double time = Convert.ToDouble(Console.ReadLine());
        int timeMilisecond = (int)(time * 1000);

        while (true)
        {
            GetProcesses();
            Sleep(timeMilisecond);

        }
    }

    static void Sleep(int time)
    {
        int timeWait = 2000;
        if (time > timeWait)
        {
            Thread.Sleep(time - timeWait);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Refreshing process list...");
            Console.ResetColor();
            Thread.Sleep(timeWait);
        }
        else
        {
            Thread.Sleep(time);
        }
    }

    static void GetProcesses()
    {
        Console.Clear();
        List<Process> processes = new List<Process>(Process.GetProcesses());
        int index = 1;
        
        foreach (Process process in processes)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{index++}: ");
    
            Console.ForegroundColor = ConsoleColor.Cyan; // Color for the ID
            Console.Write($"ID: {process.Id} ");
    
            Console.ForegroundColor = ConsoleColor.Magenta; // Color for the Name
            Console.WriteLine($"Name: {process.ProcessName}");
    
            Console.ResetColor(); // Reset to default color
        }


        Console.WriteLine("\nEnter the number of the process to view details (or 0 to refresh):");
        int choice = Convert.ToInt32(Console.ReadLine());
        if (choice > 0 && choice <= processes.Count)
        {
            ShowProcessDetails(processes[choice - 1]);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Refreshing process list...");
        }
    }

    static void ShowProcessDetails(Process process)
    {
        Console.Clear();
        Console.WriteLine($"Process ID: {process.Id}");
        Console.WriteLine($"Process Name: {process.ProcessName}");
        try
        {
            Console.WriteLine($"Start Time: {process.StartTime}");
        }
        catch
        {
            Console.WriteLine("Start Time: N/A");
        }
        try
        {
            Console.WriteLine($"Total Processor Time: {process.TotalProcessorTime}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving Total Processor Time: {ex.Message}");
        }

        Console.WriteLine($"Thread Count: {process.Threads.Count}");

        int count = Process.GetProcessesByName(process.ProcessName).Length;
        Console.WriteLine($"Number of Instances: {count}");
        Console.WriteLine("\nPress Enter to return to the main list...");
        Console.ReadLine();
    }
}

