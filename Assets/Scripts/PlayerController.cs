using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector2 input;
    private Vector2 lastMoveDir;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        input = GetMovementInput();
        Move();
        UpdateAnimator();
    }

    void Move()
    {
        Vector3 movement = new Vector3(input.x, input.y, 0f);
        transform.position += movement * moveSpeed * Time.deltaTime;
    }

    void UpdateAnimator()
    {
        if (input != Vector2.zero)
        {
            lastMoveDir = input;

            animator.SetFloat("moveX", input.x);
            animator.SetFloat("moveY", input.y);
        }

        animator.SetBool("isMoving", input != Vector2.zero);
    }

    private Vector2 GetMovementInput()
    {
        Vector2 input = Vector2.zero;
        var keyboard = Keyboard.current;

        if (keyboard != null)
        {
            if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed) input.x = -1;
            if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed) input.x = 1;
            if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed) input.y = 1;
            if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed) input.y = -1;
        }

        return input; 
    }
}
