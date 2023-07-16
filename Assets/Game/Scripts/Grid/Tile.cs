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

        public bool IsWalkable { get => isWalkable; set =>  isWalkable = value; }
        private bool isWalkable;
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
    }

}
