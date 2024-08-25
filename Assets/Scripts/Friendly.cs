using UnityEngine;
using UnityEngine.AI;

public class Friendly : MonoBehaviour
{
    public bool isTower;

    #region Renderer
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    [SerializeField] SpriteRenderer renderer;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    #endregion
    [SerializeField] protected Stats stats;
    [SerializeField] protected NavMeshAgent agent;
    protected Friendly friendly;
    protected Enemy enemy;
    protected bool canAttack;
    protected int health;

    void Awake()
    {
        renderer.sprite = stats.texture;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        health = stats.health;
    }

    protected (bool, Enemy) FindEnemy()
    {
        Enemy[] enemies = GameObject.FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        if (enemies.Length == 1 )
            return (true, enemies[0]);
        if (enemies.Length > 1)
            return (true, enemies[UnityEngine.Random.Range(0, enemies.Length - 1)]);
        return (false, null);
    }
    protected (bool, Friendly) CheckFriendliesInRadius()
    {
        Friendly[] friendlies = GameObject.FindObjectsByType<Friendly>(FindObjectsSortMode.None);
        foreach (Friendly friendly in friendlies)
        {
            if (friendly.isTower) continue;
            float distance = (friendly.transform.position - transform.position).magnitude;
            if (distance <= stats.sightRadius)
                return (true, friendly);
        }
        return (false, null);
    }
    protected void MoveTowardsFriendly()
    {
        float distance = (friendly.transform.position - transform.position).magnitude;
        canAttack = distance <= stats.attackRadius;
        agent.SetDestination(canAttack ? transform.position : friendly.transform.position);
    }
    protected void MoveTowardsEnemy()
    {
        float distance = (enemy.transform.position - transform.position).magnitude;
        canAttack = distance <= stats.attackRadius;
        agent.SetDestination(canAttack ? transform.position : enemy.transform.position);
    }

    void TakeDamage(int value)
    {
        health -= value;
        if (health <= 0)
        {
            var particles = Instantiate(stats.deathParticles, transform.position, Quaternion.identity);
            Destroy(particles, 5f);
            Destroy(gameObject, 0.01f);
        }
        else
        {
            var particles = Instantiate(stats.hurtParticles, transform.position, Quaternion.identity);
            Destroy(particles, 5f);
        }
    }
}
