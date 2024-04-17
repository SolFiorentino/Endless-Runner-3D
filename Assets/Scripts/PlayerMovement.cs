
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

   bool alive = true;
    
    public float Speed = 5;
    [SerializeField] Rigidbody rb;

    float HorizontalInput;
    [SerializeField] float HorizontalMultiplier = 2;

    public float speedIncreasePerPoint = 0.1f;

    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;

    private void FixedUpdate()
    {

        if (!alive) return;
        
        
        Vector3 fowardMove = transform.forward * Speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * HorizontalInput * Speed * Time.fixedDeltaTime * HorizontalMultiplier;
        rb.MovePosition(rb.position + fowardMove + horizontalMove);


    }


    // Update is called once per frame
    void Update()
    {

        HorizontalInput = Input.GetAxis("Horizontal");

      
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        
        
        
        if (transform.position.y < -5)
        {

            Die();

        }


    }


    public void Die ()
    {

        alive = false;

        Invoke ("Restart", 2);


    }

    void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    void Jump()
    {

        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        rb.AddForce(Vector3.up * jumpForce);
    }
}
