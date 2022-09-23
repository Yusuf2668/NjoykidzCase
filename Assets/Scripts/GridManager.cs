using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public List<GameObject> tileList = new List<GameObject>();

    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Transform tilesParent;

    [SerializeField] public float gridWidth;
    [SerializeField] private float gridHeight;

    private float tileWidthSize;
    private float tileHeightSize;
    private float widhtScaleRate;
    private float heighScaleRate;

    private int tileLine = 0;

    private SpriteRenderer tilePrefabRenderer;
    private Camera _camera;

    private Vector2 tileBounds;
    private Vector3 tilePositionOffset;
    private Vector3 firstTileinstantiateposition;
    private Vector3 topRightCorner;

    private GameObject _InstantiateTile;

    private void Awake()
    {
        tilePrefabRenderer = tilePrefab.GetComponent<SpriteRenderer>();
        _camera = Camera.main;
        tileBounds = tilePrefabRenderer.bounds.size;
        tileWidthSize = tileBounds.x;
        tileHeightSize = tileBounds.y;
        tilePositionOffset = Vector3.zero;
    }

    private void Start()
    {
        InstantiateTile();
        SetTileScaleToScreen();
        SetPositionTiles();
    }

    private void InstantiateTile()//Bütün listeyi Yaratýcak
    {
        tileLine = 1;
        for (int i = 0; i < gridHeight * gridWidth; i++)
        {
            _InstantiateTile = Instantiate(tilePrefab, firstTileinstantiateposition, Quaternion.identity, tilesParent);
            _InstantiateTile.GetComponent<TileController>().tileLine = tileLine;
            tileList.Add(_InstantiateTile);
            tileLine++;
        }
    }
    private void SetTileScaleToScreen() //Tile'larýn boyutlarýný ekrana göre ayarlar
    {
        topRightCorner = _camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 5));
        tileWidthSize = tileBounds.x * gridWidth;
        tileHeightSize = tileBounds.y * gridHeight;
        widhtScaleRate = (topRightCorner.x * 2) / tileWidthSize;
        heighScaleRate = (topRightCorner.y * 2) / tileHeightSize;
        tilesParent.gameObject.transform.localScale = new Vector3(widhtScaleRate, heighScaleRate, 1);
        tileBounds = tileList[0].gameObject.GetComponent<SpriteRenderer>().bounds.size;
    }
    private void SetPositionTiles()//Bütün listenin pozisyonunu düzenler
    {
        tileLine = 0;
        tilePositionOffset = Vector3.zero;
        firstTileinstantiateposition = _camera.ScreenToWorldPoint(new Vector3(0, Screen.height, 5f)) + new Vector3(tileBounds.x / 2, tileBounds.y / -2);
        for (int i = 0; i < gridHeight; i++)
        {
            for (int j = 0; j < gridWidth; j++)
            {
                tileList[tileLine].transform.position = firstTileinstantiateposition + tilePositionOffset;
                tilePositionOffset.x += tileBounds.x;
                tileLine++;
            }
            tilePositionOffset.x = 0;
            tilePositionOffset.y -= tileBounds.y;
        }
    }
}
