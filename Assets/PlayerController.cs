using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 input;
    private Rigidbody2D rb2D;
    public float speed;
    public float jumpForce;
    public bool isGrounded;
    // [SerializeField] private FMODUnity.StudioEventEmitter shootAudio;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Move(Vector2 input)
    {
        this.input = input;
    }

    


    private void FixedUpdate()
    {
        Vector2 velocity = new Vector2(input.x, 0);
        rb2D.position += (velocity * speed * Time.fixedDeltaTime);
    }

    private void Jump(bool pressed)
    {
        if (isGrounded) {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
        
    

    private void OnEnable()
    {
        InputManager.OnPlayerMovement += Move;
        InputManager.OnJump += Jump;
        
    }


    private void OnDisable()
    {
        InputManager.OnPlayerMovement -= Move;
        InputManager.OnJump -= Jump;



    }


}
