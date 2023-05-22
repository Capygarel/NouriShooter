using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]
    private int speed, points, maxHP, currentHP;
    public int chancesToDropPowerup;
    public int chancesToDropHeal;

    public bool autoAim;

    public GameObject powerupPrefab;
    public GameObject healPrefab;


    public GameObject nourishedParticles;
    public GameObject deathParticles;



    private bool isQuitting;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MoveForward>().speed = speed;
        isQuitting = false;
        transform.rotation = Quaternion.LookRotation(GameObject.Find("Player").transform.position - transform.position);
    }

   

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }


    public void DealDamage(int damage)
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            DestroyEnemyWithAnimation(deathParticles);
        else if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            DestroyEnemyWithAnimation(nourishedParticles);
        }
    }

    public void DestroyEnemyWithAnimation(GameObject particles)
    {
        
        int roll = Random.Range(1, 100);


        UIManager.instance.IncreaseScore(points);


        if (roll <= chancesToDropPowerup && !isQuitting && GameObject.FindWithTag("Powerup") == null)
            Instantiate(powerupPrefab, transform.position, transform.rotation);
        else if (roll <= chancesToDropPowerup + chancesToDropHeal && !isQuitting && GameObject.FindWithTag("Heal") == null)
            Instantiate(healPrefab, transform.position, transform.rotation);

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
