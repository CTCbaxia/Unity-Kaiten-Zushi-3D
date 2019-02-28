using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{

    private Vector3 endPos1 = new Vector3(-40f, 15, -40f);
    private Vector3 endPos2 = new Vector3(-40f, 15, 40f);
    private Vector3 endPos3 = new Vector3(40f, 15, 40f);
    private Vector3 endPos4 = new Vector3(40f, 15, -40f);

    private bool left = true;
    private bool up = false;
    private bool right = false;
    private bool down = false;
    private bool OnTable = false;
    private bool OnBelt = true;
    private bool OnTray = false;
    private bool OnGround = false;
    private float eatTimer = 20.0f;
    private float Timer;
    public static float PlateSpeed = 15;
    public static bool ShouldDestroy = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (OnTable)
        {
            Timer -= Time.deltaTime;
            if (Timer < 0)
            {
                print("eat by the user");
                DestroyPlate();
            }
        }

        //plate move
        if (left)
        {
            if (transform.position != endPos1)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPos1, PlateSpeed * Time.deltaTime);
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
                transform.position = Vector3.MoveTowards(transform.position, endPos2, PlateSpeed * Time.deltaTime);
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
                transform.position = Vector3.MoveTowards(transform.position, endPos3, PlateSpeed * Time.deltaTime);
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
                transform.position = Vector3.MoveTowards(transform.position, endPos4, PlateSpeed * Time.deltaTime);
            }
            else
            {
                DestroyPlate();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BeltDown"))
        {
            MoveLeft();
        }
        else if (other.CompareTag("BeltLeft"))
        {
            MoveUp();
        }
        else if (other.CompareTag("BeltUp"))
        {
            MoveRight();
        }
        else if (other.CompareTag("BeltRight"))
        {
            MoveDown();
        }
        else if (other.CompareTag("Tray"))
        {
                OnTable = false;
                OnTray = true;


        }
        // put on to table
        else if (other.CompareTag("Table"))
        {
            left = false;
            up = false;
            right = false;
            down = false;
            OnTable = true;
            OnBelt = false;
            OnTray = false;
            Timer = eatTimer;
        }
        // collision other plate
        else if (other.CompareTag("SushiPlate") || other.CompareTag("SpecialPlate") || other.CompareTag("DessertPlate"))
        {
            print("destroy by collision here");
            DestroyPlate();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (OnTray && (other.CompareTag("BeltDown") || other.CompareTag("BeltLeft") || other.CompareTag("BeltUp") || other.CompareTag("BeltRight")))
        {
            OnBelt = false;
            if (ModeController.GameMode.Equals("HARD"))
            {
                left = false;
                up = false;
                right = false;
                down = false;
                OnTable = false;
            }
        }

    }
        void DestroyPlate()
    {

        List<GameObject> list = GameController.list;
        list.Remove(gameObject);
        Destroy(gameObject);
    }
    void EatPlate()
    {
        List<GameObject> list = GameController.list;
        list.Remove(gameObject);
        Destroy(gameObject);
    }
    void MoveLeft()
    {
        left = true;
        up = false;
        right = false;
        down = false;
        OnTable = false;
        OnBelt = true;
        OnTray = false;

    }
    void MoveUp()
    {
        left = false;
        up = true;
        right = false;
        down = false;
        OnTable = false;
        OnBelt = true;
        OnTray = false;
    }
    void MoveRight()
    {
        left = false;
        up = false;
        right = true;
        down = false;
        OnTable = false;
        OnBelt = true;
        OnTray = false;
    }
    void MoveDown()
    {
        left = false;
        up = false;
        right = false;
        down = true;
        OnTable = false;
        OnBelt = true;
        OnTray = false;
    }
}
