using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{

    public GameObject projectilePrefab;
    public float reloadTime = .4f;
    private float currentReload;
    private Vector3 mousePosition;
    public bool hasPowerUp;
    private Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        currentReload = reloadTime;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameObject.FindWithTag("Player").transform.position;
        transform.position = new Vector3(playerPosition.x, 1.5f, playerPosition.z);



        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
        mousePosition.y = 1.5f;
        Vector3 direction = (mousePosition - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(direction);

        //Checks for SpaceBar press to instantiate a new projectile Prefab

        currentReload -= Time.deltaTime;

        if (Input.GetMouseButton(0) && currentReload <= 0)
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
}
