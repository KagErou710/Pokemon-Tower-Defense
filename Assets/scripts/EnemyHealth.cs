using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public float startHealth;
    public int income;
    private float hp;

    public AudioSource Sound;
    public AudioClip hit;
    public AudioClip dead;

    public EnemySpawner enemySpawner;

    public Slider slider;

    void Start()
    {
        hp = startHealth;
        slider.maxValue = hp;
        slider.value = hp;
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
            slider.value = hp;
            Sound.clip = hit;
            Sound.Play();
            //Destroy(gameObject);
            
            if (hp <= 0f)
            {
                Sound.clip = dead;
                Sound.Play();
                Destroy(gameObject);
                EnemySpawner.funds += income;
            }
            
        }
    }



}
