using STP.AspNetCore.Bus.Abstractions;

namespace DocumentsApi.Messages
{
    public class DocumentBusMessage : BusMessage
    {
        public string MessageId { get; set; }

        public Guid DocumentId { get; set; }

        public string DocumentName { get; set; }

        public int Version { get; set; }

        public string FileName { get; set; }

        public long FileSize { get; set; }
    }
}
