using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedController : MonoBehaviour
{
    public Slider Slider;

    //Invoked when a submit button is clicked.
    public void ChangSpeed(string ObjType)
    {
        if (ObjType.Equals("BELT"))
        {
            PlateController.PlateSpeed = Slider.value;
        }
        else if (ObjType.Equals("CHEF"))
        {
            GameController.ChefSpeed = Slider.value;
        }
        else if (ObjType.Equals("ROTATION"))
        {

        }

    }
}
