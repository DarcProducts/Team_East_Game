using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerRigid2DMovement : MonoBehaviour
{
    public bool canMove, canJump;
    [SerializeField] float moveSpeed;
    [SerializeField] int maxVelocity;
    [SerializeField] float jumpForce;
    [SerializeField] float gravityWhileJumping;
    [SerializeField] float gravityWhileFalling;
    [SerializeField] LayerMask groundLayers;
    [SerializeField] float groundCheckDistance;
    Rigidbody2D rb;
    Vector2 movement;

    void Awake() => rb = GetComponent<Rigidbody2D>();

    void FixedUpdate() => MovePlayer();

    public void OnMove(InputValue move) => movement = move.Get<Vector2>();

    public void OnJump()
    {
        if (!canJump) return;
        if (Physics2D.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayers))
            if (rb.velocity.magnitude < maxVelocity)
                rb.AddForce(jumpForce * Vector3.up, ForceMode2D.Impulse);
    }

    void MovePlayer()
    {
        if (!canMove)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        float currentSpeed = rb.velocity.magnitude;
        if (currentSpeed > maxVelocity)
            rb.velocity = rb.velocity.normalized * currentSpeed;
        Vector3 moveVector = moveSpeed * movement;
        float yVeloc = rb.velocity.y;
        yVeloc = yVeloc > 0 ? yVeloc -= gravityWhileJumping * Time.fixedDeltaTime : yVeloc < 0 ? yVeloc -= gravityWhileFalling * Time.fixedDeltaTime : yVeloc;
        if (rb.velocity.magnitude < maxVelocity)
            rb.velocity = new Vector3(moveVector.x, yVeloc, 0);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Vector3.down * groundCheckDistance);
    }
}