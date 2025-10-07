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
    }
}
