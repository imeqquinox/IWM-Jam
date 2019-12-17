using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Plane
{
    [SerializeField] private string m_name; 
    [SerializeField] private int m_movement_cost;
    [SerializeField] private int m_cost;
    [SerializeField] private int m_crew_cost;
    [SerializeField] private string m_resourceload_name; 

    private Vector3 m_start_location;
    private Vector3 m_target_location; 
    private GameObject m_plane;
    private Pathfinding m_pathfinding;

    public Plane() {}

    public Plane(Vector3 _start_location, Vector3 _target_location)
    {
        m_start_location = _start_location;
        m_target_location = _target_location;
    }

    public void Start()
    {
        m_plane = GameObject.Instantiate(Resources.Load("TestPlane", typeof(GameObject)), m_start_location, Quaternion.identity) as GameObject;
        m_pathfinding = m_plane.GetComponent<Pathfinding>();
        m_pathfinding.SetStartPosition(m_start_location);
        m_pathfinding.SetTargetPosition(m_target_location); 
    }

    public void Move()
    {
        // Set path node index depending on the speed of the plane
        m_pathfinding.SetPathIndex(m_movement_cost); 
        // Move plane to next position in path
        m_plane.transform.position = m_pathfinding.next_position;
        // Update current position for pathfinding  
        m_pathfinding.SetStartPosition(m_pathfinding.next_position);
    }

    // Getters 
    public Vector3 GetStartLocation()
    {
        return m_start_location; 
    }

    public Vector3 GetTargetLocation()
    {
        return m_target_location; 
    }

    public GameObject GetPlaneObject()
    {
        return m_plane; 
    }

    public string GetPlaneName()
    {
        return m_name; 
    }

    public int GetMovementCost()
    {
        return m_movement_cost; 
    }

    public int GetCost()
    {
        return m_cost; 
    }

    public int GetCrewCost()
    {
        return m_crew_cost; 
    }

    // Setters 
    public void SetStartLocation(Vector3 _start_location)
    {
        m_start_location = _start_location;
    }

    public void SetTargetLocation(Vector3 _target_location)
    {
        m_target_location = _target_location;
    }
}
