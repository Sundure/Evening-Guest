using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static event Action BlackScreen;

    [SerializeField] private Animator _taskAnim;
    [SerializeField] private TextMeshProUGUI _taskText;
    [SerializeField] private AudioSource _taskAudio;

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
        _taskText.text = task;

        if (_finalTask == false)
        {
            _taskAnim.SetBool("New Task", true);

            yield return new WaitForEndOfFrame();

            _taskAudio.Play();

            _taskAnim.SetBool("New Task", false);
        }
    }


    private void OnDestroy()
    {
        DisableFinalRadio.OnFinalRadioUse -= SetBool;
        TaskList.TaskChange -= TaskCheck;
    }
}
