using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Transform targetMovePoint;
    [SerializeField] private float allowInputDistance;

    private void Start()
    {
        targetMovePoint.parent = null; // set the target mive point to be a global (not local) transform
    }

    private void Update()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetMovePoint.position, step);

        if (Vector3.Distance(transform.position, targetMovePoint.position) <= allowInputDistance)
        {
            Vector2 inputVector = gameInput.GetMovementVectorNormalized();
            MoveTargetPoint(inputVector);
        }
    }

    private void MoveTargetPoint(Vector2 inputVector)
    {
        Debug.Log(inputVector.x + " " + inputVector.y);
        // use an if statement to prioritize horizontal movement during diagonal inputs
        if (Mathf.Abs(inputVector.x) > 0f)
        {
            // keep the direction of the vector, but make sure the targetPoint is only ever moved by 1 (grid size, not .707)
            targetMovePoint.position += new Vector3(Mathf.Sign(inputVector.x) * 1, 0, 0);
        }
        else if (Mathf.Abs(inputVector.y) > 0f)
        {
            // keep the direction of the vector, but make sure the targetPoint is only ever moved by 1 (grid size, not .707)
            targetMovePoint.position += new Vector3(0, Mathf.Sign(inputVector.y) * 1, 0);
        }
    }
}
