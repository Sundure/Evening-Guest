using UnityEngine;
public class QualitySeter : MonoBehaviour
{
    public static QualitySeter Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        Destroy(this.gameObject);
    }

    private void Start()
    {
        SaveSystem.ChangeValueEvent += ChangeVSync;

        ChangeVSync();
    }

    private void ChangeVSync()
    {
        if (SettingsSave.VSync == true)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }
    private void OnDestroy()
    {
        SaveSystem.ChangeValueEvent -= ChangeVSync;
    }
}
