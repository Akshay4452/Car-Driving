using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float acceleration = 2.0f;
    // Update is called once per frame
    void Update()
    {
        // Acceleration code
        speed += acceleration * Time.deltaTime;
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
