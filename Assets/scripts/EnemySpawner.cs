using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{

    public GameObject Wobbuffet;
    public GameObject Arbok;
    public GameObject Snorlax;
    public GameObject Lapas;
    public GameObject Buildtwo;
    public GameObject JessieAndJames;

    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam4;
    public GameObject boss;

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
    private bool firstTime = false;

    public AudioSource MpPlayer;
    public AudioClip clipFirstPhase;
    public AudioClip clipFirstBoss;
    public AudioClip clipSecondPhase;
    public AudioClip clipSecondBoss;
    public AudioClip clipThirdPhase;
    public AudioClip clipThirdBoss;
    public AudioClip kyukei;
    public AudioClip kyukei2;

    public AudioSource VoicePlayer;
    public AudioClip lapas;
    public AudioClip buildtwo;
    public AudioClip meaw;
    public AudioClip yanakanji;

    // Start is called before the first frame update
    void Start()
    {
        //spawnEnemy(JessieAndJames);
        StartCoroutine(firstPhase());
        funds = 2000;
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
            if (firstTime == false)
            {
                StartCoroutine(restTime());
                firstTime = true;
            }
            if (restIsFinish == true)
            {
                StopCoroutine(restTime());
                StartCoroutine(secondPhase());
                firstIsFinish = false;
                phase = 2;
                restIsFinish = false;
                firstTime = false;
            }
        }
        else if (secondIsFinish == true)
        {
            textPhase.text = "rest";
            if (firstTime == false)
            {
                StartCoroutine(restTime2());
                firstTime = true;
            }
            if (restIsFinish2 == true)
            {
                StopCoroutine(restTime2());
                StartCoroutine(thirdPhase());
                secondIsFinish = false;
                phase = 3;
                restIsFinish2 = false;
                firstTime = false;
            }
        }
        else if (thirdIsFinish == true)
        {
            if (firstTime == false)
            {
                VoicePlayer.clip = yanakanji;
                VoicePlayer.Play();
                firstTime = true;
                StartCoroutine(loadToWin());
            }
        }
        
    }

    private void spawnEnemy(GameObject enemy)
    {
        GameObject Temporary_Enemy_Handler;
        Temporary_Enemy_Handler = Instantiate(enemy, Enemy_Emitter.transform.position, Enemy_Emitter.transform.rotation) as GameObject;

        //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
        //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
        Temporary_Enemy_Handler.transform.Rotate(Vector3.up * 180);

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
        MpPlayer.Stop();
        MpPlayer.clip = kyukei;
        MpPlayer.Play();
        yield return new WaitForSeconds(33);
        restIsFinish = true;
    }

    IEnumerator restTime2()
    {
        MpPlayer.Stop();
        MpPlayer.clip = kyukei2;
        MpPlayer.Play();
        yield return new WaitForSeconds(40);
        restIsFinish2 = true;
    }


    IEnumerator firstPhase()
    {
        textPhase.text = "Phase 1";
        MpPlayer.clip = clipFirstPhase;
        MpPlayer.Play();
        MpPlayer.loop = false;
        for(int i = 0; i<10; i++)
        {
            spawnEnemy(Wobbuffet);
            yield return new WaitForSeconds(3);
        }
        MpPlayer.Stop();
        MpPlayer.clip = clipFirstBoss;
        MpPlayer.Play();
        textBoss.text = "Phase Boss shows up";
        spawnEnemy(Lapas);
        VoicePlayer.clip = lapas;
        VoicePlayer.Play();
        cam1.SetActive(false);
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam4.SetActive(false);
        boss.SetActive(true);
        yield return new WaitForSeconds(5);
        cam1.SetActive(true);
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam4.SetActive(false);
        boss.SetActive(false);
        textBoss.text = "";
    }
    
    IEnumerator secondPhase()
    {
        textPhase.text = "Phase 2";
        MpPlayer.Stop();
        MpPlayer.clip = clipSecondPhase;
        MpPlayer.Play();

        for (int i = 0; i < 5; i++)
        {
            spawnEnemy(Wobbuffet);
            yield return new WaitForSeconds(3);
            spawnEnemy(Arbok);
            yield return new WaitForSeconds(5);
            spawnEnemy(Arbok);
            yield return new WaitForSeconds(5);
        }

        MpPlayer.Stop();
        MpPlayer.clip = clipSecondBoss;
        MpPlayer.Play();
        textBoss.text = "Phase Boss shows up";

        cam1.SetActive(false);
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam4.SetActive(false);
        boss.SetActive(true);

        spawnEnemy(Buildtwo);
        VoicePlayer.clip = buildtwo;
        VoicePlayer.Play();
        yield return new WaitForSeconds(5);
        textBoss.text = "";

        cam1.SetActive(true);
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam4.SetActive(false);
        boss.SetActive(false);
    }


    IEnumerator thirdPhase()
    {
        textPhase.text = "Phase 3";
        MpPlayer.Stop();
        MpPlayer.clip = clipThirdPhase;
        MpPlayer.Play();

        for (int i = 0; i < 5; i++)
        {
            spawnEnemy(Snorlax);
            yield return new WaitForSeconds(5);
            spawnEnemy(Arbok);
            yield return new WaitForSeconds(5);
            spawnEnemy(Snorlax);
            yield return new WaitForSeconds(5);
            spawnEnemy(Arbok);
            yield return new WaitForSeconds(5);
            spawnEnemy(Snorlax);
            yield return new WaitForSeconds(3);
            spawnEnemy(Snorlax);
            yield return new WaitForSeconds(3);
        }

        MpPlayer.Stop();
        MpPlayer.clip = clipThirdBoss;
        MpPlayer.Play();
        textBoss.text = "Phase Boss shows up";
        spawnEnemy(JessieAndJames);
        VoicePlayer.clip = meaw;
        VoicePlayer.Play();
        cam1.SetActive(false);
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam4.SetActive(false);
        boss.SetActive(true);
        yield return new WaitForSeconds(5);
        textBoss.text = "";
        cam1.SetActive(true);
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam4.SetActive(false);
        boss.SetActive(false);
    }

    IEnumerator loadToWin()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("win");
    }
}
