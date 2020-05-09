using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarshipPlayer : MonoBehaviour
{
    Rigidbody rb;
    public float rotationSpeed = 50;
    Vector3 calibrationVec;

    public Text t1;
    public Text t2;
    public Text t3;
    public Text t4;
    public Text t5;
    public Text t6;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody>();
        CalibrateButtonClicked();
    }

    // Update is called once per frame
    void LateUpdate()
    {      
        Vector3 rotVector = Vector3.zero;
        rotVector.x = Mathf.Clamp(-(Input.acceleration.y < 0 ? Input.acceleration.z : ((Mathf.Sign(Input.acceleration.z) * 2) - Input.acceleration.z)) + calibrationVec.z, -0.5f, 0.5f);
        rotVector.z = Mathf.Clamp(-Input.acceleration.x + calibrationVec.x, -0.5f, 0.5f);

        transform.Rotate(rotVector * rotationSpeed * Time.deltaTime);
        transform.Rotate(Input.GetAxis("Vertical") * Time.deltaTime * 60, 0, -Input.GetAxis("Horizontal") * Time.deltaTime * 60);
        transform.position += transform.forward * Time.deltaTime * 60;
        //rb.AddTorque(Input.GetAxis("Vertical") * Time.deltaTime * 60, 0, -Input.GetAxis("Horizontal") * Time.deltaTime * 60, ForceMode.Acceleration);
        //rb.velocity = transform.forward * Time.deltaTime * 60; ;


        t1.text = "Acc z: " + Input.acceleration.z.ToString("F2");
        t2.text = "Acc x: " + Input.acceleration.x.ToString("F2");
        t3.text = "Acc y: " + Input.acceleration.y.ToString("F2");
    
        t4.text = "Rot x: " + (-(Input.acceleration.y < 0 ? Input.acceleration.z : ((Mathf.Sign(Input.acceleration.z) * 2) - Input.acceleration.z))).ToString("F2");
        t5.text = "rotVector.x: " + rotVector.x.ToString("F2");
        t6.text = "rotVector.z: " + rotVector.z.ToString("F2");
    }

    public void CalibrateButtonClicked()
    {
        calibrationVec = new Vector3(Input.acceleration.x, Input.acceleration.y, (Input.acceleration.y < 0 ? Input.acceleration.z : ((Mathf.Sign(Input.acceleration.z) * 2) - Input.acceleration.z)));
    }
}
