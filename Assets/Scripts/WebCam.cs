using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class WebCam : MonoBehaviour
{
    public Camera maincamera;
    WebCamTexture webcamTexture;
    const int FPS = 60;

    void Start()
    {
        //float _h = maincamera.orthographicSize * 2;
        //float _w = _h * maincamera.aspect;
        //transform.localScale = new Vector3(_w, _h, 1);
        Renderer rend = GetComponent<Renderer>();
        if (WebCamTexture.devices.Length > 1)
        {
            WebCamDevice cam = WebCamTexture.devices[0];
            WebCamTexture wcam = new WebCamTexture(cam.name);
            wcam.Play();
            int width = wcam.width, height = wcam.height;
            //if (width < 1280 || height < 720) { width *= 2; height *= 2; }
            webcamTexture = new WebCamTexture(cam.name, width, height, FPS);
            wcam.Stop();

            rend.material.mainTexture = webcamTexture;
            webcamTexture.Play();
        }
    }
    
}