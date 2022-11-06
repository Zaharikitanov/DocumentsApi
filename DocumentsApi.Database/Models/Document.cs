using System.ComponentModel.DataAnnotations;

namespace DocumentsApi.Database.Models
{
    public class Document
    {
        [Key]
        public Guid Id { get; set; }

        public string DocumentName { get; set; }

        public int Version { get; set; } = 1;

        public string FileName { get; set; }

        /// <summary>
        /// Measured in bytes
        /// </summary>
        public long FileSize { get; set; }
    }
}
