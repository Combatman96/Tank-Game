using System.Collections;
using System.Collections.Generic;
using TurnBase.System;
using UnityEngine;
using DG.Tweening;
using PhucNH.pathfinding;
[RequireComponent(typeof(InputController))]

public class Tank : MonoBehaviour
{
    InputController m_input => GetComponent<InputController>();
    public float bulletSpeed = 2f;
    public Board board { get; set; }

    //[SerializeField] private Transform m_bulletSpawnPoint;
    //[SerializeField] private Bullet m_bulletPrefab;
    [SerializeField] private BattleSystem m_battleSystem;


    [Range(1, 2)] public int playerID = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // Tank controll
        // NOTE: If you want true tank controll the tank can not rotate and move at the same time.
        //RotateTank();
        //MoveTank();
        ShootBullet();
    }

  /*  void RotateTank()
    {
        if (m_input.Right && m_input.Left)
            return;

        float rotarion = m_rigidbody.rotation;
        if (m_input.Right) rotarion += -1 * rotationSpeed;
        if (m_input.Left) rotarion += rotationSpeed;
        rotarion %= 360f;
        m_rigidbody.rotation = rotarion;
    }

    void MoveTank()
    {
        if (m_input.Up && m_input.Down)
            return;
        int forward = 0;
        if (m_input.Up) forward = 1;
        if (m_input.Down) forward = -1;
        Vector3 velocity = transform.up * moveSpeed * forward;
        m_rigidbody.velocity = velocity;

    }*/

    void ShootBullet()
    {
        // Note: Just a thought, we can only shoot one bullet every n seconds.
        if (m_input.Fire)
        {
           /* Bullet bullet = Instantiate(m_bulletPrefab, m_bulletSpawnPoint.position, Quaternion.identity);
            bullet.transform.up = m_bulletSpawnPoint.up;
            Vector3 velocity = m_bulletSpawnPoint.up * bulletSpeed;
            bullet.SetVelocity(velocity, bulletSpeed);*/
        }
    }

    /*private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Debug.Log(gameObject.name + " got hit!");
        }
    }*/
}
