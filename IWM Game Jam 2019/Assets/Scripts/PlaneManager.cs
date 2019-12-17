﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{
    public static PlaneManager Instance { get; private set; }

    [SerializeField] private WorldGrid world_grid;

    private Plane[] planes = new Plane[5]; 
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

    public void UpdatePlaneMovement()
    {
        //foreach (Plane _plane in planes)
        //{
        //    _plane.Move(); 
        //}
        planes[0].Move(); 
    }

    public void AssignMissionToPlane(Mission _mission)
    {
        Vector2 start_coords = Locations.GetLocation(_mission.m_spawn_location.ToString());
        Vector2 target_coords = Locations.GetLocation(_mission.m_target_location.ToString());

        Vector3 world_start = world_grid.GetWorldPosition(start_coords);
        Vector3 world_target = world_grid.GetWorldPosition(target_coords);

        planes[m_plane_index] = new Plane(world_start, world_target);
        planes[m_plane_index].Start();
        m_plane_index++; 
    }
}
