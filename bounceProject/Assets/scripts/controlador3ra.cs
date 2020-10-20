using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class controlador3ra : MonoBehaviour {
    public float speed = 6.0f;
    public float speedOnHair = 0;
    public float jumpSpeed = 8.0f;
    public float gravity = 2.0f;

    public float rotateSpeed = 4.0f;
    public Transform camaraTransform;
    private Vector3 moveDirection = Vector3.zero;

    private float giro;

    public bool adelanteBool = false;
    public bool atrasBool = false;
    public bool izquierdaBool = false;
    public bool derechaBool = false;

    public Rigidbody rb;

    public Transform pelotaAnimacion;

    public bool drogado = false;

    public LayerMask paredLayer;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();

        pelotaAnimacion = GameObject.Find("pelotaAnimada").transform;

    }
	
	// Update is called once per frame
	void Update () {

        Vector3 downRay = transform.TransformDirection(Vector3.up * -1);

        Vector3 backRay = transform.TransformDirection(Vector3.back);

        Vector3 frontRay = transform.TransformDirection(Vector3.forward);

        //CONDICION DE DROGADO O NO (SI COGES LA PASTILLA SE INVIERTEN LOS CONTROLES)
        if (drogado == false)
        {
            // MOVIMIENTO ADELANTE
            if (adelanteBool == true)
            {
                if (Physics.Raycast(transform.position, downRay, 1.0f))
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * speed);
                }
                else
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * speed);
                }
            }

            // MOVIMIENTO ATRAS
            if (atrasBool == true)
            {
                if (Physics.Raycast(transform.position, downRay, 1.0f))
                {
                    transform.Translate(Vector3.back * Time.deltaTime * speed);
                }
                else
                {
                    transform.Translate(Vector3.back * Time.deltaTime * speed);
                }
            }
           // MOVIMIENTO SI ESTAS DROGADO
        } else
            {
            if (adelanteBool == true)
            {
                if (Physics.Raycast(transform.position, downRay, 1.0f))
                {
                    transform.Translate(Vector3.back * Time.deltaTime * speed);
                }
                else
                {
                    transform.Translate(Vector3.back * Time.deltaTime * speed);
                }
            }

            // MOVIMIENTO ATRAS
            if (atrasBool == true)
            {
                if (Physics.Raycast(transform.position, downRay, 1.0f))
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * speed);
                }
                else
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * speed);
                }
            }

        }

        //SALTO ESPACIO PRUEBA

        if(Input.GetKeyDown(KeyCode.Space))
            {
            rb.AddForce(transform.up * 400);
           // rb.AddForce(transform.forward * 300);
        }

        //SISTEMA DE GRAVEDAD
       
        if (!Physics.Raycast(transform.position, downRay, 0.4f))
        {
            rb.AddForce(-transform.up * 25);

        
        }
        //Sistema de girar acialante y abajo cuando caes
        if (!Physics.Raycast(transform.position, downRay, 1f,paredLayer))
        {
          

            if (Physics.Raycast(transform.position, backRay, 1.0f,paredLayer))
            {
                rb.velocity = Vector3.zero;
                Quaternion rotationAmount = Quaternion.Euler(90, 0, 0);
                Quaternion postRotation = transform.rotation * rotationAmount;
                transform.rotation = postRotation;
            }
        }
        //Sistema de girar atras y arriba cuando caes
        if (!Physics.Raycast(transform.position, downRay, 1f,paredLayer))
        {


            if (Physics.Raycast(transform.position, frontRay, 1.0f,paredLayer))
            {
                rb.velocity = Vector3.zero;
                Quaternion rotationAmount = Quaternion.Euler(-90, 0, 0);
                Quaternion postRotation = transform.rotation * rotationAmount;
                transform.rotation = postRotation;
            }
        }

        //RAYCAST GIRO 90º PARA ABAJO Y CAMBIO DE GRAVEDAD
        if (atrasBool == true)
        {
            if (Physics.Raycast(transform.position, backRay, 1.0f,paredLayer))
            {
                rb.velocity = Vector3.zero;
                Quaternion rotationAmount = Quaternion.Euler(90, 0, 0);
                Quaternion postRotation = transform.rotation * rotationAmount;
                transform.rotation = postRotation;
            }
            else
            {
            }
        }

        //RAYCAST GIRO 90º PARA ARRIBA Y CAMBIO DE GRAVEDAD
        if (adelanteBool == true)
        {
            if (Physics.Raycast(transform.position, frontRay, 1.0f,paredLayer))
            {
                rb.velocity = Vector3.zero;
                Quaternion rotationAmount = Quaternion.Euler(-90, 0, 0);
                Quaternion postRotation = transform.rotation * rotationAmount;
                transform.rotation = postRotation;
            }
            else
            {
            }
        }

        if(drogado == true)
        {
            StartCoroutine(Example());
        }

        //ROTAR MIENTRAS SALTAS
       
         if (!Physics.Raycast(transform.position, downRay, 0.4f))
        {
            pelotaAnimacion.Rotate(Vector3.right * 400 * Time.deltaTime);
        }



    }

    
    public void derecha90()
    {
        if (drogado == false)
        {
            Quaternion rotationAmount = Quaternion.Euler(0, 90, 0);
            Quaternion postRotation = transform.rotation * rotationAmount;
            transform.rotation = postRotation;
        }else
        {
            Quaternion rotationAmount = Quaternion.Euler(0, -90, 0);
            Quaternion postRotation = transform.rotation * rotationAmount;
            transform.rotation = postRotation;
        }

    }
    public void izquierda90()
    {
        if (drogado == false)
        {
            Quaternion rotationAmount = Quaternion.Euler(0, -90, 0);
            Quaternion postRotation = transform.rotation * rotationAmount;
            transform.rotation = postRotation;
        }else
        {
            Quaternion rotationAmount = Quaternion.Euler(0, 90, 0);
            Quaternion postRotation = transform.rotation * rotationAmount;
            transform.rotation = postRotation;
        }
    }

    public void adelantetrue()
    {
        adelanteBool = true;
    }

    public void adelantefalse()
    {
        adelanteBool = false;
    }

    public void atrasTrue()
    {
        atrasBool = true;
    }

    public void atrasFalse()
    {
        atrasBool = false;
    }

    public void izquierdaTrue()
    {
        izquierdaBool = true;
    }
    public void izquierdaFalse()
    {
        izquierdaBool = false;
    }

    public void derechaTrue()
    {
        derechaBool = true;
    }
    public void derechaFalse()
    {
        derechaBool = false;
    }

    public void salto()
    {
        Vector3 downRay = transform.TransformDirection(Vector3.up * -1);

        if (Physics.Raycast(transform.position, downRay, 0.4f))
        {
            //Debug.Log("wewewewe");
            rb.AddForce(transform.up * 400);
            //rb.AddForce(transform.forward * 300);
            
        }
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(3);

        drogado = false;
    }



}
