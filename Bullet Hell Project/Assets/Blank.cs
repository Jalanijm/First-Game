using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blank : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FunctionTimer.Create(DeleteSelf, .2f);
    }

    void DeleteSelf()
    {
        Destroy(gameObject);
    }

}
