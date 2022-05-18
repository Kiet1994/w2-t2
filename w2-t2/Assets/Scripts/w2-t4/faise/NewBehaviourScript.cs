using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Transform AClockSec;
    private void Awake()

    {
        AClockSec = transform.Find("ClockSec");  
    }

    private void Update()
    {
        AClockSec.eulerAngles = new Vector3(0, 0, - Time.realtimeSinceStartup * 90f);
    }
}
