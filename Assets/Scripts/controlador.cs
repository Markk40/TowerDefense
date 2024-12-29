using UnityEngine;

public class EstadoObjeto : MonoBehaviour
{
    public GameObject objetoASupervisar; // Asigna el objeto que deseas supervisar
    public float intervalo = 0.1f; // Tiempo entre verificaciones

    private bool estabaDestruido = false; // Para evitar mensajes repetidos

    void Start()
    {
        // Inicia la supervisión en intervalos regulares
        InvokeRepeating(nameof(ComprobarEstado), 0f, intervalo);
    }

    void ComprobarEstado()
    {
        if (objetoASupervisar == null)
        {
            if (!estabaDestruido)
            {
                //Debug.Log($"El objeto {objetoASupervisar} ha sido destruido.");
                estabaDestruido = true;
            }
        }
        else
        {
            //Debug.Log($"El objeto {objetoASupervisar.name} sigue existiendo.");
            estabaDestruido = false;
        }
    }
}
