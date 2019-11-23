using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckAI : MonoBehaviour
{
    public Vector3 direction;
    public float acceleration;
    public Rigidbody rb;

    void Start()
    {
        Invoke("QuitGame", 7f); // Задержка перед вызовом метода, сек
    }

    void FixedUpdate()
    {
        rb.AddForce(direction.normalized * acceleration, ForceMode.Impulse);
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
