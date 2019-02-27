using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamController : MonoBehaviour
{
    public GameObject DessertPlate;
    public GameObject IceCream;
    private float speedAxis = 50;
    private float speedIce = 300;

    // Start is called before the first frame update
    void Start()
    {
        DessertPlate = transform.parent.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = DessertPlate.transform.position.x;
        float y = DessertPlate.transform.position.y + 1.5f;
        float z = DessertPlate.transform.position.z;
        transform.RotateAround(new Vector3(x, y, z), DessertPlate.transform.forward, speedAxis * Time.deltaTime);
        IceCream.transform.RotateAround(transform.position, transform.right, speedIce * Time.deltaTime);
        IceCream.transform.rotation = Quaternion.Euler(0, 0, 0);//set ice cream down
    }
}
