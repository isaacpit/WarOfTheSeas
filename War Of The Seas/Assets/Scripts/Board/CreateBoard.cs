using System.Collections.Generic;
using UnityEngine;

public class CreateBoard : MonoBehaviour {

    public Transform tilePrefab;
    public Vector2 mapSize;
    public Vector2 offset;

    void Start()
    {
        //CreateGameBoard();
    }

    public void CreateGameBoard()
    {
        for(int x = 0; x < mapSize.x; x++)
        {
            for(int y = 0; y < mapSize.y; y++)
            {
                Vector3 tilePosition = new Vector3(x * 50 + offset.x, - y * 50 + offset.y, 850);
                Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.right)) as Transform;
                if(offset.x < 850)
                {
                    newTile.gameObject.name = 'P' + char.ConvertFromUtf32(x + 65) + (y + 1);
                    newTile.parent = gameObject.transform;
                    newTile.GetComponent<BoxCollider2D>().enabled = false;
                }
                else
                {
                    newTile.gameObject.name = 'O' + char.ConvertFromUtf32(x + 65) + (y + 1);
                    newTile.parent = gameObject.transform;
                }
            }
        }
    }
}
