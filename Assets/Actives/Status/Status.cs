
public class Status
{
    public readonly bool hasBuffIcon;
    public readonly bool altersStats;
    public readonly bool hasActiveComponent;
    public readonly bool hasTurnDuration;
    private bool complete { get => complete; set => complete = value; }

    public Status(bool altersStats, bool hasActiveComponent, bool hasTurnDuration, bool hasBuffIcon)
    {
        complete = false;
        this.altersStats = altersStats;
        this.hasActiveComponent = hasActiveComponent;
        this.hasTurnDuration = hasTurnDuration;
        this.hasBuffIcon = hasBuffIcon;
    }

    public abstract void update();
    public abstract void remove();
}