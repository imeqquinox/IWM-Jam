using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    private Vector3 m_start_location;
    private Vector3 m_target_location;
    private GameObject m_plane; 

    public Plane(Vector3 _start_location, Vector3 _target_location)
    {
        m_start_location = _start_location;
        m_target_location = _target_location; 
    }

    public void Start()
    {
        m_plane = Instantiate(Resources.Load("TestPlane", typeof(GameObject)), m_start_location, Quaternion.identity) as GameObject; 
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
}
