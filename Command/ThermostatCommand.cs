

class ThermostatCommand(Thermostat thermostat, int temprature) : ICommand
{
    private readonly Thermostat thermostat = thermostat;
    private readonly int temprature = temprature;

    public void Execute()
    {
        thermostat.SetTemprature(temprature);
    }

    public void Undo()
    {
        thermostat.Reset();
    }
}
