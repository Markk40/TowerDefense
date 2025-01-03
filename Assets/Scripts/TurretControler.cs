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
            // Crear un nuevo punto con la coordenada Y especificada
            Vector3 posicionAjustada = new Vector3(hit.point.x, yCoord, hit.point.z);

            // Verificar si el punto pertenece al Path
            if (hit.collider.CompareTag("Path"))
            {
                Debug.Log("No puedes colocar una torreta sobre el camino.");
                return; // No continuar si está en el path
            }

            // Obtener el BoxCollider del prefab para usarlo en las verificaciones
            BoxCollider torretaCollider = prefabTorreta.GetComponent<BoxCollider>();
            if (torretaCollider == null)
            {
                Debug.LogError("El prefab de la torreta no tiene un BoxCollider.");
                return;
            }

            // Calcular las dimensiones del área de verificación basadas en el tamaño mundial del BoxCollider
            Vector3 colliderSize = new Vector3(
                torretaCollider.size.x * prefabTorreta.transform.localScale.x,
                torretaCollider.size.y * prefabTorreta.transform.localScale.y,
                torretaCollider.size.z * prefabTorreta.transform.localScale.z
            );
            Vector3 halfExtents = colliderSize / 2f;

            // Verificar si el área de colocación colisiona con otras torretas
            Collider[] collidersInTorreta = Physics.OverlapBox(posicionAjustada, halfExtents, Quaternion.identity, LayerMask.GetMask("Torreta"));
            if (collidersInTorreta.Length > 0)
            {
                Debug.Log("No puedes colocar una torreta aquí, ya hay otra torreta.");
                return; // No continuar si hay una torreta en el área
            }

            // Verificar si hay suficientes puntos antes de colocar la torreta
            if (ScoreManager.Instance.SpendPoints(costoTorreta))
            {
                Instantiate(prefabTorreta, posicionAjustada, Quaternion.identity);
                Debug.Log("Torreta colocada en: " + posicionAjustada);
            }
            else
            {
                Debug.Log("No tienes suficientes puntos para colocar una torreta.");
            }

            // Salir del modo colocar
            modoColocar = false;
        }
        else
        {
            Debug.Log("Haz clic en un área válida del mapa.");
        }
    }
}
