using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// 
/// This class generates the boundaries for the game dynamically
/// using inputs in the Inspector.
/// Generates during the Start() phase in Unity.
///
public class Boundaries : MonoBehaviour
{

    public float distanceFromOrigin = 10f; //!< Origin the location of boundary prefab
    public GameObject BoundaryPrefab; //!< A reference to the BoundaryPrefab
    public bool debugVisibility = false; //!< Boundaries will be visible if true

    private const float Y_OFFSET = -2;
    private GameObject[] boundaries;

    
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
        boundary.transform.localPosition = new Vector3(0, Y_OFFSET, 0);

        // ceiling
        boundary = Instantiate(BoundaryPrefab, transform);
        boundary.name = "Boundary Y+";
        boundary.transform.localScale = boundaryScale;
        boundary.transform.localPosition = new Vector3(0,distanceFromOrigin+y_position, 0);

        // walls
        boundary = Instantiate(BoundaryPrefab, transform);
        boundary.name = "Boundary X+";
        boundary.transform.localScale = boundaryScale;
        boundary.transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
        boundary.transform.localPosition = new Vector3(distanceFromOrigin, y_position, 0);

        boundary = Instantiate(BoundaryPrefab, transform);
        boundary.name = "Boundary X-";
        boundary.transform.localScale = boundaryScale;
        boundary.transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
        boundary.transform.localPosition = new Vector3(-distanceFromOrigin, y_position, 0);

        boundary = Instantiate(BoundaryPrefab, transform);
        boundary.name = "Boundary Z+";
        boundary.transform.localScale = boundaryScale;
        boundary.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
        boundary.transform.localPosition = new Vector3(0, y_position, distanceFromOrigin);

        boundary = Instantiate(BoundaryPrefab, transform);
        boundary.name = "Boundary Z-";
        boundary.transform.localScale = boundaryScale;
        boundary.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
        boundary.transform.localPosition = new Vector3(0, y_position, -distanceFromOrigin);
        
        boundaries = GameObject.FindGameObjectsWithTag("Boundary");
    }

    void Update(){
        
        for(int i = 0; i<boundaries.Length; i++){
            boundaries[i].GetComponent<Renderer>().enabled = debugVisibility;
        }
    }

    
}
