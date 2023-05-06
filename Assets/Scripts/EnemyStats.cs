using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int speed, points;

    public bool autoAim;

    public GameObject powerupPrefab;
    public GameObject healPrefab;

    public int chancesToDropPowerup;
    public int chancesToDropHeal;

    private bool isQuitting = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MoveForward>().speed = speed;
        if (autoAim)
            transform.rotation = Quaternion.LookRotation(GameObject.Find("Player").transform.position - transform.position);
    }

   

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            int roll = Random.Range(1, 100);
            if (roll <= chancesToDropPowerup && !isQuitting && GameObject.FindWithTag("Powerup") == null)
            {
                Instantiate(powerupPrefab, transform.position, transform.rotation);
            }else if (roll <= chancesToDropPowerup + chancesToDropHeal && !isQuitting && GameObject.FindWithTag("Heal") == null)
            {
                Instantiate(healPrefab, transform.position, transform.rotation);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
