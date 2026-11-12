using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    [SerializeField] private const float JUMP_POWER = 3f;

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
}
