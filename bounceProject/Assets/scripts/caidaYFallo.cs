using UnityEngine;
using System.Collections;

public class caidaYFallo : MonoBehaviour {

    public managerEscenas controladorManagerEscenas;
    

    public GameObject volverAIntentar;
    public GameObject misionfallida;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

      

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0.0f;
            controladorManagerEscenas.salirAlMenu.SetActive(true);
            controladorManagerEscenas.fondoMenu.SetActive(true);
            volverAIntentar.SetActive(true);
            misionfallida.SetActive(true);

        }
    }
}
