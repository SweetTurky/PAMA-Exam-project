using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    public delegate void StartTouchEvent (Vector2 positions, float time);
    public event StartTouchEvent OnStartTouch;
    public delegate void EndTouchEvent (Vector2 positions, float time);
    public event StartTouchEvent OnEndTouch;
    private TouchControls touchControls;

    private void Awake()
    {
        touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        touchControls.Enable();
    }

    private void OnDisable()
    {
        touchControls.Disable();
    }

    private void Start()
    {
        touchControls.Touch.TouchInput.started += ctx => StartTouch(ctx);
        touchControls.Touch.TouchInput.canceled += ctx => EndTouch(ctx);
    }
    private void StartTouch(InputAction.CallbackContext context)
    {
        Debug.Log("touch started");
    }
    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("touch ended");
    }
}
