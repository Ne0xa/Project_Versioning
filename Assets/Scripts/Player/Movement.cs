using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float health;
    
    [Header("Ground Detection")]
    [SerializeField] float groundCheckDistance = 0.1f;
    [SerializeField] LayerMask groundLayer;
    
    [Header("Inputs")]
    [SerializeField] InputActionReference moveInput;
    [SerializeField] InputActionReference jumpInput;
    [SerializeField] InputActionReference attackInput;
    [SerializeField] InputActionReference shootInput;
    
    private Rigidbody2D rb;
    private CapsuleCollider2D collider;
    
    private bool isGrounded;
    
    private Vector3 startPosition;
    
    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
    } 
    
    private void OnEnable()
    {
        moveInput.action.Enable();
        jumpInput.action.Enable();
    }
    
    void Update()
    {
        isGrounded = Physics2D.Raycast(collider.bounds.center, Vector2.down, 
            collider.bounds.extents.y + groundCheckDistance,groundLayer);

        if (isGrounded && jumpInput.action.WasPressedThisFrame())
        {
            rb.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        float horizontalInput = moveInput.action.ReadValue<Vector2>().x;

        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
    }
}
