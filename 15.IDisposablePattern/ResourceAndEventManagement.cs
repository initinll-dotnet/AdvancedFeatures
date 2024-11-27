namespace IDisposablePattern;

public class EventPublisher
{
    public event EventHandler? Notify;

    public void RaiseEvent()
    {
        Console.WriteLine("Raising event...");
        Notify?.Invoke(this, EventArgs.Empty);
    }
}

public class ResourceManager : IDisposable, IAsyncDisposable
{
    private readonly FileStream _fileStream;
    private readonly EventPublisher _publisher;

    public ResourceManager(string filePath, EventPublisher publisher)
    {
        _fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
        _publisher = publisher;
        _publisher.Notify += OnEventReceived;
        Console.WriteLine("Resources initialized and event subscribed.");
    }

    public void WriteToFile(string content)
    {
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(content);
        _fileStream.Write(bytes, 0, bytes.Length);
        Console.WriteLine("Content written to file.");
    }

    private void OnEventReceived(object? sender, EventArgs e)
    {
        Console.WriteLine("Event received and handled.");
    }

    public void Dispose()
    {
        _publisher.Notify -= OnEventReceived;
        _fileStream?.Dispose();
        Console.WriteLine("Resources released and unsubscribed from event (Dispose).");
    }

    public async ValueTask DisposeAsync()
    {
        _publisher.Notify -= OnEventReceived;
        if (_fileStream is not null)
        {
            await _fileStream.DisposeAsync();
        }
        Console.WriteLine("Resources released and unsubscribed from event (DisposeAsync).");
    }

    // Finalizer (not recommended for resource cleanup)
    ~ResourceManager()
    {
        // This will only run if Dispose was not called.
        // Resource cleanup in finalizers is discouraged due to performance costs.
        // Finalizer will only be called if the garbage collector runs is capable of collecting the object!
        Console.WriteLine("Finalizer called. Clean up non-managed resources here.");
        Dispose();
    }
}

public class ResourceAndEventManagement
{
    public static async Task Execute()
    {
        var publisher = new EventPublisher();

        // Using IDisposable with synchronous resource management
        using (var resourceManager = new ResourceManager("example_sync.txt", publisher))
        {
            resourceManager.WriteToFile("Hello, IDisposable with events!");
            publisher.RaiseEvent();
        }

        // Using IAsyncDisposable with asynchronous resource management
        await using (var asyncResourceManager = new ResourceManager("example_async.txt", publisher))
        {
            asyncResourceManager.WriteToFile("Hello, IAsyncDisposable with events!");
            publisher.RaiseEvent();
        }

        publisher.RaiseEvent();  // No event handling since resources are disposed
        Console.WriteLine("End of program.");
    }
}
