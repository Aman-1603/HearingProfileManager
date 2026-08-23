namespace HearingProfileManager.Models
{
    public class CochlearImplant : HearingDevice
    {
        public int Channels { get; set; }

        public CochlearImplant(string id, string manufacturer, int channels)
            : base(id, manufacturer)
        {
            Channels = channels;
        }

        public override string GetDeviceInfo()
        {
            return $"Cochlear Implant: {DeviceId} | Channels: {Channels}";
        }
    }
}