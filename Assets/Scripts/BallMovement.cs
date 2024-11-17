using UnityEngine;

public class BallController : MonoBehaviour
{
    public float maxForce = 2000f; // Incrementa la fuerza máxima que se puede aplicar
    public float chargeRate = 100f; // Incrementa la velocidad de carga de la fuerza
    private float currentForce = 0f; // La fuerza actual acumulada
    private bool isCharging = false; // Para saber si está cargando la fuerza
    private Rigidbody2D rb;

    public float stopThreshold = 0.1f; // Umbral de velocidad para detener la pelota
    public PhysicsMaterial2D noFrictionMaterial; // Material sin fricción para la pelota

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.sharedMaterial = noFrictionMaterial; // Asigna el material sin fricción
    }

    void Update()
    {
        // Detecta si se mantiene presionada la tecla Space
        if (Input.GetKey(KeyCode.Space))
        {
            isCharging = true;
            // Incrementa la fuerza hasta el valor máximo
            currentForce += chargeRate * Time.deltaTime;
            currentForce = Mathf.Clamp(currentForce, 0, maxForce);
        }

        // Al soltar la tecla Space, se aplica la fuerza acumulada
        if (Input.GetKeyUp(KeyCode.Space) && isCharging)
        {
            ApplyForce();
            isCharging = false;
        }

        // Detiene el movimiento cuando la velocidad es muy baja
        if (rb.velocity.magnitude < stopThreshold && rb.velocity.magnitude > 0)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
        }
    }

    void ApplyForce()
    {
        // Obtiene la posición del ratón en el mundo 2D
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        // Calcula la dirección desde la posición de la pelota hasta el ratón
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;
        
        // Aplica la fuerza acumulada en esa dirección, usando un multiplicador para aumentar la potencia
        rb.AddForce(direction * currentForce * 8f); // Multiplicador aumentado para más fuerza
        
        // Reinicia la fuerza acumulada
        currentForce = 0f;
    }
}
