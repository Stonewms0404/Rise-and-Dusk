using UnityEngine;

public class FriendlyHealer : Friendly
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
        }
        if (canAttack)
        {
            agent.SetDestination(transform.position);
            if (timer >= 1)
            {
                Heal();
                timer = 0;
            }
            
        }
        else
            agent.SetDestination(friendly.transform.position);
    }

    void Heal()
    {
        friendly.health += stats.damage;
    }
}
