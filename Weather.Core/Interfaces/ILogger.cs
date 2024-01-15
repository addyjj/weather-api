namespace Weather.Core.Interfaces;

public interface ILogger
{
    void Information(string message);
    void Warning(string message);
    void Error(string message, Exception ex);
    void Debug(string message);
    void CloseAndFlush();
}