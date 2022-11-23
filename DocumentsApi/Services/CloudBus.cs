using DocumentsApi.Services.Interfaces;
using STP.AspNetCore.Bus;
using STP.Lsb;

namespace DocumentsApi.Services
{
    public class CloudBus : LexolutionServiceBus, ICloudBus
    {
        public CloudBus(ILexolutionQueue queue)
            : base(queue)
        {
        }
    }
}
