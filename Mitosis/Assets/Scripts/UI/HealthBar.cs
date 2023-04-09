using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Image greenhealth;
    [SerializeField] Image redhealth;
    [SerializeField] GameObject healthBG;
    [SerializeField] Animator healthanimator;
  
    private void Start()
    {
        if (greenhealth == null)
        {
            healthBG = gameObject.transform.Find("Canvas").transform.Find("HealthBG").gameObject;
            greenhealth = healthBG.gameObject.transform.Find("green").GetComponent<Image>();
            redhealth = healthBG.gameObject.transform.Find("red").GetComponent<Image>();
        }
    }
    public void Damage(float currenthealth, float damage, float maxhealth)
    {
        greenhealth.fillAmount = (currenthealth - damage) / maxhealth;
        StartCoroutine(RedHealth(1, currenthealth, damage, maxhealth));
        if (healthanimator!=null)
        {
            healthanimator.Play("HealthDamage");
        }
    }
    IEnumerator RedHealth(float time, float starthealth, float damage, float maxhealth)
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < time)
        {
            yield return new YieldInstruction();
            elapsedTime += Time.unscaledDeltaTime;
            redhealth.fillAmount = (starthealth - damage * Mathf.Clamp01(elapsedTime / time)) / maxhealth;
        }
    }
}
