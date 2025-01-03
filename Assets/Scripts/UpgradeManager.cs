using UnityEngine;

public class GestionMejoras : MonoBehaviour
{
    public GameObject prefabTorretaNivel2; // Prefab de torreta de nivel 2
    public int costoMejora = 50; // Costo en puntos para mejorar
    private SeleccionTorreta seleccionTorreta; // Referencia al script de selección de torreta

    void Start()
    {
        seleccionTorreta = FindObjectOfType<SeleccionTorreta>();
    }

    public void IntentarMejorarTorreta()
    {
        if (seleccionTorreta.torretaSeleccionada != null)
        {
            GameObject torreta = seleccionTorreta.torretaSeleccionada;
            TorretaBase torretaBase = torreta.GetComponent<TorretaBase>();

            if (torretaBase != null && torretaBase.NivelTorreta == 1)
            {
                if (ScoreManager.Instance.SpendPoints(costoMejora))
                {
                    MejorarTorreta(torreta);
                }
                else
                {
                    Debug.Log("No tienes suficientes puntos para mejorar la torreta.");
                }
            }
            else
            {
                Debug.Log("La torreta seleccionada no puede ser mejorada.");
            }
        }
        else
        {
            Debug.Log("No has seleccionado ninguna torreta.");
        }
    }

    private void MejorarTorreta(GameObject torretaNivel1)
    {
        Vector3 posicion = torretaNivel1.transform.position;
        Quaternion rotacion = torretaNivel1.transform.rotation;

        // Instanciar el prefab de nivel 2
        GameObject nuevaTorreta = Instantiate(prefabTorretaNivel2, posicion, rotacion);

        // Destruir la torreta de nivel 1
        Destroy(torretaNivel1);

        Debug.Log("¡Torreta mejorada!");
    }
}
