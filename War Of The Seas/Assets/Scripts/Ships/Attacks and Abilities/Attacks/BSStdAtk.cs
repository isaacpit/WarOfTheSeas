using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSStdAtk : MonoBehaviour 
{
    public void Selected()
    {
        GameObject g = GameObject.FindGameObjectWithTag("MouseSelector");

        g.GetComponent<Transform>().localScale = new Vector3(100, 100, 1);
        g.GetComponent<MouseSelector>().setOffset(new Vector2(25, -25));
    }

    public void Deselected()
    {
        GameObject g = GameObject.FindGameObjectWithTag("MouseSelector");

        g.GetComponent<Transform>().localScale = new Vector3(50, 50, 1);
        g.GetComponent<MouseSelector>().setOffset(new Vector2(0, 0));
    }
}
