using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int speed, points;
    public int chancesToDropPowerup;
    public int chancesToDropHeal;

    public bool autoAim;

    public GameObject powerupPrefab;
    public GameObject healPrefab;


    public ParticleSystem nourishedParticles;

    

    private bool isQuitting;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MoveForward>().speed = speed;
        isQuitting = false;
        if (autoAim)
            transform.rotation = Quaternion.LookRotation(GameObject.Find("Player").transform.position - transform.position);
    }

   

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }


    public void DestroyEnemyWithAnimation()
    {
        
        int roll = Random.Range(1, 100);

        if (roll <= chancesToDropPowerup && !isQuitting && GameObject.FindWithTag("Powerup") == null)
            Instantiate(powerupPrefab, transform.position, transform.rotation);
        else if (roll <= chancesToDropPowerup + chancesToDropHeal && !isQuitting && GameObject.FindWithTag("Heal") == null)
            Instantiate(healPrefab, transform.position, transform.rotation);
        nourishedParticles.Play();

        StartCoroutine(DeathAnimation());

        
    }

    IEnumerator DestroyCoroutine()
    {
        Destroy(gameObject);
        yield return null;
    }

    IEnumerator DeathAnimation()
    {
        yield return new WaitForSeconds(0.1f);
        nourishedParticles.Stop();
        yield return StartCoroutine(DestroyCoroutine());
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
