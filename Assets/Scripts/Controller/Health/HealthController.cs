using UnityEngine;

public abstract class HealthController : MonoBehaviour
{
    public abstract void ApplyDamage(int damage);
    public abstract void Heal(int damage);
}
