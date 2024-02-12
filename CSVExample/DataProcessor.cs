using System;


namespace CSVExample
{
    public class DataProcessor
    {
        public string ChunkName { get; set; }
        public List<string> Chunk { get; set; }
        public Dictionary<string, int>  GenderCounts { get; set; } = new Dictionary<string, int>();

        public void ProcessChunk()
        {
            foreach (var line in Chunk)
            {
                if(string.IsNullOrEmpty(line)) continue;

                var values = line.Split(',');
                if(values.Length >= 5)
                {
                    string gender = values[4].Trim().ToLower();
                    if(GenderCounts.ContainsKey(gender))
                        GenderCounts[gender]++;
                    else
                        GenderCounts.Add(gender, 1);
                }

                //Simulate delay
                var random = new Random();
                Thread.Sleep(100 * random.Next(2, 5));
            }
        }

    }
}
