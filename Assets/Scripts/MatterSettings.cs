

public class MatterSettings
{

    public MatterType type;
    public MatterPhase phase;

    public MatterSettings(MatterType type, MatterPhase phase)
    {
        this.type = type;
        this.phase = phase;
    }

}

public enum MatterType
{
    A,
    B,
    C,
    D,
    E,
}

public enum MatterPhase
{
    Circle,
    Square,
    Triangle
}