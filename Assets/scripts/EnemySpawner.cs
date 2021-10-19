using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject Enemy1;
    public GameObject Enemy_Emitter;
    private float Bullet_Forward_Force = 10;

    private float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= Random.Range(3.0f, 5.0f))
        {
            GameObject Temporary_Enemy_Handler;
            Temporary_Enemy_Handler = Instantiate(Enemy1, Enemy_Emitter.transform.position, Enemy_Emitter.transform.rotation) as GameObject;

            //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
            //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
            Temporary_Enemy_Handler.transform.Rotate(Vector3.left * 90);

            //Retrieve the Rigidbody component from the instantiated Bullet and control it.
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Enemy_Handler.GetComponent<Rigidbody>();

            //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force. 
            Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);
            time = 0.0f;

        }
    }
}
