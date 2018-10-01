using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drum : MonoBehaviour {
    
    [SerializeField]private AudioSource bass,snare,hat,roll;

    private bool play;
    private float playt;
    private Mode mode;
    private float max;
    private float timeSpan;
    //private Vector3 Velocity;
    private void Awake()
    {
        play = true;
        playt = 0;
        max = 1.0f;
        timeSpan = 0.6f;
        //Velocity = new Vector3();
    }
    void Update()
    {
        if (!play)
        {
            mode = GetMode(Input.acceleration);
            if (mode == Mode.x)
            {
                var x = Input.acceleration.x;
                if (Mathf.Abs(x) > max)
                {
                    bass.Play();
                    play = true;
                }
            }
            if (mode == Mode.y)
            {
                var y = Input.acceleration.y;
                if (Mathf.Abs(y) > max)
                {
                    hat.Play();
                    play = true;
                }
            }
            if(mode==Mode.z){
                var z = Input.acceleration.z;
                if (Mathf.Abs(z) > max) {
                    snare.Play();
                    play = true;
                }
            }
        }
        /*else {
            snare.Play();
            play = true;
        }*/

        if (play) {

            playt += Time.deltaTime;
            if (playt > timeSpan) {
                play = false;
                playt = 0;
            }
        }
    }

    private Mode GetMode(Vector3 vec) {
        if (ALargerThanBWithAbs(vec.x, vec.y))
        {
            if (ALargerThanBWithAbs(vec.x, vec.z))
            {
                return Mode.x;
            }
            else
            {
                return Mode.z;
            }
        }
        else {
            if (ALargerThanBWithAbs(vec.y, vec.z))
            {
                return Mode.y;
            }
            else {
                return Mode.z;
            }
        }

    }
    private bool ALargerThanBWithAbs(float a,float b) {
        a = Mathf.Abs(a);
        b = Mathf.Abs(b);
        return a > b;
    }
}

public enum Mode {
    x,y,z
}