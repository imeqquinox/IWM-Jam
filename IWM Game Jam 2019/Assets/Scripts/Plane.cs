using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane
{
    private int m_movement_cost = 3; 

    private Vector3 m_start_location;
    private Vector3 m_target_location; 
    private GameObject m_plane;
    private Pathfinding m_pathfinding; 

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
        for (int i = 0; i < m_movement_cost; i++)
        {
            // Move plane to next position in path
            m_plane.transform.position = m_pathfinding.next_position;
            // Update current position for pathfinding  
            m_pathfinding.SetStartPosition(m_pathfinding.next_position);
            Debug.Log("Plane position: " + m_plane.transform.position);
            Debug.Log("Next position: " + m_pathfinding.next_position);
        }
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
