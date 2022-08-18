using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPointPoint : MonoBehaviour
{
    public Transform Point;

    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    //Face Mouse Direction 
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)Point.position;
        FaceMouse();
    }

    void FaceMouse()
    {
        Point.transform.right = direction;
    }
}
