using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class West_East_Car_Spawner : MonoBehaviour
{
    public GameObject car;
    public float spawnRate = 2;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        car = Resources.Load<GameObject>("West East Car");   
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        } else
        {
            Instantiate(car,transform.position, transform.rotation);
            timer = 0;
        }

    }
}
