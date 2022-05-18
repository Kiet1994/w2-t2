using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demo : MonoBehaviour
{
    public GameObject SecondHand;
    string oldSeconds;
    

    void Update()
    {
        string seconds = System.DateTime.UtcNow.ToString("ss");
        

        if (seconds != oldSeconds)
        {
            UpdateTimer();
        }
        oldSeconds = seconds;
    }
    void UpdateTimer()
    {
        int secondsInt = int.Parse(System.DateTime.UtcNow.ToString("ss"));
        print(secondsInt);
        
    }    
}
