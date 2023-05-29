using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceItemContainer : MonoBehaviour
{
    public IItem item;

    

    public void Start()
    {
        gameObject.SetActive(true);
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);

        }
        if (TryGetComponent<Collider>(out Collider col))
        {
            col.enabled = true;
        }

        item.Setup();
    }

    public void DropItem(GameObject player)
    {
        transform.position = new Vector3(player.transform.position.x + Random.Range(-5, 5), 0, player.transform.position.z + Random.Range(-5, 5));
        if (TryGetComponent<Collider>(out Collider col))
        {
            col.enabled = true;
        }
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);

        }
        gameObject.tag = "Item";
    }

    public IItem TakeItem()
    {
        if (TryGetComponent<Collider>(out Collider col))
        {
            col.enabled = false;
        }
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);

        }
        gameObject.tag = "EquippedItem";
        return item;
    }
}