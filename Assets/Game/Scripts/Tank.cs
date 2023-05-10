using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    private Rigidbody2D m_rigidbody => GetComponent<Rigidbody2D>();
    public float rotationSpeed = 20f;
    public float moveSpeed = 5f;
    public float bulletSpeed = 2f;
    [SerializeField] private Transform m_bulletSpawnPoint;
    [SerializeField] private Bullet m_bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // Tank controll
        // NOTE: If you want true tank controll the tank can not rotate and move at the same time.
        RotateTank();
        MoveTank();
        ShootBullet();
    }

    void RotateTank()
    {
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow))
            return;

        float rotarion = m_rigidbody.rotation;
        if (Input.GetKey(KeyCode.RightArrow)) rotarion += -1 * rotationSpeed;
        if (Input.GetKey(KeyCode.LeftArrow)) rotarion += rotationSpeed;
        rotarion %= 360f;
        m_rigidbody.rotation = rotarion;
    }

    void MoveTank()
    {
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow))
            return;
        int forward = 0;
        if (Input.GetKey(KeyCode.UpArrow)) forward = 1;
        if (Input.GetKey(KeyCode.DownArrow)) forward = -1;
        Vector3 velocity = transform.up * moveSpeed * forward;
        m_rigidbody.velocity = velocity;
    }

    void ShootBullet()
    {
        // Note: Just a thought, we can only shoot one bullet every n seconds.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Bullet bullet = Instantiate(m_bulletPrefab, m_bulletSpawnPoint.position, Quaternion.identity);
            bullet.transform.up = m_bulletSpawnPoint.up;
            Vector3 velocity = m_bulletSpawnPoint.up * bulletSpeed;
            bullet.SetVelocity(velocity, bulletSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Debug.Log(gameObject.name + " got hit!");
        }
    }
}
