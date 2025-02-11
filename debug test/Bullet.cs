abstract class Bullet : MoveableObject
{
    public float damage;

    // when you collide with an enemy, hp is subtracted and you remove the bullet
    public void OnHit(float damage)
    {
        MoveableObject target = CheckCollisions();
        if (target is Enemy)
        {
            target.TakeDamage(damage, target);
            remove = true;
        }
    }
}