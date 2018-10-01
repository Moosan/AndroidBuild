using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMover : MonoBehaviour {
    public Text text;
    private float gravity;
    public bool Moving;
    public Transform Under;
    private Vector3 PlayerPos;
    private Vector3 PlayerVel;
    private Vector3 dir;
    public Text StartButtonText;
    private void Start()
    {
        dir = new Vector3();
        AccDispley();
        gravity = 1.0f;
        if (Moving) {
            MoveStart();
        }
    }
    void Update()
    {
        if (Moving)
        {
            dir = GetAcc();
            AccDispley();
            PlayerVel += dir * Time.deltaTime;
            transform.position += PlayerVel * Time.deltaTime;
        }
    }
    private void SetGravity()
    {
        gravity = GravitySenser.sensor.Gravity;
    }

    public void MoveStart() {
        SetGravity();
        Moving = true;
        StartButtonText.text = "移動チュー";
    }
    private void AccDispley() {
        text.text = dir.x+"\n"+dir.y+"\n"+dir.z;
    }
    private Vector3 GetAcc() {
        var di = Under.localPosition.normalized;
        var beforeVector= (Input.acceleration+ new Vector3(di.x,di.y,-di.z).normalized * gravity)*9.8f;
        return beforeVector;
    }
}