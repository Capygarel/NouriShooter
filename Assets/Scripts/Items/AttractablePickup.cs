using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractablePickup : MonoBehaviour
{
    public bool isAttracted = false;
    public int speed;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttracted)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            if (transform.position == target.transform.position)
            {
                target.GetComponent<XPController>().gainExperience(20f);
                Destroy(gameObject);
            }
        }
        
            
            
    }

    public void Attract(GameObject newTarget)
    {
        isAttracted = true;
        target = newTarget ;
    }

}
