
class LightOnCommand(SmartLight light, int id) : ICommand
{
    private readonly SmartLight light = light;
    private readonly int id = id;

    public void Execute()
    {
        light.TurnOn(id);
    }

    public void Undo()
    {
        light.TurnOFF(id);
    }
}
