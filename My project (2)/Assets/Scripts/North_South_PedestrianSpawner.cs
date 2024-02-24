using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PedestrianSpawner : MonoBehaviour
{

    public GameObject pedestrianPrefab; 
    public float spawnInterval = 5.0f;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {

        timer = spawnInterval;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<=0){
            Instantiate(pedestrianPrefab, transform.position, Quaternion.identity);

            timer = spawnInterval;
            
        }
        
    }
}
