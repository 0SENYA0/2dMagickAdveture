using UnityEngine;

public abstract class HealthPresenter : MonoBehaviour
{
    public abstract void ApplyDamage(int damage);
    public abstract void Heal(int damage);
}
