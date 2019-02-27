using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    private GameObject plate1 = null;
    private GameObject plate2 = null;
    private GameObject plate3 = null;
    private GameObject plate4 = null;
    //private float numOfPlate;
    void FixedUpdate()
    {
        //numOfPlate = 0.0f;
        //if (plate1 != null) numOfPlate += 1.0f;
        //else if (plate2 != null) numOfPlate += 1.0f;
        //else if (plate3 != null) numOfPlate += 1.0f;
        //else if (plate4 != null) numOfPlate += 1.0f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SushiPlate") || other.CompareTag("SpecialPlate") || other.CompareTag("DessertPlate"))
        {
            if (plate1 == null) plate1 = other.gameObject;
            else if (plate2 == null) plate2 = other.gameObject;
            else if (plate3 == null) plate3 = other.gameObject;
            else if (plate4 == null) plate4 = other.gameObject;
            else
            {
                print("more than 4");
                DestroyPlate(other.gameObject);
            }
        }

    }
    private void DestroyPlate(GameObject obj)
    {

        List<GameObject> list = GameController.list;
        list.Remove(obj);
        Destroy(obj);
    }

}
