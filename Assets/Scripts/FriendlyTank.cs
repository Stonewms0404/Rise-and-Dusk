using UnityEngine;

public class FriendlyTank : Friendly
{
    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        (bool isFriendlyNearby, Enemy f) = FindEnemy();
        if (isFriendlyNearby)
        {
            enemy = f;
            MoveTowardsEnemy();
            if (canAttack)
            {
                agent.SetDestination(transform.position);
                if (timer >= stats.attackSpeed)
                {
                    timer = 0;
                    Attack();
                }
            }
            else
                agent.SetDestination(enemy.transform.position);
        }

    }

    void Attack()
    {
        enemy.TakeDamage(stats.damage);
        Destroy(Instantiate(stats.shootParticles, transform.position, Quaternion.identity), 5);
    }
}
