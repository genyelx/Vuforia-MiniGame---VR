using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    private Vector2 movement;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    [Header("Config Player")]
    [Header("Reference Inputs")]
    [SerializeField] InputActionReference moveAction;
    [SerializeField] Transform camTransform;


    public float moveSpeed = 5f;
    public Animator anim;
    bool isMovement;
    Rigidbody rb;

    public CanvasManager canvasManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
    }

    void Update()
    {
        ReadInput();
        anim.SetBool("pWalk", isMovement);
    }

    void FixedUpdate()
    {
        Movement();
    }

    void ReadInput()
    {
        movement = moveAction.action.ReadValue<Vector2>();
    }

    public void Movement()
    {
        Vector3 Direction = new Vector3(movement.x, 0.0f, movement.y).normalized;

        if (Direction.magnitude >= 0.01f)
        {
            isMovement = true;
            float targetAngle = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg + camTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            rb.MoveRotation(Quaternion.Euler(0.0f, angle, 0f));

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.linearVelocity = new Vector3(moveDir.x * moveSpeed, rb.linearVelocity.y, moveDir.z * moveSpeed);
        }
        else
        {
            isMovement = false;
            rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            canvasManager.Perdeu();
            Time.timeScale = 0;
        }
    }
}
