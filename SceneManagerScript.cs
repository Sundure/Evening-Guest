using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public static SceneManagerScript Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }
    public static void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public static void LoadForest()
    {
        SceneManager.LoadScene("Forest");
    }
    public static void LoadHouse()
    {
        SceneManager.LoadScene("House");
    }
    public static void LoadFinalScene()
    {
        SceneManager.LoadScene("Final Scene");
    }
}