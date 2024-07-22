using UnityEngine;

public class DevsLight : MonoBehaviour
{
    [SerializeField] private GameObject _light;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            _light.gameObject.SetActive(!_light.activeSelf);
        }
    }
}
