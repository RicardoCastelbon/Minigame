using UnityEngine;
using System.Collections;

public class rotacionAnimacion : MonoBehaviour {

    public controlador3ra controladorScript;

   

	// Use this for initialization
	void Start () {

        controladorScript = gameObject.GetComponentInParent<controlador3ra>();
	
	}
	
	// Update is called once per frame
	void Update () {

        if (controladorScript.drogado == false)
        {
            if (controladorScript.adelanteBool == true)
            {
                transform.Rotate(Vector3.right * 400 * Time.deltaTime);
            }
            if (controladorScript.atrasBool == true)
            {
                transform.Rotate(Vector3.right * -400 * Time.deltaTime);
            }
        } else
        {
            if (controladorScript.adelanteBool == true)
            {
                transform.Rotate(Vector3.right * -400 * Time.deltaTime);
            }
            if (controladorScript.atrasBool == true)
            {
                transform.Rotate(Vector3.right * 400 * Time.deltaTime);
            }
        }


    }
}
