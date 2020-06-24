using System.Collections.Generic;

namespace HomeAutio.Mqtt.GoogleHome.Models
{
    /// <summary>
    /// Device type enumeration.
    /// </summary>
    public static class DeviceMetadata
    {
        /// <summary>
        /// Device supported traits.
        /// </summary>
        public static IDictionary<DeviceType, IList<TraitType>> SupportedTraits => new Dictionary<DeviceType, IList<TraitType>>
        {
            { DeviceType.AirConditioningUnit, new List<TraitType> { TraitType.FanSpeed, TraitType.OnOff, TraitType.TemperatureSetting } },
            { DeviceType.AirCooler, new List<TraitType> { TraitType.FanSpeed, TraitType.HumiditySetting, TraitType.Modes, TraitType.OnOff, TraitType.TemperatureSetting, TraitType.Toggles } },
            { DeviceType.AirFreshener, new List<TraitType> { TraitType.Modes, TraitType.OnOff, TraitType.Toggles } },
            { DeviceType.AirPurifier, new List<TraitType> { TraitType.FanSpeed, TraitType.Modes, TraitType.OnOff, TraitType.SensorState, TraitType.Toggles } },
            { DeviceType.Awning, new List<TraitType> { TraitType.Modes, TraitType.OpenClose } },
            { DeviceType.Bathtub, new List<TraitType> { TraitType.Fill, TraitType.OnOff } },
            { DeviceType.Bed, new List<TraitType> { TraitType.Modes, TraitType.Scene, TraitType.Toggles } },
            { DeviceType.Blender, new List<TraitType> { TraitType.Cook, TraitType.Modes, TraitType.OnOff, TraitType.StartStop, TraitType.Timer, TraitType.Toggles } },
            { DeviceType.Blinds, new List<TraitType> { TraitType.Modes, TraitType.OpenClose, TraitType.Rotation } },
            { DeviceType.Boiler, new List<TraitType> { TraitType.Modes, TraitType.OnOff, TraitType.Toggles, TraitType.TemperatureControl } },
            { DeviceType.Camera, new List<TraitType> { TraitType.CameraStream } },
            { DeviceType.CarbonMonoxideDetector, new List<TraitType> { TraitType.SensorState } },
            { DeviceType.Charger, new List<TraitType> { TraitType.EnergyStorage } },
            { DeviceType.Closet, new List<TraitType> { TraitType.OpenClose } },
            { DeviceType.CoffeeMaker, new List<TraitType> { TraitType.Cook, TraitType.Modes, TraitType.OnOff, TraitType.TemperatureControl, TraitType.Toggles } },
            { DeviceType.Cooktop, new List<TraitType> { TraitType.Cook, TraitType.Modes, TraitType.OnOff, TraitType.StartStop, TraitType.Timer, TraitType.Toggles } },
            { DeviceType.Curtain, new List<TraitType> { TraitType.OpenClose } },
            { DeviceType.Dehumidifier, new List<TraitType> { TraitType.FanSpeed, TraitType.HumiditySetting, TraitType.Modes, TraitType.OnOff, TraitType.RunCycle, TraitType.StartStop, TraitType.Toggles } },
            { DeviceType.Dehydrator, new List<TraitType> { TraitType.Cook, TraitType.Modes, TraitType.OnOff, TraitType.StartStop, TraitType.Timer, TraitType.Toggles } },
            { DeviceType.Dishwasher, new List<TraitType> { TraitType.Modes, TraitType.OnOff, TraitType.RunCycle, TraitType.StartStop, TraitType.Toggles } },
            { DeviceType.Door, new List<TraitType> { TraitType.OpenClose } },
            { DeviceType.Drawer, new List<TraitType> { TraitType.OpenClose } },
            { DeviceType.Dryer, new List<TraitType> { TraitType.Modes, TraitType.OnOff, TraitType.RunCycle, TraitType.StartStop, TraitType.Toggles } },
            { DeviceType.Fan, new List<TraitType> { TraitType.FanSpeed, TraitType.Modes, TraitType.OnOff, TraitType.Toggles } },
            { DeviceType.Faucet, new List<TraitType> { TraitType.Dispense, TraitType.Modes, TraitType.OnOff, TraitType.StartStop } },
            { DeviceType.Fireplace, new List<TraitType> { TraitType.Modes, TraitType.OnOff, TraitType.Toggles } },
            { DeviceType.Freezer, new List<TraitType> { TraitType.Modes, TraitType.OnOff, TraitType.TemperatureControl, TraitType.Toggles } },
            { DeviceType.Fryer, new List<TraitType> { TraitType.Cook, TraitType.Modes, TraitType.OnOff, TraitType.StartStop, TraitType.Timer, TraitType.Toggles } },
            { DeviceType.GarageDoor, new List<TraitType> { TraitType.OpenClose } },
            { DeviceType.Gate, new List<TraitType> { TraitType.OpenClose } },
            { DeviceType.Grill, new List<TraitType> { TraitType.Cook, TraitType.Modes, TraitType.OnOff, TraitType.StartStop, TraitType.Timer, TraitType.Toggles } },
            { DeviceType.Heater, new List<TraitType> { TraitType.FanSpeed, TraitType.OnOff, TraitType.TemperatureSetting } },
            { DeviceType.Hood, new List<TraitType> { TraitType.FanSpeed, TraitType.Modes, TraitType.OnOff, TraitType.Toggles } },
            { DeviceType.Humidifier, new List<TraitType> { TraitType.FanSpeed, TraitType.HumiditySetting, TraitType.Modes, TraitType.OnOff, TraitType.StartStop, TraitType.Toggles } },
            { DeviceType.Kettle, new List<TraitType> { TraitType.Modes, TraitType.OnOff, TraitType.TemperatureControl, TraitType.Toggles } },
            { DeviceType.Light, new List<TraitType> { TraitType.Brightness, TraitType.ColorSetting, TraitType.OnOff } },
            { DeviceType.Lock, new List<TraitType> { TraitType.LockUnlock } },
            { DeviceType.MediaRemote, new List<TraitType> { TraitType.AppSelector, TraitType.InputSelector, TraitType.MediaState, TraitType.OnOff, TraitType.Toggles, TraitType.TransportControl, TraitType.Volume } },
            { DeviceType.Mop, new List<TraitType> { TraitType.Dock, TraitType.Locator, TraitType.Modes, TraitType.OnOff, TraitType.RunCycle, TraitType.StartStop, TraitType.Toggles } },
            { DeviceType.Mower, new List<TraitType> { TraitType.Dock, TraitType.Locator, TraitType.Modes, TraitType.OnOff, TraitType.RunCycle, TraitType.StartStop, TraitType.Toggles } },
            { DeviceType.Microwave, new List<TraitType> { TraitType.Cook, TraitType.Modes, TraitType.OnOff, TraitType.StartStop, TraitType.Timer, TraitType.Toggles } },
            { DeviceType.Multicooker, new List<TraitType> { TraitType.Cook, TraitType.Modes, TraitType.OnOff, TraitType.StartStop, TraitType.Timer, TraitType.Toggles } },
            { DeviceType.Network, new List<TraitType> { TraitType.Modes, TraitType.Toggles, TraitType.Reboot, TraitType.SoftwareUpdate, TraitType.NetworkControl } },
            { DeviceType.Outlet, new List<TraitType> { TraitType.OnOff } },
            { DeviceType.Oven, new List<TraitType> { TraitType.Cook, TraitType.Modes, TraitType.OnOff, TraitType.StartStop, TraitType.TemperatureControl, TraitType.Toggles } },
            { DeviceType.Pergola, new List<TraitType> { TraitType.OpenClose, TraitType.Rotation } },
            { DeviceType.PetFeeder, new List<TraitType> { TraitType.Dispense, TraitType.Modes, TraitType.OnOff, TraitType.StartStop, TraitType.Toggles } },
            { DeviceType.PressureCooker, new List<TraitType> { TraitType.Cook, TraitType.Modes, TraitType.OnOff, TraitType.StartStop, TraitType.Timer, TraitType.Toggles } },
            { DeviceType.Radiator, new List<TraitType> { TraitType.Modes, TraitType.OnOff, TraitType.Toggles } },
            { DeviceType.Refrigerator, new List<TraitType> { TraitType.Modes, TraitType.OnOff, TraitType.TemperatureControl, TraitType.Toggles } },
            { DeviceType.Router, new List<TraitType> { TraitType.Modes, TraitType.Toggles, TraitType.Reboot, TraitType.SoftwareUpdate, TraitType.NetworkControl } },
            { DeviceType.Scene, new List<TraitType> { TraitType.Scene } },
            { DeviceType.Sensor, new List<TraitType> { TraitType.HumiditySetting, TraitType.Modes, TraitType.OnOff, TraitType.SensorState } },
            { DeviceType.SecuritySystem, new List<TraitType> { TraitType.ArmDisarm, TraitType.SensorState, TraitType.StatusReport } },
            { DeviceType.SetTopBox, new List<TraitType> { TraitType.AppSelector, TraitType.Channel, TraitType.InputSelector, TraitType.MediaState, TraitType.OnOff, TraitType.TransportControl, TraitType.Volume } },
            { DeviceType.Shutter, new List<TraitType> { TraitType.Modes, TraitType.OpenClose, TraitType.Rotation } },
            { DeviceType.Shower, new List<TraitType> { TraitType.Modes, TraitType.OnOff, TraitType.StartStop, TraitType.TemperatureControl } },
            { DeviceType.SmokeDetector, new List<TraitType> { TraitType.SensorState } },
            { DeviceType.SousVide, new List<TraitType> { TraitType.Cook, TraitType.Modes, TraitType.OnOff, TraitType.StartStop, TraitType.Timer, TraitType.Toggles } },
            { DeviceType.Sprinkler, new List<TraitType> { TraitType.StartStop } },
            { DeviceType.StandMixer, new List<TraitType> { TraitType.Cook, TraitType.Modes, TraitType.OnOff, TraitType.StartStop, TraitType.Toggles } },
            { DeviceType.Switch, new List<TraitType> { TraitType.OnOff } },
            { DeviceType.Television, new List<TraitType> { TraitType.AppSelector, TraitType.Channel, TraitType.InputSelector, TraitType.MediaState, TraitType.Modes, TraitType.OnOff, TraitType.Toggles, TraitType.TransportControl, TraitType.Volume } },
            { DeviceType.Thermostat, new List<TraitType> { TraitType.TemperatureSetting } },
            { DeviceType.Vacuum, new List<TraitType> { TraitType.Dock, TraitType.Modes, TraitType.OnOff, TraitType.StartStop, TraitType.Toggles } },
            { DeviceType.Valve, new List<TraitType> { TraitType.OpenClose } },
            { DeviceType.Washer, new List<TraitType> { TraitType.Modes, TraitType.OnOff, TraitType.RunCycle, TraitType.StartStop, TraitType.Toggles } },
            { DeviceType.WaterHeater, new List<TraitType> { TraitType.Modes, TraitType.OnOff, TraitType.TemperatureControl, TraitType.Toggles } },
            { DeviceType.WaterPurifier, new List<TraitType> { TraitType.Modes, TraitType.OnOff, TraitType.SensorState, TraitType.Toggles } },
            { DeviceType.WaterSoftener, new List<TraitType> { TraitType.Modes, TraitType.OnOff, TraitType.SensorState, TraitType.Toggles } },
            { DeviceType.Window, new List<TraitType> { TraitType.LockUnlock, TraitType.OpenClose } },
            { DeviceType.YogurtMaker, new List<TraitType> { TraitType.Cook, TraitType.Modes, TraitType.OnOff, TraitType.StartStop, TraitType.Timer, TraitType.Toggles } },
        };
    }
}