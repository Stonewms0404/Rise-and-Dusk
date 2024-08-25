using UnityEngine;

public class EnemyHealer : Enemy
{
    void Update()
    {
        (bool isFriendlyNearby, Enemy e) = CheckEnemiesInRadius();
        if (isFriendlyNearby)
        {
            enemy = e;
            MoveTowardsEnemy();
        }
        if (canAttack)
        {
            agent.SetDestination(transform.position);
            Heal();
        }
        else
            agent.SetDestination(friendly.transform.position);
    }

    void Heal()
    {

    }
}
