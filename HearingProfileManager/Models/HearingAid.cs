namespace HearingProfileManager.Models
{
    // HearingAid INHERITS from HearingDevice
    public class HearingAid : HearingDevice
    {
        public string Style { get; set; }

        public HearingAid(string id, string manufacturer, string style)
            : base(id, manufacturer) // calls parent constructor
        {
            Style = style;
        }

        // override replaces the parent version
        public override string GetDeviceInfo()
        {
            return $"Hearing Aid: {DeviceId} | Style: {Style}";
        }
    }
}