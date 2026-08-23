namespace HearingProfileManager.Models
{
    public class HearingDevice
    {
        public string DeviceId { get; set; }
        public string Manufacturer { get; set; }

        public HearingDevice(string id, string manufacturer)
        {
            DeviceId = id;
            Manufacturer = manufacturer;
        }

        // virtual means child classes CAN override this
        public virtual string GetDeviceInfo()
        {
            return $"Device: {DeviceId} by {Manufacturer}";
        }
    }
}