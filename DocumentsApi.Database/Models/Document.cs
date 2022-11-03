namespace DocumentsApi.Database.Models
{
    public class Document
    {
        public string DocumentName { get; set; }

        public int Version { get; set; }

        public string FileName { get; set; }

        public long FileSize { get; set; }
    }
}
