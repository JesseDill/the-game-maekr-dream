using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDisplacer : MonoBehaviour
{
    BoxCollider2D boxCollider;
    [SerializeField] float displacement;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        boxCollider.transform.position = new Vector2(
            boxCollider.transform.position.x, boxCollider.transform.position.y + displacement);
    }
}
