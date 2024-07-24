using System.Collections;
using UnityEngine;

public class FinalSceneChangeScene : MonoBehaviour
{
    [SerializeField] private AudioSource _source;

    private float _time;
    private void Start()
    {
        _time = _source.clip.length;

        StartCoroutine(ChangeScene());
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(_time);

        SceneManagerScript.LoadNewspaperScene();
    }
}
