using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float extraJumpForce;
    
    [Header("Visual")]
    private SpriteRenderer _spriteRenderer;
    
    [Header("Ground Detection")]
    [SerializeField] float groundCheckDistance = 0.1f;
    [SerializeField] LayerMask groundLayer;
    
    [Header("Inputs")]
    [SerializeField] InputActionReference moveInput;
    [SerializeField] InputActionReference jumpInput;
    
    private Rigidbody2D _rb;
    private CapsuleCollider2D collider;
    private bool _isGrounded;
    private Animator _anim;

    public float facing = 1f;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    } 
    
    private void OnEnable()
    {
        moveInput.action.Enable();
        jumpInput.action.Enable();
    }
    
    void Update()
    {
        _isGrounded = Physics2D.Raycast(collider.bounds.center, Vector2.down, 
            collider.bounds.extents.y + groundCheckDistance,groundLayer);

        if (_isGrounded && jumpInput.action.WasPressedThisFrame())
        {
            _rb.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        }

        if (jumpInput.action.IsPressed() && _rb.linearVelocity.y > 0)
        {
            _rb.AddForce(Vector2.up * extraJumpForce, ForceMode2D.Force);
        }
    }

    void FixedUpdate()
    {
        float horizontalInput = moveInput.action.ReadValue<Vector2>().x;
        if (horizontalInput > 0) facing = 1;
        if (horizontalInput < 0) facing = -1;

        transform.localScale = new Vector3(facing, 1, 1);
        _rb.linearVelocity = new Vector2(horizontalInput * speed, _rb.linearVelocity.y);
        _anim.SetBool("isMoving", _rb.linearVelocity.magnitude > 0.0001);
    }
}
