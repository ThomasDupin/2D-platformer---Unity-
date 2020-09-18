using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{   
    public static PlayerHealthController instance;
    public int currentHealth, maxHealth;
    public GameObject deathEffect;
    public float invicibleLenght;
    private float invicibleCounter;

    private SpriteRenderer theSr;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        theSr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(invicibleCounter > 0)
        {
            invicibleCounter -= Time.deltaTime;

            if(invicibleCounter <=0)
            {
                theSr.color = new Color(theSr.color.r, theSr.color.g, theSr.color.b, 1);

            }
        }
    }
    public void DealDamage()
    {
        if(invicibleCounter <= 0)
        {
        currentHealth--;
        if(currentHealth <= 0)
        {
            currentHealth =0;
            Instantiate(deathEffect, transform.position, transform.rotation);
            //gameObject.SetActive(false);
            LevelManager.instance.RespawnPlayer();
        }else
        {
            invicibleCounter = invicibleLenght;
            theSr.color = new Color(theSr.color.r, theSr.color.g, theSr.color.b, .5f);
            PlayerController.instance.KnocBack();
        }
        UiController.instance.UpdateHealthDisplay();
    }
    }
    public void HealPlayer()
    {
        currentHealth++;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UiController.instance.UpdateHealthDisplay();
    }
}
