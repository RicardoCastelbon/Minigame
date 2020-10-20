using UnityEngine;
using System.Collections;

public class followCamara : MonoBehaviour
{

  

    public Camera camara;

   

    public Transform target;
    public float smoothPositionTime = 1.0f;
    public float smoothRotationTime = 1.0f;





    // Use this for initialization
    void Start()
    {

     



    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.Slerp(transform.position, target.position, Time.deltaTime * smoothPositionTime);

        if (Input.GetAxis("Vertical") > -0.1)
        {

            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * smoothRotationTime);

        }




    }
}
