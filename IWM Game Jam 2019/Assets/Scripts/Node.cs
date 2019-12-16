using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{
    // Potential city object, mission object etc 
    private Vector3 m_world_position;
    private GameObject m_node; 

    public int gridX { get; private set; }
    public int gridY { get; private set; }

    public int gCost { get; private set; }
    public int hCost { get; private set; }
    public Node parent { get; private set; }

    public Node(Vector3 _world_position, int _gridX, int _gridY)
    {
        m_world_position = _world_position;
        gridX = _gridX;
        gridY = _gridY; 
    }

    public void Start()
    {
        // Instantiate node prefab from resources folder to world position
        //m_node = MonoBehaviour.Instantiate(Resources.Load("Node", typeof(GameObject)), m_world_position, Quaternion.identity, GameObject.Find("Nodes").transform) as GameObject; 
    }

    // Getters 
    public Vector3 GetWorldPosition()
    {
        return m_world_position; 
    }

    public GameObject GetNodeObject()
    {
        return m_node; 
    }

    public int fCost
    {
        get
        {
            return gCost + hCost; 
        }
    }

    // Setters 
    public void SetGCost(int value)
    {
        gCost = value; 
    }

    public void SetHCost(int value)
    {
        hCost = value; 
    }

    public void SetParent(Node _parent)
    {
        parent = _parent;
    }
}
