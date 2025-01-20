
var player = new MusicPlayer();
player.Play();
player.IncreaseVolume(70);
player.Pause();
player.DecreaseVolume(30);
player.Pause();
player.Stop();
player.Play();
player.IncreaseVolume(20);
class MusicPlayer
{
    private IState _state = new StoppedState();
    private int _volume = 70;

    public int Volume
    {
        get => _volume;
        set => _volume = Math.Clamp(value,0,100);
    }
    public void SetState(IState state)
    {
        _state = state;
    }

    public void IncreaseVolume(int amount)
    {
        _state.IncreaseVolume(this, amount);
    }
    public void DecreaseVolume(int amount)
    {
        _state.DecreaseVolume(this,amount);
    }
    public void Play()
    {
        _state.Play(this);
    }
    public void Pause()
    {
        _state.Pause(this);
    }
    public void Stop()
    {
        _state.Stop(this);
    }
}
interface IState
{
    void Play(MusicPlayer context);
    void Pause(MusicPlayer context);
    void Stop(MusicPlayer context);

    void IncreaseVolume(MusicPlayer context, int amount);
    void DecreaseVolume(MusicPlayer context, int amount);
}
class StoppedState : IState
{
    public StoppedState()=>Console.WriteLine($"{GetType().Name} : ");
    public void DecreaseVolume(MusicPlayer context, int amount)
    {
       
    }

    public void IncreaseVolume(MusicPlayer context, int amount)
    {
        
    }

    public void Pause(MusicPlayer context)
    {
        Console.WriteLine("Music is already stopped");
    }

    public void Play(MusicPlayer context)
    {
        Console.WriteLine("Music starts playing....");
        context.SetState(new PlayingState());
    }


    public void Stop(MusicPlayer context)
    {
        Console.WriteLine("Music is already stopped");
    }
}

class PausedState : IState
{
    public PausedState()=>Console.WriteLine($"{GetType().Name} : ");
    public void DecreaseVolume(MusicPlayer context, int amount)
    {
        
    }

    public void IncreaseVolume(MusicPlayer context, int amount)
    {
        
    }

    public void Pause(MusicPlayer context)
    {
        Console.WriteLine("Music is already paused");
    }

    public void Play(MusicPlayer context)
    {
        Console.WriteLine("Musc Start Playing from previous location");
        context.SetState(new PlayingState());
    }

    public void Stop(MusicPlayer context)
    {
        Console.WriteLine("Music stopped and set to the beginning of the music");
        context.SetState(new StoppedState());
    }
}

class PlayingState : IState
{
    public PlayingState()=>Console.WriteLine($"{GetType().Name} : ");
    public void DecreaseVolume(MusicPlayer context, int amount)
    {
       context.Volume -=amount;
       Console.WriteLine($"Volume Decreased and set to {context.Volume}");
    }

    public void IncreaseVolume(MusicPlayer context, int amount)
    {
             context.Volume +=amount;
       Console.WriteLine($"Volume Increased and set to {context.Volume}");
    }

    public void Pause(MusicPlayer context)
    {
        Console.WriteLine("Music is paused in this specific location");
        context.SetState(new PausedState());
    }

    public void Play(MusicPlayer context)
    {
        Console.WriteLine("Music is alreay playing ..");
    }

    public void Stop(MusicPlayer context)
    {
        Console.WriteLine("Music stopped and goes to the beginning of the music");
        context.SetState(new StoppedState());
    }
}
