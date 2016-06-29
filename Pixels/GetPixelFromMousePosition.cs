using UnityEngine;
using System.Collections;

public class GetPixelFromMousePosition : MonoBehaviour
{
    private Collider _collider;

    void Start()
    {
        _collider = GetComponent<Collider>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Send a ray to collide with the plane
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (_collider.Raycast(ray, out hit, Mathf.Infinity))
            {
                // Find the u,v coordinate of the Texture
                Vector2 uv;
                uv.x = (hit.point.x - hit.collider.bounds.min.x) / hit.collider.bounds.size.x;
                uv.y = (hit.point.y - hit.collider.bounds.min.y) / hit.collider.bounds.size.y;
                // Paint it red
                Texture2D tex = (Texture2D)hit.transform.gameObject.GetComponent<SpriteRenderer>().sprite.texture;
                tex.SetPixel((int)(uv.x * tex.width), (int)(uv.y * tex.height), Color.red);
                tex.Apply();
            }
        }
    }

}