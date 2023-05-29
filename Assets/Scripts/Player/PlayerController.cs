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

    private Animator playerAnimator;

    public PlayerStats stats;
    
    [SerializeField] private AudioClip playerDamage;
    [SerializeField] private float volumeScale;

    private Rigidbody rb;

    
    private bool hasPowerUp;

    private Vector3 originalTransform;
    private Quaternion originalRotation;

    public ShootingManager shootingManager;

    public Inventory inventory;

    private bool activateLVLUP = false;



    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        originalTransform = transform.position;
        originalRotation = transform.rotation;
        playerAnimator = GetComponent<Animator>();


        inventory.SetupInventory();


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            activateLVLUP = LVLUpManager.instance.isActive;
            if (!activateLVLUP)
            {
                LVLUpManager.instance.PauseGame();
            }
            else
            {
                LVLUpManager.instance.ResumeGame();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftControl)) inventory.DropLastItem();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        playerAnimator.SetFloat("Speed_f", Mathf.Abs(horizontalAxis) + Mathf.Abs(verticalAxis));

        // calculate movement vector
        Vector3 movement = new Vector3(horizontalAxis, 0.0f, verticalAxis);

        // add movement to rigidbody velocity
        rb.velocity = movement * inventory.modifiedStats.Speed;

        // face the direction of movement
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }



    }

    //reset the player position when a new wave begins
    public void NewWave()
    {
        transform.position = originalTransform;
        transform.rotation = originalRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameObject toDestroy = Instantiate(hurtParticles, transform.position, Quaternion.identity);
            Destroy(toDestroy, 1f);
            SoundManager.Instance.PlaySound(playerDamage, volumeScale);
            inventory.modifiedStats.ChangeCurrentHP( - other.gameObject.GetComponent<EnemyStats>().damage);
            if (inventory.modifiedStats.CurrentHP == 0)
            {
                StartCoroutine(DeathAnimation());
            }
        }else if(other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            shootingManager.hasPowerUp = true;
            powerupParticles.Play();
            StartCoroutine(PowerupCooldown(other.gameObject.GetComponent<PowerUp>().duration));

        }else if(other.gameObject.CompareTag("Item"))
        {
            if (other.TryGetComponent(out InstanceItemContainer foundItem))
            {
                inventory.EquipNewItem(foundItem.TakeItem());
            }

            GameObject toDestroy = Instantiate(healParticles, transform.position, Quaternion.identity);
            Destroy(toDestroy, 1f);
        }
        else if (other.gameObject.CompareTag("Boundary")){
            rb.velocity = Vector3.zero;
        }
    }

    public void UseItems()
    {
        inventory.applyEffects();
    }


    IEnumerator PowerupCooldown(float powerUpDuration)
    {
        yield return new WaitForSeconds(powerUpDuration);
        shootingManager.hasPowerUp = false;
        powerupParticles.Stop();
    }

    IEnumerator DeathAnimation()
    {
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(.1f);
        onPlayerDeath.Invoke();
    }

    public int GetCurrentHP()
    {
        return stats.CurrentHP;
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
