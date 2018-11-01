using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelector : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;
    private Vector2 size;
    public List<string> tiles;

    private Vector2 offset;
    public bool mousePause;

    void Start ()
    {
        offset.x = 0;
        offset.y = 0;

        size.x = 50;
        size.y = 50;
	}

    private void FixedUpdate()
    {
        if(!mousePause)
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            size.x = GetComponent<Transform>().localScale.x;
            size.y = GetComponent<Transform>().localScale.y;

            if (((mousePosition.x >= 900 && mousePosition.x <= 900 + (50 * 16)) && (mousePosition.y <= -50 && mousePosition.y >= -850)))
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
                transform.position = new Vector3(Mathf.Floor(mousePosition.x / 50) * 50 + 25 + offset.x, Mathf.Ceil(mousePosition.y / 50) * 50 - 25 + offset.y, 850);
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
                transform.position = new Vector3(925, -25, 850);
            }
        }
    }

    public Vector2 getOffset()
    {
        return offset;
    }

    public void setOffset(Vector2 o)
    {
        offset = o;
    }

    private void OnMouseDown()
    {
        tiles.Clear();
        if(size.x == 50 && size.y == 50)
        {
            string temp;
            temp = char.ConvertFromUtf32((int)(-1 * transform.position.y / 50) + 64) + ((transform.position.x - 925) / 50 + 1).ToString();
            mousePause = true;
            tiles.Add(temp);
            Debug.Log(temp);
        }
        else if(size.x == 100 && size.y == 100)
        {
            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    string temp;
                    temp = char.ConvertFromUtf32((int)(-1 * transform.position.y / 50) + i + 63) + Mathf.Floor((transform.position.x - 925) / 50 + 1 + j).ToString();
                    tiles.Add(temp);
                    Debug.Log(temp);
                }
            }
            mousePause = true;
        }
    }
}
