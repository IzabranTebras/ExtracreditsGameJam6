using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Vector2 MovementInput { get; private set; }
    public Vector2 CameraInput { get; private set; }
    public bool JumpInput { get; private set; }
    public bool FireInput { get; private set; }
    public bool InteractInput { get; private set; }

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        MovementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        CameraInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        JumpInput = Input.GetButtonDown("Jump");
        FireInput = Input.GetButton("Fire1");
        InteractInput = Input.GetButtonDown("Interact");
    }
}
