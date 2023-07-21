using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NghiaTQ.tile;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI modeText;
    [SerializeField] GridManager gridManager;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        EditMap();
    }

    private void EditMap()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform.TryGetComponent<Tile>(out Tile tile))
            {
                if (tile != null)
                {
                    Debug.Log(hit.transform.name);
                }
            }
        }
    }
}
