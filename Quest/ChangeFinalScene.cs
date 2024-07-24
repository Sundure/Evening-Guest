using System.Collections;
using UnityEngine;

public class ChangeFinalScene : MonoBehaviour
{
    private void Start()
    {
        HorrorAudioPayer.AudioTrigger += ChangeScene;
    }

    private void ChangeScene(float time)
    {
        HorrorAudioPayer.AudioTrigger -= ChangeScene;

        StartCoroutine(Timer(time));
    }

    private IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);


        SceneManagerScript.LoadFinalScene();
    }

    private void OnDestroy()
    {
        HorrorAudioPayer.AudioTrigger -= ChangeScene;
    }
}
