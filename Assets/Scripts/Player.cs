using UnityEngine;

public class Player : MonoBehaviour
{
    private LayerMask mask;
    void Start()
    {
        mask = LayerMask.GetMask("Interactable");
    }

    void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 5f, Color.red);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit,5f,mask))
            {
                Debug.Log(hit.collider.gameObject.name);
                IInteractable interactable = hit.collider.gameObject.GetComponent<IInteractable>();
            }
        }
    }
}
