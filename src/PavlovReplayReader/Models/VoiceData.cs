namespace PavlovReplayReader.Models
{
    public class VoiceData
    {
        public float TimeSeconds { get; set; }
        public int PlayerIndex { get; set; }
        public string PlayerName { get; set; }
        public byte[] Data { get; set; }
        public bool IsReplay { get; set; }
    }
}