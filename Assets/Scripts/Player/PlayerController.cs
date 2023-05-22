using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float horizontalAxis;
    private float verticalAxis;

    public UnityEvent onPlayerDeath;

    public GameObject hurtParticles;
    public GameObject healParticles;
    public ParticleSystem powerupParticles;

    private Rigidbody rb;

    
    private bool hasPowerUp;

    public float speed = 10.0f;


    private  float xRangeMin;
    private float xRangeMax;
    private  float zRangeMin;
    private float zRangeMax;
    private Vector3 originalTransform;
    private Quaternion originalRotation;

    public GameObject shootingManager;




    public int lives = 3;


    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalTransform = transform.position;
        originalRotation = transform.rotation;
        

        Vector3[] vercticesList = GameObject.Find("Ground").GetComponent<MeshFilter>().sharedMesh.vertices;

        xRangeMin = transform.TransformPoint(vercticesList[0]).x;
        zRangeMax = transform.TransformPoint(vercticesList[0]).z;
        xRangeMax = transform.TransformPoint(vercticesList[120]).x;
        zRangeMin = transform.TransformPoint(vercticesList[120]).z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        // calculate movement vector
        Vector3 movement = new Vector3(horizontalAxis, 0.0f, verticalAxis);

        // add movement to rigidbody velocity
        rb.velocity = movement * speed;

        // face the direction of movement
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }


        CheckBoundaries();


        
    }

    private void CheckBoundaries()
    {
        /*
        //Checks for the horizontal boudaries
        if (transform.position.x < xRangeMin)
            transform.position = new Vector3(xRangeMin, transform.position.y, transform.position.z);
        if (transform.position.x > xRangeMax)
            transform.position = new Vector3(xRangeMax, transform.position.y, transform.position.z);


        //Move player along the vertical (z) axis, until they reach the boundaries (zRange)


        //Checks for the vertical boundaries
        if (transform.position.z < zRangeMin)
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeMin);
        if (transform.position.z > zRangeMax)
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeMax);
    */
    }

    public void NewWave()
    {
        transform.position = originalTransform;
        transform.rotation = originalRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Instantiate(hurtParticles, transform.position, Quaternion.identity);
            lives--;
            UIManager.instance.SetHealth(lives);
            if (lives == 0)
            {
                StartCoroutine(DeathAnimation());
            }
        }else if(other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            shootingManager.GetComponent<ShootingManager>().hasPowerUp = true;
            powerupParticles.Play();
            StartCoroutine(PowerupCooldown(other.gameObject.GetComponent<PowerUp>().duration));

        }else if(other.gameObject.CompareTag("Heal"))
        {
            Destroy(other.gameObject);
            lives++;
            UIManager.instance.SetHealth(lives);
            Instantiate(healParticles, transform.position, Quaternion.identity);
        }
        else if (other.gameObject.CompareTag("Boundary")){
            rb.velocity = Vector3.zero;
        }
    }

    IEnumerator PowerupCooldown(float powerUpDuration)
    {
        yield return new WaitForSeconds(powerUpDuration);
        shootingManager.GetComponent<ShootingManager>().hasPowerUp = false;
        powerupParticles.Stop();
    }

    IEnumerator DeathAnimation()
    {
        GetComponent<BoxCollider>().isTrigger = false;
        yield return new WaitForSeconds(.1f);
        onPlayerDeath.Invoke();
    }
}








/* Test pour faire tourner le perso en manière discrète
         * 
         * if (Mathf.Abs(horizontalAxis) > Mathf.Abs(verticalAxis))
        {
            if (horizontalAxis > 0)
                transform.eulerAngles = new Vector3(
                    transform.eulerAngles.x,
                     90,
                    transform.eulerAngles.z);

            else if (horizontalAxis < 0)
                transform.eulerAngles = new Vector3(
                    transform.eulerAngles.x,
                     -90,
                    transform.eulerAngles.z);
        }
        else if (verticalAxis > 0)
            transform.eulerAngles = new Vector3(
            transform.eulerAngles.x,
            0,
            transform.eulerAngles.z);

        else if (verticalAxis < 0)
            transform.eulerAngles = new Vector3(
            transform.eulerAngles.x,
            180,
            transform.eulerAngles.z);
        
        

        //Move player along the horizontal (x) axis, until they reach the boundaries (xRange)
        if(verticalAxis == 0)
            transform.Translate(Vector3.forward * horizontalAxis *  horizontalAxis * Time.deltaTime * speed);
        else*/


//
/*if(Mathf.Abs(horizontalAxis) > Mathf.Abs(verticalAxis))
 {
     if(horizontalAxis < 0)
     {
         transform.rotation = Quaternion.Euler(0, -90, 0);
         isInputNegative = -1;
     }
     else
     {
         transform.rotation = Quaternion.Euler(0, 90, 0);
         isInputNegative = 1;
     }
     transform.Translate(Vector3.forward * Mathf.Abs(horizontalAxis) * Time.deltaTime * speed);
     //transform.Translate(Vector3.left * isInputNegative * verticalAxis * Time.deltaTime * speed);
 }
 else if  (Mathf.Abs(verticalAxis) > 0 )
 {
     if (verticalAxis > 0)
     {
         transform.rotation = Quaternion.Euler(0, 0, 0);
         isInputNegative = 1;
     }
     else
     {
         transform.rotation = Quaternion.Euler(0, 180, 0);
         isInputNegative = -1;
     }

     transform.Translate(Vector3.forward * Mathf.Abs(verticalAxis) * Time.deltaTime * speed);
     //transform.Translate(Vector3.right * isInputNegative * horizontalAxis * Time.deltaTime * speed);
 }
 */
