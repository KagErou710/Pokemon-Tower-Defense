using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject Enemyself;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Target = GameObject.FindGameObjectWithTag("Target");
        Enemyself.transform.LookAt(Target.transform);
        transform.Translate(Vector3.forward  * Time.deltaTime * speed);
    }
}
