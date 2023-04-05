using UnityEngine;

public class Tablet : IHeal
{
    public int GetRandomValue() =>
        Random.Range(5, 10);

    public int Heal()
    {
        return GetRandomValue();
    }
}
