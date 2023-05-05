using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabsArray;
    private GameObject animalSelected;
    private float spawnRangeX = 25;
    private float spawnRangeZ = 25;
    private int startSpawnDelay = 2;
    private float spawnInterval = 0.5f;
    Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startSpawnDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

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


    