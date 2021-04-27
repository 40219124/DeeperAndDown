using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollower : MonoBehaviour
{
    [SerializeField] Camera Cam;

    void Update()
    {
        Cursor.visible = false;
        Vector3 worldPos = Cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(worldPos.x, worldPos.y, 0);
    }
}
