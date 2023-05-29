using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LVLUpManager : MonoBehaviour
{
    public static LVLUpManager instance;

    public GameObject LvlUpScreen;

    public bool isActive = false;

    [SerializeField] private Inventory inventory;

    public List<IItem> possiblePicks;

    public GameObject choice1Wrapper, choice2Wrapper, choice3Wrapper, choice4Wrapper;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        LvlUpScreen.SetActive(true);
        isActive = true;
        Time.timeScale = 0f;

        choice1Wrapper.GetComponentInChildren<Image>().sprite = possiblePicks[0].itemType.icon;
        choice1Wrapper.GetComponentInChildren<TextMeshProUGUI>().text = possiblePicks[0].itemType.itemName;
        choice2Wrapper.GetComponentInChildren<Image>().sprite = possiblePicks[1].itemType.icon;
        choice2Wrapper.GetComponentInChildren<TextMeshProUGUI>().text = possiblePicks[1].itemType.itemName;
        choice3Wrapper.GetComponentInChildren<Image>().sprite = possiblePicks[2].itemType.icon;
        choice3Wrapper.GetComponentInChildren<TextMeshProUGUI>().text = possiblePicks[2].itemType.itemName;
        choice4Wrapper.GetComponentInChildren<Image>().sprite = possiblePicks[3].itemType.icon;
        choice4Wrapper.GetComponentInChildren<TextMeshProUGUI>().text = possiblePicks[3].itemType.itemName;
    }

    public void ResumeGame()
    {
        isActive = false;
        LvlUpScreen.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void FirstChoice()
    {
        if (inventory.IsItemInInventory(possiblePicks[0]) < 0)
        {
            possiblePicks[0] = Instantiate(possiblePicks[0]);
            inventory.EquipNewItem(possiblePicks[0]);
       } else
            inventory.UpgradeItem(inventory.IsItemInInventory(possiblePicks[0]));

    }
    public void SeecondChoice()
    {
        if (inventory.IsItemInInventory(possiblePicks[1]) < 0)
        {
            possiblePicks[1] = Instantiate(possiblePicks[1]);
            inventory.EquipNewItem(possiblePicks[1]);
        }
        else
            inventory.UpgradeItem(inventory.IsItemInInventory(possiblePicks[1]));

    }
    public void ThirdChoice()
    {
        if (inventory.IsItemInInventory(possiblePicks[2]) < 0) {
            possiblePicks[2] = Instantiate(possiblePicks[2]);
            inventory.EquipNewItem(possiblePicks[2]);
        }else
            inventory.UpgradeItem(inventory.IsItemInInventory(possiblePicks[2]));

    }

    public void FourthChoice()
    {
        if (inventory.IsItemInInventory(possiblePicks[3]) < 0) {
            possiblePicks[3] = Instantiate(possiblePicks[3]);
            inventory.EquipNewItem(possiblePicks[3]);
        }else
            inventory.UpgradeItem(inventory.IsItemInInventory(possiblePicks[3]));

    }
    
}
