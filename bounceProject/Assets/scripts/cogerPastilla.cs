using UnityEngine;
using System.Collections;

public class cogerPastilla : MonoBehaviour {

    public controlador3ra controladorPastilla;

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
            controladorPastilla.drogado = true;
            
             Destroy(this.gameObject);
        }
    }

   
}
