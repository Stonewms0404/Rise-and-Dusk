using UnityEngine;

public class EnemyTank : Enemy
{
    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        (bool isFriendlyNearby, Friendly f) = CheckFriendliesInRadius();
        if (isFriendlyNearby)
        {
            friendly = f;
            MoveTowardsEnemy();
            if (canAttack)
            {
                if (timer >= stats.attackSpeed)
                {
                    timer = 0;
                    Attack();
                }
            }
        }
    }

    void Attack()
    {
        friendly.TakeDamage(stats.damage);
        Destroy(Instantiate(stats.shootParticles, transform.position, Quaternion.identity), 5);
    }
}
