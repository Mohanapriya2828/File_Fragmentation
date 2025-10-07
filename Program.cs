using System;
using File_Fragmentation.View;

namespace File_Fragmentation
{
    class Program
    {
        static void Main(string[] args)
        {
            FileView view = new FileView();
            view.Start();
        }
    }
}
