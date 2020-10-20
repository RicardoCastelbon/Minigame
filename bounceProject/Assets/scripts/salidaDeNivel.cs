using UnityEngine;
using System.Collections;

public class salidaDeNivel : MonoBehaviour {

    public gameManager controladorLlaves;
    public managerEscenas controladorBotones;

    public GameObject misionCompletada;
    public GameObject siguienteMision;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && controladorLlaves.llaves >= 1)
        {
            Time.timeScale = 0.0f;
            misionCompletada.SetActive(true);
            siguienteMision.SetActive(true);
            controladorBotones.salirAlMenu.SetActive(true);
            controladorLlaves.textoPuntuacionFinal.SetActive(true);
            controladorBotones.fondoMenu.SetActive(true);

        }
    }
}
