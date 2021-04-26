using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    Camera MainCamera;
    [SerializeField]
    Camera TextureCamera;
    [SerializeField]
    Transform Target; // ~~~ debug
    [SerializeField]
    Canvas Canvas;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPos = TextureCamera.ScreenToWorldPoint(Input.mousePosition);
            Target.position = new Vector3(worldPos.x, worldPos.y, 0); 
            Debug.DrawRay(worldPos, Vector3.forward * 10.0f, Color.green,2.0f);
            //Debug.Log(worldPos);
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);
            if((hit.collider != null) && TryGetClickable(hit.collider, out IOurClickable clickable))
            {
                clickable.Clicked();
            }
        }
    }

    private bool TryGetClickable(Collider2D coll, out IOurClickable outClickable)
    {
        outClickable = coll.GetComponent<IOurClickable>();
        return outClickable != null;
    }
}
