using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGrid : MonoBehaviour
{
    [SerializeField] private Vector2 m_grid_size;
    [SerializeField] private float node_radius;

    private Node[,] m_grid;
    private int grid_size_X, grid_size_Y;
    private float node_diameter;

    private void Start()
    {
        node_diameter = node_radius * 2;
        grid_size_X = Mathf.RoundToInt(m_grid_size.x / node_diameter);
        grid_size_Y = Mathf.RoundToInt(m_grid_size.y / node_diameter);
        CreateGrid();
    }

    private void CreateGrid()
    {
        m_grid = new Node[grid_size_X, grid_size_Y];
        Vector3 world_bottom_left = transform.position - Vector3.right * m_grid_size.x / 2 - Vector3.forward * m_grid_size.y / 2;

        // Loop through X and Y coord
        for (int x = 0; x < grid_size_X; x++)
        {
            for (int y = 0; y < grid_size_Y; y++)
            {
                Vector3 world_point = world_bottom_left + Vector3.right * (x * node_diameter + node_radius) + Vector3.forward * (y * node_diameter + node_radius);
                m_grid[x, y] = new Node(world_point);
            }
        }

        foreach (Node n in m_grid)
        {
            n.Start();
            n.GetNodeObject().transform.localScale = Vector3.one * (node_diameter - 0.1f); 
        }
    }

    /// Temp DrawGizmo for cubes 
    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireCube(transform.position, new Vector3(m_grid_size.x, 1, m_grid_size.y));

    //    if (m_grid != null)
    //    {
    //        foreach (Node n in m_grid)
    //        {
    //            Gizmos.color = Color.blue;
    //            Gizmos.DrawCube(n.GetWorldPosition(), Vector3.one * (node_diameter - 0.1f));
    //        }
    //    }
    //}
}

