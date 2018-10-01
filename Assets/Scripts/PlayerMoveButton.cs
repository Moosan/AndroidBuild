using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveButton : MonoBehaviour {
    private bool forward, back, right, left;
    public float speed;
    private void Awake()
    {
        forward = false;
        back = false;
        right = false;
        left = false;
    }
    private void Update()
    {
        if (forward)
        {
            transform.position+=speed * Time.deltaTime * new Vector3(transform.forward.x, 0.0f, transform.forward.z);
        }
        else if (back)
        {
            transform.position+=speed * Time.deltaTime * new Vector3(-transform.forward.x, 0.0f, -transform.forward.z);
        }
        else if (right)
        {
            transform.position+=speed * Time.deltaTime * new Vector3(transform.right.x, 0.0f, transform.right.z);
        }
        else if (left) {
            transform.position+=speed * Time.deltaTime * new Vector3(-transform.right.x, 0.0f, -transform.right.z);
        }
    }
    public void OnFD()
    {
        forward = true;
    }

    public void OnFU()
    {
        forward = false;
    }
    public void OnBD()
    {
        back = true;
    }

    public void OnBU()
    {
        back = false;
    }
    public void OnRD()
    {
        right = true;
    }

    public void OnRU()
    {
        right = false;
    }
    public void OnLD()
    {
        left = true;
    }

    public void OnLU()
    {
        left = false;
    }
}
