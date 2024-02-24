using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class North_South_Light : MonoBehaviour
{
    public Sprite redLightSprite;
    public Sprite greenLightSprite;
    public Sprite yellowLightSprite;

    private SpriteRenderer spriteRenderer;
    public East_West_Light eastWestLight;
    private TrafficLightState currentState = TrafficLightState.Red;
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
        eastWestLight = GameObject.FindGameObjectWithTag("East West Light").GetComponent<East_West_Light>();
        if (spriteRenderer != null)
        {
            // Initially set the sprite to red
            spriteRenderer.sprite = redLightSprite;
        }

        // Start the timer
        timer = 0f;
    }

    void Update()
    {
        if (eastWestLight.GetCurrentState() == East_West_Light.TrafficLightState.Green)
        {
            // Start the timer when the East-West light turns green
            if (currentState != TrafficLightState.Green)
            {
                timer = 0f;
            }

            // Set this light to red
            ChangeLight(redLightSprite, TrafficLightState.Red);
            Debug.Log("East is green, setting North to red");
        }
        else if (timer >= switchTime)
        {
            // Reset the timer
            timer = 0f;

            // Switch between traffic light states
            switch (currentState)
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
            currentState = newState;
        }
    }

    // Public method to get the current state of the traffic light
    public TrafficLightState GetCurrentState()
    {
        return currentState;
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