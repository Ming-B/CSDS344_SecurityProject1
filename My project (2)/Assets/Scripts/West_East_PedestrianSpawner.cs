using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class West_East_PedestrianSpawner : MonoBehaviour
{

    public GameObject pedestrian;

    public float spawnRate = 2.0f;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {

        pedestrian = Resources.Load<GameObject>("Tim");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        } else
        {
            Instantiate(pedestrian,transform.position, transform.rotation);
            timer = 0;
        }
        
    }
}
