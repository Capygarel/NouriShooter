using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPController : MonoBehaviour
{

    public float currentXP, requiredXP;
    public PlayerStats modifiedPlayerStats;
    private float xpAreaSize;
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        UIManager.instance.UpdateXPBar(currentXP, requiredXP);
        xpAreaSize = modifiedPlayerStats.ItemPickupRange;
        Debug.Log(xpAreaSize);
        gameObject.transform.localScale = new Vector3(0,xpAreaSize,0);

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = player.transform.position;
        if (Input.GetKeyDown(KeyCode.Tab))
            gainExperience(5);
    }

    public void gainExperience(float ammount)
    {
        currentXP += ammount;
        UIManager.instance.UpdateXPBar(currentXP, requiredXP);
        if (currentXP >= requiredXP)
            LevelUp();
    }

    private void LevelUp()
    {
        modifiedPlayerStats.Level++;
        currentXP -= requiredXP;
        UIManager.instance.UpdateXPBar(currentXP, requiredXP);
        UIManager.instance.LevelUp(modifiedPlayerStats.Level);
        LVLUpManager.instance.PauseGame();

    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<AttractablePickup>().Attract(this.gameObject);
    }

}
