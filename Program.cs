using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageCollection {
  class Program {
    private static string _filePath = 
      @"C:\Lab Formulatrix\GarbageCollection\GarbageCollection\Assets\covid_tweet.csv";
    static void Main(string[] args) {
      Stopwatch timer = new Stopwatch();
      IDisposable manager = new CSVManager(timer, _filePath);
      
      // Console.WriteLine(" Press any key to dispose"); // 500mb ++
      Console.WriteLine(GC.GetTotalMemory(true) + " Press any key to dispose"); // 300mb ++, is it refreshed?
      Console.ReadKey();

      manager.Dispose();

      Console.WriteLine("\n Press any key to exit");
      // Console.WriteLine("\n" + GC.GetTotalMemory(true) + " Press any key to exit");
      Console.ReadKey();
    }
  }
}
