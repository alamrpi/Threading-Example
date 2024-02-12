using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVExample
{
    public class Shared
    {
        public static object LockObject { get; set; } = new object();
        public static string FilePath { get; set; } = "data.csv";

        public static int ChunkSize { get; set; } = 100;
        public static int MaxConcurrent { get; set; } = 3;
        public static Mutex Mutex { get; set; } = new();
    }
}
