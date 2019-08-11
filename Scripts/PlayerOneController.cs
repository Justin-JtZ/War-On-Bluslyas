using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOneController : MonoBehaviour
{
    // PUBLIC VARIABLES
    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private LayerMask rayCastLM;

    // PRIVATE VARIABLES
    private Rigidbody2D rBody;
    private AudioSource aSrc;
    private Vector2 rayCastOrigin;


    //public GameObject laser;
    //public Transform laserSpawn;
    //public float fireRate = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        //isDead = false;
        rBody = GetComponent<Rigidbody2D>();
        aSrc = GetComponent<AudioSource>();
    }

    // Fixed update is called once per frame
    // Used for physics-related calculations
    void FixedUpdate()
    {

        if (Input.GetKeyDown("w"))
        {
            rBody.velocity = new Vector2(rBody.velocity.x, 1 * speed);
        }
        else if (Input.GetKeyDown("s"))
        {
            rBody.velocity = new Vector2(rBody.velocity.x, -1 * speed);
        }
        else if (Input.GetKeyDown("a"))
        {
            rBody.velocity = new Vector2(-1 * speed, rBody.velocity.y);
        }
        else if (Input.GetKeyDown("d"))
        {
            rBody.velocity = new Vector2(1 * speed, rBody.velocity.y);
        }

        if ((Input.GetKeyUp("w")) || (Input.GetKeyUp("a")) || (Input.GetKeyUp("s")) || (Input.GetKeyUp("d")))
        {
            rBody.velocity = new Vector2(0, 0);
        }

        //rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);
        //rBody.velocity = new Vector2(rBody.velocity.x, vert * speed);

        //counter += Time.deltaTime;
        //// Debug.Log(counter);

        //if (Input.GetButton("Fire1") && counter > fireRate)
        //{
        //    // Create my laser object
        //    Instantiate(laser, laserSpawn.position, laser.transform.rotation);
        //    counter = 0.0f;
        //}

        // Check direction of the player
        if (Input.GetKeyDown("d"))
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (Input.GetKeyDown("a"))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        if (Input.GetKeyDown("s"))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKeyDown("w"))
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
