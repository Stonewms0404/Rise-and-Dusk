using UnityEngine;
using System.Collections;
using TMPro;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip[] clipList;
    [SerializeField] TextMeshProUGUI songNameUI;
    private IEnumerator coroutine;
    float delay = 3f;
    int count = 0;

    void Start()
    {
        coroutine = PlayMusic();
        StartCoroutine(coroutine);
    }

    void Update()
    {
        HandleArrayCount();
    }

    void HandleArrayCount()
    {
        if (count > 8) count = 0;
    }

    private IEnumerator PlayMusic()
    {
        while (true)
        {
            source.PlayOneShot(clipList[count]);
            songNameUI.text = clipList[count].name;
            yield return new WaitForSeconds(clipList[count].length + delay); 
            count++;
        }
        
    }
}
