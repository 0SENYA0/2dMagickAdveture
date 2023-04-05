using UnityEngine;

public class PlayerBulletView : MonoBehaviour
{
    [SerializeField] private ScriptableObjectBulletFireBullet _playerFireBullet;
    [SerializeField] private ScriptableObjectIceBullet _playerIceBullet;

    private ScriptableObjectBullet _currentTypeBullet;
    
    private void Awake()
    {
        _currentTypeBullet = _playerIceBullet;
    }

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
                _currentTypeBullet = _playerFireBullet;
                break;
            case IceBullet:
                _currentTypeBullet = _playerIceBullet;
                break;
        }
    }
}
