using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam4;
    public GameObject boss;

    private int count = 0;
    private bool check = false;

    // Update is called once per frame
    void Update()
    {

    }

    public void changeCamera()
    {
        count += 1;
        if(count == 0)
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(false);
            boss.SetActive(false);

        }
        else if (count == 1)
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            cam3.SetActive(false);
            cam4.SetActive(false);
            boss.SetActive(false);
        }
        else if (count == 2)
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(true);
            cam4.SetActive(false);
            boss.SetActive(false);
        }
        else if (count == 3)
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
            cam4.SetActive(true);
            boss.SetActive(false);
            count = -1;
        }
    }
}
