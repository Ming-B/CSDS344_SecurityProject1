using System.Collections;
using UnityEngine;

public class Intersection : MonoBehaviour
{
    [SerializeField] private TrafficLight northTrafficLight;
    [SerializeField] private TrafficLight southTrafficLight;
    [SerializeField] private TrafficLight eastTrafficLight;
    [SerializeField] private TrafficLight westTrafficLight;

    [SerializeField] private PedestrianLight northPedestrianLight;
    [SerializeField] private PedestrianLight southPedestrianLight;
    [SerializeField] private PedestrianLight eastPedestrianLight;
    [SerializeField] private PedestrianLight westPedestrianLight;

    private void Update()
    {
        //checks the opposite directions lights and adjusts pedestrianLights accordingly
        if (northTrafficLight.State == "Red" && southTrafficLight.State == "Red")
        {
            eastPedestrianLight.ChangeState("Walk");
            westPedestrianLight.ChangeState("Walk");
        }
        else
        {
            eastPedestrianLight.ChangeState("Don't Walk");
            westPedestrianLight.ChangeState("Don't Walk");
        }

        if (eastTrafficLight.State == "Red" && westTrafficLight.State == "Red")
        {
            northPedestrianLight.ChangeState("Walk");
            southPedestrianLight.ChangeState("Walk");
        }
        else
        {
            northPedestrianLight.ChangeState("Don't Walk");
            southPedestrianLight.ChangeState("Don't Walk");
        }
    }
}