using UnityEngine;
using System.Collections;

public class managerEscenas : MonoBehaviour {

    public GameObject volverAJuego;
    public GameObject salirAlMenu;
    public GameObject fondoMenu;

    

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void start()
    {
        
        Time.timeScale = 1.0f;
        Application.LoadLevel("proyectoDispMoviles");
        


    }
    public void exit()
    {
        Application.Quit();
    }

    public void pausa()
    {
        Time.timeScale = 0.0f;
        volverAJuego.SetActive(true);
        salirAlMenu.SetActive(true);
        fondoMenu.SetActive(true);
    }

    public void volverAlJuego()
    {
        Time.timeScale = 1.0f;
        volverAJuego.SetActive(false);
        salirAlMenu.SetActive(false);
        fondoMenu.SetActive(false);
    }

    public void salirAMenuPrincipal()
    {
        Application.LoadLevel("escenaStart");
        Time.timeScale = 1.0f;
    }
}
