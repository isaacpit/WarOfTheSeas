using UnityEngine;

public class Highlight : MonoBehaviour
{
    SpriteRenderer sr;

    public string BoardCordinate = "";

    // Use this for initialization
    void Start ()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.color = new Color(1f, 1f, 1f, 0f);
    }

    private void OnMouseOver()
    {
        sr.color = new Color(1f, 1f, 1f, 0.5f);
    }

    private void OnMouseExit()
    {
        sr.color = new Color(1f, 1f, 1f, 0f);
    }
}
