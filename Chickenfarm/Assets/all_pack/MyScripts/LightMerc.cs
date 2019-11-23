using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMerc : MonoBehaviour
{
    // Скрипт плавного мерцания лампы

    public float duration = 1.5f;
    public Light lt;

    private void Start()
    {
        lt = GetComponent<Light>();
    }

    void Update()
    {

        float phi = Time.time / duration * 4 * Mathf.PI;
        float amplitude = Mathf.Cos(phi) * 8.6F + 25.75F;
        lt.intensity = amplitude;

    }
}
