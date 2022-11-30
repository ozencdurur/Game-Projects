using UnityEngine;
public class Pipe : MonoBehaviour
{
    Rigidbody2D rb;
    float pipeSpeed = 1.5f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocity = Vector2.left * pipeSpeed;
        Destroy(gameObject, 10);
    }
}

