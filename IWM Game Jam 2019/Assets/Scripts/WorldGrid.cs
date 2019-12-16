using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGrid : MonoBehaviour
{
    [SerializeField] private Transform player; 
    [SerializeField] private Vector2 m_grid_size;
    [SerializeField] private float node_radius;

    private Node[,] m_grid;
    private int grid_size_X, grid_size_Y;
    private float node_diameter;

    private void Awake()
    {
        node_diameter = node_radius * 2;
        grid_size_X = Mathf.RoundToInt(m_grid_size.x / node_diameter);
        grid_size_Y = Mathf.RoundToInt(m_grid_size.y / node_diameter);
        Debug.Log("X: " + grid_size_X);
        Debug.Log("Y: " + grid_size_Y); 
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
                m_grid[x, y] = new Node(world_point, x, y);
            }
        }

        //foreach (Node n in m_grid)
        //{
        //    n.Start();
        //    n.GetNodeObject().transform.localScale = Vector3.one * (node_diameter - 0.1f);
        //}
    }

    // This works for now 
    public Vector3 GetWorldPosition(Vector2 _coords)
    {
        Vector3 world_point = Vector3.zero;
        Vector3 world_bottom_left = transform.position - Vector3.right * m_grid_size.x / 2 - Vector3.forward * m_grid_size.y / 2;

        for (int x = 0; x < _coords.x; x++)
        {
            for (int y = 0; y < _coords.y; y++)
            {
                world_point = world_bottom_left + Vector3.right * (x * node_diameter + node_radius) + Vector3.forward * (y * node_diameter + node_radius);
            }
        }

        return world_point; 
    }

    public List<Node> GetNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>(); 

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <=1; y++)
            {
                if (x == 0 && y == 0)
                    continue;

                int checkX = node.gridX + x;
                int checkY = node.gridY + y; 

                if (checkX >= 0 && checkX < grid_size_X && checkY >= 0 && checkY < grid_size_Y)
                {
                    neighbours.Add(m_grid[checkX, checkY]); 
                }
            }
        }

        return neighbours; 
    }

    public Node NodeFromWorldPoint(Vector3 _world_position)
    {
        float percentX = (_world_position.x + m_grid_size.x/2) / m_grid_size.x;
        float percentY = (_world_position.z + m_grid_size.y/2) / m_grid_size.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((grid_size_X - 1) * percentX);
        int y = Mathf.RoundToInt((grid_size_Y - 1) * percentY);
        return m_grid[x, y]; 
    }

    public List<Node> path;
    /// Temp DrawGizmo for cubes 
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(m_grid_size.x, 1, m_grid_size.y));

        if (m_grid != null)
        { 
            foreach (Node n in m_grid)
            {
                Gizmos.color = Color.blue;

                if (path != null)
                {
                    if (path.Contains(n))   
                        Gizmos.color = Color.red; 
                }

                Gizmos.DrawCube(n.GetWorldPosition(), Vector3.one * (node_diameter - 0.1f)); 
            }
        }
    }
}

