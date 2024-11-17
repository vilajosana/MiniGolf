using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float topLimit = 2f;    // Límite superior del movimiento
    public float bottomLimit = -2f; // Límite inferior del movimiento
    public float speed = 2f;       // Velocidad del movimiento

    void Update()
    {
        // Oscilar entre los límites superior e inferior
        float newY = Mathf.PingPong(Time.time * speed, topLimit - bottomLimit) + bottomLimit;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
