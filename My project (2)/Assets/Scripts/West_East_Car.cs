using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class West_East_Car : MonoBehaviour
{

    public float speed = 7f;
    public int deadzoneOffset = 2;
    private East_West_Light trafficLight;
    private bool reachedTrafficLight = false;
    private bool hitOtherCar = false;

    private void Start()
    {
        trafficLight = GameObject.FindObjectOfType<East_West_Light>();
    }

    // Update is called once per frame
    void Update()
    {


        // Keep going till you reach the light and the light is not red
        if ((!hitOtherCar && !reachedTrafficLight) || (trafficLight != null && trafficLight.GetCurrentState() != East_West_Light.TrafficLightState.Red))
        {
            transform.position = transform.position + (Vector3.right * speed) * Time.deltaTime;
        }

        // Get the screen width in world coordinates
        float screenWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;

        // Check if the car's x position is beyond the left edge of the screen
        if (transform.position.x > screenWidth / 2 + 5f)
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
        if (collision.gameObject.CompareTag("West East Car"))
        {
            hitOtherCar = true;

        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("West East Car"))
        {
            hitOtherCar = false;
        }
    }
}
