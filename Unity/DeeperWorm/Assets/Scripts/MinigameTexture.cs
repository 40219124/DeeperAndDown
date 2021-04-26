using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameTexture : MonoBehaviour, IOurClickable
{
    [SerializeField]
    Camera MinigameCam;
    Vector3 RayTranslation;
    private void Start()
    {
        RayTranslation = MinigameCam.transform.position - transform.position;
    }
    public void Clicked()
    {
        if (GameAssistant.Running)
        {
            Vector3 clickPos = GameAssistant.MainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 newRayPos = clickPos + RayTranslation;
            newRayPos.z = MinigameCam.transform.position.z;
            Physics.Raycast(newRayPos, Vector3.forward, out RaycastHit hit, 100.0f);
            Debug.DrawRay(newRayPos, Vector3.forward * 100.0f, Color.green, 2.0f);

            if (hit.collider != null)
            {
                IOurClickable testClickable = hit.collider.GetComponent<IOurClickable>();
                if (testClickable != null)
                {
                    testClickable.Clicked();
                }
            }
            else
            {
                // ~~~ not interacting with focus error
            }
        }
    }
}
