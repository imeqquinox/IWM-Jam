using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{
    public static PlaneManager Instance { get; private set; }

    [SerializeField] private WorldGrid world_grid;
    [SerializeField] private Plane[] plane_types; 

    private Plane[] planes = new Plane[25]; 
    private int m_plane_index; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        m_plane_index = 0; 
    }

    private void Update()
    {
        for (int i = 0; i < planes.Length; i++)
        {
            
        }
    }

    public void UpdatePlaneMovement()
    {
        for (int i = 0; i < planes.Length; i++)
        {
            if (planes[i] == null)
                return; 

            planes[i].Move(); 
        }
    }

    public void AssignMissionToPlane(Mission _mission, int _plane_type)
    {
        Vector2 start_coords = Locations.GetLocation(_mission.m_spawn_location.ToString());
        Vector2 target_coords = Locations.GetLocation(_mission.m_target_location.ToString());

        Vector3 world_start = world_grid.GetWorldPosition(start_coords);
        Vector3 world_target = world_grid.GetWorldPosition(target_coords);

        planes[m_plane_index] = plane_types[_plane_type];
        planes[m_plane_index].SetStartLocation(world_start);
        planes[m_plane_index].SetTargetLocation(world_target);
        planes[m_plane_index].SetIndex(m_plane_index);
        planes[m_plane_index].Start();
        Debug.Log(planes[m_plane_index].GetPlaneName());

        // Sub crew and money for the plane
        GameManager.Instance.SubCrew(planes[m_plane_index].GetCrewCost());
        GameManager.Instance.SubMoney(planes[m_plane_index].GetCost()); 

        m_plane_index++; 
    }

    // Getter 
    public Plane GetPlaneType(int index)
    {
        return plane_types[index]; 
    }

    public void DeletePlane(int index)
    {
        planes[index] = null;
    }
}
