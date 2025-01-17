
var lightCommmand1 = new LightOnCommand(new SmartLight(),1);
var lightCommmand2 = new LightOnCommand(new SmartLight(),2);
var thermostatCommand = new ThermostatCommand(new Thermostat(),23);

var goodMorningRoutine = new RoutineInvoker();
goodMorningRoutine.SetCommand(lightCommmand1);
goodMorningRoutine.SetCommand(lightCommmand2);
goodMorningRoutine.SetCommand(thermostatCommand);

goodMorningRoutine.ExecuteCommands();

goodMorningRoutine.UndoCommands();

interface ICommand
{
    void Execute();
    void Undo();
}
