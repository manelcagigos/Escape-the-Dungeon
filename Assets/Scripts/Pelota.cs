using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pelota : MonoBehaviour
{
    private Rigidbody rig;
    private float velocidad = 600;
    private GameManager gameManager;
    public GameObject panelWin;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 orientacion = Input.acceleration;
        orientacion = Quaternion.Euler(90, 0, 0) * orientacion;
        rig.AddForce(orientacion * velocidad * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Salida"))
        {
            Time.timeScale = 0f;
            panelWin.SetActive(true);
        } else if (collision.gameObject.CompareTag("Pared"))
        {
            gameManager.RestaPuntos();
            Handheld.Vibrate();
            CineMachineMovementCamera.Instance.MoverCamara(5, 5, 0.3f);
        }
    }
}
