using UnityEngine;

public class ObjectState : MonoBehaviour
{
    public GameObject objectToMonitor; // Assign the object you want to monitor
    public float interval = 0.1f; // Time between checks

    private bool wasDestroyed = false; // To avoid repeated messages

    void Start()
    {
        // Start monitoring at regular intervals
        InvokeRepeating(nameof(CheckState), 0f, interval);
    }

    void CheckState()
    {
        if (objectToMonitor == null)
        {
            if (!wasDestroyed)
            {
                //Debug.Log($"The object {objectToMonitor} has been destroyed.");
                wasDestroyed = true;
            }
        }
        else
        {
            //Debug.Log($"The object {objectToMonitor.name} still exists.");
            wasDestroyed = false;
        }
    }
}
