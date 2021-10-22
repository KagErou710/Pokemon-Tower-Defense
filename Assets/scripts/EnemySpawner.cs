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
    public TMPro.TextMeshProUGUI textPhase;
    public TMPro.TextMeshProUGUI textBoss;

    private GameObject pokemon;
    private float time = 0.0f;
    private int phase = 1;

    private bool firstIsFinish = false;
    private bool secondIsFinish = false;
    private bool thirdIsFinish = false;
    private bool restIsFinish = false;
    private bool restIsFinish2 = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(firstPhase());
        //spawnEnemy(Lapas);
        textFunds.text = "" + funds;
    }

    // Update is called once per frame
    void Update()
    {
        textFunds.text = "" + funds;
        isEnemy(phase);
        if (firstIsFinish == true)
        {
            textPhase.text = "rest";
            StartCoroutine(restTime());
            if (restIsFinish == true)
            {
                StopCoroutine(restTime());
                StartCoroutine(secondPhase());
                firstIsFinish = false;
                phase = 2;
                restIsFinish = false;
            }
        }
        else if (secondIsFinish == true)
        {
            textPhase.text = "rest";
            StartCoroutine(restTime2());
            Debug.Log("1:" + restIsFinish);
            if (restIsFinish2 == true)
            {
                StopCoroutine(restTime2());
                StartCoroutine(thirdPhase());
                secondIsFinish = false;
                phase = 3;
                restIsFinish2 = false;
            }
        }
        else if (thirdIsFinish == true)
        {
            textBoss.text = "u win";
        }
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

    private void isEnemy(int num)
    {
        pokemon = GameObject.FindGameObjectWithTag("enemy");
        
        if(num == 1)
        {
            if (pokemon == null)
            {
                firstIsFinish = true;
            }
            else
            {
                firstIsFinish = false;
            }
        }
        else if (num == 2)
        {
            if (pokemon == null)
            {
                secondIsFinish = true;
            }
            else
            {
                secondIsFinish = false;
            }
        }
        else if (num == 3)
        {
            if (pokemon == null)
            {
                thirdIsFinish = true;
            }
            else
            {
                thirdIsFinish = false;
            }
        }
    }
    IEnumerator restTime()
    {
        yield return new WaitForSeconds(5);
        restIsFinish = true;
    }

    IEnumerator restTime2()
    {
        yield return new WaitForSeconds(5);
        restIsFinish2 = true;
    }


    IEnumerator firstPhase()
    {
        textPhase.text = "Phase 1";
        
        for(int i = 0; i<10; i++)
        {
            spawnEnemy(Wobbuffet);
            yield return new WaitForSeconds(3);
        }
        
        textBoss.text = "Phase Boss shows up";
        spawnEnemy(Lapas);
        yield return new WaitForSeconds(3);
        textBoss.text = "";
    }
    
    IEnumerator secondPhase()
    {
        textPhase.text = "Phase 2";

        for (int i = 0; i < 5; i++)
        {
            spawnEnemy(Wobbuffet);
            yield return new WaitForSeconds(3);
            spawnEnemy(Wobbuffet);
            yield return new WaitForSeconds(3);
            spawnEnemy(Arbok);
            yield return new WaitForSeconds(3);
        }

        textBoss.text = "Phase Boss shows up";
        spawnEnemy(Buildtwo);
        yield return new WaitForSeconds(3);
        textBoss.text = "";
    }


    IEnumerator thirdPhase()
    {
        textPhase.text = "Phase 3";

        for (int i = 0; i < 5; i++)
        {
            spawnEnemy(Wobbuffet);
            yield return new WaitForSeconds(2);
            spawnEnemy(Arbok);
            yield return new WaitForSeconds(2);
            spawnEnemy(Snorlax);
            yield return new WaitForSeconds(2);
            spawnEnemy(Arbok);
            yield return new WaitForSeconds(2);
            spawnEnemy(Snorlax);
            yield return new WaitForSeconds(2);
            spawnEnemy(Snorlax);
            yield return new WaitForSeconds(2);
        }

        textBoss.text = "Phase Boss shows up";
        spawnEnemy(JessieAndJames);
        yield return new WaitForSeconds(3);
        textBoss.text = "";
    }
}
