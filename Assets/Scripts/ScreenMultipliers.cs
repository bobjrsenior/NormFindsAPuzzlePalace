using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class ScreenMultipliers : MonoBehaviour
{
    public static float horizontalMultiplier = UnityEngine.Device.Screen.width / 1920.0f;
    public static float verticalMultiplier = UnityEngine.Device.Screen.width / 1080.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
