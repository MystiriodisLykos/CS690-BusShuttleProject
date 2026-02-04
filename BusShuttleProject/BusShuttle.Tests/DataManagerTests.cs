namespace BusShuttle.Tests;

using BusShuttle;

public class DataManagerTests
{
    DataManager dataManager;

    public DataManagerTests() {
        File.WriteAllText("stops.txt","One"+Environment.NewLine+"Two"+Environment.NewLine+"Three"+Environment.NewLine+"Four"+Environment.NewLine+"Five");
        File.WriteAllText("drivers.txt","Driver1"+Environment.NewLine+"Driver2"+Environment.NewLine+"Driver3");
        dataManager = new DataManager();
    }

    [Fact]
    public void Test_AddStop()
    {
        Assert.Equal(5,dataManager.Stops.Count);
        dataManager.AddStop(new Stop("new stop"));
        Assert.Equal(6,dataManager.Stops.Count);
    }

    [Fact]
    public void Test_DataManager_loads_drivers_from_file()
    {
        Assert.Equal(3,dataManager.Drivers.Count);
    }

    [Fact]
    public void Test_DataManager_can_add_driver()
    {
        dataManager.AddDriver(new Driver("new driver"));
        Assert.Equal(4,dataManager.Drivers.Count);
    }

    [Fact]
    public void Test_DataManager_can_remove_driver()
    {
        dataManager.RemoveDriver(dataManager.Drivers[0]);
        Assert.Equal(2,dataManager.Drivers.Count);
    }

    [Fact]
    public void Test_DataManager_add_driver_persists()
    {
        dataManager.AddDriver(new Driver("new driver"));

        dataManager = null;
        dataManager = new DataManager();

        Assert.Equal(4,dataManager.Drivers.Count);
    }

    [Fact]
    public void Test_DataManager_remove_driver_persists()
    {
        dataManager.RemoveDriver(dataManager.Drivers[0]);

        dataManager = null;
        dataManager = new DataManager();

        Assert.Equal(2,dataManager.Drivers.Count);
    }
}
