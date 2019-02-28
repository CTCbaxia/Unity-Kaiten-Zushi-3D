using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewController : MonoBehaviour
{
    public Camera PCamera;
    public Slider Slider;

    //Invoked when a submit button is clicked.
    public void ChangView(string Direction)
    {
        if (Direction.Equals("LR"))
        {
            PCamera.transform.position = new Vector3(Slider.value, PCamera.transform.position.y, PCamera.transform.position.z);
        }
        if (Direction.Equals("UD"))
        {
            PCamera.transform.rotation = Quaternion.Euler(50-Slider.value, PCamera.transform.rotation.y, PCamera.transform.rotation.z);
        }

    }
}
