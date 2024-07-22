using System;
using System.Collections;
using UnityEngine;

public class TaskList : MonoBehaviour
{
    private int _arrayIndex;

    public string[] TaskName = new string[0];

    public bool[] CompletedTasks = new bool[0];

    public static event Action<string> TaskChange;

    public string CurrentTask;

    private void Awake()
    {
        CompletedTasks = new bool[TaskName.Length];
        ChangeTask();
    }

    public void ChangeTask()
    {
        if (_arrayIndex < TaskName.Length)
        {
            TaskChange?.Invoke(TaskName[_arrayIndex]);

            CurrentTask = TaskName[_arrayIndex];

            if (_arrayIndex > 0)
                CompletedTasks[_arrayIndex - 1] = true;

            _arrayIndex++;
        }
    }

    public void CroroutineChangeTask(float time)
    {
        StartCoroutine(ChangeTaskCoroutine(time));
    }

    private IEnumerator ChangeTaskCoroutine(float time)
    {
        yield return new WaitForSeconds(time);

        ChangeTask();
    }
}