namespace EventAndDelegate;

public class DelegateDemo
{
    public delegate bool SendConfirmationDelegate(string message);
    public delegate void DemoCompletedDelegate();

    public void Demo(
        string message,
        DemoCompletedDelegate demoCompletedDelegate = default,
        SendConfirmationDelegate sendConfirmationDelegate = default)
    {
        var delegate1 = new WorkPerformedHandler_CustomDelegate(WorkPerformed1);
        var delegate2 = new WorkPerformedHandler_CustomDelegate(WorkPerformed2);

        // multicast delegate
        delegate1 += delegate2;

        // lamda expression
        delegate1 += (hours, workType) =>
        {
            Console.WriteLine($"WorkPerformed3 called with {hours} hours of {workType}");
        };

        Console.WriteLine("Invoking delegates");

        // one way of invoking the delegate
        // thi will invoke 3 times - WorkPerformed1, WorkPerformed2, WorkPerformed3
        delegate1(8, WorkType.GenerateReports);

        // another way of invoking the delegate
        // this will invoke 3 times - WorkPerformed1, WorkPerformed2, WorkPerformed3
        delegate1?.Invoke(6, WorkType.Golf);

        // invoked the delegate, implemenatation provided by the caller
        demoCompletedDelegate?.Invoke();

        // invoked the delegate, implemenatation provided by the caller
        bool? result = sendConfirmationDelegate?.Invoke(message);

        if (result?.Equals(true) ?? false)
        {
            Console.WriteLine("Confirmation sent");
        }
        else
        {
            Console.WriteLine("Confirmation not sent");
        }
    }

    private void WorkPerformed1(int hours, WorkType workType)
    {
        Console.WriteLine($"WorkPerformed1 called with {hours} hours of {workType}");
    }

    private void WorkPerformed2(int hours, WorkType workType)
    {
        Console.WriteLine($"WorkPerformed2 called with {hours} hours of {workType}");
    }
}