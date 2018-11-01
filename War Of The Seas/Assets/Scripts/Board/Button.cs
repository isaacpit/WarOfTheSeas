using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private bool dragable = true;
    private bool attack = false;
    public void OnClick()
    {
        if(dragable)
        {
            int counter = 0;
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Ship");
            foreach (GameObject go in gameObjects)
            {
                if (PlacedOnBoard(go.transform.position))
                {
                    counter++;
                }
                else
                {
                    Debug.Log("Ship not in play area");
                }
            }

            if (counter == gameObjects.Length)
            {
                foreach (GameObject go in gameObjects)
                {
                    go.GetComponent<Ship>().dragShip = false;
                    Debug.Log(go.name + ": dragShip set to: " + go.GetComponent<Ship>().dragShip);
                }
            }
            dragable = false;
            attack = true;
        }
        else if(attack)
        {
            GameObject g = GameObject.FindGameObjectWithTag("MouseSelector");
            if(g.GetComponent<MouseSelector>().tiles.Count != 0)
            {
                foreach(var x in g.GetComponent<MouseSelector>().tiles)
                {
                    Debug.Log(x);
                }
            }
        }
    }

    private bool PlacedOnBoard(Vector3 pos)
    {
        return (pos.x >= 50 && pos.x <= 850) && (pos.y <= -50 && pos.y >= -850);
    }
}
