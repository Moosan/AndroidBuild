using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintMarkerMover : MonoBehaviour {
    public float MaxValue;
    public float MinValue;
    private float delta;
    private Vector3 thisPos;
    private void Start()
    {
        delta = MaxValue - MinValue;
        SetValue(0);
    }
    public void SetValue(float value) {
        thisPos.x = 0;
        thisPos.y = 0;
        thisPos.z = value * delta+MinValue;
        transform.localPosition = thisPos;
    }
}
