namespace PavlovReplayReader.Models.Events;

public class EncryptionKey : BaseEvent
{
    public string Key { get; set; }
}