using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Image greenhealth;
    [SerializeField] Image redhealth;
    [SerializeField] Animator healthanimator;
    bool enemy;

    private void Start()
    {
        if (greenhealth == null)
        {
            healthanimator = gameObject.transform.Find("Canvas").transform.Find("HealthBG").GetComponent<Animator>();
            greenhealth = healthanimator.gameObject.transform.Find("green").GetComponent<Image>();
            redhealth = healthanimator.gameObject.transform.Find("red").GetComponent<Image>();
            enemy = true;
        }
    }
    public void Damage(float currenthealth, float damage, float maxhealth)
    {
        greenhealth.fillAmount = (currenthealth - damage) / maxhealth;
        StartCoroutine(RedHealth(1, currenthealth, damage, maxhealth));
        if (!enemy)
        {
            healthanimator.Play("HealthDamage");
        }
        else
        {
            healthanimator.Play("EnemyHealthShake");
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
