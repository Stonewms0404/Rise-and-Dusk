using System;
using UnityEngine;

public class BuildingArea : MonoBehaviour
{
    public static event Action<bool> ToggleShop;

    [SerializeField] FriendlyTower[] towers;
    [SerializeField] int[] costs;
    [SerializeField] Wallet wallet;

    void BuyTower(int value)
    {
        if (wallet.Transaction(costs[value]))
        {
            Instantiate(towers[value], transform.position, Quaternion.identity);
            ToggleShop(false);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ToggleShop(true);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        ToggleShop(false);
    }
}
