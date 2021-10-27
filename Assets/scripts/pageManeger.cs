using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pageManeger : MonoBehaviour
{
    public string win;
    public string lose;
    // Start is called before the first frame update
    public void winWindown()
    {
        SceneManager.LoadScene("win");
    }

    public void loseWindown()
    {
        SceneManager.LoadScene(lose);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
