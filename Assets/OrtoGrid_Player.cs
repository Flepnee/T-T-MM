using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrtoGrid_Player : MonoBehaviour
{
    GameObject myCamera;

    public GameObject Cube;
    public LayerMask rayMask;

    void Start()
    {
        myCamera = Camera.main.gameObject;
        
    }

    void Update()
    {
        RaycastPlane();
    }

    void RaycastPlane()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100.0f, rayMask))
        {
            Cube.transform.position = new Vector3(Mathf.FloorToInt(hit.point.x) + 0.5f, 0, Mathf.FloorToInt(hit.point.z) + 0.5f);
        }
    }
}
