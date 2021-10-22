using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject Enemyself;
    private float speed = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timeExtender());
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject Target = GameObject.FindGameObjectWithTag("Target");
        //Enemyself.transform.LookAt(Target.transform);
        transform.Translate(Vector3.up * Time.deltaTime * speed);

    }

    IEnumerator timeExtender()
    {
        yield return new WaitForSeconds(5);
        transform.Rotate(new Vector3(0, 0, 90));
        yield return new WaitForSeconds(10);
        transform.Rotate(new Vector3(0, 0, -90));
        yield return new WaitForSeconds(5);
        transform.Rotate(new Vector3(0, 0, -90));
        yield return new WaitForSeconds(15);
        transform.Rotate(new Vector3(0, 0, 90));
        yield return new WaitForSeconds(5);
        transform.Rotate(new Vector3(0, 0, 90));
        yield return new WaitForSeconds(5);
        transform.Rotate(new Vector3(0, 0, -90));
        yield return new WaitForSeconds(5);
        transform.Rotate(new Vector3(0, 0, -90));
        yield return new WaitForSeconds(10);
        transform.Rotate(new Vector3(0, 0, 90));
        yield return new WaitForSeconds(5);
        transform.Rotate(new Vector3(0, 0, 90));
        yield return new WaitForSeconds(10);
        transform.Rotate(new Vector3(0, 0, -90));
        
    }

}


/*
yield return new WaitForSeconds(1);
yield return new WaitForSeconds(3);
yield return new WaitForSeconds(5);
yield return new WaitForSeconds(10);
yield return new WaitForSeconds(15);
yield return new WaitForSeconds(20);
 */