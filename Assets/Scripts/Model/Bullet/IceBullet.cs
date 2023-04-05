public class IceBullet : Bullet
{
    public const float TimeAction = 3;

    public void Freeze(int moveValue)
    {
        if (moveValue != 0)
            moveValue -= 1;
    }
}
