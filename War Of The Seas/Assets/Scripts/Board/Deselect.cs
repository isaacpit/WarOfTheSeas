using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deselect : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameObject[] g = GameObject.FindGameObjectsWithTag("Ship");

        GameObject mousePointer = GameObject.FindGameObjectWithTag("MouseSelector");

        foreach(GameObject o in g)
        {
            o.GetComponent<Ship>().Deselect();
        }

        mousePointer.GetComponent<MouseSelector>().mousePause = false;
    }
}
