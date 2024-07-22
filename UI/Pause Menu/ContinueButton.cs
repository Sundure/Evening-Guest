using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    [SerializeField] private Pause _pause;
    public void Continue()
    {
        Pause.IsPause = false;

        _pause.PauseCheck();
    }
}