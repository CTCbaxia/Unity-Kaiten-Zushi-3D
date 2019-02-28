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
    public Camera RCamera;
    public Camera PCamera;

    void Start()
    {
        ChefSpeed = 4.0f;
        time = 0.0f;
        list = new List<GameObject>();
        RCamera.depth = 0;
        PCamera.depth = -1;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pause) return;

        if (CameraController.CameraChanged) 
        {
            print("RCamera.depth:"+RCamera.depth);
            print("PCamera.depth:" + PCamera.depth);
            ChangeView();
            //string s = CameraController.CameraType;
            //if (s.Equals("PERSONAL"))
            //{
            //    RCamera.enabled = true;
            //    PCamera.enabled = false;
            //}
            //else if (s.Equals("RESTAURANT"))
            //{
            //    print("changeshhhhhhhhhhhh");
            //    PCamera.enabled = true;
            //    RCamera.enabled = false;

            //}
            print("After RCamera.depth:" + RCamera.depth);
            print("After PCamera.depth:" + PCamera.depth);
            CameraController.CameraChanged = false;
        }

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

    public void ChangeView()
    {
        print("changed view");
        if (RCamera.depth > -1)
        {

            //viewSlider.SetActive(false);
            RCamera.depth = -1;
            PCamera.depth = 0;
            //modeText.text = "Restaurant Mode";
            //Vector3 v = TouchController.BPanel.transform.position;
            //print(v.x + " " + v.y + " " +v.z);
            //TouchController.GameCanvas.transform.rotation = Quaternion.Euler(0, 0, 0);
            //TouchController.GameCanvas.transform.position = new Vector3(0, -5.0f, 0);
        }
        else
        {
            //viewSlider.SetActive(true);
            PCamera.depth = -1;
            RCamera.depth = 0;
            //modeText.text = "Player Mode";
            //TouchController.BPanel.transform.position = new Vector3(1030, 1068, 0);
        }
    }
}
