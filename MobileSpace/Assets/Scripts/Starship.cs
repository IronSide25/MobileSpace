using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starship : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));
        //transform.Rotate(-Input.acceleration.z, 0, -Input.acceleration.x);
        transform.position += transform.forward;
    }
}
