using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject Wobbuffet;
    public GameObject Arbok;
    public GameObject Snorlax;
    public GameObject Lapas;
    public GameObject Buildtwo;
    public GameObject JessieAndJames;

    public GameObject Enemy_Emitter;
    private float Bullet_Forward_Force = 10;

    public static int funds = 2000;
    public float timer = 30f;
    public TMPro.TextMeshProUGUI textFunds;
    public TMPro.TextMeshProUGUI textTimer;
    public TMPro.TextMeshProUGUI textPhase;
    public TMPro.TextMeshProUGUI textBoss;

    private float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        textFunds.text = "" + funds;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timer -= Time.deltaTime;
        float randomTime = Random.Range(3.0f, 15.0f);
        textTimer.text = "" + Mathf.Round(timer);
        textFunds.text = "" + funds;
    }

    private void spawnEnemy(GameObject enemy)
    {
        GameObject Temporary_Enemy_Handler;
        Temporary_Enemy_Handler = Instantiate(enemy, Enemy_Emitter.transform.position, Enemy_Emitter.transform.rotation) as GameObject;

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

    IEnumerator phaseCounter()
    {
        //phase 1
        textPhase.text = "Phase 1";
        for(int i = 0; i<10; i++)
        {
            spawnEnemy(Wobbuffet);
            yield return new WaitForSeconds(3);
        }
        textBoss.text = "Phase Boss shows up";


    }
}
