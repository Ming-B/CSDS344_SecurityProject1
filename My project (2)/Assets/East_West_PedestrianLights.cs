using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class East_West_PedestrianLights : MonoBehaviour
{

    //put sprites here when found

    private float timer;
    private PedestrianLightState currentState;
    //enum for state of pedestrian lights
    public enum PedestrianLightState
    {
        Red,
        White
    }
    // Start is called before the first frame update

    public float redLightDuration = 5.0f;

    public float whiteLightDuration = 5.0f;
    void Start()
    {

        //spawn pedestrian assets here

        currentState = PedestrianLightState.Red;
        timer = redLightDuration;

        
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;

        if(timer <= 0){
            if(currentState == PedestrianLightState.Red){
                currentState = PedestrianLightState.White;
                timer = whiteLightDuration;
            }
            else{
                currentState = PedestrianLightState.Red;
                timer = redLightDuration;
            }
        }
        
    }

    // SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    // if (spriteRenderer != null)
    // {
    //     if (currentState == PedestrianLightState.Red)
    //     {
    //         spriteRenderer.color = Color.red;
    //     }
    //     else
    //     {
    //         spriteRenderer.color = Color.white;
    //     }
    // }
    
}
