
public class Parameter : IParameter
{
    public Parameter(int startValue)
    {
        CurrentValue = startValue;
    }

    public int CurrentValue { get; private set; }

    public void ChangeValue(int value) =>
        CurrentValue += value;
}
