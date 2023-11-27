using UnityEngine;


public class PlayerInput : MonoBehaviour
{
    PlayerInputActions playerInputActions;

    public Vector2 axes => playerInputActions.InGame.Dir.ReadValue<Vector2>();
    public bool Move => axes != Vector2.zero;
    public bool AxisInput => playerInputActions.InGame.Dir.WasPressedThisFrame();
    public float AxisX => axes.x;
    public float AxisY => axes.y;



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
    }
    public void EnableGameplayInputs()
    {
        playerInputActions.InGame.Enable();
        Cursor.lockState = CursorLockMode.Confined;
    }
}
