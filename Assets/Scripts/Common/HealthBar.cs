using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float drainTime = 0.1f;
    [SerializeField] private Gradient healthBarGradient;

    private float targetAmmount = 1f;

    private Image img;

    private Color newImgColor;

    private Coroutine animationDrainCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponentInChildren<Image>();
        img.color = healthBarGradient.Evaluate(targetAmmount);
        UpdateHealthBarGradient();


    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
        transform.rotation = Quaternion.LookRotation(Vector3.up);
    }

    public void UpdateHealthBar( float maxHealth, float currentHealth)
    {
        targetAmmount = currentHealth / maxHealth;

        animationDrainCoroutine = StartCoroutine(AnimationDrain());
        UpdateHealthBarGradient();
    }

    private IEnumerator AnimationDrain()
    {
        float fillAmount = img.fillAmount;
        Color currentColor = img.color;

        float elapsedTime = 0f;
        while (elapsedTime < drainTime)
        {
            elapsedTime += Time.deltaTime;

            img.fillAmount = Mathf.Lerp(fillAmount, targetAmmount, elapsedTime / drainTime);
            img.color = Color.Lerp(currentColor, newImgColor, elapsedTime / drainTime);

            yield return null;
        }
    }

    private void UpdateHealthBarGradient()
    {
        newImgColor = healthBarGradient.Evaluate(targetAmmount);
    }
}
