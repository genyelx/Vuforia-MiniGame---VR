using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    private Vector2 moveDirection;
    public float speed = 5f;
    public Animator anim;

    bool moving;

    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    void Update()
    {
        Move();
        anim.SetBool("pWalk", moving);
    }

    public void Move()
    {
        Vector3 move = new Vector3(moveDirection.x, 0, moveDirection.y);
        transform.Translate(move * speed * Time.deltaTime, Space.World);

        if(moveDirection.x > 0.01 || moveDirection.y > 0.01)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
    }
}
