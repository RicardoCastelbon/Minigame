using UnityEngine;
using System.Collections;

public class fixCamara : MonoBehaviour {

    public Camera camara;
    public GameObject objetoOrigen;
    public GameObject personaje;

    private Vector3 velocityCamSmooth = Vector3.zero;
    private float camSmoothDampTime = 0.1f;

    RaycastHit hitInfo = new RaycastHit();

    int layermask = (int)(1 << 8);

    Vector3 dir;

    public float distancia;


    // Use this for initialization
    void Start () {

        distancia = Vector3.Distance(camara.transform.position, personaje.transform.position);

    }
	
	// Update is called once per frame
	void Update ()
    {
        dir = camara.transform.position - personaje.transform.position;
        //arregloMuro(personaje.transform.position, ref dir);

        //Ray rayToCameraPos = new Ray(personaje.transform.position, dir);

        if (Physics.Raycast(transform.position, dir, out hitInfo, distancia))
        {
            Debug.Log(hitInfo.collider.name + ", " + hitInfo.collider.tag);
            //Debug.DrawLine(personaje.transform.position, dir, Color.red);
           // smoothPosition(this.transform.position, camara.transform.position);
            camara.transform.position = hitInfo.point;
        }else
        {
            camara.transform.position = objetoOrigen.transform.position;
        }
    }

    private void smoothPosition(Vector3 fromPos, Vector3 toPos)
    {
        this.transform.position = Vector3.SmoothDamp(fromPos, toPos, ref velocityCamSmooth, camSmoothDampTime);
    }

    private void arregloMuro (Vector3 origen, ref Vector3 objetivo)
    {
        Debug.DrawLine(origen, objetivo, Color.cyan);

        RaycastHit hitMuro = new RaycastHit();
        if(Physics.Linecast(origen, objetivo, out hitMuro))
        {
            Debug.DrawRay(hitMuro.point, Vector3.left, Color.red);
            objetivo = new Vector3(hitMuro.point.x, objetivo.y, hitMuro.point.z);
        }
    }

       
}
