namespace EventAndDelegate;

public class WorkerEventSubscriber
{
    private WorkerEventPublisher _workerEventPublisher { get; set; }
    private EventHandler<WorkPerformedEventArgs> _workPerformed2_GenericEvent_Handler;
    private EventHandler _workCompleted_Handler;

    ~WorkerEventSubscriber()
    {
        Unsubscribe();
    }

    public WorkerEventSubscriber(WorkerEventPublisher workerEventPublisher)
    {
        _workerEventPublisher = workerEventPublisher;
        _workPerformed2_GenericEvent_Handler = new EventHandler<WorkPerformedEventArgs>(WorkPerformed2_GenericEvent);
        _workCompleted_Handler = new EventHandler(WorkCompleted_Handler);
    }

    public void Subscribe()
    {
        // event handler methods
        Console.WriteLine("-------------------------------");
        Console.WriteLine("Subscribing to events");
        Console.WriteLine("-------------------------------");

        _workerEventPublisher.WorkPerformed_CustomEvent += WorkPerformed1_CustomEvent_Handler;
        _workerEventPublisher.WorkPerformed_CustomEvent += WorkPerformed2_CustomEvent_Handler;

        _workerEventPublisher.WorkPerformed_GenericEvent += WorkPerformed1_GenericEvent_Handler;
        _workerEventPublisher.WorkPerformed_GenericEvent += _workPerformed2_GenericEvent_Handler;

        _workerEventPublisher.WorkCompleted_Event += WorkCompleted_Handler;
        _workerEventPublisher.WorkCompleted_Event += _workCompleted_Handler;

        // lambda expression
        // not recommended to use lambda expression as it is difficult to unsubscribe
        _workerEventPublisher.WorkCompleted_Event += (object? sender, EventArgs e) =>
        {
            Console.WriteLine("WorkCompleted called using lambda expression");
        };
    }

    public void Unsubscribe()
    {
        Console.WriteLine("-------------------------------");
        Console.WriteLine("Unsubscribing to events");
        Console.WriteLine("-------------------------------");

        _workerEventPublisher.WorkPerformed_CustomEvent -= WorkPerformed1_CustomEvent_Handler;
        _workerEventPublisher.WorkPerformed_CustomEvent -= WorkPerformed2_CustomEvent_Handler;

        _workerEventPublisher.WorkPerformed_GenericEvent -= WorkPerformed1_GenericEvent_Handler;
        _workerEventPublisher.WorkPerformed_GenericEvent -= _workPerformed2_GenericEvent_Handler;

        _workerEventPublisher.WorkCompleted_Event -= WorkCompleted_Handler;
        _workerEventPublisher.WorkCompleted_Event -= _workCompleted_Handler;
        // lambda expression
        // this is not possible to unsubscribe
        _workerEventPublisher.WorkCompleted_Event -= (object? sender, EventArgs e) =>
        {
            Console.WriteLine("WorkCompleted called using lambda expression");
        };
    }

    private void WorkPerformed1_CustomEvent_Handler(int hours, WorkType workType)
    {
        Console.WriteLine($"Custom event 1 handled - Index: {hours}");
    }

    private void WorkPerformed2_CustomEvent_Handler(int hours, WorkType workType)
    {
        Console.WriteLine($"Custom event 2 handled - Index: {hours}");
    }

    private void WorkPerformed1_GenericEvent_Handler(object? sender, WorkPerformedEventArgs e)
    {
        Console.WriteLine($"Generic event 1 handled - Index: {e.Hours} hours of {e.WorkType}");
    }

    private void WorkPerformed2_GenericEvent(object? sender, WorkPerformedEventArgs e)
    {
        Console.WriteLine($"Generic event 2 handled - Index: {e.Hours} hours of {e.WorkType}");
    }

    private void WorkCompleted_Handler(object? sender, EventArgs e)
    {
        Console.WriteLine("\nWorkCompleted called");
    }
}