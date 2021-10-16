using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public float startHealth;
    private float hp;
    private bool judge = false;

    void Start()
    {
        hp = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        if(collision.gameObject.tag == "Bullet")
        {
            hp -= 30;
            //Destroy(gameObject);
            
            if (hp <= 0f)
            {
                Destroy(gameObject);
            }
            
        }
    }
}
