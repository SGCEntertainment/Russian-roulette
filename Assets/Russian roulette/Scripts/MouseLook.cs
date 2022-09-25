using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Space(10)]
    [SerializeField] float mouseSensitivity = 100.0f;

    [Space(10)]
    [SerializeField] float clampAngleY = 80.0f;
    [SerializeField] float clampAngleX = 120.0f;

    float rotY = 0.0f;
    float rotX = 0.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngleY, clampAngleY);
        rotY = Mathf.Clamp(rotY, -clampAngleX, clampAngleX);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }
}
