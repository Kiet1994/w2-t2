using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clock2 : MonoBehaviour
{
    [SerializeField] private int addhour;

    const float degreesPerHour = 30f;
    const float degreesPerMinute = 6f;
    const float degreesPerSecond = 6f;

    public Transform hoursTransform, minutesTransform, secondsTransform;

    public bool twirl;

    private void Awake()
    {
        DateTime time = DateTime.Now;
        TimeSpan timechange = new System.TimeSpan(addhour, 0, 0);
        DateTime setTime = time.Add(timechange);

        hoursTransform.localRotation = Quaternion.Euler(0f, 0f, setTime.Hour * degreesPerHour);

        minutesTransform.localRotation = Quaternion.Euler(0f, 0f , setTime.Minute * degreesPerMinute);

        secondsTransform.localRotation = Quaternion.Euler(0f, 0f , setTime.Second * degreesPerSecond);
    }

    private void Update()
    {
        if (twirl)
        {
            UpdateContinuous();
        }
        else
        {
            UpdateDiscription();
        }
    }

    void UpdateContinuous()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;

        hoursTransform.localRotation = Quaternion.Euler(0f, 0f , (float)time.TotalHours * degreesPerHour);

        minutesTransform.localRotation = Quaternion.Euler(0f, 0f , (float)time.TotalMinutes * degreesPerMinute);

        secondsTransform.localRotation = Quaternion.Euler(0f, 0f , (float)time.TotalSeconds * degreesPerSecond);
    }

    void UpdateDiscription()
    {
        DateTime time = DateTime.Now;
        TimeSpan timechange = new System.TimeSpan(addhour, 0, 0);
        DateTime setTime = time.Add(timechange);

        hoursTransform.localRotation = Quaternion.Euler(0f, 0f , setTime.Hour * degreesPerHour);

        minutesTransform.localRotation = Quaternion.Euler(0f, 0f, setTime.Minute * degreesPerMinute);

        secondsTransform.localRotation = Quaternion.Euler(0f, 0f, setTime.Second * degreesPerSecond);
    }
}
