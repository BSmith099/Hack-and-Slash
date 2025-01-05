using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Player player;

    private PlayerInputActions playerInputActions;

    public InputAction attackAction;

    private void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        player = FindFirstObjectByType<Player>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        attackAction = InputSystem.actions.FindAction("Attack");
        attackAction.Enable();
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }

    private void Update()
    {
        if (!gameManager.gameOver)
        {
            if (attackAction.IsPressed())
            {
                player.DoAttack();
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                gameManager.PauseGame();
            }

            playerInputActions.Player.Enable();
        }
        else
        {
            playerInputActions.Player.Disable();
            attackAction.Disable();
        }

        if(attackAction != null && attackAction.IsPressed())
        {
            player.DoAttack();
        }
    }

}
