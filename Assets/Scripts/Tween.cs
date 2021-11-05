using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween 
{
    public Transform Target { get; set; }
    public Vector2 StartPos { get;  set; }
    public Vector2 EndPos { get;  set; }
    public float StartTime { get;  set; }
    public float Duration { get;  set; }

    public Tween(Transform targe, Vector3 startPos, Vector3 endPos, float startTime, float duration)
    {
        Target = targe;
        StartPos = startPos;
        EndPos = endPos;
        StartTime = startTime;
        Duration = duration;

    }
}
