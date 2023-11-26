using AmusementPark.Interfaces;

public class Logger : ILogger
{
    public event Action<string> LogEvent;

    public void Log(string message)
    {
        LogEvent?.Invoke($"{DateTime.Now:G} - {message}");
    }
}