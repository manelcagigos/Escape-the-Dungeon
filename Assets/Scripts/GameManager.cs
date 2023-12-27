using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoTiempo;
    [SerializeField] private float tiempo;

    private int tiempoMinutos, tiempoSegundos;

    bool tiempoDetenido;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        Cronometro();

        //UnityEngine.UI.Text miTextoUI = textoTiempo as UnityEngine.UI.Text;

        //textoTiempo = GameObject.FindGameObjectWithTag("textoTiempo").GetComponent("TextMeshProUGUI");
    }

    void Cronometro()
    {
        if (!tiempoDetenido)
        {
            tiempo -= Time.deltaTime;
        }

        tiempoSegundos = Mathf.FloorToInt(tiempo % 60);

        string currentTime = string.Format("{00}", tiempoSegundos);
        textoTiempo.text = currentTime.ToString();

        if (tiempo <= 0)
        {
            tiempoDetenido = true;
            Muerto();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        tiempo -= Time.deltaTime;
        textoTiempo.text = "" + (int)tiempo;
    }

    private void Muerto()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RestaPuntos()
    {
        tiempo--;
    }
}
