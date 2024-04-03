using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    GameObject myCamera;

    public GameObject Cube;
    public LayerMask rayMask;
    public LayerMask buildingMask;
    public Collider[] colliders;

    void Start()
    {
        myCamera = Camera.main.gameObject;

    }

    void Update()
    {
        RaycastPlane();
        CheckForCollisions();
    }

    void RaycastPlane()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100.0f, rayMask))
        {
            Cube.transform.position = new Vector3(Mathf.FloorToInt(hit.point.x) + 0.5f, 0, Mathf.FloorToInt(hit.point.z) + 0.5f);
        }
    }

    void CheckForCollisions()
    {
        Vector3 spherePosition = new Vector3(Cube.transform.position.x - 0.15f, Cube.transform.position.y, Cube.transform.position.z - 0.4f);

        Collider[] colliders = Physics.OverlapSphere(spherePosition, 0.2f, LayerMask.GetMask("Buildings"), QueryTriggerInteraction.UseGlobal);

        if (colliders.Length > 0)
        {
            Cube.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            Cube.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
}
