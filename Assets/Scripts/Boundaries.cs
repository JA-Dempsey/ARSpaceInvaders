using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This class generates the boundaries for the game dynamically
// using inputs in the Inspector
public class Boundaries : MonoBehaviour
{

    public float distanceFromOrigin = 10f;
    public GameObject BoundaryPrefab;
    public bool debugVisibility = false;

    private const float Y_OFFSET = -2.5f;

    
    // Start is called before the first frame update
    void Start()
    {

        GameObject boundary;
        float scaleConstant = 2*distanceFromOrigin;
        float y_position = Y_OFFSET + distanceFromOrigin;

        Vector3 boundaryScale = new Vector3(scaleConstant, 0.1f, scaleConstant);

        // floor
        boundary = Instantiate(BoundaryPrefab, transform);
        boundary.name = "Boundary Y-";
        boundary.transform.localScale = boundaryScale;
        boundary.transform.position = new Vector3(0, Y_OFFSET, 0);

        // ceiling
        boundary = Instantiate(BoundaryPrefab, transform);
        boundary.name = "Boundary Y+";
        boundary.transform.localScale = boundaryScale;
        boundary.transform.position = new Vector3(0,distanceFromOrigin+y_position, 0);

        // walls
        boundary = Instantiate(BoundaryPrefab, transform);
        boundary.name = "Boundary X+";
        boundary.transform.localScale = boundaryScale;
        boundary.transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
        boundary.transform.position = new Vector3(distanceFromOrigin, y_position, 0);

        boundary = Instantiate(BoundaryPrefab, transform);
        boundary.name = "Boundary X-";
        boundary.transform.localScale = boundaryScale;
        boundary.transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
        boundary.transform.position = new Vector3(-distanceFromOrigin, y_position, 0);

        boundary = Instantiate(BoundaryPrefab, transform);
        boundary.name = "Boundary Z+";
        boundary.transform.localScale = boundaryScale;
        boundary.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
        boundary.transform.position = new Vector3(0, y_position, distanceFromOrigin);

        boundary = Instantiate(BoundaryPrefab, transform);
        boundary.name = "Boundary Z-";
        boundary.transform.localScale = boundaryScale;
        boundary.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
        boundary.transform.position = new Vector3(0, y_position, -distanceFromOrigin);
        

        GameObject[] boundaries = GameObject.FindGameObjectsWithTag("Boundary");
        for(int i = 0; i<boundaries.Length; i++){
            boundaries[i].GetComponent<Renderer>().enabled = debugVisibility;
        }
    }

    
}
