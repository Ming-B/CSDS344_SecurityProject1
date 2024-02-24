using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class North_South_PedestrianLights : MonoBehaviour
{
    public float timer;
    private PedestrianLightState _currentPLState;

    public PedestrianLightState CurrentPLState{
        get {return _currentPLState;}
        set {_currentPLState = value;}
    }



    public enum PedestrianLightState{
        Red,
        White
    }

    public float redLightDuration = 5.0f;
    public float whiteLightDuration = 5.0f;
    
    private SpriteRenderer spriteRenderer;
    public East_West_PedestrianLights east_West_PedestrianLight;


    // Start is called before the first frame update
    void Start()
    {
        CurrentPLState = PedestrianLightState.Red;
        timer = redLightDuration;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0){
            if(CurrentPLState == PedestrianLightState.Red){
                CurrentPLState = PedestrianLightState.White;
                timer = whiteLightDuration;
            }
        }
        else{
            CurrentPLState = PedestrianLightState.Red;
            timer = redLightDuration;

        }


    // if (this.CurrentPLState == East_West_Light.TrafficLightState.Red)
    // {
    //     // change pedestrian light = white
    // }
    // else if (East_West_PedestrianLights.CurrentPLState ==)
    // {
    //     // The east-west light is green
    // }
    // else if (East_West_PedestrianLights.CurrentPLState == )
    // { 
    //     // The east-west light is yellow
    // }

        
        
    }
}
