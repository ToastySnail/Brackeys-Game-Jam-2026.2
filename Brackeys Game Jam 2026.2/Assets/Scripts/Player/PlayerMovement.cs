using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private Vector2 moveDirection;
    
    private void Update()
    {
        moveDirection = Vector2.zero;

        if (Keyboard.current.wKey.isPressed)
        {
            moveDirection.y = 1;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            moveDirection.y = -1;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            moveDirection.x = 1;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            moveDirection.x = -1;
        }

        moveDirection = moveDirection.normalized;
        float step = movementSpeed * Time.deltaTime;
        transform.position += new Vector3(moveDirection.x * step, moveDirection.y * step, 0);
    }
}
