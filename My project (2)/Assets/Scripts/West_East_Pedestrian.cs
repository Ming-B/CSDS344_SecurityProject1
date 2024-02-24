using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class West_East_Pedestrian : MonoBehaviour
{

    private float PedSpeed = 3.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        transform.position = transform.position + (Vector3.left * PedSpeed) * Time.deltaTime;

        float screenWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;

        if (transform.position.x > screenWidth / 2 + 5f)
        {
            Destroy(gameObject);
        }
        
    }

}
