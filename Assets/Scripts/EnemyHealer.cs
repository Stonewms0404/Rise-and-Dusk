using UnityEngine;

public class EnemyHealer : Enemy
{
    float timer;
    void Update()
    {
        timer += Time.deltaTime;
        (bool isFriendlyNearby, Friendly f) = CheckFriendliesInRadius();
        if (isFriendlyNearby)
        {
            friendly = f;
            MoveTowardsFriendly();
            if (canAttack)
            {
                agent.SetDestination(transform.position);
                if (timer >= stats.attackSpeed)
                {
                    Heal();
                    timer = 0;
                }
            }
            else
                agent.SetDestination(friendly.transform.position);
        }
    }

    void Heal()
    {
        enemy.HealEnemy(stats.damage);
        Destroy(Instantiate(stats.shootParticles, transform.position, Quaternion.identity), 5);
    }
}
