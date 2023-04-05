public class PlayerMana
{
    private readonly IParameter _mana;

    public PlayerMana(IParameter mana) =>
        _mana = mana;

    public int Mana => _mana.CurrentValue;

    public void Use(int usedValue) =>
        _mana.ChangeValue(-usedValue);

    public void Recharge(int rechargeValue) =>
        _mana.ChangeValue(rechargeValue);
}
