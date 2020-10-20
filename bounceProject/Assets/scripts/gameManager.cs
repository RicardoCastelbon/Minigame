using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {

    public float contador = 60;
    public GameObject textoCronometro;
   
    public int puntos = 0;
    public GameObject textoPuntos;
    public GameObject textoPuntuacionFinal;

    public int llaves = 0;
    public GameObject llave;

    public managerEscenas controladorGUI;
    public caidaYFallo controladorGUI2;

    public bool tutorialActivo = true;
    public GameObject botonTutorial;
    
    
    

    // Use this for initialization
    void Start () {

        contador = 60;

        

        if (tutorialActivo == true)
        {
            botonTutorial.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else
        {
            botonTutorial.SetActive(false);
            Time.timeScale = 1.0f;
        }

    }
	
	// Update is called once per frame
	void Update () {

        //CRONOMETRO
        contador -= Time.deltaTime;
        textoCronometro.GetComponent<Text>().text = Mathf.Round(contador).ToString();

        //PUNTOS
        textoPuntos.GetComponent<Text>().text = puntos.ToString();

        //PUNTUACION FINAL
        textoPuntuacionFinal.GetComponent<Text>().text = puntos.ToString();

        //LLAVES
        if(llaves == 1)
        {
            llave.SetActive(true);   
        }

        //CONDICION DE DERROTA TIEMPO LLEGA A 0
         if (contador <= 0.0f)
         {
             Time.timeScale = 0.0f;
            controladorGUI.salirAlMenu.SetActive(true);
            controladorGUI2.volverAIntentar.SetActive(true);
            controladorGUI2.misionfallida.SetActive(true);
           
        }

      }
    
    public void cerrarTutorial()
    {
        tutorialActivo = false;
        botonTutorial.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
