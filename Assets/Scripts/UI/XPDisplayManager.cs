using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XPDisplayManager : MonoBehaviour
{
    [SerializeField] private Image xpBarImage;
    [SerializeField] private TextMeshProUGUI levelTxt;
    [SerializeField] private TextMeshProUGUI xpTxt;

    // Start is called before the first frame update
    void Start()
    {
        xpBarImage.fillAmount = 0f;
        levelTxt.text = "Level 0";
        xpTxt.text = "0/0";
    }

    public void Setup()
    {

    }

    // Update is called once per frame
    public void UpdateXPBar(float newValue, float requiredXP)
    {
        xpBarImage.fillAmount = newValue / requiredXP;
        xpTxt.text = newValue + "/" + requiredXP;
    }

    public void LevelUp(int level)
    {
        levelTxt.text = "Level " + level;
    }
}
