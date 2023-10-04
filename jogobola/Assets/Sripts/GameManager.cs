using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI hud, msgVitoria;
    public int restantes;

    // Start is called before the first frame update
    void Start()
    {
        restantes = FindObjectsOfType<Moeda>().Length;

        hud.text = $"Moedas: {restantes}";
    }

    public void SubtrairMoedas(int valor)
    {
        restantes = restantes - valor;
        hud.text = $"Moedas: {restantes}";

        if (restantes <= 0)
        {
            //Ganhou

            msgVitoria.text = "Parabéns";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}