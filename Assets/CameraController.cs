using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static bool CameraChanged = false;

    public void ChangeCamera()
    {
        CameraChanged = true;
    }
}
