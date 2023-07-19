using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTQ.tile
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] private Color _baseColor, _offsetColor;
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private GameObject _highlight;
        [SerializeField] private GameObject _unit;

        public bool IsWalkable { get => isWalkable; set => isWalkable = value; }
        private bool isWalkable;
        private Vector2Int _tilePos;
        public Vector2Int TilePos { get => _tilePos; set => _tilePos = value; }
        [SerializeField] private TileType _tileType;
        public TileType TileType { get => _tileType; set => _tileType = value; }

        private bool _isSelect = false;

        public void Init(bool isOffset)
        {
            _renderer.color = isOffset ? _offsetColor : _baseColor;
        }

        void OnMouseEnter()
        {
            _highlight.SetActive(true);
        }

        void OnMouseExit()
        {
            _highlight.SetActive(false);
        }

        void OnMouseDown()
        {
            if (!_isSelect)
            {
                GridManager._selectedTile = this;
                _renderer.color = Color.yellow;
            }
            else
            {
                GridManager._selectedTile = null;
                int temp = (_tilePos.x + _tilePos.y) % 2;
                bool isOffset = temp != 0;
                Init(isOffset);
            }

            _isSelect = !_isSelect;
        }
    }

    [System.Serializable]
    public enum TileType
    {
        NORMAL,
        OBSTANCE,
        PLAYER,
        ENEMY
    }
}
