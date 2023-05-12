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

    private float startSpawnDelay = .5f;
    public float spawnInterval = 1f;

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
        int side = Random.Range(0, 3);
        

        animalSelected = animalPrefabsArray[index];

        if(side == 0) //gauche
        {
            spawnPosition = new Vector3(-spawnRangeX, 0, Random.Range(-spawnRangeZ,spawnRangeZ));
            Instantiate(animalSelected, spawnPosition, Quaternion.Euler(new Vector3(0, 90, 0)));
        }
        else if (side == 1) //Haut
        {
            spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnRangeZ);
            Instantiate(animalSelected, spawnPosition, animalSelected.transform.rotation);
        }
        else //droite
        {
            spawnPosition = new Vector3(spawnRangeX, 0, Random.Range(-spawnRangeZ, spawnRangeZ));
            Instantiate(animalSelected,spawnPosition , Quaternion.Euler(new Vector3(0,-90,0 )));
        }

        

        
    }
}


    