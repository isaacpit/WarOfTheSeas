using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public int currentHealth = 4;
    public int totalHealth = 4;
    public GameObject StdAtk;
    public GameObject SpcAtk;
    public GameObject SpcAbi1;
    public GameObject SpcAbi2;
    
    private Vector3 origPosition;
    private Vector3 screenPoint;
    private Vector3 offset;

    public bool dragShip = true;

    void Start()
    {
        origPosition = gameObject.transform.position;
    }

    void OnMouseDown()
    {
        if (GetComponent<Ship>().dragShip)
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
        else
        {
            Select();
        }
    }

    void OnMouseDrag()
    {
        if (GetComponent<Ship>().dragShip)
        {
            if (Input.GetButtonDown("Rotate"))
            {
                if (transform.rotation.z == 0)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                }
                else if (transform.rotation == Quaternion.Euler(new Vector3(0, 0, 90)))
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                }
                else if (transform.rotation == Quaternion.Euler(new Vector3(0, 0, 180)))
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
                }
                else if (transform.rotation == Quaternion.Euler(new Vector3(0, 0, 270)))
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                }
            }

            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = new Vector3(Mathf.Floor(curPosition.x / 50) * 50, Mathf.Ceil(curPosition.y / 50) * 50, curPosition.z);
        }
    }

    void OnMouseUp()
    {
        if (GetComponent<Ship>().dragShip)
        {
            if (!((gameObject.transform.position.x >= 50 && gameObject.transform.position.x <= 850) && (gameObject.transform.position.y <= -50 && gameObject.transform.position.y >= -850)))
            {
                transform.position = origPosition;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
        }
    }

    public void Select()
    {
        if (gameObject.name == "Battleship")
        {
            StdAtk.GetComponent<BSStdAtk>().Selected();
        }

        DeselectOutline();
        GetComponent<Outline>().enabled = true;
    }

    public void Deselect()
    {
        if (gameObject.name == "Battleship")
        {
            StdAtk.GetComponent<BSStdAtk>().Deselected();
        }
        
        GetComponent<Outline>().enabled = false;
    }

    private void DeselectOutline()
    {
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Ship"))
        {
            g.GetComponent<Outline>().enabled = false;
        }
    }
}
