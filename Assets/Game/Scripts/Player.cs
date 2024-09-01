using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body2D;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private bool isGrounded;
    /*
    [Header("Ground Check")]
    private LayerMask groundLayer;
    private float groundCheckDistance = 0.1f;
    private Transform groundCheck;
    */

    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Jump();
    }

    #region Movement
    public void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            body2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    public void Move(float x, float y)
    {
        body2D.linearVelocity = new Vector2(x * moveSpeed, body2D.linearVelocity.y);
    }
    #endregion

    #region Collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if(collision.gameObject.tag == "Obstacle")
        {
            GameManager.instance.EndGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PointCheck"))
        {
            GameManager.instance.AddScore(100f);
        }
    }

    #endregion
}