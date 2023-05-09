using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D m_rigidbody => GetComponent<Rigidbody2D>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetVelocity(Vector3 velocity)
    {
        m_rigidbody.velocity = velocity;
    }
}
