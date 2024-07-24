using System;
using System.Collections;
using UnityEngine;

public class FinalQuest : MonoBehaviour
{
    public static event Action BlackScreen;

    private void Start()
    {
        HorrorAudioPayer.AudioTrigger += Manager;
    }

    private void Manager(float time)
    {
        StartCoroutine(Timer(time));
    }

    private IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time - 0.5f);

        BlackScreen?.Invoke();
    }

    private void OnDestroy()
    {
        HorrorAudioPayer.AudioTrigger -= Manager;
    }
}
