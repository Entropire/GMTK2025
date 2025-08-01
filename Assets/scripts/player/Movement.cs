using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class movement : MonoBehaviour
{
  [SerializeField] float SpeedMultiplier = 10f;
  [SerializeField] float SprintingSpeedMultiplier = 1.5f;   
  [SerializeField] float GroundCheckDistance = 1.2f;
  [SerializeField] float JumpForce = 7f;
  [SerializeField] float SprintingJumpForce = 3f;

  private Rigidbody2D rb;
  private float input = 0f;

  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    input = (Input.GetKey(KeyCode.A) ? -1 : 0) + (Input.GetKey(KeyCode.D) ? 1 : 0);

    if (Input.GetKeyDown("space"))
    {
      HandleJump();
    }
  }

  private void FixedUpdate()
  {
    HandleMovement();
    HandleRotation();
    HandleState();
  }

  private void HandleMovement()
  {

    float speed = Input.GetKey(KeyCode.LeftControl) ? SpeedMultiplier * SprintingSpeedMultiplier : SpeedMultiplier;

    rb.velocity = new Vector2(
        input * speed,
        rb.velocity.y
      );
  }

  private void HandleRotation()
  {
    if (rb.velocity.x != 0)
    {
      transform.rotation = Quaternion.Euler(0f, (rb.velocity.x < 0 ? 180f : 0f), 0f);
    }
  }

  private bool IsGrounded()
  {
    return Physics2D.Raycast(transform.position, Vector2.down, GroundCheckDistance, LayerMask.GetMask("Ground"));
  }

  private void HandleJump()
  {
    if (IsGrounded())
    {
      float jump = Input.GetKey(KeyCode.LeftControl) ? SprintingJumpForce : JumpForce;

      rb.velocity = new Vector2(
        rb.velocity.x,
        jump
        );
    }
  }

  private void HandleState()
  {
    if (IsGrounded())
    {
      if (input != 0)
      {
        if (Input.GetKey(KeyCode.LeftControl))
        {
          PlayerState.Instance.SetState(rb.velocity.x < 0 ? StatesEnum.RunningLeft : StatesEnum.RunningRight);
        }
        else
        {
          PlayerState.Instance.SetState(rb.velocity.x < 0 ? StatesEnum.RunningLeft : StatesEnum.RunningRight);
        }
      }
      else
      {
        PlayerState.Instance.SetState(StatesEnum.Idle);
      }
    }
    else
    {
      if (rb.velocity.y > 0)
      {
        if (Input.GetKey(KeyCode.LeftControl))
        {
          PlayerState.Instance.SetState(rb.velocity.x < 0 ? StatesEnum.JumpingRunnuingLeft : StatesEnum.JumpingRunnuingRight);
        }
        else
        {
          PlayerState.Instance.SetState(rb.velocity.x < 0 ? StatesEnum.JumpingLeft : StatesEnum.JumpingRight);
        }
      }
      else
      {
        if (Input.GetKey(KeyCode.LeftControl))
        {
          PlayerState.Instance.SetState(rb.velocity.x < 0 ? StatesEnum.FallingRunningLeft : StatesEnum.FallingRunnuingRight);
        }
        else
        {
          PlayerState.Instance.SetState(rb.velocity.x < 0 ? StatesEnum.FallingLeft : StatesEnum.FallingRight);
        }
      }
    }
  }
}
