using UnityEngine;

public class RaycastOnClick : MonoBehaviour
{
    public Camera mainCamera;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (mainCamera == null)
            {
                mainCamera = Camera.main;
                if (mainCamera == null)
                {
                    Debug.LogError("No camera found!");
                    return;
                }
            }

            Vector3 screenCenter = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f);
            Ray ray = mainCamera.ScreenPointToRay(screenCenter);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // The ray has hit something
                Debug.Log("Raycast hit: " + hit.transform.name);
                
                // Perform actions based on the hit object
                if (hit.transform.CompareTag("Enemy"))
                {
                    // Deactivate the enemy object
                    hit.transform.gameObject.SetActive(false);
                }
            }
        }
    }
}
