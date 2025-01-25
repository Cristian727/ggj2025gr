using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    [SerializeField] Transform target;                    // Objetivo al que seguir (personaje)
    Rigidbody2D targetRb;                                 // Rigidbody2D del objetivo
    [SerializeField] Vector3 offset = new Vector3(0, 0, -10);  // Desplazamiento de la c�mara
    [SerializeField] float followSmooth = 0.3f;           // Suavidad del seguimiento horizontal
    [SerializeField] float verticalSmooth = 0.5f;         // Suavidad del seguimiento vertical (m�s lento que el horizontal)
    [SerializeField] float minSize = 5f;                  // Tama�o m�nimo de la c�mara
    [SerializeField] float maxSize = 8f;                  // Tama�o m�ximo de la c�mara
    [SerializeField] float minZoomableSpeed = 1f;         // Velocidad m�nima para aplicar zoom
    [SerializeField] float maxZoomableSpeed = 10f;        // Velocidad m�xima para el zoom
    [SerializeField] float zoomSmooth = 0.1f;             // Suavidad del zoom
    [SerializeField] float lookAheadDistance = 2f;        // Distancia de anticipaci�n al objetivo en horizontal
    [SerializeField] float verticalLookAheadLimit = 1f;   // L�mite de anticipaci�n en vertical para evitar movimientos bruscos
    [SerializeField] float lookAheadSmooth = 0.1f;        // Suavidad de la anticipaci�n
    new Camera camera;

    Vector3 positionVelocity = Vector3.zero;              // Velocidad del seguimiento de posici�n
    Vector3 lookAheadVelocity = Vector3.zero;             // Velocidad del "look ahead"
    float sizeVelocity = 0f;                              // Velocidad del zoom
    Vector3 lookAhead;                                    // Vector de anticipaci�n
    float targetSpeed;                                    // Velocidad actual del personaje
    float normalizedSpeed;                                // Velocidad normalizada para el zoom
    float targetSize;                                     // Tama�o objetivo de la c�mara

    private void Awake()
    {
        // Inicializar posiciones y referencias
        transform.position = target.position + offset;
        targetRb = target.GetComponent<Rigidbody2D>();
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        // Ajuste de anticipaci�n seg�n la velocidad del personaje (solo en horizontal)
        if (targetRb.velocity.magnitude > 0)
        {
            Vector2 targetVelocity = targetRb.velocity;
            // Solo anticipar en horizontal, limitar la anticipaci�n vertical
            lookAhead = Vector3.SmoothDamp(
                lookAhead,
                new Vector3(targetVelocity.x, 0, 0) * lookAheadDistance,
                ref lookAheadVelocity,
                lookAheadSmooth
            );
        }

        // Ajuste de la posici�n de la c�mara, separando el suavizado horizontal y vertical
        Vector3 targetPosition = new Vector3(
            Mathf.SmoothDamp(transform.position.x, target.position.x + offset.x + lookAhead.x, ref positionVelocity.x, followSmooth),
            Mathf.SmoothDamp(transform.position.y, target.position.y + offset.y, ref positionVelocity.y, verticalSmooth), // Suavidad vertical distinta
            offset.z
        );

        transform.position = targetPosition;

        // C�lculo del zoom basado en la velocidad del personaje
        targetSpeed = targetRb.velocity.magnitude;
        normalizedSpeed = Mathf.Clamp01((targetSpeed - minZoomableSpeed) / (maxZoomableSpeed - minZoomableSpeed));
        targetSize = normalizedSpeed * (maxSize - minSize) + minSize;

        // Ajuste suave del tama�o de la c�mara
        camera.orthographicSize = Mathf.SmoothDamp(
            camera.orthographicSize,
            targetSize,
            ref sizeVelocity,
            zoomSmooth
        );
    }
}