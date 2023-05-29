using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float shotSpeed, damage, range;
    private Vector3 lastpos;
    public GameObject model;
    public float distanceTravelled;


    public void Set(float _shotSpeed, float _damage, float _range, Vector3 _startpos)
    {
        shotSpeed = _shotSpeed;
        damage = _damage;
        range = _range;
        lastpos = _startpos;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * shotSpeed * Time.deltaTime);
        distanceTravelled += Vector3.Distance(transform.position, lastpos);
        lastpos = transform.position;
        if (distanceTravelled >= range) Destroy(gameObject);
        
    }
}
