using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 input;

    void Update()
    {
        input = GetMovementInput();
        Move();
    }

    void Move()
    {
        Vector3 movement = new Vector3(input.x, input.y, 0f);
        transform.position += movement * moveSpeed * Time.deltaTime;
    }

    private Vector2 GetMovementInput()
    {
        Vector2 input = Vector2.zero;
        var keyboard = Keyboard.current;

        if (keyboard != null)
        {
            if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed) input.x -= 1;
            if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed) input.x += 1;
            if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed) input.y += 1;
            if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed) input.y -= 1;
        }

        return input.normalized;
    }
}
