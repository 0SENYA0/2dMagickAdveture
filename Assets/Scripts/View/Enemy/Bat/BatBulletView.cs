using UnityEngine;

public class BatBulletView : MonoBehaviour
{
    [SerializeField] private ScriptableObjectBulletFireBullet _batFireBullet;
    [SerializeField] private ScriptableObjectIceBullet _batIceBullet;

    private ScriptableObjectBullet _currentTypeBullet;

    private void Awake() =>
        _currentTypeBullet = _batIceBullet;

    public Sprite Sprite => _currentTypeBullet.Sprite;
    public float Speed => _currentTypeBullet.Speed;
    public int Damage => _currentTypeBullet.Damage;
    public int Cooldown => _currentTypeBullet.Cooldown;
    public int LifeTime => _currentTypeBullet.LifeTime;

    public void SetTypeBulletView(Bullet bullet)
    {
        switch (bullet)
        {
            case FireBullet:
                _currentTypeBullet = _batFireBullet;
                break;
            case IceBullet:
                _currentTypeBullet = _batIceBullet;
                break;
        }
    }
}
