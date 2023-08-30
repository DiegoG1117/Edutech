using UnityEngine;
using TMPro;

public class ImprimiendoDatos : MonoBehaviour
{
    public GameObject balon; // El objeto del balón en la escena
    public Transform puntoInicial; // El punto inicial del balón en la parábola
    public TextMeshPro alturaText; // El objeto TextMeshPro para mostrar la altura
    public TextMeshPro distanciaText; // El objeto TextMeshPro para mostrar la distancia

    private void Update()
    {
        if (balon != null && puntoInicial != null && alturaText != null && distanciaText != null)
        {
            // Obtener la altura del balón
            float altura = balon.transform.position.y;

            // Calcular la distancia entre el punto inicial y la posición actual del balón
            float distancia = Vector3.Distance(puntoInicial.position, balon.transform.position);

            // Actualizar el TextMeshPro de altura con la altura
            alturaText.text = "Altura: " + altura.ToString("F2") + "M"; // "F2" para mostrar dos decimales

            // Actualizar el TextMeshPro de distancia con la distancia
            distanciaText.text = "Distancia: " + distancia.ToString("F2") + "M"; // "F2" para mostrar dos decimales
        }
    }
}
