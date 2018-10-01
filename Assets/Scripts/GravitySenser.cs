using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GravitySenser : MonoBehaviour {
    public float Gravity { get; private set; }
    public static GravitySenser sensor;
    private bool Calcurating;
    private float CalcurateTime;
    public GameObject tex;
    private Text text;
    private float AccelerometerUpdateInterval;
    private float LowPassKernelWidthInSeconds;
    private List<float> AccList;

    private float LowPassFilterFactor; // 微調整可能
    private Vector3 lowPassValue  = Vector3.zero;
	void Start () {
        AccList = new List<float>();
        CalcurateTime = 5.0f;
        Calcurating = false;
        text = tex.GetComponent<Text>();
        sensor = this;
        Gravity = 1.00f;
        AccelerometerUpdateInterval = 1.0f / 60.0f;
        LowPassKernelWidthInSeconds = 1.0f;
        lowPassValue = Input.acceleration;
        LowPassFilterFactor = AccelerometerUpdateInterval / LowPassKernelWidthInSeconds;
        ArrayMax = 500;
    }
    private float sum;
    private int ArrayMax;
	void FixedUpdate () {
        var thisz = LowPassFilterAccelerometer(new Vector3(0,0,Input.acceleration.z)).z;
        AccList.Add(thisz);
        if (AccList.Count > ArrayMax)
        {
            AccList.RemoveAt(0);
        }
        else
        {
            return;
        }
        if (Calcurating) {
            CalcurateTime -= Time.deltaTime;
            if (CalcurateTime <= 0) {
                sum = 0.0f;
                foreach (var z in AccList)
                {
                    sum += z;
                }
                Gravity = sum / ArrayMax;
                Calcurating = false;
                CalcurateTime = 5.0f;
                text.text = Gravity.ToString();
            }
            //text.text = thisz.ToString()+"\n"+(ave/AccList.Count).ToString();
        }
	}
    public void Calculate() {
        Calcurating = true;
        text.text = "測定チュー";
    }

    public Vector3 LowPassFilterAccelerometer(Vector3 vector){
        lowPassValue = Vector3.Lerp(lowPassValue, vector, LowPassFilterFactor);
        return lowPassValue;
    }
    /*public Vector3 Sampling() {
        var period  = 0.0f;
        var acc  = Vector3.zero;
        foreach (var evnt in Input.accelerationEvents)
        {
            acc += evnt.acceleration * evnt.deltaTime;
            period += evnt.deltaTime;
        }
        if (period > 0){
            acc *= 1.0f / period;
        }
        return acc;
    }*/
}
