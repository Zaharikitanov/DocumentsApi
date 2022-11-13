namespace DocumentsApi.Services.Interfaces
{
    public interface IMessageProducer
    {
        public void SendMessage<T>(T message);
    }
}
