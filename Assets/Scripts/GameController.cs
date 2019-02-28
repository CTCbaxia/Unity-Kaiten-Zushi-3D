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
    private Transform trans = null;
    private int i;
    private float duration = 20.0f;
    public static float ChefSpeed;


    void Start()
    {
        ChefSpeed = 4.0f;
        time = 0.0f;
        list = new List<GameObject>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pause) return;

        time += Time.deltaTime;
        if (time > duration/ChefSpeed)
        {
            time = 0.0f;
            float rand = Random.Range(0, 3.0f);
            //rand = 1.5f;
            if (rand < 1.0f)
            {
                list.Add(Instantiate(SushiPlate, new Vector3(25, 15, -35), Quaternion.identity));
            }
            else if (rand < 2.0f)
            {
                list.Add(Instantiate(SpecialPlate, new Vector3(25, 15, -35), Quaternion.identity));
            }
            else
            {
                list.Add(Instantiate(DessertPlate, new Vector3(25, 15, -35), Quaternion.identity));
            }
        }

        for (i = 0; i < list.Count; i++)
        {
            if (list[i].GetComponent<PlateController>().OnBelt || list[i].GetComponent<PlateController>().OnTray)
            {
                print(i);
                trans = list[i].transform;
                break;
            }
        }
        if(i < list.Count)
        {
            ChefLightController.target = trans;
        }
        else
        {
            ChefLightController.target = null;
        }


    }

    public void PauseAndResume(string s)
    {
        if (s.Equals("PAUSE"))
        {
            Time.timeScale = 0.0f;
        }else if (s.Equals("RESUME"))
        {
            Time.timeScale = 1.0f;
        }
    }
}
