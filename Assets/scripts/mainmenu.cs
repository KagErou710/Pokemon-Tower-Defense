using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public string _firstSceneName;
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene(_firstSceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
