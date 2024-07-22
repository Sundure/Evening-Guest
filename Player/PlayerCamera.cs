using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public static bool CanMove = true;

    public static float MouseSens = 5f;
    private const int _sensMultiplier = 200;

    [SerializeField] private Transform _playerTransform;

    private float _xRotation;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Start()
    {
        MouseSens = SettingsSave.Sensitivity;
    }
    private void Update()
    {

        if (CanMove == true)
        {
            float mouseX = Input.GetAxis("Mouse X") * MouseSens * _sensMultiplier * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * MouseSens * _sensMultiplier * Time.deltaTime;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            _playerTransform.Rotate(Vector3.up * mouseX);
        }
    }

}
