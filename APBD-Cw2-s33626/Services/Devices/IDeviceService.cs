using APBD_Cw2_s33626.Models;

namespace APBD_Cw2_s33626.Services.Devices;

public interface IDeviceService
{
    public void AddDevice(Device device);
    public void ListDevices();
    public void ListAvailableDevices();
    public void ServiceDevice(int deviceId);
}