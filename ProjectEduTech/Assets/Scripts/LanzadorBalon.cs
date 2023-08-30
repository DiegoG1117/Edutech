using System.Collections;
using UnityEngine;

public class LanzadorBalon : MonoBehaviour
{
    public float velocidadInicial = 10f; // Velocidad inicial del balón
    public float anguloLanzamiento = 45f; // Ángulo de lanzamiento en grados

    private Rigidbody rb;
    private Vector3 lanzamientoVector;
    private bool lanzamientoRealizado = false;

    public LineRenderer lineRenderer;
    public int resolution = 1; // Mayor resolución dará una línea más suave

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Desactivar la gravedad inicialmente
        lineRenderer.positionCount = resolution + 1; // Configurar el número de puntos en la línea
    }

    void Update()
    {
        // Detectar la entrada del usuario para lanzar el balón
        if (!lanzamientoRealizado && Input.GetKeyDown(KeyCode.Space))
        {
            LanzarBalon();
            lanzamientoRealizado = true;
        }
    }

    void LanzarBalon()
    {
        // Activar la gravedad
        rb.useGravity = true;

        // Calcular las componentes del vector de velocidad inicial
        float anguloRad = Mathf.Deg2Rad * anguloLanzamiento;
        float velocidadX = velocidadInicial * Mathf.Cos(anguloRad);
        float velocidadY = velocidadInicial * Mathf.Sin(anguloRad);

        // Aplicar la velocidad inicial al balón
        lanzamientoVector = new Vector3(velocidadX, velocidadY, 0);
        rb.velocity = lanzamientoVector;

        // Calcular y dibujar la trayectoria
        DibujarTrayectoria();
    }

    void DibujarTrayectoria()
    {
        for (int i = 0; i <= resolution; i++)
        {
            float t = (float)i / resolution;
            Vector3 position = CalcularPosicionEnTiempo(t);
            lineRenderer.SetPosition(i, position);
        }
    }

    Vector3 CalcularPosicionEnTiempo(float t)
    {
        float x = lanzamientoVector.x * t;
        float y = lanzamientoVector.y * t - 0.5f * Physics.gravity.magnitude * t * t;
        float z = lanzamientoVector.z * t;
        return transform.TransformPoint(new Vector3(x, y, z));
    }
}
