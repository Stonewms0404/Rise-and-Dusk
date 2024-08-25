using UnityEngine;

[CreateAssetMenu(fileName = "TowerStats", menuName = "Scriptable Objects/TowerStats")]
public class Stats : ScriptableObject
{
    public int health, damage;
    public float speed, attackSpeed, sightRadius, attackRadius;
    public Sprite texture;
}
