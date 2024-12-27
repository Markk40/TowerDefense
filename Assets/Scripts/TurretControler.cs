using UnityEngine;

public class ControladorTorretas : MonoBehaviour
{
    public GameObject prefabTorreta; // Prefab de la torreta
    private bool modoColocar = false; // Controla si estamos colocando torretas

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
            // Coloca la torreta en la posición del clic
            Instantiate(prefabTorreta, hit.point, Quaternion.identity);
            Debug.Log("Torreta colocada en: " + hit.point);

            // Salir del modo colocar
            modoColocar = false;
        }
    }
}

