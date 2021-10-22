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
        if (locatePokemon == "Venusaur")
        {
            if (EnemySpawner.funds >= 300)
            {
                Instantiate(pokemon, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z), Quaternion.identity);
                EnemySpawner.funds -= 300;
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
                Instantiate(pokemon2, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z), Quaternion.identity);
            EnemySpawner.funds -= 150;
            }
            else
            {
                textCaution.text = "Not enough money!";
            }
        }
        else if(locatePokemon == "Charizard")
        {
            if (EnemySpawner.funds >= 1000)
            {
                Instantiate(pokemon3, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z), Quaternion.identity);
                EnemySpawner.funds -= 1000;
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
                Instantiate(pokemon4, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z), Quaternion.identity);
                EnemySpawner.funds -= 10000;
            }
            else
            {
                textCaution.text = "Not enough money!";
            }
        }


    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
