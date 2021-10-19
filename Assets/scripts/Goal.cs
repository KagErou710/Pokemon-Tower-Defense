using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public float GoalHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemt")
        {
            Destroy(collision.gameObject);
            GoalHealth -= 50;
            if (GoalHealth <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
