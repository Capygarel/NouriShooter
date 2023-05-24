using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{

    public GameObject projectilePrefab;
    public float reloadTime;
    private Vector3 mousePosition;
    public bool hasPowerUp;
    private Vector3 playerPosition;

    [SerializeField]
    private AudioClip appleThrow;

    [SerializeField] private float volumeScale;

    [SerializeField] private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        reloadTime = playerController.stats.FiringRateModifier;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameObject.FindWithTag("Player").transform.position;
        transform.position = new Vector3(playerPosition.x, 1.5f, playerPosition.z);

        //look towards mouse position
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
        mousePosition.y = 1.5f;
        Vector3 direction = (mousePosition - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(direction);

        //Checks for SpaceBar press to instantiate a new projectile Prefab

        reloadTime -= Time.deltaTime;

        //Shoot when the reload time is up and play the shooting sound
        if (Input.GetMouseButton(0) && reloadTime <= 0)
        {

            reloadTime = playerController.stats.FiringRateModifier;

            //Triple shot when the player has a powerup
            if (hasPowerUp)
            {

                Quaternion secondRotation = transform.rotation * Quaternion.Euler(0, 45, 0);
                Quaternion thirdRotation = transform.rotation * Quaternion.Euler(0, -45, 0);
                SoundManager.Instance.PlaySound(appleThrow,volumeScale);
                Instantiate(projectilePrefab, transform.position, transform.rotation);
                Instantiate(projectilePrefab, transform.position, secondRotation);
                Instantiate(projectilePrefab, transform.position, thirdRotation);
            }
            else
            {
                SoundManager.Instance.PlaySound(appleThrow,volumeScale);
                Instantiate(projectilePrefab, transform.position, transform.rotation);
            }

        }
    }
}
