using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefLightController : MonoBehaviour
{
    public static Transform target;
    public Transform chefTarget;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (target == null)
        {
            transform.LookAt(chefTarget);
        }
        else
        {
            print("ChefLightController:" + target);
            transform.LookAt(target);
        }

    }
}
