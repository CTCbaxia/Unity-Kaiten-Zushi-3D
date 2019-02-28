using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public Material OnSelect;
    public Material PreSelect;
    GameObject pre = null;
    GameObject obj = null;
    Plane objPlane;
    float rayDistance;
    private bool TouchedOnce = false;
    private bool PlateSelected = false;
    private bool BeltSelected = false;
    private bool ChefSelected = false;
    private bool NonSelect = false;
    private bool DeSelect = false; // TBD deselect in the UI
    //public static bool TouchedPlate = false;

    public static bool PlateOnGround = false;
    public GameObject BeltPanel;
    public GameObject ChefPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount == 0) return;
        Touch touch = Input.GetTouch(0);

        if(touch.phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) //if we hit anything
            {
                // assign for drag
                obj = hit.transform.gameObject;
                objPlane = new Plane(new Vector3(0, 1, 0), obj.transform.position);
                print("here hit chef" + obj.CompareTag("Chef"));
                if (obj.CompareTag("SushiPlate") || obj.CompareTag("SpecialPlate") || obj.CompareTag("DessertPlate") || obj.CompareTag("Belt") || obj.CompareTag("Chef"))
                {
                    NonSelect = false;
                }
                else
                {
                    NonSelect = true;
                }

                // deselect pre (if we select before, and this time select new)
                if ((PlateSelected || BeltSelected || ChefSelected) && (!NonSelect || DeSelect))
                {
                    DeSelectObject(pre);

                }
                if (pre == obj && TouchedOnce)
                {
                    TouchedOnce = false;
                    return;
                }
                TouchedOnce = true;

                SelectObject(obj);

                // if we select some obj
                if (!NonSelect) pre = obj;
                if (DeSelect)
                {
                    PlateSelected = false;
                    BeltSelected = false;
                    ChefSelected = false;
                }

            }
        }
        else if(touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
        {

            if (obj == null) return;//if the object is destroyed when collision
            if (!obj.CompareTag("SushiPlate") && !obj.CompareTag("SpecialPlate")&& !obj.CompareTag("DessertPlate"))
            {
                return;
            }

            // can only drag plates
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            if(objPlane.Raycast(ray, out rayDistance))
            {
                obj.transform.position = ray.GetPoint(rayDistance);
                //TouchedPlate = false;
            }
        }
        else if(touch.phase == TouchPhase.Ended)
        {
            //RaycastHit hit;
            //if (Physics.Raycast(obj.transform.position, obj.transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
            //{
            //    GameObject hitObject = hit.collider.gameObject;
            //    if (hitObject.CompareTag("Ground") && !hitObject.CompareTag("Table") && !hitObject.CompareTag("Belt"))
            //    {
            //        if(obj.CompareTag("SushiPlate") || obj.CompareTag("SpecialPlate") || obj.CompareTag("DessertPlate"))
            //        {
            //            DestroyPlate(obj);
            //        }
            //    }

            //}


        }

    }


    void DeSelectObject(GameObject preObj)
    {
        if (preObj == null) return;

        if (PlateSelected)
        {
            // recover color
            GameObject plate = preObj.transform.Find("Plate").gameObject;
            plate.GetComponent<Renderer>().material = PreSelect;

            //recover food
            if (preObj.CompareTag("SpecialPlate"))
            {
                preObj.transform.Find("Sauce Plate A").GetComponent<SaucePlateController>().enabled = true;
                preObj.transform.Find("Sauce Plate B").GetComponent<SaucePlateController>().enabled = true;
            }
            else if (preObj.CompareTag("DessertPlate"))
            {
                preObj.transform.Find("Axis").GetComponent<IceCreamController>().enabled = true;
            }

        }
        else if (BeltSelected)
        {
            GameObject b1 = preObj.transform.Find("up").gameObject;
            GameObject b2 = preObj.transform.Find("down").gameObject;
            GameObject b3 = preObj.transform.Find("left").gameObject;
            GameObject b4 = preObj.transform.Find("right").gameObject;
            b1.GetComponent<Renderer>().material = PreSelect;
            b2.GetComponent<Renderer>().material = PreSelect;
            b3.GetComponent<Renderer>().material = PreSelect;
            b4.GetComponent<Renderer>().material = PreSelect;

            List<GameObject> list = GameController.list;
            for (int i = 0; i < list.Count; i++)
            {
                list[i].GetComponent<PlateController>().enabled = true;
            }
           
            GameController.pause = false;
            // close panel
            BeltPanel.SetActive(false);
        }
        else if (ChefSelected)
        {
            ChefPanel.SetActive(false);
        }
    }

    void SelectObject(GameObject obj)
    {
        if (obj.CompareTag("SushiPlate") || obj.CompareTag("SpecialPlate") || obj.CompareTag("DessertPlate"))
        {
            PlateSelected = true;
            BeltSelected = false;
            NonSelect = false;

            //change color
            GameObject plate = obj.transform.Find("Plate").gameObject;//get this obj's plate child
            PreSelect = plate.GetComponent<Renderer>().material;
            plate.GetComponent<Renderer>().material = OnSelect;

            // TBD source should stop moving
            if (obj.CompareTag("SpecialPlate"))
            {
                obj.transform.Find("Sauce Plate A").GetComponent<SaucePlateController>().enabled = false;
                obj.transform.Find("Sauce Plate B").GetComponent<SaucePlateController>().enabled = false;
            }
            else if (obj.CompareTag("DessertPlate"))
            {
                obj.transform.Find("Axis").GetComponent<IceCreamController>().enabled = false;
            }
        }
        // if obj is belt
        else if (obj.CompareTag("Belt"))
        {
            PlateSelected = false;
            BeltSelected = true;
            NonSelect = false;

            //change belt color
            GameObject b1 = obj.transform.Find("up").gameObject;
            GameObject b2 = obj.transform.Find("down").gameObject;
            GameObject b3 = obj.transform.Find("left").gameObject;
            GameObject b4 = obj.transform.Find("right").gameObject;
            PreSelect = b1.GetComponent<Renderer>().material;
            b1.GetComponent<Renderer>().material = OnSelect;
            b2.GetComponent<Renderer>().material = OnSelect;
            b3.GetComponent<Renderer>().material = OnSelect;
            b4.GetComponent<Renderer>().material = OnSelect;

            // stop moving plates
            List<GameObject> list = GameController.list;
            for(int i = 0; i < list.Count; i++)
            {
                list[i].GetComponent<PlateController>().enabled = false;
            }

            // stop creating plates
            GameController.pause = true;

            // open panel
            BeltPanel.SetActive(true);

        }
        else if (obj.CompareTag("Chef"))
        {
            ChefPanel.SetActive(true);
        }
    }
    private void DestroyPlate(GameObject obj)
    {

        List<GameObject> list = GameController.list;
        list.Remove(obj);
        Destroy(obj);
    }
}
