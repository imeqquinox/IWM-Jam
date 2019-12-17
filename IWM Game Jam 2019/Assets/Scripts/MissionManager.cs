using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance { get; private set; }

    [SerializeField] private Mission[] missions; 

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
        if (missions[0] != null)
        {
            Debug.Log("Mission name: " + missions[0].m_mission_name);
            Debug.Log("Spawn: " + missions[0].m_spawn_location);
            Debug.Log("Target location: " + missions[0].m_target_location);
        }
    }

    public Mission GetNewMission()
    {
        if (missions == null)
            return null;

        return missions[0];
    }
}
