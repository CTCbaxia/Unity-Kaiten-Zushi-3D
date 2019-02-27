using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private float time;
    public static bool pause = false;
    public GameObject SushiPlate;
    public GameObject SpecialPlate;
    public GameObject DessertPlate;
    public static List<GameObject> list;
    void Start()
    {
        time = 0f;
        list = new List<GameObject>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pause) return;

        time += Time.deltaTime;
        if (time > 3.0f)
        {
            time = 0f;
            float rand = Random.Range(0, 3.0f);
            //rand = 1.5f;
            if (rand < 1.0f)
            {
                list.Add(Instantiate(SushiPlate, new Vector3(5, 3, -7), Quaternion.identity));
            }
            else if (rand < 2.0f)
            {
                list.Add(Instantiate(SpecialPlate, new Vector3(5, 3, -7), Quaternion.identity));
            }
            else
            {
                list.Add(Instantiate(DessertPlate, new Vector3(5, 3, -7), Quaternion.identity));
            }
        }
    }
}
