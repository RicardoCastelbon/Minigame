using UnityEngine;
using System.Collections;

public class cogerMoneda : MonoBehaviour {

    public gameManager controladorPuntos;
    private AudioSource audio;
   
	// Use this for initialization
	void Start () {

        audio = GetComponent<AudioSource>();



    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            controladorPuntos.puntos += 1000;
            audio.Play();
            StartCoroutine(esperarSonido());

        }
    }
    IEnumerator esperarSonido()
    {
       
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }
}
