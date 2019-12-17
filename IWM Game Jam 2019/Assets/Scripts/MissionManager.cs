using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance { get; private set; }

    [SerializeField] private Mission[] missions;

    private UIManager ui_manager;
    private int rand_mission;

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
        ui_manager = GameObject.Find("UI Canvas").GetComponent<UIManager>();
        ActiviateMission(); 
    }

    // For all mission information to assign to plane
    public Mission GetNewMission()
    {
        if (missions == null)
            return null;

        return missions[rand_mission];
    }

    public void ActiviateMission()
    {
        rand_mission = Random.Range(0, missions.Length);
        ui_manager.MissionPanelActive(missions[rand_mission]);
    }
}
