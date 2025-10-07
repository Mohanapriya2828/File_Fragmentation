using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace File_Fragmentation.Model
{
    public class FileModel
    {
        public string FileName { get; set; }
        public string Data { get; set; }

        public FileModel(string fileName, string data)
        {
            FileName = fileName;
            Data = data;
        }

        public static List<FileModel> Fragment(string inputFile, int fragmentSize)
        {
            var fragments = new List<FileModel>();

            if (!File.Exists(inputFile))
                throw new FileNotFoundException($"Input file '{inputFile}' not found.");

            string data = File.ReadAllText(inputFile);
            int totalFiles = (int)Math.Ceiling((double)data.Length / fragmentSize);
            int padding = totalFiles.ToString().Length;

            for (int i = 0; i < totalFiles; i++)
            {
                int start = i * fragmentSize;
                int length = Math.Min(fragmentSize, data.Length - start);
                string fragmentData = data.Substring(start, length);
                string fileName = (i + 1).ToString().PadLeft(padding, '0') + ".txt";

                File.WriteAllText(fileName, fragmentData);

                fragments.Add(new FileModel(fileName, fragmentData));
            }

            return fragments;
        }
        public static string Defragment(List<FileModel> fragments, string outputFile)
        {
            fragments.Sort((a, b) => string.Compare(a.FileName, b.FileName));
            var combinedData = new StringBuilder();
            foreach (var f in fragments)
            {
                combinedData.Append(File.ReadAllText(f.FileName));
            }

            File.WriteAllText(outputFile, combinedData.ToString());
            return combinedData.ToString();
        }
    }
}
