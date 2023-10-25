
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public CameraShake cameraShake;

    public float forwardForce = 2000.0f;

    public float sidewaysForce = 500.0f;

    bool moveRight = false;
    bool moveLeft = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey("d"))
        {
            moveRight = true;
        }
       else
        {
            moveRight = false;
        }

       if (Input.GetKey("a"))
        {
            moveLeft = true;
        }
       else
        {
            moveLeft = false;
        }

       if (Input.GetMouseButton(0))
        {
            StartCoroutine(cameraShake.Shake(0.1f, 0.4f));
        }

       
    }

  

    // To mess with physics
    void FixedUpdate()
    {
        // Add a forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (moveRight)
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            
            
        }

        if (moveLeft)
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();

        }
    }
}
