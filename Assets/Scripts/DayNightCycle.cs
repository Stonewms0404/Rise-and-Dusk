using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayNightCycle : MonoBehaviour
{
    public static event Action<bool> Cycle;

    [SerializeField] Light2D globalLight;
    public bool isDay;

    const float dayLight = 0.8f;
    const float nightLight = 0.01f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && true)
        {
            Cycle?.Invoke(true);
            Debug.Log(isDay);
            isDay = false;
            StartCoroutine(CycleLight());
            return;
        }
    }

    IEnumerator CycleLight()
    {
        var end = Time.time + 1.5f;
        while (Time.time < end)
        {
            globalLight.intensity = Mathf.Lerp(globalLight.intensity, (isDay ? dayLight : nightLight), 3 * Time.deltaTime);
            yield return null;
        }
        globalLight.intensity = isDay ? dayLight : nightLight;
    }
}
