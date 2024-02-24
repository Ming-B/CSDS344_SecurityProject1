using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class East_West_Light : MonoBehaviour
{
    public Sprite redLightSprite;
    public Sprite greenLightSprite;
    public Sprite yellowLightSprite;

    private SpriteRenderer spriteRenderer;
    public North_South_Light northSouthLight;
    // private TrafficLightState currentState = TrafficLightState.Red;

    private TrafficLightState _currentTLState;

    public TrafficLightState currentTLState
    {
        get { return _currentTLState; }
        set { _currentTLState = value; }
    }
    private float timer;
    private float switchTime = 3f; // Change this to control the time interval for each state

    // Enum to represent the traffic light states
    public enum TrafficLightState
    {
        Red,
        Green,
        Yellow
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        northSouthLight = GameObject.FindGameObjectWithTag("North South Light").GetComponent<North_South_Light>();
        if (spriteRenderer != null)
        {
            // Initially set the sprite to green
            spriteRenderer.sprite = greenLightSprite;
        }

        // Start the timer
        timer = 0f;
    }

    void Update()
    {
        if (northSouthLight.GetCurrentState() == North_South_Light.TrafficLightState.Green)
        {
            // Start the timer when the North-South light turns green
            if (currentTLState != TrafficLightState.Green)
            {
                timer = 0f;
            }

            // Set this light to red
            ChangeLight(redLightSprite, TrafficLightState.Red);
            Debug.Log("North is green, setting East to red");
        }
        else if (timer >= switchTime)
        {
            // Reset the timer
            timer = 0f;

            // Switch between traffic light states
            switch (currentTLState)
            {
                case TrafficLightState.Red:
                    ChangeLight(greenLightSprite, TrafficLightState.Green);
                    break;
                case TrafficLightState.Green:
                    ChangeLight(yellowLightSprite, TrafficLightState.Yellow);
                    break;
                case TrafficLightState.Yellow:
                    ChangeLight(redLightSprite, TrafficLightState.Red);
                    break;
                default:
                    break;
            }
        }
        else
        {
            // Update the timer
            timer += Time.deltaTime;
        }
    }

    public void ChangeLight(Sprite newSprite, TrafficLightState newState)
    {
        // Change the sprite and update the current state
        if (spriteRenderer != null && newSprite != null)
        {
            spriteRenderer.sprite = newSprite;
            currentTLState = newState;
        }
    }

    // Public method to get the current state of the traffic light
    public TrafficLightState GetCurrentState()
    {
        return currentTLState;
    }

    public void SetOppositeState(TrafficLightState oppositeState)
    {
        if (oppositeState == TrafficLightState.Red)
        {
            ChangeLight(greenLightSprite, oppositeState);
        }
        else if (oppositeState == TrafficLightState.Green)
        {
            ChangeLight(redLightSprite, oppositeState);
        }
    }
}
