using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera overHeadCamera;
    [SerializeField] private float time; 
    [SerializeField] private Camera MainCamera; 
    // Start is called before the first frame update
    private float timeAux;
    private void Start()
    {
        timeAux = time;
        overHeadCamera.enabled = false;
        MainCamera.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            overHeadCamera.enabled = true;
            MainCamera.enabled = false;
        }
    }
}

