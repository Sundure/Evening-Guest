using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void Exit()
    {
        SceneManagerScript.LoadMenu();
    }
}