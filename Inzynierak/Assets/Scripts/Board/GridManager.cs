﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using UnityEngine;

public class GridManager : Singleton<GridManager>
{

    [SerializeField]
    private GameObject tile;
    [SerializeField]
    private GameObject board;
    [SerializeField]
    private GameObject GridTiles;

    public Dictionary<Vector2, GameObject> grid = new Dictionary<Vector2, GameObject>();

    private float scale=6;
    private float interval = 5;

    // Start is called before the first frame update
    void Start()
    {
        CreateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateGrid()
    {
        float tileSize = tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        Vector3 offset = new Vector3(-9, -41, 100);
        
        /*GameObject board = Instantiate(this.board, offset, Quaternion.identity);
        board.transform.localScale = new Vector3(scale,scale,0);*/

        for (int y=0; y<10; y++)
        {
            for (int x=0; x< 10; x++)
            {
                GameObject newTile = Instantiate(tile);
                newTile.GetComponent<TileEntity>().Setup(new Vector2(x, y), new Vector3(offset.x - ((tileSize * scale + interval) * (x+1) ), offset.y + interval + ((tileSize * scale + interval) * y), 0), scale);
                newTile.transform.parent = GridTiles.transform;
                grid.Add(new Vector3(x, y, 100), newTile);
            }
        }



    }
}
