using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Followed youtube tutorial https://www.youtube.com/watch?v=o9l699x_qZM */
public class RocketController : MonoBehaviour
{
    [SerializeField] float thrusterForce = 10f;
    [SerializeField] float tiltingForce = 10f;


    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        float tilt = Input.GetAxis("Horizontal");
       
        if (!Mathf.Approximately(tilt, 0f))
        {
            
            rb.freezeRotation = true;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (new Vector3(-(tilt * tiltingForce * Time.deltaTime), 0f, 0f)));

          
        }

        rb.freezeRotation = false;

    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrusterForce * Time.deltaTime);
        }
    }

}
