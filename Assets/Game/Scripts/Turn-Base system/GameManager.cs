using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NghiaTQ.tile;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI modeText;
    [SerializeField] GridManager gridManager;
    public enum Mode
    {
        Edit,
        Normal
    }
    public Mode mode;
    // Start is called before the first frame update
    void Start()
    {
        mode = Mode.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        modeText.text = "Mode: " + mode;
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            mode = (mode == Mode.Edit) ? Mode.Normal : Mode.Edit;
        }
        if(mode == Mode.Edit)
        {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.transform.TryGetComponent<Tile>(out Tile tile))
            {
                if (tile != null)
                {
                    Debug.Log(hit.transform.name);
                }
            }
        }
    }
}
