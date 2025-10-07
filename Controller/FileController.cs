using System;
using System.Collections.Generic;
using File_Fragmentation.Model;

namespace File_Fragmentation.Controller
{
    public class FileController
    {
        private string inputFile = "input.txt";
        public void CreateInputFile(string paragraph)
        {
            try
            {
                System.IO.File.WriteAllText(inputFile, paragraph);
                Console.WriteLine($"Input file '{inputFile}' created successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating file: {ex.Message}");
            }
        }
    }
}