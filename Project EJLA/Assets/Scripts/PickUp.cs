using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{   
    public bool isGem, isHeal;

    private bool isCollected;
    public GameObject puEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !isCollected)
        {
            if (isGem)
            {
                LevelManager.instance.GemsCollected++;
                isCollected = true;
                Destroy(gameObject);
                Instantiate(puEffect, transform.position, transform.rotation);
                UiController.instance.UpdateGemsCount();
            }
            if(isHeal)
            {
                if(PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
                {
                    PlayerHealthController.instance.HealPlayer();
                    isCollected = true;
                    Destroy(gameObject);
                     Instantiate(puEffect, transform.position, transform.rotation);

                }
            }
        }
    }
}
