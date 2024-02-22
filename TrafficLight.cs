using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSignal : MonoBehaviour
{
    private float greenDuration;
    private float yellowDuration;
    private float redDuration;

    private float timer;

    public string State {get; set;}

    public TrafficSignal(float green, float yellow, float red){
        redDuration = red;
        yellowDuration = yellow;
        greenDuration = green;
        State = "Red";
        timer = 0f;
    }

    public void ChangeLight(){
        if(State == "Green"){
            State = "Yellow";
            timer = yellowDuration;
        }
        else if(State == "Yellow"){
            State = "Red";
            timer = redDuration
        }
        else if(State == "Red"){
            State = "Green";
            timer = greenDuration;
        }

    }

    
    // Start is called before the first frame update
    void Start()
    {

        timer = redDuration;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0){
            ChangeLight();
        }
        
    }
}