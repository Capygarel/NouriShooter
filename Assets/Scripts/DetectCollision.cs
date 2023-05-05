using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectCollision : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            int scoreToAdd = other.gameObject.GetComponent<EnemyStats>().points;

            GameObject.Find("Canvas").GetComponent<UIManager>().IncreaseScore(scoreToAdd);

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
