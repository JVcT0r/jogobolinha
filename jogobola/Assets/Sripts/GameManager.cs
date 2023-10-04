using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI hud, msgVitoria;
    public int restantes;
    public AudioClip clipMoeda, clipVitoria;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out source);
        restantes = FindObjectsOfType<Moeda>().Length;

        hud.text = $"Moedas: {restantes}";
    }

    public void SubtrairMoedas(int valor)
    {
        restantes = restantes - valor;
        hud.text = $"Moedas: {restantes}";
        source.PlayOneShot(clipMoeda);

        if (restantes <= 0)
        {
            //Ganhou

            msgVitoria.text = "Parabéns";
            source.Stop();
            source.PlayOneShot(clipVitoria);
            SceneManager.LoadScene(+1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
