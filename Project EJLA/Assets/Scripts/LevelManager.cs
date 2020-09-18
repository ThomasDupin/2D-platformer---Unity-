using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float WaitToRespawn;
    public int GemsCollected;
    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }
    private IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);
        yield return new WaitForSeconds(WaitToRespawn);
        PlayerController.instance.gameObject.SetActive(true);
        PlayerController.instance.transform.position = CheckPointController.instance.spawnPosition;
        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;
        UiController.instance.UpdateHealthDisplay();
    }
}
