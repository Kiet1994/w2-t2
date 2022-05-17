using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float Diff; // Diff < 0.2
    public float MoveSpeed; 
    private int currentIndex = 0; //

    private Vector3[] points;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        points = PointsController.Instance.PosPoints;

        if (currentIndex >= 0 && currentIndex < points.Length)
        {
            float distance = Vector3.Distance(points[currentIndex], transform.position);
            if (distance < Diff)
            {
                if (currentIndex + 1 >= points.Length)
                {
                    currentIndex = 0;
                }
                else
                {
                    currentIndex++;
                }
            }
            Vector3 dir = (points[currentIndex] - transform.position).normalized;
            transform.Translate(dir * MoveSpeed * Time.deltaTime, Space.World);
            transform.LookAt(points[currentIndex]);
        }
    }
}
