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

    private Image choice1Image, choice2Image, choice3Image, choice4Image;

    private TextMeshProUGUI choice1Text, choice2Text, choice3Text, choice4Text;

    int firstOptionIndex, secondOptionIndex, thirdOptionIndex, fourthOptionIndex;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        choice1Image = choice1Wrapper.GetComponentInChildren<Image>();
        choice1Text = choice1Wrapper.GetComponentInChildren<TextMeshProUGUI>();

        choice2Image = choice2Wrapper.GetComponentInChildren<Image>();
        choice2Text = choice2Wrapper.GetComponentInChildren<TextMeshProUGUI>();

        choice3Image = choice3Wrapper.GetComponentInChildren<Image>();
        choice3Text = choice3Wrapper.GetComponentInChildren<TextMeshProUGUI>();

        choice4Image = choice4Wrapper.GetComponentInChildren<Image>();
        choice4Text = choice4Wrapper.GetComponentInChildren<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        SelectOptions();
        LvlUpScreen.SetActive(true);
        isActive = true;
        Time.timeScale = 0f;



    }

    private void SelectOptions()
    {

        firstOptionIndex = Random.Range(0, possiblePicks.Count);

        secondOptionIndex = Random.Range(0, possiblePicks.Count);
        while(secondOptionIndex == firstOptionIndex)
            secondOptionIndex = Random.Range(0, possiblePicks.Count);

        thirdOptionIndex = Random.Range(0, possiblePicks.Count);
        while (thirdOptionIndex == firstOptionIndex || thirdOptionIndex == secondOptionIndex)
            thirdOptionIndex = Random.Range(0, possiblePicks.Count);

        fourthOptionIndex = Random.Range(0, possiblePicks.Count);
        while (fourthOptionIndex == firstOptionIndex || fourthOptionIndex == secondOptionIndex || fourthOptionIndex == thirdOptionIndex)
            fourthOptionIndex = Random.Range(0, possiblePicks.Count);

        Debug.Log(firstOptionIndex + " " + secondOptionIndex + " " + thirdOptionIndex + " " + fourthOptionIndex);

        choice1Image.sprite = possiblePicks[firstOptionIndex].itemType.icon;
        choice1Text.text = possiblePicks[firstOptionIndex].itemType.itemName;

        choice2Image.sprite= possiblePicks[secondOptionIndex].itemType.icon;
        choice2Text.text = possiblePicks[secondOptionIndex].itemType.itemName;

        choice3Image.sprite = possiblePicks[thirdOptionIndex].itemType.icon;
        choice3Text.text = possiblePicks[thirdOptionIndex].itemType.itemName;

        choice4Image.sprite = possiblePicks[fourthOptionIndex].itemType.icon;
        choice4Text.text = possiblePicks[fourthOptionIndex].itemType.itemName;
    }

    public void ResumeGame()
    {
        isActive = false;
        LvlUpScreen.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void FirstChoice()
    {
        if (inventory.IsItemInInventory(possiblePicks[firstOptionIndex]) < 0)
        {
            possiblePicks[firstOptionIndex] = Instantiate(possiblePicks[firstOptionIndex]);
            inventory.EquipNewItem(possiblePicks[firstOptionIndex]);
       } else
            inventory.UpgradeItem(inventory.IsItemInInventory(possiblePicks[firstOptionIndex]));

    }
    public void SeecondChoice()
    {
        if (inventory.IsItemInInventory(possiblePicks[secondOptionIndex]) < 0)
        {
            possiblePicks[secondOptionIndex] = Instantiate(possiblePicks[secondOptionIndex]);
            inventory.EquipNewItem(possiblePicks[secondOptionIndex]);
        }
        else
            inventory.UpgradeItem(inventory.IsItemInInventory(possiblePicks[secondOptionIndex]));

    }
    public void ThirdChoice()
    {
        if (inventory.IsItemInInventory(possiblePicks[thirdOptionIndex]) < 0) {
            possiblePicks[thirdOptionIndex] = Instantiate(possiblePicks[thirdOptionIndex]);
            inventory.EquipNewItem(possiblePicks[thirdOptionIndex]);
        }else
            inventory.UpgradeItem(inventory.IsItemInInventory(possiblePicks[thirdOptionIndex]));

    }

    public void FourthChoice()
    {
        if (inventory.IsItemInInventory(possiblePicks[fourthOptionIndex]) < 0) {
            possiblePicks[fourthOptionIndex] = Instantiate(possiblePicks[fourthOptionIndex]);
            inventory.EquipNewItem(possiblePicks[fourthOptionIndex]);
        }else
            inventory.UpgradeItem(inventory.IsItemInInventory(possiblePicks[fourthOptionIndex]));

    }
    
}
