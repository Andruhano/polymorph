using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public abstract class StorageDevice
{
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public StorageDevice(string name, string manufacturer, string model, int quantity, decimal price)
    {
        Name = name;
        Manufacturer = manufacturer;
        Model = model;
        Quantity = quantity;
        Price = price;
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine($"Name: {Name}, Manufacturer: {Manufacturer}, Model: {Model}, Quantity: {Quantity}, Price: {Price}");
    }

    public abstract void LoadFromFile(string filePath);
    public abstract void SaveToFile(string filePath);
}
public class Flash : StorageDevice
{
    public int MemorySize { get; set; }
    public double UsbSpeed { get; set; }

    public Flash(string name, string manufacturer, string model, int quantity, decimal price, int memorySize, double usbSpeed)
        : base(name, manufacturer, model, quantity, price)
    {
        MemorySize = memorySize;
        UsbSpeed = usbSpeed;
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Memory Size: {MemorySize} GB, USB Speed: {UsbSpeed} MB/s");
    }

    public override void LoadFromFile(string filePath)
    {
        
    }

    public override void SaveToFile(string filePath)
    {
        
    }
}

public class RemovableHDD : StorageDevice
{
    public int DiskSize { get; set; }
    public double UsbSpeed { get; set; }

    public RemovableHDD(string name, string manufacturer, string model, int quantity, decimal price, int diskSize, double usbSpeed)
        : base(name, manufacturer, model, quantity, price)
    {
        DiskSize = diskSize;
        UsbSpeed = usbSpeed;
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Disk Size: {DiskSize} GB, USB Speed: {UsbSpeed} MB/s");
    }

    public override void LoadFromFile(string filePath)
    {
        
    }

    public override void SaveToFile(string filePath)
    {
        
    }
}
public class DVD : StorageDevice
{
    public double ReadSpeed { get; set; }
    public double WriteSpeed { get; set; }

    public DVD(string name, string manufacturer, string model, int quantity, decimal price, double readSpeed, double writeSpeed)
        : base(name, manufacturer, model, quantity, price)
    {
        ReadSpeed = readSpeed;
        WriteSpeed = writeSpeed;
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Read Speed: {ReadSpeed} MB/s, Write Speed: {WriteSpeed} MB/s");
    }

    public override void LoadFromFile(string filePath)
    {
        
    }

    public override void SaveToFile(string filePath)
    {
        
    }
}

public class PriceList
{
    private List<StorageDevice> devices = new List<StorageDevice>();

    public void AddDevice(StorageDevice device)
    {
        devices.Add(device);
    }

    public void RemoveDevice(string name)
    {
        devices.RemoveAll(d => d.Name == name);
    }

    public StorageDevice FindDevice(string name)
    {
        return devices.FirstOrDefault(d => d.Name == name);
    }

    public void UpdateDevice(string name, StorageDevice newDevice)
    {
        int index = devices.FindIndex(d => d.Name == name);
        if (index >= 0)
        {
            devices[index] = newDevice;
        }
    }

    public void PrintDevices()
    {
        foreach (var device in devices)
        {
            device.PrintInfo();
            Console.WriteLine();
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        PriceList priceList = new PriceList();

        Flash flashDrive = new Flash("Flash Drive", "SanDisk", "Ultra", 10, 500, 64, 150);
        DVD dvd = new DVD("DVD-R", "Verbatim", "Optical", 20, 100, 16, 8);
        RemovableHDD hdd = new RemovableHDD("External HDD", "Seagate", "Backup Plus", 5, 2000, 1000, 500);

        priceList.AddDevice(flashDrive);
        priceList.AddDevice(dvd);
        priceList.AddDevice(hdd);

        Console.WriteLine("List of devices:");
        priceList.PrintDevices();

        var foundDevice = priceList.FindDevice("Flash Drive");
        if (foundDevice != null)
        {
            Console.WriteLine("Found device:");
            foundDevice.PrintInfo();
        }

        priceList.RemoveDevice("DVD-R");

        Console.WriteLine("\nList of devices after deletion:");
        priceList.PrintDevices();
    }
}
