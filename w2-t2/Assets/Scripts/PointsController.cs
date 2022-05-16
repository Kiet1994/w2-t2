using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    public static PointsController Instance { get; private set; }
    public Vector3[] PosPoints;
    [Range(0, 20)]
    public int numberPos;
    [Range(0, 50)]
    public int maxRange;
    [Range(0, 50)]
    public int minRange;

    public bool Run;

    private bool isActive;

    void Awake()
    {
        Instance = this;
        
    }
    
    void Update()
    {
        if (Run)
        {
            Run = false;
            PosPoints = new Vector3[numberPos];
            for (int i = 0; i < numberPos; i++)
            {
                PosPoints[i] = randomVector(minRange, maxRange);
            }
        }
    }
    
    Vector3 randomVector(int minRange, int maxRange)
    {
        return new Vector3(Random.Range(minRange, maxRange), 0, Random.Range(minRange, maxRange));
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (int i = 0; i < PosPoints.Length; i++)
        {
            int nextPointIndex = i + 1;
            if (nextPointIndex >= PosPoints.Length) nextPointIndex = 0;
            Gizmos.DrawLine(PosPoints[i], PosPoints[nextPointIndex]);
        }
    }
}
