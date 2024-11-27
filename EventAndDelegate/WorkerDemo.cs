namespace EventAndDelegate;

public class WorkerEventDemo
{
    public static void Execute()
    {
        var eventPublisher = new WorkerEventPublisher();
        var eventSubscriber = new WorkerEventSubscriber(eventPublisher);

        eventSubscriber.Subscribe();

        eventPublisher.DoWork(8, WorkType.GenerateReports);
        eventSubscriber.Unsubscribe();
    }
}