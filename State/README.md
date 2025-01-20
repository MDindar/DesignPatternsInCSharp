# State Design Pattern : 
The State Design Pattern allows an object to alter its behavior when its internal state changes. This pattern is especially useful in scenarios where an object's behavior is dependent on its state and it needs to switch states at runtime dynamically.

# Use-cases: 
1. Objects with Dynamic Behavior
Scenario: Objects change behavior or functionality depending on their state.
Examples:
Media players (Playing, Paused, Stopped).
Game characters (Idle, Walking, Running, Jumping).

2. UI Component State Management
Scenario: User interface elements behave differently depending on their state.
Examples:
Button states in a UI (Enabled, Disabled, Hovered, Pressed).
Form submission states (Idle, Validating, Success, Error).
Progress bars or loaders (Idle, Loading, Completed).

3. State Persistence
Scenario: Systems need to persist and restore state (e.g., saving and resuming functionality).
Examples:
Video games saving and loading player progress.
Multi-step form submission resuming after a pause.
Workflow applications restoring the last step after a crash or restart.


## Advantages : 

1.Single Responsibility Principal 
2.Open Closed Principal

## DrawBack: 
Each state need a concrete class
In simple cases , it increase complexity
State Transition become challenging in complex scenario
Each state knows about other state and it has a dependency
Debugging and testing is more complex

# Most Basic Implementation :

```cs
var mobile = new Mobile(new OffState());
mobile.PushPowerButton();
mobile.PushPowerButton();
mobile.PushPowerButton();
mobile.PushPowerButton();

class Mobile(IMobileState initialState)
{
    private IMobileState _state = initialState;

    public void SetState(IMobileState state)
    {
        _state = state;
    }

    public void PushPowerButton()
    {
        _state.Handle(this);
    }
}
interface IMobileState
{
    void Handle(Mobile context);
}

class OffState : IMobileState
{
    public void Handle(Mobile context)
    {
        Console.WriteLine("cellphone turn ON");
        context.SetState(new ONState());
    }
}

class ONState : IMobileState
{
    public void Handle(Mobile context)
    {
        Console.WriteLine("cellphone turn OFF");
        context.SetState(new OffState());

    }
}

```
