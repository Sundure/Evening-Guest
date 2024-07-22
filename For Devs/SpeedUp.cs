using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F9))
        {
            Time.timeScale = 1f;
        }
        if (Input.GetKeyDown(KeyCode.F10))
        {
            Time.timeScale = 2f;
        }
        if (Input.GetKeyDown(KeyCode.F11))
        {
            Time.timeScale = 3f;
        }
        if (Input.GetKeyDown(KeyCode.F12))
        {
            Time.timeScale = 5f;
        }
    }
}
