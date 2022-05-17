using System;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

public class PointController : MonoBehaviour
{
    public static readonly int OFFSET_HOTCONTROL = 10;

    public float ZOffsetCamera;
    public bool Loop;
    public Color LineColor;
    public Color ObjectColor;
    public float ObjectScale;
    public float Diff;
    public bool AddMiddlePoint;
    [HideInInspector] // lam cho bien khong hien thi tren inspector
    public Vector3[] Positions;
    [HideInInspector]
    public int SelectedPointIndex;
    [HideInInspector]
    public int AddPointIndex;
    [HideInInspector]
    public Vector3 AddPoint;
    private void Awake()
    {
        ZOffsetCamera = 5;
    }
    public void AddPosition()
    {
        Vector3[] tmp = new Vector3[Positions.Length + 1];
        int count = 0;
        if (!AddMiddlePoint)
        {
            for (int i = 0; i < Positions.Length; i++)
            {
                tmp[i] = Positions[i];
            }
            tmp[tmp.Length - 1] = AddPoint;
        }
        else
        {
            if (AddPointIndex == -1) return;
            for (int i = 0; i < tmp.Length; i++)
            {
                if (AddPointIndex == i)
                {
                    tmp[i] = AddPoint;
                    continue;
                }
                tmp[i] = Positions[count++];
            }
        }
        Positions = tmp;
    }
    private void OnDrawGizmos()
    {
        for (int i = 0; i < Positions.Length; i++)
        {
            DrawConntectedLine(i);
            DrawPoint(i);
        }
    }

    public void DeletePosition()
    {
        if (SelectedPointIndex == -1) return;
        Vector3[] tmp = new Vector3[Positions.Length - 1];
        int count = 0;
        for (int i = 0; i < Positions.Length; i++)
        {
            if (SelectedPointIndex == i) continue;
            tmp[count++] = Positions[i];
        }
        Positions = tmp;
    }

    
    private void DrawConntectedLine(int i)
    {
        Gizmos.color = LineColor;
        int nextLineIndex = 0;
        if (i + 1 >= Positions.Length)
        {
            if (Loop)
            {
                nextLineIndex = 0;
            } else
            {
                nextLineIndex = i;
            }
        }
        else nextLineIndex = i + 1;
        Gizmos.DrawLine(Positions[i], Positions[nextLineIndex]);
    }
    private void DrawPoint(int i)
    {
        Gizmos.color = ObjectColor;
        Gizmos.DrawIcon(Positions[i], "sv_icon_dot11_pix16_gizmo");
    }

}


