using System;
using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private AudioSource _doorAudio;
    public static event Action BlackScreenActivate;

    private IEnumerator OnDoorOpenCoroutine()
    {
        _doorAudio.enabled = true;
        BlackScreenActivate?.Invoke();
        yield return new WaitForSeconds(5f);
        SceneManagerScript.LoadHouse();
    }
    public void OnDoorOpen()
    {
        StartCoroutine(OnDoorOpenCoroutine());
    }
}
