using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMaterialChange : MonoBehaviour
{
    public void ChangeMaterial(Collider2D col, float direction, LayerMask layer, PhysicsMaterial2D material2D)
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(col.bounds.center, col.bounds.size - new Vector3(0f, 0.25f, 0f), 0, new Vector2(direction, 0f), 1f, layer);

        if (raycastHit.collider != null)
        {
            Debug.DrawRay(col.bounds.center + new Vector3(0f, col.bounds.extents.y - .125f, 0f), new Vector3(direction, 0f, 0f) * (col.bounds.extents.x), Color.green);
            Debug.DrawRay(col.bounds.center - new Vector3(0f, col.bounds.extents.y - .125f, 0f), new Vector3(direction, 0f, 0f) * (col.bounds.extents.x), Color.green);
            col.sharedMaterial = material2D;
        }
        else
        {
            Debug.DrawRay(col.bounds.center + new Vector3(0f, col.bounds.extents.y - .125f, 0f), new Vector3(direction, 0f, 0f) * (col.bounds.extents.x), Color.red);
            Debug.DrawRay(col.bounds.center - new Vector3(0f, col.bounds.extents.y - .125f, 0f), new Vector3(direction, 0f, 0f) * (col.bounds.extents.x), Color.red);
            col.sharedMaterial = null;
        }
    }
}
