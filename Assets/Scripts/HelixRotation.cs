using UnityEngine;

public class HelixRotation : MonoBehaviour
{
    public float rotationSpeed = 500f; // Incrementa la velocidad para un giro rápido de hélice

    void Update()
    {
        // Rota la hélice rápidamente en el eje Z para simular el movimiento de una hélice
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
