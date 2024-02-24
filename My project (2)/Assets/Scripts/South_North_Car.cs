using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class South_North_Car : MonoBehaviour
{
    public float speed = 7f;
    public int deadzoneOffset = 2;
    private North_South_Light trafficLight;
    private bool reachedTrafficLight = false;
    private bool hitOtherCar = false;

    private void Start()
    {
        trafficLight = GameObject.FindObjectOfType<North_South_Light>();
    }

    // Update is called once per frame
    void Update()
    {
        

        // Keep going till you reach the light and the light is not red
        if ((!hitOtherCar && !reachedTrafficLight) || (trafficLight != null && trafficLight.GetCurrentState() != North_South_Light.TrafficLightState.Red))
        {
            transform.position = transform.position + (Vector3.up * speed) * Time.deltaTime;
        }

        // Get the screen height in world coordinates
        float screenHeight = Camera.main.orthographicSize * 2;

        // Check if the car's y position is beyond the top edge of the screen
        if (transform.position.y > screenHeight / 2 + deadzoneOffset)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Intersection"))
        {
            reachedTrafficLight = true;
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Intersection"))
        {
            reachedTrafficLight = false;
            Debug.Log("Exited intersection");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("South North Car"))
        {
            hitOtherCar = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("South North Car"))
        {
            hitOtherCar = false;
        }
    }

}
