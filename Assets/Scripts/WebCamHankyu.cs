using UnityEngine;
using System.Collections;

public class WebCamHankyu : MonoBehaviour
{
    public int Width = 1920;
    public int Height = 1080;
    public int FPS = 30;

    // Use this for initialization
    void Start()
    {
        var devices = WebCamTexture.devices;
        if (devices.Length == 0)
        {
            Debug.LogError("Webカメラが検出できませんでした。");
            return;
        }

        // WebCamテクスチャを作成する
        var webcamTexture = new WebCamTexture(Width, Height, FPS);

        GetComponent<MeshRenderer>().material.mainTexture = webcamTexture;
        webcamTexture.Play();
    }
}