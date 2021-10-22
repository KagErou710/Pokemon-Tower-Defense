using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public float startHealth;
    public int income;
    private float hp;

    public EnemySpawner enemySpawner;

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
        
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            BulletDamage damage = collision.gameObject.GetComponent<BulletDamage>();
            hp -= damage.Damage;
            //Destroy(gameObject);
            
            if (hp <= 0f)
            {
                Destroy(gameObject);
                EnemySpawner.funds += income;
            }
            
        }
    }
}
