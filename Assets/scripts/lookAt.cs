using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAt : MonoBehaviour
{

    public GameObject what;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject where = GameObject.FindGameObjectWithTag("MainCamera");
        what.transform.LookAt(where.transform);
    }
}
