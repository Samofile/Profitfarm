using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Атрибут запрещает дублировать скрипт на другие объеты
[DisallowMultipleComponent]

public class moveObject : MonoBehaviour
{

    [SerializeField] Vector3 movePosition;
    [SerializeField] float moveSpeed;
    [SerializeField] int i;
    [SerializeField] [Range(0, 1)] float moveProgress;
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position; // Сохраняем текущее положение объекта в переменную

    }

    // Update is called once per frame
    void Update()
    {
        for (i=1; i<=1000; i++)
        {
        moveProgress = Mathf.PingPong(Time.time * moveSpeed, 1);
        Vector3 offset = movePosition * moveProgress; // Логика перемещения объекта
        transform.position = startPosition + offset;
        // yield return new WaitForSeconds(2f); // Обновление каждые 2 сек
        }
    }
}