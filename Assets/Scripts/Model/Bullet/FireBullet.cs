public class FireBullet : Bullet
{
    public const float TimeAction = 4;

    public void Burn(int healthValue)
    {
        if (healthValue != 0)
            healthValue -= 1;
    }
}
