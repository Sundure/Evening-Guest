using UnityEngine;

public class ItemSway : MonoBehaviour
{
    [SerializeField] private float _smooth;
    [SerializeField] private float _multiplier;
    private void Update()
    {
        if (Cursor.visible)
        {
            return;
        }

        float mouseX = Input.GetAxis("Mouse X") * _multiplier;
        float mouseY = Input.GetAxis("Mouse Y") * _multiplier;

        Quaternion rotationX = Quaternion.AngleAxis(mouseX, Vector3.up);
        Quaternion rotationY = Quaternion.AngleAxis(-mouseY, Vector3.right);

        Quaternion targetRotation = rotationX * rotationY;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, _smooth * Time.deltaTime);
    }
}
