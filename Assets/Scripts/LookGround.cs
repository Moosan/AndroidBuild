using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookGround : MonoBehaviour {
    public GameObject par;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = par.transform.position + new Vector3(0.0f,-100.0f,0.0f);
	}
}
