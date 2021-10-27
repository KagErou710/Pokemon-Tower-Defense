using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resultWin : MonoBehaviour
{
    // Start is called before the first frame update


    public TMPro.TextMeshProUGUI textWin;
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
        textWin.text = "Saved Pikachu!";
        yield return new WaitForSeconds(5);
        button.SetActive(true);
    }
}
