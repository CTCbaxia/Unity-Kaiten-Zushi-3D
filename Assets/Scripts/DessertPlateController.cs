using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DessertPlateController : MonoBehaviour
{
    //public GameObject DessertPlate;
    public GameObject IceAxis;
    public GameObject IceCream;


    private Vector3 endPos1 = new Vector3(-7.5f, 3, -7.5f);
    private Vector3 endPos2 = new Vector3(-7.5f, 3, 7.5f);
    private Vector3 endPos3 = new Vector3(7.5f, 3, 7.5f);
    private Vector3 endPos4 = new Vector3(7.5f, 3, -7.5f);

    private bool left = true;
    private bool up = false;
    private bool right = false;
    private bool down = false;

    private float speedAxis = 50;
    private float speedIce = 300;
    private float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        //DessertPlate = GameObject.FindWithTag("DessertPlate");
        //IceAxis = GameObject.FindWithTag("IceAxis");
        //IceCream = GameObject.FindWithTag("IceCream");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //float x = transform.position.x;
        //float y = transform.position.y + 1.5f;
        //float z = transform.position.z;
        //IceAxis.transform.RotateAround(new Vector3(x,y,z), Vector3.back, speedAxis * Time.deltaTime);
        //IceCream.transform.RotateAround(IceAxis.transform.position, IceAxis.transform.right, speedIce * Time.deltaTime);
        //IceCream.transform.rotation = Quaternion.Euler(0, 0, 0);//set ice cream down

        //plate move
        if (left)
        {
            if (transform.position != endPos1)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPos1, speed * Time.deltaTime);
            }
            else
            {
                left = false;
                up = true;
            }
        }

        if (up)
        {
            if (transform.position != endPos2)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPos2, speed * Time.deltaTime);
            }
            else
            {
                up = false;
                right = true;
            }
        }
        if (right)
        {
            if (transform.position != endPos3)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPos3, speed * Time.deltaTime);
            }
            else
            {
                right = false;
                down = true;
            }
        }
        if (down)
        {
            if (transform.position != endPos4)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPos4, speed * Time.deltaTime);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BeltDown"))
        {
            left = true;
            up = false;
            right = false;
            down = false;
        }
        else if (other.CompareTag("BeltLeft"))
        {
            left = false;
            up = true;
            right = false;
            down = false;
        }
        else if (other.CompareTag("BeltUp"))
        {
            left = false;
            up = false;
            right = true;
            down = false;
        }
        else if (other.CompareTag("BeltRight"))
        {
            left = false;
            up = false;
            right = false;
            down = true;
        }

    }
}
