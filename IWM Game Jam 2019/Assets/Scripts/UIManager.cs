using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UIManager : MonoBehaviour
{
    [Header("[UI Elements]")]
    [SerializeField] private Text turn_text; 
    [SerializeField] private Button next_turn_btn;
    [SerializeField] private Button assign_mission_btn;

    [Header("[Mission Panel]")]
    [SerializeField] private GameObject mission_panel;
    [SerializeField] private Text mission_name;
    [SerializeField] private Text mission_location;
    [SerializeField] private Text mission_description; 

    private void Start()
    {
        next_turn_btn.onClick.AddListener(NextTurn);
        assign_mission_btn.onClick.AddListener(AssignMission); 
    }

    private void Update()
    {
        turn_text.text = "Turn: " + GameManager.Instance.GetCurrentTurn().ToString(); 
    }

    private void NextTurn()
    {
        GameManager.Instance.NextTurn(); 
    }

    private void AssignMission()
    {
        PlaneManager.Instance.AssignMissionToPlane(MissionManager.Instance.GetNewMission());
        mission_panel.SetActive(false); 
    }

    public void MissionPanelActive(Mission _mission)
    {
        mission_panel.SetActive(true);

        mission_name.text = _mission.m_mission_name;
        mission_location.text = _mission.m_target_location.ToString();
        mission_description.text = _mission.m_description; 
    }
}
