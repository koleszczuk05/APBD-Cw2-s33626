using APBD_Cw2_s33626.Models;
using APBD_Cw2_s33626.Data;
using APBD_Cw2_s33626.Enums;

namespace APBD_Cw2_s33626.Services.Devices;

public class DeviceService(DataBase dataBase) : IDeviceService
{
    public void AddDevice(Device device)
    {
        dataBase.Devices.Add(device);
    }

    public void ListDevices()
    {
        if (dataBase.Devices.Count > 0)
        {
            foreach (Device device in dataBase.Devices)
            {
                Console.WriteLine($"{device.Id} - {device.Name} -  {device.Status}");
            }
        }
        else
        {
            throw new ArgumentException($"There are no available devices in database");
        }
    }

    public void ListAvailableDevices()
    {
        if (dataBase.Devices.Count > 0)
        {
            foreach (Device device in dataBase.Devices)
            {
                if (device.Status == DeviceStatus.Available)
                {
                    Console.WriteLine($"{device.Id} - {device.Name}  - {device.Status}");
                }
            }
        }
        else
        {
            throw new ArgumentException($"There are no available devices in database");
        }
    }

    public void ServiceDevice(int deviceId)
    {
        if (dataBase.Devices.Count > 0)
        {
            var isPresent = false;
            foreach (Device device in dataBase.Devices)
            {
                if (device.Id == deviceId)
                {
                    device.Status = DeviceStatus.Damaged;
                    isPresent = true;
                }
            }

            if (!isPresent)
            {
                throw new ArgumentException($"There is no device with this id in database");
            }
        }
        else
        {
            throw new ArgumentException($"There are no available devices in database");
        }
    }
}