using UnityEngine;

public class ScriptableObjectBullet : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private int _cooldown;
    [SerializeField] private int _lifeTime;

    public Sprite Sprite => _sprite;
    public float Speed => _speed;
    public int Damage => _damage;
    public int Cooldown => _cooldown;
    public int LifeTime => _lifeTime;
}
