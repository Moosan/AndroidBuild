using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetAccer : MonoBehaviour {

    public GameObject obj;
    private float gravity;
    public bool Moving;
    public Transform Under;
    private void Start()
    {
        gravity = 0.98f;
        Moving = true;
    }
    void Update()
    {
        if (Moving)
        {
            var dir = /*Input.acceleration*/Under.localPosition.normalized*gravity;
            var tex = obj.GetComponent<Text>();

            tex.text = "" + dir.x + '\n' + dir.y + '\n' + dir.z + '\n';

            transform.position = Time.time * dir;
        }
    }
    public void SetGravity() {
        gravity = GravitySenser.sensor.Gravity;
    }
}
