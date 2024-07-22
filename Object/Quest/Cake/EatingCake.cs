using System;
using System.Collections;
using UnityEngine;
public class EatingCake : MonoBehaviour
{
    private int _durability = 5;
    private AudioSource _eatingAudio;

    private LayerMask _interactedLayer;
    private LayerMask _defaultLayer;

    public static event Action OnCakeDestroy;
    public static event Action<bool> WindowEvent;
    private void Start()
    {
        _eatingAudio = GetComponent<AudioSource>();

        _interactedLayer = LayerMask.NameToLayer("Interacted");
        gameObject.layer = _interactedLayer;
        gameObject.tag = "Cake";

        _defaultLayer = LayerMask.NameToLayer("Default");
    }
    public void Eating()
    {
        StartCoroutine(EatingCoroutine());
    }
    private IEnumerator EatingCoroutine()
    {
        gameObject.layer = _defaultLayer;

        _eatingAudio.Play();

        yield return new WaitForSeconds(_eatingAudio.clip.length);

        _durability--;

        gameObject.layer = _interactedLayer;
        if (_durability == 4)
        {
            WindowEvent?.Invoke(false);
        }
        else if (_durability == 2)
        {
            WindowEvent?.Invoke(true);
        }
        else if (_durability == 0)
        {
            OnCakeDestroy?.Invoke();

            gameObject.layer = _defaultLayer;

            Destroy(gameObject);
        }
    }
}