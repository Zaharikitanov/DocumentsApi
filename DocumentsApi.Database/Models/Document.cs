namespace DocumentsApi.Database.Models
{
    public class Document
    {
        public string DocumentName { get; set; }

        public int Version { get; set; } = 1;

        public string FileName { get; set; }

        /// <summary>
        /// Measured in bytes
        /// </summary>
        public long FileSize { get; set; }
    }
}
