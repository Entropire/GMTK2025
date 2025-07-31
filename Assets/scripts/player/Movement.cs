using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class movement : MonoBehaviour
{
  [SerializeField] float SpeedMultiplier = 10f;
  [SerializeField] float GroundCheckDistance = 1.2f;
  [SerializeField] float JumpForce = 5f;

  private Rigidbody2D rb;
  private float input = 0f;

  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    input = Input.GetAxis("Horizontal");

    if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
    {
      HandleJump();
    }
  }

  private void FixedUpdate()
  {
    HandleMovement(); 
  }

  private void HandleMovement()
  {
    rb.velocity = new Vector2(input * SpeedMultiplier, rb.velocity.y);
  }

  private void HandleJump()
  {
    rb.velocity += new Vector2(rb.velocity.x, JumpForce);
  }

  private bool IsGrounded()
  {
    Debug.DrawRay(transform.position, Vector2.down * GroundCheckDistance, Color.red);
    return Physics2D.Raycast(transform.position, Vector2.down, GroundCheckDistance, LayerMask.GetMask("Ground"));
  }
}
