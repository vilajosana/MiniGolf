using UnityEngine;

public class Vortex : MonoBehaviour
{
    public Transform startPoint; // Punto de inicio de la bola
    public float movementSpeed = 2f; // Velocidad del movimiento de arriba a abajo
    public float upperLimit = 2f; // Límite superior del movimiento
    public float lowerLimit = -2f; // Límite inferior del movimiento

    private void Update()
    {
        // Movimiento de arriba a abajo dentro de los límites
        float newY = Mathf.PingPong(Time.time * movementSpeed, upperLimit - lowerLimit) + lowerLimit;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            // Reiniciar la posición de la bola al punto de inicio
            other.transform.position = startPoint.position;

            // Reiniciar la velocidad de la bola
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
