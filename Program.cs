using EventAndDelegate;

// Events and Delegates

DelegateDemo delegateDemo1 = new();
delegateDemo1.Demo(
    message: "Hey there",
    demoCompletedDelegate: DemoComple,
    sendConfirmationDelegate: SendEmail);

void DemoComple()
{
    Console.WriteLine("Demo completed");
}

bool SendEmail(string message)
{
    Console.WriteLine($"Confirmation Email sent: {message}");
    return true;
}

DelegateDemo delegateDemo2 = new();
delegateDemo2.Demo(
    message: "Hello there",
    demoCompletedDelegate: () => Console.WriteLine("Demo completed"),
    sendConfirmationDelegate: bool (string msg) =>
    {
        Console.WriteLine($"Confirmation SMS sent: {msg}");
        return true;
    });

// var workerEventRaiser = new WorkerEventRaiser();
// var workerEventHandler = new WorkerEventHandler(workerEventRaiser);

// workerEventHandler.Subscribe();

// workerEventRaiser.DoWork(8, WorkType.GenerateReports);
// workerEventHandler.Unsubscribe();

// Actions and Funcs
// ProcessData processData = new();

// var del = new SomeDelegate((x, y) => x * y);
// // with delegate 
// processData.Process(2, 3, del);
// // with lambda
// processData.Process(2, 3, (x, y) => x + y);
// // using Action
// processData.ProcessAction(2, 3, (x, y) => Console.WriteLine($"Action: {x + y}"));
// // using Func
// processData.ProcessFunc(2, 3, (x, y) => x - y);

