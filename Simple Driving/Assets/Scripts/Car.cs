using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float acceleration = 2.0f;
    [SerializeField] private float turnSpeed = 200f;
    private int steerValue;
    
    // Update is called once per frame
    void Update()
    {
        // Acceleration code
        speed += acceleration * Time.deltaTime;
        transform.Rotate(0f, steerValue * turnSpeed * Time.deltaTime, 0f);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    public void Steer(int value)
    {
        steerValue = value;
        // transform.Rotate(0f, steerValue * turnSpeed * Time.deltaTime, 0f);
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene("Scene_MainMenu");
        }
    }
}
