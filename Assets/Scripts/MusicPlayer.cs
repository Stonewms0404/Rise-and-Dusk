using UnityEngine;
using System.Collections;
using TMPro;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip[] clipList;
    [SerializeField] TextMeshProUGUI songNameUI;
    private IEnumerator coroutine;
    const float delay = 3f;
    int index = -1;

    void Start()
    {
        ShuffleMusic();
        coroutine = PlayMusic();
        StartCoroutine(coroutine);
    }

    void Update()
    {
        HandleArrayCount();
    }

    void HandleArrayCount()
    {
        if (index > 8) index = 0;
    }

    private IEnumerator PlayMusic()
    {
        while (true)
        {
            source.PlayOneShot(clipList[index]);
            songNameUI.text = clipList[index].name;
            yield return new WaitForSeconds(clipList[index].length + delay);
            songNameUI.text = "Shuffling Music";
        }
    }

    void ShuffleMusic()
    {
        while (true)
        {
            int lastIndex = index;
            index = UnityEngine.Random.Range(0, clipList.Length);
            if (index != lastIndex)
                break;
        }
    }
}
