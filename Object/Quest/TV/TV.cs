using UnityEngine;

public class TV : MonoBehaviour
{
    [SerializeField] private GameObject _noise;

    private void Start()
    {
        Sofa.OnSofaSeat += SwitchOnTV;
    }

    private void SwitchOnTV()
    {
        Sofa.OnSofaSeat -= SwitchOnTV;

        _noise.SetActive(true);
    }

    private void OnDestroy()
    {
        Sofa.OnSofaSeat -= SwitchOnTV;
    }
}
