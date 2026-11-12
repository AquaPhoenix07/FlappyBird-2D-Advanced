using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    [SerializeField] private const float JUMP_POWER = 3f;
    [SerializeField] private const float ROTATE_SPEED = 10f;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InputHandler();
    }

    private void InputHandler()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.linearVelocity = Vector2.up * JUMP_POWER;
        }
    }

    private void FixedUpdate()
    {
        // Tele góc xoay bird mà ko xoay Collider
        //transform.rotation = Quaternion.Euler(0, 0, playerRigidbody.linearVelocity.y * ROTATE_SPEED);
        playerRigidbody.rotation = playerRigidbody.linearVelocity.y *  ROTATE_SPEED;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }
    
}
