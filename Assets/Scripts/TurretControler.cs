using UnityEngine;

public class ControladorTorretas : MonoBehaviour
{
    public GameObject prefabTorreta; // Prefab de la torreta
    private bool modoColocar = false; // Controla si estamos colocando torretas
    private const float yCoord = 3.902035f;
    private const int costoTorreta = 50; // Costo en puntos para colocar una torreta

    public void ActivarModoColocar()
    {
        modoColocar = true;
        Debug.Log("Modo colocar torreta activado.");
    }

    void Update()
    {
        if (modoColocar && Input.GetMouseButtonDown(0)) // Detecta clic izquierdo
        {
            ColocarTorreta();
        }
    }

    void ColocarTorreta()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Verificar si el punto pertenece al Path
            if (hit.collider.CompareTag("Path"))
            {
                Debug.Log("No puedes colocar una torreta sobre el camino.");
                modoColocar = false; // Salir del modo colocar
                return;
            }
            else if (hit.collider.CompareTag("Map"))
            {
                // Verificar si hay suficientes puntos antes de colocar la torreta
                if (ScoreManager.Instance.SpendPoints(costoTorreta))
                {
                    Instantiate(prefabTorreta, hit.point, Quaternion.identity);
                    Debug.Log("Torreta colocada en: " + hit.point);
                }
                else
                {
                    Debug.Log("No tienes suficientes puntos para colocar una torreta.");
                }
            }
            // Salir del modo colocar
            modoColocar = false;
        }
    }

}
