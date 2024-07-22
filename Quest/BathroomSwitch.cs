using System;
using System.Collections;
using UnityEngine;

public class BathroomSwitch : MonoBehaviour
{
    public static event Action OnBathroomChange;

    [SerializeField] private GameObject _bathroom;
    [SerializeField] private GameObject _ruinedBathroom;

    [SerializeField] private GameObject _bounds;
    [SerializeField] private GameObject _window;
    [SerializeField] private GameObject _lamp;

    private void Start()
    {
        WashingMachine.ActivateHorrorRadio += StartCoroutines;
    }

    private IEnumerator ChangeBathroom()
    {
        Flashlight.CanLight = false;
        _lamp.SetActive(false);

        yield return new WaitForSeconds(0.1f);

        _bathroom.SetActive(false);
        _ruinedBathroom.SetActive(true);
    }

    private void StartCoroutines()
    {
        StartCoroutine(ChangeBathroom());
        StartCoroutine(DisableBounds());
    }

    private IEnumerator DisableBounds()
    {
        yield return new WaitForSeconds(8);

        _bounds.SetActive(false);
        _window.SetActive(false);

        Flashlight.CanLight = true;

        OnBathroomChange?.Invoke();
    }


    private void OnDestroy()
    {
        WashingMachine.ActivateHorrorRadio -= StartCoroutines;
    }
}
