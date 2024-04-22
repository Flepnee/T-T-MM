using UnityEngine;
using UnityEngine.EventSystems;

public class Grid : MonoBehaviour
{
    GameObject myCamera;

    public GameObject Projection;
    public LayerMask rayMask;
    public LayerMask buildingMask;
    public bool canPlace;
    public GameObject[] buildings;
    public Vector3 cursorPos;
    public SpriteRenderer projectionImage;

    void Start()
    {
        myCamera = Camera.main.gameObject;
    }

    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject()) // Check if mouse is over UI
        {
            RaycastPlane();
            CheckForCollisions();
            PlaceBuilding();
            UpdateProjection();
        }
    }

    void RaycastPlane()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100.0f, rayMask))
        {
            cursorPos = new Vector3(Mathf.FloorToInt(hit.point.x) + 0.5f, Mathf.FloorToInt(hit.point.y) + 0.5f, 0);
            Projection.transform.position = cursorPos;
        }
    }

    void CheckForCollisions()
    {
        if (Physics2D.OverlapBox(Projection.transform.position, new Vector2(2.9f, 2.9f), 0f, buildingMask))
        {
            projectionImage.color = Color.red;
            canPlace = false;
        }
        else
        {
            projectionImage.color = Color.green;
            canPlace = true;
        }
    }

    void PlaceBuilding()
    {
        if (Input.GetButtonUp("Fire1") && canPlace)
        {
            Instantiate(buildings[transform.GetComponent<BuildingSelector>().selectedIndex], cursorPos, Quaternion.identity);
        }
    }

    void UpdateProjection()
    {
        projectionImage.sprite = buildings[transform.GetComponent<BuildingSelector>().selectedIndex].GetComponentInChildren<SpriteRenderer>().sprite;
    }
}
