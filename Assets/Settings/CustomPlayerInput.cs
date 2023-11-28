using UnityEngine;
using UnityEngine.InputSystem;


public class CustomPlayerInput : MonoBehaviour
{
    PlayerInputActions playerInputActions;
    //PlayerInput playerInput;

    public static string GAMEPAD_CONTROL_SCHEME = "Gamepad";
    public static string MNK_CONTROL_SCHEME = "MNK";
    public static string CURRENT_CONTROL_SCHEME { get; private set; }

    public Vector2 aim => playerInputActions.InGame.AimMouse.ReadValue<Vector2>();
    public Vector2 aimPad => playerInputActions.InGame.AimPad.ReadValue<Vector2>();
    public bool fire => playerInputActions.InGame.Gripple.WasPressedThisFrame();
    public bool release => playerInputActions.InGame.Gripple.WasReleasedThisFrame();
    public bool bulletTime => playerInputActions.InGame.BulletTime.WasPressedThisFrame();
    public bool stopBulletTime => playerInputActions.InGame.BulletTime.WasReleasedThisFrame();
    public bool gravityUp => playerInputActions.InGame.GravityUp.WasPressedThisFrame();
    public bool gravityDown => playerInputActions.InGame.GravityDown.WasPressedThisFrame();
    public bool restart => playerInputActions.InGame.Restart.WasPressedThisFrame();

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        //playerInput = GetComponent<PlayerInput>();
    }
    private void Start()
    {
        
    }
    public void SwitchInput(PlayerInput input)
    {
        CURRENT_CONTROL_SCHEME = input.currentControlScheme;
        print(CURRENT_CONTROL_SCHEME);
    }
    public void EnableGameplayInputs()
    {
        playerInputActions.InGame.Enable();
        Cursor.lockState = CursorLockMode.None;
    }
}
