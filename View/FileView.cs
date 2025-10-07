using System;
using System.Text;
using File_Fragmentation.Controller;

namespace File_Fragmentation.View
{
    public class FileView
    {
        private FileController controller = new FileController();
        public void Start()
        {

            while (true)
            {
                Console.WriteLine("\nFile Fragmentation App \n");

                Console.WriteLine("Enter your paragraph (press Enter on empty line to finish):");
                StringBuilder paragraphBuilder = new StringBuilder();
                string line;
                while (!string.IsNullOrEmpty(line = Console.ReadLine()))
                {
                    paragraphBuilder.AppendLine(line);
                }
                string paragraph = paragraphBuilder.ToString().TrimEnd('\r', '\n');
                controller.CreateInputFile(paragraph);

                
            }
        }
    }
}
