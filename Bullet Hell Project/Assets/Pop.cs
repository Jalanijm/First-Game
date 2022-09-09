using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pop : MonoBehaviour
{
    private void Awake()
    {
        Invoke("EndSelf", 5f);

    }

    private void EndSelf()
    {
        Destroy(gameObject);
    }
}
