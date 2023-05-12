using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private float horizontalAxis;
    private float verticalAxis;

    public UnityEvent onPlayerDeath;

    public ParticleSystem hurtParticles;
    public ParticleSystem healParticles;
    public ParticleSystem powerupParticles;

    private Rigidbody rb;

    public GameObject projectilePrefab;
    private bool hasPowerUp;

    public float speed = 10.0f;
    public float reloadTime = .4f;
    private float currentReload;

    private readonly int xRange = 25;
    private readonly int zRange = 25;
    private Vector3 originalTransform;
    private Quaternion originalRotation;

    private int isInputNegative;
    public int lives = 3;


    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalTransform = transform.position;
        originalRotation = transform.rotation;
        currentReload = reloadTime;
    }

    // Update is called once per frame
    void Update()
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
        //Checks for the horizontal boudaries
        if (transform.position.x < -xRange)
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        if (transform.position.x > xRange)
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);


        //Move player along the vertical (z) axis, until they reach the boundaries (zRange)
        

        //Checks for the vertical boundaries
        if (transform.position.z < -zRange)
            transform.position = new Vector3(transform.position.x, transform.position.y,-zRange);
        if (transform.position.z > zRange)
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);


        //Checks for SpaceBar press to instantiate a new projectile Prefab

        currentReload -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && currentReload <= 0)
        {
            currentReload = reloadTime;
            if (hasPowerUp)
            {
                Quaternion secondRotation = transform.rotation * Quaternion.Euler(0, 45, 0);
                Quaternion thirdRotation = transform.rotation * Quaternion.Euler(0, -45, 0);
                Instantiate(projectilePrefab, transform.position, transform.rotation);
                Instantiate(projectilePrefab, transform.position, secondRotation);
                Instantiate(projectilePrefab, transform.position, thirdRotation);
            }
            else
            {
                Instantiate(projectilePrefab, transform.position, transform.rotation);
            }
            
        }
        
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
            hurtParticles.Play();
            lives--;
            GameObject.Find("Canvas").GetComponent<UIManager>().SetHealth(lives);
            if (lives == 0)
            {
                StartCoroutine(DeathAnimation());
            }
        }else if(other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerUp = true;
            powerupParticles.Play();
            StartCoroutine(PowerupCooldown(other.gameObject.GetComponent<PowerUp>().duration));

        }else if(other.gameObject.CompareTag("Heal"))
        {
            Destroy(other.gameObject);
            lives++;
            GameObject.Find("Canvas").GetComponent<UIManager>().SetHealth(lives);
            healParticles.Play();
        }
    }

    IEnumerator PowerupCooldown(float powerUpDuration)
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerUp = false;
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
