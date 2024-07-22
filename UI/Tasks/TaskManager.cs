using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static event Action FinalTaskDone;
    public static event Action BlackScreen;

    [SerializeField] private Animator _taskAnim;
    [SerializeField] private TextMeshProUGUI _taskText;
    [SerializeField] private AudioSource _taskAudio;

    [SerializeField] private AudioClip _finalTaskClip;

    private bool _finalTask;
    private void Update()
    {
        if (_finalTask == false)
        {
            if (Input.GetKey(KeyCode.Tab))
            {
                _taskAnim.SetBool("Check Task", true);
            }
            else
            {
                _taskAnim.SetBool("Check Task", false);
            }
        }
        else
        {
            _taskAnim.SetBool("Final Task", true);
        }
    }
    private void Start()
    {
        TaskList.TaskChange += TaskCheck;
        DisableFinalRadio.OnFinalRadioUse += SetBool;
    }

    private void SetBool()
    {
        DisableFinalRadio.OnFinalRadioUse -= SetBool;

        _finalTask = true;
    }

    private void TaskCheck(string task)
    {
        StartCoroutine(TaskCheckCoroutine(task));
    }

    private IEnumerator TaskCheckCoroutine(string task)
    {
        if (_finalTask == false)
        {
            _taskAnim.SetBool("New Task", true);

            _taskText.text = task;

            yield return new WaitForEndOfFrame();

            _taskAudio.Play();

            _taskAnim.SetBool("New Task", false);
        }
        else
        {
            _taskText.text = task;

            yield return new WaitForEndOfFrame();

            _taskAudio.clip = _finalTaskClip;
            _taskAudio.loop = true;
            _taskAudio.volume = 0.4f;

            float time = _taskAudio.clip.length;

            _taskAudio.Play();

            StartCoroutine(InvokeEvent(time));
        }
    }

    private IEnumerator InvokeEvent(float time)
    {
        FinalTaskDone?.Invoke();

        yield return new WaitForSeconds((time - 0.5f) / _taskAudio.pitch);

        BlackScreen?.Invoke();

        yield return new WaitForSeconds(0.5f);

        SceneManagerScript.LoadFinalScene();
    }

    private void OnDestroy()
    {
        DisableFinalRadio.OnFinalRadioUse -= SetBool;
        TaskList.TaskChange -= TaskCheck;
    }
}
