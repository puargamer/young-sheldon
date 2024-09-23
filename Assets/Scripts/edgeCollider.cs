using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class edgeCollider : MonoBehaviour
{
    //edge colliders serve as containers, but must be manually defined. makes an edge collider based on a given polygon collider

    public PolygonCollider2D ReferenceCollider;
    public PhysicsMaterial2D Material;

    // Start is called before the first frame update
    void Start()
    {
        EdgeCollider2D EdgeCollider = this.gameObject.AddComponent<EdgeCollider2D>();

        Vector2[] points = ReferenceCollider.points;
        EdgeCollider.points = points;
        ReferenceCollider.enabled = false;

        EdgeCollider.sharedMaterial = Material;
    }

}
