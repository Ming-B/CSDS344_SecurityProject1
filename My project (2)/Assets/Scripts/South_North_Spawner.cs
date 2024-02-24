using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class South_North_Spawner : MonoBehaviour
{
    public GameObject car;
    public float spawnRate = 2;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        car = Resources.Load<GameObject>("South North Car");
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Instantiate(car, transform.position, Quaternion.Euler(0f, 0f, 90f));
            timer = 0;
        }
    }
}
