using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

    [RequireComponent(typeof(CharacterController))]
   // [RequireComponent(typeof(Rigidbody))]
public class Move : MonoBehaviour {

    private CharacterController character;
    //private Rigidbody rigid;

    [SerializeField] float speed, speed_rotate = 4f;

    private Vector2 m_Input;

    private Vector3 root;

	void Start () {
        character = GetComponent<CharacterController>();
       // rigid = GetComponent<Rigidbody>();
	}

	void Update () {
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float vertical = CrossPlatformInputManager.GetAxis("Vertical");
        m_Input = new Vector2(horizontal, vertical);

        if (m_Input.sqrMagnitude > 1)
        {
            m_Input.Normalize();
        }

        Vector3 desiredMove = transform.forward * m_Input.y * speed + transform.right * m_Input.x * speed;
        transform.Rotate(0f, horizontal * speed_rotate, 0f);
        character.Move(desiredMove);
    }
}
