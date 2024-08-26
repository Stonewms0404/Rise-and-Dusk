using UnityEngine;

public class FriendlyTower : Friendly
{
    [SerializeField] Friendly spawn;
    public int count;

    private void OnEnable()
    {
        DayNightCycle.Cycle += SpawnFriendlies;
    }
    private void OnDisable()
    {
        DayNightCycle.Cycle -= SpawnFriendlies;
    }

    void SpawnFriendlies(bool value)
    {
        if (!value) for (int i = 0; i < count; i++)
        {
            Vector2 offset = (new Vector2(UnityEngine.Random.Range(0, 5f), UnityEngine.Random.Range(0, 5f))).normalized * 2;
            Instantiate(spawn, (Vector2)transform.position + offset, Quaternion.identity);
        }
    }
}
