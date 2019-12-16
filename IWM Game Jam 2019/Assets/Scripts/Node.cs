using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    // Potential city object, mission object etc 
    private Vector3 m_world_position;
    private GameObject m_node; 

    public Node(Vector3 _world_position)
    {
        m_world_position = _world_position; 
    }

    public void Start()
    {
        // Instantiate node prefab from resources folder to world position
        m_node = Instantiate(Resources.Load("Node", typeof(GameObject)), m_world_position, Quaternion.identity, GameObject.Find("Nodes").transform) as GameObject; 
    }

    public Vector3 GetWorldPosition()
    {
        return m_world_position; 
    }

    public GameObject GetNodeObject()
    {
        return m_node; 
    }
}
