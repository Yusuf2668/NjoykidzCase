using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelecterManager : MonoBehaviour
{
    public List<GameObject> selectedTilesList = new List<GameObject>();

    private Camera _camera;
    private RaycastHit2D hit;

    private void Awake()
    {
        _camera = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(_camera.ScreenPointToRay(Input.mousePosition).origin, Vector2.positiveInfinity, Mathf.Infinity);
            if (hit.transform.CompareTag("Tile"))
            {
                hit.transform.gameObject.GetComponent<TileController>().ShowXSprite();
                hit.transform.gameObject.GetComponent<TileController>().CheckTileMatch();
            }
        }
    }
}
