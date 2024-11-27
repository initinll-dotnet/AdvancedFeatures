namespace EventAndDelegate;

// Instead of sending tons of delegate parameters, 
// we can use this class to send all the parameters in one object as EventArgs
public class WorkPerformedEventArgs : EventArgs
{
    public int Hours { get; }
    public WorkType WorkType { get; }

    // constructor
    public WorkPerformedEventArgs(int hours, WorkType workType) =>
        (Hours, WorkType) = (hours, workType);
}

public enum WorkType
{
    GoToMeetings,
    Golf,
    GenerateReports
}