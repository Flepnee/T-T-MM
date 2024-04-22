using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerOrder : MonoBehaviour
{
    [SerializeField] SpriteRenderer m_SpriteRenderer;

    void Start()
    {
        m_SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        AdjustLayerOrder();
    }

    void AdjustLayerOrder()
    {
        Vector3 position = transform.position;
        float priority = -(position.x + position.y);
        m_SpriteRenderer.sortingOrder = Mathf.RoundToInt(priority);
    }
}
