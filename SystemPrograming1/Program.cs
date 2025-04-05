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
            Thread.Sleep(timeMilisecond);
        }
    }
    
    static void GetProcesses()
    {
        Console.Clear();
        foreach(Process process in Process.GetProcesses())
        {
            Console.WriteLine($"ID: {process.Id}  Name: {process.ProcessName}");
        }
    }
}

