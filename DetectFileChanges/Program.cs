using System;
using System.IO;

namespace DetectFileChanges
{
    internal class Program
    {

        private static void File_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File {e.Name} is being changed: {e.ChangeType}");
            Console.WriteLine();
        }
        private static void File_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File created: {e.Name}");
            Console.WriteLine();
        }

        private static void File_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"File renamed from: {e.OldName} to {e.Name}");
            Console.WriteLine();
        }
  
        private static void File_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File deleted: {e.Name}");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher(@"C:\Users\Alex\Desktop\Monitor")
            {
                IncludeSubdirectories = true,
                EnableRaisingEvents = true
            };
            fileSystemWatcher.Changed += File_Changed;
            fileSystemWatcher.Created += File_Created;
            fileSystemWatcher.Renamed += File_Renamed;
            fileSystemWatcher.Deleted += File_Deleted;
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}