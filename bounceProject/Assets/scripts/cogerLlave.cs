using UnityEngine;
using System.Collections;

public class cogerLlave : MonoBehaviour {

    public gameManager controladorLlaves;
    private AudioSource audioLlave;
    // Use this for initialization
    void Start () {
        audioLlave = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

       }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            controladorLlaves.llaves = controladorLlaves.llaves + 1;

            audioLlave.Play();
            StartCoroutine(esperarSonidoLlave());
        }
    }
    IEnumerator esperarSonidoLlave()
    {

        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }
}
