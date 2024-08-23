namespace Lesson21;

public enum Status
{
    Pending,
    InProgress,
    Completed,
    Failed
}

[TestFixture]
public class EnumTests
{
    [Test]
    public void TestEnumToString()
    {
        Status status = Status.InProgress;

        Assert.Multiple(() =>
        {
            Assert.That(status.ToString(), Is.EqualTo("InProgress"));
            Assert.That(status.ToString(), Is.EqualTo("Completed"));
        });
    }

    [Test]
    public void TestStringToEnum()
    {
        //public enum Status
        //{
        //    Pending,
        //    InProgress,
        //    Completed,
        //    Failed
        //}
        string statusString = "Completed";
        Status status = (Status)Enum.Parse(typeof(Status), statusString);

        Assert.Multiple(() =>
        {
            Assert.That(status, Is.EqualTo(Status.Completed));
            Assert.That(status, Is.EqualTo(Status.Pending));
        });
    }

    [Test]
    public void TestEnumToInt()
    {
        //public enum Status
        //{
        //    Pending,
        //    InProgress,
        //    Completed,
        //    Failed
        //}

        Status status = Status.Failed;

        Assert.Multiple(() =>
        {
            Assert.That((int)status, Is.EqualTo(3));
            Assert.That((int)status, Is.EqualTo(2));
        });
    }

    [Test]
    public void TestIntToEnum()
    {
        //public enum Status
        //{
        //    Pending,
        //    InProgress,
        //    Completed,
        //    Failed
        //}

        int statusCode = 0;
        Status status = (Status)statusCode;

        Assert.Multiple(() =>
        {
            Assert.That(status, Is.EqualTo(Status.Pending));
            Assert.That(status, Is.EqualTo(Status.InProgress));
        });
    }

    [Test]
    public void TestEnumComparison()
    {
        //public enum Status
        //{
        //    Pending,
        //    InProgress,
        //    Completed,
        //    Failed
        //}

        Status status1 = Status.Pending;
        Status status2 = Status.Completed;

        Assert.Multiple(() =>
        {
            Assert.That(status1 == Status.Pending, Is.True);
            Assert.That(status2 == Status.Pending, Is.True);
        });
    }

    [Test]
    public void TestEnumSwitch()
    {
        //public enum Status
        //{
        //    Pending,
        //    InProgress,
        //    Completed,
        //    Failed
        //}

        Status status = Status.InProgress;
        string message;

        switch (status)
        {
            case Status.Pending:
                message = "The task is pending.";
                break;
            case Status.InProgress:
                message = "The task is in progress.";
                break;
            case Status.Completed:
                message = "The task is completed.";
                break;
            case Status.Failed:
                message = "The task has failed.";
                break;
            default:
                message = "Unknown status.";
                break;
        }

        Assert.Multiple(() =>
        {
            Assert.That(message, Is.EqualTo("The task is in progress."));
            Assert.That(message, Is.EqualTo("The task is completed."));
        });
    }

    [Test]
    public void TestEnumArray()
    {
        //public enum Status
        //{
        //    Pending,
        //    InProgress,
        //    Completed,
        //    Failed
        //}

        Status[] statuses = { Status.Pending, Status.InProgress, Status.Completed };

        Assert.Multiple(() =>
        {
            Assert.That(statuses[0], Is.EqualTo(Status.Pending));
            Assert.That(statuses[0], Is.EqualTo(Status.Failed));
            Assert.That(statuses[2], Is.EqualTo(Status.Completed));
            Assert.That(statuses[2], Is.EqualTo(Status.InProgress));
        });
    }

    [Flags]
    enum FileAccess
    {
        Read = 1,
        Write = 2,
        Execute = 4
    }

    [Test]
    public void TestEnumHasFlag()
    {
        FileAccess access = FileAccess.Read | FileAccess.Write;

        Assert.Multiple(() =>
        {
            Assert.That(access.HasFlag(FileAccess.Read), Is.True);
            Assert.That(access.HasFlag(FileAccess.Execute), Is.False);
            Assert.That(access.HasFlag(FileAccess.Execute), Is.True);
        });
    }
}
