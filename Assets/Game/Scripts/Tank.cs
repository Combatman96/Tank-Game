using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    private Rigidbody2D m_rigidbody => GetComponent<Rigidbody2D>();
    public float rotationSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Tank controll
        RotateTank();
    }

    void RotateTank()
    {
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow))
            return;

        float rotarion = m_rigidbody.rotation;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rotarion += -1 * rotationSpeed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotarion += rotationSpeed;
        }
        rotarion %= 360f;
        m_rigidbody.rotation = rotarion;
    }
}
