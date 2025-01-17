
class LightOffCommand(SmartLight smartLight, int id) : ICommand
{
    private readonly SmartLight smartLight = smartLight;
    private readonly int id = id;

    public void Execute()
    {
        smartLight.TurnOFF(id);
    }

    public void Undo()
    {
        smartLight.TurnOn(id);
    }
}
