using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ball : MonoBehaviour
{
    Rigidbody2D rb;
    float min = .8f;
    float max = 1.2f;

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();

        Singleton.instance.addtoList(this.gameObject);
    }

    private void OnDestroy()
    {
        Singleton.instance.removeFromList(this.gameObject);
    }

}
