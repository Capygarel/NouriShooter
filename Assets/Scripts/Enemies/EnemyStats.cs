using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]
    private float speed, maxHP;
    private float currentHP;

    [SerializeField]
    private int points, chancesToDropPowerup, chancesToDropHeal;

    [SerializeField] private AudioClip enemyHitSound, enemyNourishedSound;
    [SerializeField] private float volumeScaleHit, volumeScaleNourished;

    private HealthBar healthBarUI;

    public bool autoAim;

    public GameObject powerupPrefab;
    public GameObject healPrefab;


    public GameObject nourishedParticles;
    public GameObject deathParticles;


    //Checks if the wave is finished so that the enemy doesn't drop loot when destroyed that way
    private bool isQuitting;

    // Start is called before the first frame update
    void Start()
    {

        gameObject.GetComponent<MoveForward>().speed = speed;
        isQuitting = false;
        //Spawns looking at the player
        transform.rotation = Quaternion.LookRotation(GameObject.Find("Player").transform.position - transform.position);

        currentHP = maxHP;
        healthBarUI = GetComponentInChildren<HealthBar>();
    }

   

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    //Deal damage to the enemy, update the health bar and play the hit sound
    public void DealDamage(float damage)
    {
        currentHP -= damage;
        healthBarUI.UpdateHealthBar(maxHP, currentHP);
        SoundManager.Instance.PlaySound(enemyHitSound, volumeScaleHit);

        if (currentHP <= 0)
        {
            SoundManager.Instance.PlaySound(enemyNourishedSound, volumeScaleNourished);
            DestroyEnemyWithAnimation(nourishedParticles);
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyEnemyWithAnimation(deathParticles);
        }
        else if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            DealDamage(1f);
        }
    }

    //
    public void DestroyEnemyWithAnimation(GameObject particles)
    {
        UIManager.instance.IncreaseScore(points);

        // Checks if a powerup or heal is spawned : the enemy has to be killed by the player, and only one powerup and one heal can be present at the same type
        int roll = Random.Range(1, 100);
        if (roll <= chancesToDropPowerup && !isQuitting && GameObject.FindWithTag("Powerup") == null)
            Instantiate(powerupPrefab, transform.position, transform.rotation);
        else if (roll <= chancesToDropPowerup + chancesToDropHeal && !isQuitting && GameObject.FindWithTag("Heal") == null)
            Instantiate(healPrefab, transform.position, transform.rotation);

        //Play a particle effect on death, then destroy the gameobject
        GameObject obj = Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(obj, 0.5f);
        Destroy(gameObject);

        
    }



    // Update is called once per frame
    void Update()
    {
        if (autoAim)
            transform.rotation = Quaternion.LookRotation(GameObject.Find("Player").transform.position - transform.position);
    }
}
