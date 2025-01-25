using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtén el Rigidbody2D del jugador
    }

    void Update()
    {
        // Captura las entradas de las teclas WASD
        movement.x = Input.GetAxisRaw("Horizontal"); // A y D (-1, 0, 1)
        movement.y = Input.GetAxisRaw("Vertical");   // W y S (-1, 0, 1)
    }

    void FixedUpdate()
    {
        // Mueve al jugador en función de la entrada
        rb.velocity = movement * speed;
    }
}
