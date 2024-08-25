using System;
using UnityEngine;

public class BuildingArea : MonoBehaviour
{
    public static event Action<bool, GameObject> ToggleShop;

    void OnTriggerEnter2D(Collider2D collision)
    {
        ToggleShop(true, gameObject);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        ToggleShop(false, null);
    }
}
