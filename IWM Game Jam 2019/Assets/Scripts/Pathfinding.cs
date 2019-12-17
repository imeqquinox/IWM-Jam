using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    private Vector3 start_position;
    private Vector3 target_position;
    public Vector3 next_position { get; private set; }

    private int m_path_index = 0; 
    private WorldGrid grid;

    private bool m_found; 

    private void Awake()
    {
        grid = GameObject.Find("Grid").GetComponent<WorldGrid>(); 
    }

    private void Start()
    {
        m_found = false; 
    }

    private void Update()
    {
        if (!m_found)
        {
            FindPath(start_position, target_position);
        }
    }
    
    // Setters 
    public void SetStartPosition(Vector3 _start_position)
    {
        start_position = _start_position;
    }

    public void SetTargetPosition(Vector3 _target_position)
    {
        target_position = _target_position; 
    }

    public void SetPathIndex(int value)
    {
        m_path_index = value; 
    }

    private void FindPath(Vector3 _start_position, Vector3 _target_position)
    {
        if (_start_position == _target_position)
        {
            m_found = true;
            MissionManager.Instance.MissionComplete();
            // Get plane index
            //Destroy(this.gameObject); 
        }

        Node start_node = grid.NodeFromWorldPoint(_start_position);
        Node target_node = grid.NodeFromWorldPoint(_target_position);

        List<Node> open_set = new List<Node>();
        HashSet<Node> closed_set = new HashSet<Node>();
        open_set.Add(start_node); 

        while (open_set.Count > 0)
        {
            Node node = open_set[0]; 
            for (int i = 1; i < open_set.Count; i ++)
            {
                if (open_set[i].fCost < node.fCost || open_set[i].fCost == node.fCost)
                {
                    if (open_set[i].hCost < node.hCost)
                    {
                        node = open_set[i];
                    }
                }
            }

            open_set.Remove(node);
            closed_set.Add(node);

            if (node == target_node)
            {
                RetracePath(start_node, target_node);
                return; 
            }

            foreach (Node neighbour in grid.GetNeighbours(node))
            {
                if (closed_set.Contains(neighbour))
                {
                    continue; 
                }

                int new_cost_to_neighbour = node.gCost + GetDistance(node, neighbour); 
                if (new_cost_to_neighbour < neighbour.gCost || !open_set.Contains(neighbour))
                {
                    neighbour.SetGCost(new_cost_to_neighbour);
                    neighbour.SetHCost(GetDistance(neighbour, target_node));
                    neighbour.SetParent(node); 

                    if (!open_set.Contains(neighbour))
                    {
                        open_set.Add(neighbour); 
                    }
                }
            }
        }
    }

    private void RetracePath(Node _start_node, Node _end_node)
    {
        List<Node> path = new List<Node>();
        Node current_node = _end_node; 

        while (current_node != _start_node)
        {
            path.Add(current_node);
            current_node = current_node.parent; 
        }

        path.Reverse();
        grid.path = path;

        if (m_path_index > path.Count - 1)
            m_path_index = path.Count - 1; 

        next_position = path[m_path_index].GetWorldPosition(); 
    }

    private int GetDistance(Node _node_A, Node _node_B)
    {
        int dist_X = Mathf.Abs(_node_A.gridX - _node_B.gridX);
        int dist_Y = Mathf.Abs(_node_A.gridY - _node_B.gridY); 

        if (dist_X > dist_Y)
        {
            return 14 * dist_Y + 10 * (dist_X - dist_Y); 
        }

        return 14 * dist_X + 10 * (dist_Y - dist_X); 
    }
}
