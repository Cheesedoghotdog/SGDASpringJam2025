using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable(); // ensure that the ActionMap "Player" is enabled (Awake() doesn't guarantee it)
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>(); // read x and y inputs from playerInputActions

        inputVector = inputVector.normalized;

        return inputVector;
    }
}
