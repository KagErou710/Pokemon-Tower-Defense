using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource source;
    public AudioClip voice;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
            source.clip = voice;
            source.Play();
            StartCoroutine(loadToLose());

        }
    }

    IEnumerator loadToLose()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("lose");
    }


}
