using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaucePlateController : MonoBehaviour
{
    public GameObject SpecialPlate;
    public float SauceSpeed;
    // Start is called before the first frame update
    void Start()
    {
        SpecialPlate = transform.parent.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.RotateAround(SpecialPlate.transform.position,SpecialPlate.transform.up, SauceSpeed * Time.deltaTime);
    }
}
