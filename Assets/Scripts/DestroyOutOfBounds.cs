using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private readonly float boundZ = 20f;
    private readonly float boundX= 33f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > boundZ || transform.position.z < -boundZ || transform.position.x > boundX || transform.position.x < -boundX)
        {
            Destroy(gameObject);

        }
    }
}
