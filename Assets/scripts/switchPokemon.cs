using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchPokemon : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textPokemon;
    private locator poke;
    // Start is called before the first frame update
    void Start()
    {
        textPokemon.text = "Venusaur";
    }

    // Update is called once per frame
    void Update()
    {
        textPokemon.text = locator.locatePokemon;
    }
}
