using UnityEngine;

public class ArrowControlDown : MonoBehaviour
{
    public float arrow_speed = 8f;
    public float arrow_lifetime = 4f;

    void Start()
    {
        Destroy(gameObject, arrow_lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.down * arrow_speed * Time.deltaTime);
    }
}

