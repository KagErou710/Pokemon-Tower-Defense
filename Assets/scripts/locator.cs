using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locator : MonoBehaviour
{
    public Color hoverColor;

    public static string locatePokemon = "Venusaur";
    public GameObject pokemon;
    public GameObject pokemon2;
    public GameObject pokemon3;
    public GameObject pokemon4;
    public TMPro.TextMeshProUGUI textCaution;
    private bool isPokemon = false;
    private bool canDelete = false;

    public AudioSource VoicePlayer;
    public AudioClip C;
    public AudioClip B;
    public AudioClip V;
    public AudioClip L;
    public AudioClip monsterball;

    private Renderer rend;
    private Color startColor;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    // Update is called once per frame
    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseDown()
    {
        
    textCaution.text = "";         
        if (gameObject.transform.childCount == 0)
        {
            textCaution.text = "";
            if (locatePokemon == "Venusaur")
            {
                if (EnemySpawner.funds >= 300)
                {
                    VoicePlayer.clip = V;
                    VoicePlayer.Play();
                    GameObject tempPokemon = Instantiate(pokemon, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.0f, gameObject.transform.position.z), Quaternion.identity);
                    EnemySpawner.funds -= 300;
                    tempPokemon.transform.SetParent(gameObject.transform);
                }
                else
                {
                    textCaution.text = "Not enough money!";
                }
            }
            else if (locatePokemon == "Blastoise")
            {
                if (EnemySpawner.funds >= 150)
                {
                    VoicePlayer.clip = B;
                    VoicePlayer.Play();
                    GameObject tempPokemon = Instantiate(pokemon2, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.5f, gameObject.transform.position.z), Quaternion.identity);
                    EnemySpawner.funds -= 150;
                    tempPokemon.transform.SetParent(gameObject.transform);
                }
                else
                {
                    textCaution.text = "Not enough money!";
                }
            }
            else if (locatePokemon == "Charizard")
            {
                if (EnemySpawner.funds >= 1000)
                {
                    VoicePlayer.clip = C;
                    VoicePlayer.Play();
                    GameObject tempPokemon = Instantiate(pokemon3, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.5f, gameObject.transform.position.z), Quaternion.identity);
                    EnemySpawner.funds -= 1000;
                    tempPokemon.transform.SetParent(gameObject.transform);
                }
                else
                {
                    textCaution.text = "Not enough money!";
                }
            }
            else if (locatePokemon == "Legend")
            {
                if (EnemySpawner.funds >= 10000)
                {
                    VoicePlayer.clip = L;
                    VoicePlayer.Play();
                    GameObject tempPokemon = Instantiate(pokemon4, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.5f, gameObject.transform.position.z), Quaternion.identity);
                    EnemySpawner.funds -= 10000;
                    tempPokemon.transform.SetParent(gameObject.transform);
                }
                else
                {
                    textCaution.text = "Not enough money!";
                }
            }
        }
        else
        {
            foreach (Transform child in gameObject.transform)
            {
                VoicePlayer.clip = monsterball;
                VoicePlayer.Play();
                GameObject.Destroy(child.gameObject);
            }
        }
         

    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
