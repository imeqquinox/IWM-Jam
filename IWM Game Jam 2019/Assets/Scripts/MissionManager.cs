using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance { get; private set; }

    [SerializeField] private Mission[] missions;

    private UIManager ui_manager;
    private int rand_mission;
    public bool mission_choice { get; private set; }

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
        mission_choice = false; 
        ui_manager = GameObject.Find("UI Canvas").GetComponent<UIManager>();
        ActiviateMission(); 
    }

    // For all mission information to assign to plane
    public Mission GetMission()
    {
        if (missions == null)
            return null;

        return missions[rand_mission];
    }

    public void ActiviateMission()
    {
        mission_choice = true; 
        rand_mission = Random.Range(0, missions.Length);
        ui_manager.MissionPanelActive(missions[rand_mission]);
    }

    public void MissionFail()
    {
        GameManager.Instance.AddThreatLevel(missions[rand_mission].m_threat_level); 
    }

    public void MissionComplete()
    {
        GameManager.Instance.AddCrew(missions[rand_mission].m_crew);
        GameManager.Instance.AddMoney(missions[rand_mission].m_reward);
    }

    // Setters 
    public void SetMissionChoice(bool value)
    {
        mission_choice = value; 
    }
}
