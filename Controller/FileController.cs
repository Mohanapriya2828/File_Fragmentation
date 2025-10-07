using System;
using System.Collections.Generic;
using File_Fragmentation.Model;

namespace File_Fragmentation.Controller
{
    public class FileController
    {
        private string inputFile = "input.txt";
        private List<FileModel> fragments = new List<FileModel>();
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
        public void FragmentFile(int fragmentSize)
        {
            try
            {
                fragments = FileModel.Fragment(inputFile, fragmentSize);
                Console.WriteLine("Fragmentation Completed. Created Files:");
                foreach (var f in fragments)
                    Console.WriteLine(f.FileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during fragmentation: {ex.Message}");
            }
        }
        public void VerifyFile(string fileName)
        {
            try
            {
                while (!System.IO.File.Exists(fileName))
                {
                    Console.WriteLine("File does not exist. Please enter correct file name:");
                    fileName = Console.ReadLine();
                }

                string content = System.IO.File.ReadAllText(fileName);
                Console.WriteLine($"File '{fileName}' contains:\n{content}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error verifying file: {ex.Message}");
            }
        }
        public void DefragmentFiles()
        {
            try
            {
                string combinedData = FileModel.Defragment(fragments, outputFile);
                Console.WriteLine($"Defragmentation Completed. Output file: '{outputFile}' created!");
                Console.WriteLine("You can open 'output.txt' to see the combined text.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during defragmentation: {ex.Message}");
            }
        }

    }
}