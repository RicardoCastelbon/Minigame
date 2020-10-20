using UnityEngine;
using System.Collections;

public class cogerReloj : MonoBehaviour {

    public gameManager controladorContador;

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
            controladorContador.contador += 5;

            Destroy(this.gameObject);
        }
    }
}
