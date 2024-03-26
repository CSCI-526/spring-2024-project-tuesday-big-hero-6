using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControleft : MonoBehaviour
{
    public float arrow_speed = -8f;
    public float arrow_lifetime = 4f;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(arrow_speed, 0);

        Destroy(gameObject, arrow_lifetime);
    }
}
