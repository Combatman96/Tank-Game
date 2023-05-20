using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D m_rigidbody => GetComponent<Rigidbody2D>();
    [SerializeField] private float m_speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetVelocity(Vector2 velocity, float speed)
    {
        m_speed = speed;
        m_rigidbody.velocity = velocity;
    }

    public Vector2 GetVelocity()
    {
        return m_rigidbody.velocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            OnWallCollided(other.GetContact(0).normal);
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Tank"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnWallCollided(Vector2 normal)
    {
        Vector2 curDir = transform.up;
        Vector2 newDir = curDir * -1;
        Debug.Log("curDir " + curDir);
        if (normal.x == 0f)
        {
            newDir = new Vector2(-curDir.x, curDir.y) * -1;
        }
        if (normal.y == 0f)
        {
            newDir = new Vector2(curDir.x, -curDir.y) * -1;
        }
        Debug.Log("new Dir " + newDir);
        m_rigidbody.velocity = newDir * m_speed;
        transform.up = newDir;
    }
}
