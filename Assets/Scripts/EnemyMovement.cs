using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public enum MovementType { Horizontal, Vertical } // Tipos de movimiento
    public MovementType movementType = MovementType.Horizontal; // Tipo de movimiento del enemigo

    public float speed = 2f; // Velocidad del movimiento
    public float minBoundary = -5f; // Límite mínimo
    public float maxBoundary = 5f;  // Límite máximo

    private bool movingPositive = true; // Dirección inicial

    void Update()
    {
        // Determinar dirección y mover según el tipo
        if (movementType == MovementType.Horizontal)
        {
            MoveHorizontally();
        }
        else if (movementType == MovementType.Vertical)
        {
            MoveVertically();
        }
    }

    void MoveHorizontally()
    {
        if (movingPositive)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            if (transform.position.x >= maxBoundary)
            {
                movingPositive = false;
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            if (transform.position.x <= minBoundary)
            {
                movingPositive = true;
            }
        }
    }

    void MoveVertically()
    {
        if (movingPositive)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);

            if (transform.position.y >= maxBoundary)
            {
                movingPositive = false;
            }
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);

            if (transform.position.y <= minBoundary)
            {
                movingPositive = true;
            }
        }
    }
}
