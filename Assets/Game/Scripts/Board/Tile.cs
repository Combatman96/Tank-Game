using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector2Int coordinate;
    [SerializeField] private Transform m_itemGroup;
    [SerializeField] private SpriteRenderer m_tileSprite;
    [SerializeField] private Color m_normalColor = Color.white;
    [SerializeField] private Color m_moveColor = Color.green;
    [SerializeField] private Color m_wallColor = Color.gray;

    const string WALL = "Wall";
    const string GROUND = "Ground";


    public void SetTileWall()
    {
        m_tileSprite.color = m_wallColor;
        gameObject.tag = WALL;
        gameObject.layer = LayerMask.NameToLayer(WALL);
    }

    public bool IsWall()
    {
        return gameObject.CompareTag(WALL);
    }

    public bool IsGround()
    {
        return gameObject.CompareTag(GROUND);
    }

}
