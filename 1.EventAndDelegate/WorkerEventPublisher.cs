namespace EventAndDelegate;

// Custom delegate
public delegate void WorkPerformedHandler_CustomDelegate(int hours, WorkType workType);


public class WorkerEventPublisher
{
    // custom event
    public event WorkPerformedHandler_CustomDelegate? WorkPerformed_CustomEvent;

    // or use built-in event generic delegate
    // this method does not need a custom delegate to be defined
    public event EventHandler<WorkPerformedEventArgs>? WorkPerformed_GenericEvent;
    // this converts into delegate internally as below
    // public delegate void EventHandler<TEventArgs>(object? sender, TEventArgs e) where TEventArgs : EventArgs;

    // built-in event
    public event EventHandler? WorkCompleted_Event;

    public void DoWork(int hours, WorkType workType)
    {
        for (int i = 0; i < hours; i++)
        {
            // raises the custom event - WorkPerformed_CustomEvent & WorkPerformed_GenericEvent
            OnWorkPerformed(i + 1, workType);
        }

        // raises the built-in event - WorkCompleted_Event
        OnWorkCompleted();
    }

    // making this overridable so that derived classes can override this method to have custom behavior
    protected virtual void OnWorkPerformed(int hours, WorkType workType)
    {
        Console.WriteLine("-------------------------------");
        Console.WriteLine($"Custom event invoked/raised - Index: {hours}");
        Console.WriteLine("-------------------------------");
        // raise the custom event
        WorkPerformed_CustomEvent?.Invoke(hours, workType);

        // OR 

        Console.WriteLine("-------------------------------");
        Console.WriteLine($"Generic event invoked/raised - Index: {hours}");
        Console.WriteLine("-------------------------------");
        // this method does not need a custom delegate to be defined
        // create an instance of the EventArgs class
        var args = new WorkPerformedEventArgs(hours, workType);
        // raise the built-in event
        WorkPerformed_GenericEvent?.Invoke(this, args);
    }

    protected virtual void OnWorkCompleted()
    {
        // raise the built-in event
        WorkCompleted_Event?.Invoke(this, EventArgs.Empty);
    }
}