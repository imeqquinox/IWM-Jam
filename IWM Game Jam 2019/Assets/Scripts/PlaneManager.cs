using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{
    [SerializeField] private WorldGrid world_grid; 
    private Plane test_plane;
    private Vector2 start_coords; 
    private Vector3 test_start_location = Vector3.zero; 

    private void Start()
    {
        start_coords = new Vector2(9, 15);
        test_start_location = world_grid.GetWorldPosition(start_coords);

        test_plane = new Plane(test_start_location, Vector3.zero); 
        test_plane.Start();
    }

    private void Update()
    {
        // Update plane movement here
    }
}
