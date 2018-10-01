using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painter : MonoBehaviour {
    public GameObject trail;
    private GameObject obj;
    public void PaintStart() {
        obj = Instantiate(trail, trail.transform.position, trail.transform.rotation);
        obj.transform.parent = trail.transform.parent.transform;
        obj.transform.GetComponent<TrailRenderer>().enabled = true;
    }
    public void PaintEnd() {
        obj.transform.parent = null;
    }
    private void Start()
    {
        
    }
}
