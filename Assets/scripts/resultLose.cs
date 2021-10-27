using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resultLose : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textLose;
    public AudioSource MpPlayer;
    public AudioClip BGM;
    public GameObject button;
    void Start()
    {
        StartCoroutine(doSomething());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator doSomething()
    {
        MpPlayer.clip = BGM;
        MpPlayer.Play();
        textLose.text = "Bye bye Pikachu...";
        yield return new WaitForSeconds(5);
        textLose.text = "Bye bye Pikachu...\nPikachu was caught...";
        yield return new WaitForSeconds(5);
        button.SetActive(true);
    }
}
