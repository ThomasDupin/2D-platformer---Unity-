using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public static CheckPointController instance;
    private Checkpoint[] checkpoints;
    public Vector3 spawnPosition;
    private void Awake()
     {
        instance = this;
     }
    // Start is called before the first frame update
    void Start()
    {
        checkpoints = FindObjectsOfType<Checkpoint>();
        spawnPosition = PlayerController.instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DeactivateCheckpoints()
    {
        for(int i =0; i<checkpoints.Length; i++)
        {
            checkpoints[i].ResetCheckPoint();
        }
    }
    public void SetSpawnPosition(Vector3 newSpawnPosition)
    {
        spawnPosition = newSpawnPosition;
    }
}
