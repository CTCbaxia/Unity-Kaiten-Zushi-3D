using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPlateController : MonoBehaviour
{


    // Start is called before the first frame update

    //public GameObject SpecialPlate;
    public GameObject SaucePlateA;
    public GameObject SaucePlateB;

    private Vector3 endPos1 = new Vector3(-7.5f, 3, -7.5f);
    private Vector3 endPos2 = new Vector3(-7.5f, 3, 7.5f);
    private Vector3 endPos3 = new Vector3(7.5f, 3, 7.5f);
    private Vector3 endPos4 = new Vector3(7.5f, 3, -7.5f);

    private bool left = true;
    private bool up = false;
    private bool right = false;
    private bool down = false;

    private float speed = 5;
    private float speedA = 100;
    private float speedB = 50;
    // Update is called once per frame
    private void Start()
    {
        //SpecialPlate = GameObject.FindWithTag("SpecialPlate");
        //SaucePlateA = GameObject.FindWithTag("SaucePlateClose");
        //SaucePlateB = GameObject.FindWithTag("SaucePlateFar");
    }
    void FixedUpdate()
    {
        //sauce plate move
        //SaucePlateA.transform.RotateAround(transform.position, Vector3.up, speedA * Time.deltaTime);
        //SaucePlateB.transform.RotateAround(transform.position, Vector3.up, speedB * Time.deltaTime);

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
