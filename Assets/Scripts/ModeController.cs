using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeController : MonoBehaviour
{
    public static string GameMode = "EASY";
    public void ChangeMode(string mode)
    {
        GameMode = mode;
    }
}
