using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchPokemon : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textPokemon;
    public TMPro.TextMeshProUGUI textStatus;
    // Start is called before the first frame update
    void Start()
    {
        textPokemon.text = "Venusaur";
        textStatus.text = "Attack : 100\nRPS : 3s\nRange : 15";
    }

    // Update is called once per frame
    void Update()
    {
        textPokemon.text = locator.locatePokemon;
        if (locator.locatePokemon == "Venusaur")
        {
            textStatus.text = "Attack : 100\nRPS : 3s\nRange : 15";
        }
        else if (locator.locatePokemon == "Blastoise")
        {
            textStatus.text = "Attack : 4\nRPS : 0.1s\nRange : 10";
        }
        else if (locator.locatePokemon == "Charizard")
        {
            textStatus.text = "Attack : 500\nRPS : 10s\nRange : 25";
        }
        else if (locator.locatePokemon == "Legend")
        {
            textStatus.text = "Attack : 1000\nRPS : 1s\nRange : 25";
        }

    }
}
