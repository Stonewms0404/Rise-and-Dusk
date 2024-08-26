using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public static event Action<int> EnemyDeath;

    #region Renderer
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    [SerializeField] SpriteRenderer renderer;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    #endregion
    [SerializeField] protected Stats stats;
    #nullable enable
    [SerializeField] protected NavMeshAgent? agent;
    #nullable disable
    protected Friendly friendly;
    protected Enemy enemy;
    protected bool canAttack;
    [SerializeField] protected int health;

    void Awake()
    {
        renderer.sprite = stats.texture;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = stats.speed;
    }
    private void OnEnable()
    {
        DayNightCycle.Cycle += DestroyEnemies;
    }
    private void OnDisable()
    {
        DayNightCycle.Cycle -= DestroyEnemies;
    }

    private void OnDestroy()
    {
        EnemyDeath?.Invoke(stats.loot);
    }

    private void DestroyEnemies(bool value)
    {
        if (value)
        {
            Instantiate(stats.deathParticles);
            Destroy(gameObject);
        }
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
    protected (bool, Enemy) CheckEnemiesInRadius()
    {
        Enemy[] friendlies = GameObject.FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        foreach (Enemy friendly in friendlies)
        {
            if (friendly.stats.health <= friendly.stats.health * 0.5f) continue;
            float distance = (friendly.transform.position - transform.position).magnitude;
            if (distance <= stats.sightRadius)
                return (true, friendly);
        }
        return (false, null);
    }

    protected (bool, Friendly) FindTower()
    {
        Friendly[] friendlies = GameObject.FindObjectsByType<Friendly>(FindObjectsSortMode.None);
        foreach (Friendly f in friendlies)
        {
            if (!f.isTower) continue;
            return (true, f);
        }
        return (false, null);
    }

    protected void MoveTowardsFriendly()
    {
        float distance = (friendly.transform.position - transform.position).magnitude;
        canAttack = distance <= stats.attackRadius;
        agent.SetDestination(friendly.transform.position);
    }
    protected void MoveTowardsEnemy()
    {
        float distance = (enemy.transform.position - transform.position).magnitude;
        canAttack = distance <= stats.attackRadius;
        agent.SetDestination(canAttack ? transform.position : enemy.transform.position);
    }
    public int TakeDamage(int value)
    {
        health -= value;
        if (health <= 0)
        {
            var particles = Instantiate(stats.deathParticles, transform.position, Quaternion.identity);
            Destroy(particles, 5f);
            Destroy(gameObject, 0.01f);
            return stats.loot;
        }
        else
        {
            var particles = Instantiate(stats.hurtParticles, transform.position, Quaternion.identity);
            Destroy(particles, 5f);
        }
        return 0;
    }

    public void HealEnemy(int value)
    {
        health += value;
    }
}
