using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _startHealth;
    [SerializeField] private int _cooldown;
    [SerializeField] private int _startMana;

    [SerializeField] private BulletSpawnController _bulletSpawnController;
    [SerializeField] private PlayerHealthController _playerHealthController;
    [SerializeField] private PlayerBulletView _playerBulletView;
    [SerializeField] private Transform _backPoint;
    [SerializeField] private Transform _forwardPoint;

    public Player Player => _player;
    public Transform BackPoint => _backPoint;
    public Transform ForwardPoint => _forwardPoint;
    public int FullMana => _fullMana;
    public int FullHealth => _fullhealth;
    public int CurrentBulletCoodown { get; private set; }
    public int CurrentBulletDamage { get; private set; }
    
    private Player _player;
    private int _fullMana;
    private int _fullhealth;
    
    private void Awake()
    {
        _player = new Player(_startHealth, _startMana);
        _fullMana = _startMana;
        _fullhealth = _startHealth;
        SetFireBullet();
    }

    private void OnEnable()
    {
        _playerHealthController.Damaged += OnDamaged;
    }

    private void OnDisable()
    {
        _playerHealthController.Damaged -= OnDamaged;
    }

    public void ChangeMaxMana(int addedValue) =>
        _fullMana += addedValue;

    public void ChangeMaxHealth(int addedValue) =>
        _fullMana += addedValue;

    public void SetFireBullet()
    {
        _player.SetTypeBullet(typeof(FireBullet));
        _player.Spell.ChangeCooldownValue((int)_player.Spell.Cooldown);
        _player.Spell.ChangeBulletDamage(_player.Spell.GetDamage());

        _bulletSpawnController.SetBullet(_player.GetBullet(typeof(FireBullet)));
    }

    public void SetIceBullet()
    {
        _player.SetTypeBullet(typeof(IceBullet));
        _player.Spell.ChangeCooldownValue((int)_player.Spell.Cooldown);
        _player.Spell.ChangeBulletDamage(_player.Spell.GetDamage());

        _bulletSpawnController.SetBullet(_player.GetBullet(typeof(IceBullet)));
    }

    public void ChangeBulletDamage(int damage) =>
        _player.Spell.ChangeBulletDamage(damage);

    public void ChangeBulletCooldown(int cooldown) =>
        _player.Spell.ChangeCooldownValue(cooldown);

    private void SpawnBullet() =>
        _bulletSpawnController.Atack();

    private void OnDamaged(int damage)
    {
        if (_playerHealthController.CurrentValue <= 0)
            Die();
    }

    public void Die()
    {
        Debug.Log("игрок умер");
    }
}
