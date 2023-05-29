using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabsArray;
    private GameObject animalSelected;

    private float spawnRangeX = 30;
    private float spawnRangeZ = 20;
    public Camera cam;

    [SerializeField] private float startSpawnDelay = .5f;
    public float spawnInterval = 1f;

    public GameObject player;
    Vector3 spawnPosition;

    public static int wavenumber;


    // Start is called before the first frame update
    void Start()
    {
        wavenumber = 0;
        StartNewWave();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartNewWave()
    {
        foreach (GameObject animal in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(animal);
        }

        foreach (GameObject projectile in GameObject.FindGameObjectsWithTag("Projectile"))
        {
            Destroy(projectile);
        }

        if (GameObject.FindGameObjectWithTag("Heal") != null)
            Destroy(GameObject.FindGameObjectWithTag("Heal"));

        if (GameObject.FindGameObjectWithTag("Powerup") != null)
            Destroy(GameObject.FindGameObjectWithTag("Powerup"));

        InvokeRepeating("SpawnRandomAnimal", startSpawnDelay, spawnInterval);
        spawnInterval -= 0.1f;
        wavenumber++;
    }

    void SpawnRandomAnimal()
    {
        int index = Random.Range(0, animalPrefabsArray.Length);
        int side = Random.Range(0, 4);
        

        animalSelected = animalPrefabsArray[index];



        if (side == 0) //gauche
        {
            //spawnPosition = cam.ViewportToWorldPoint(new Vector3(0, Random.Range(0,1), cam.nearClipPlane));
            spawnPosition = new Vector3(player.transform.position.x - spawnRangeX, 0, player.transform.position.z + Random.Range(-spawnRangeZ,spawnRangeZ));
            Instantiate(animalSelected, spawnPosition, Quaternion.Euler(new Vector3(0, 90, 0)));
        }
        else if (side == 1) //Haut
        {
            //spawnPosition = cam.ViewportToWorldPoint(new Vector3(Random.Range(0, 1),1 , cam.nearClipPlane));
            spawnPosition = new Vector3(player.transform.position.x + Random.Range(-spawnRangeX, spawnRangeX), 0, player.transform.position.z + spawnRangeZ);
            Instantiate(animalSelected, spawnPosition, animalSelected.transform.rotation);
        }
        else if (side == 2)//droite
        {
            //spawnPosition = cam.ViewportToWorldPoint(new Vector3(1, Random.Range(0, 1), cam.nearClipPlane));
            spawnPosition = new Vector3(player.transform.position.x + spawnRangeX, 0, player.transform.position.z + Random.Range(-spawnRangeZ, spawnRangeZ));
            Instantiate(animalSelected,spawnPosition , Quaternion.Euler(new Vector3(0,-90,0 )));
        }
        else
        {
            spawnPosition = new Vector3(player.transform.position.x + Random.Range(-spawnRangeX, spawnRangeX), 0, player.transform.position.z - spawnRangeZ);
            Instantiate(animalSelected, spawnPosition, Quaternion.Euler(new Vector3(0, 180, 0)));
        }

        

        
    }
}


    