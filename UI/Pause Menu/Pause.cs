using System;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static event Action<bool> OnPauseUse;

    [SerializeField] private GameObject _pausePanel;

    public static bool IsPause;

    private void Start()
    {
        IsPause = _pausePanel.activeSelf;

        PauseCheck();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsPause = !IsPause;

            PauseCheck();
        }
    }
    public void PauseCheck()
    {
        OnPauseUse?.Invoke(IsPause);

        _pausePanel.SetActive(IsPause);

        SetTimeSpeed();
        CursorVisible();
    }

    private void SetTimeSpeed()
    {
        if (IsPause)
        {
            Time.timeScale = 0.0f;
            return;
        }
        Time.timeScale = 1.0f;
    }
    private void CursorVisible()
    {
        if (IsPause)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            return;
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}