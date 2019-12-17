using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UIManager : MonoBehaviour
{
    [Header("[UI Elements]")]
    [SerializeField] private Text turn_text; 
    [SerializeField] private Button next_turn_btn;
    [SerializeField] private Image threat_level;
    [SerializeField] private GameObject game_over; 

    [Header("[Mission Panel]")]
    [SerializeField] private GameObject mission_panel;
    [SerializeField] private Text mission_name;
    [SerializeField] private Text mission_location;
    [SerializeField] private Text mission_description;
    [SerializeField] private Text mission_threat; 
    [SerializeField] private Button accept_missionBtn;
    [SerializeField] private Button reject_missionBtn; 

    [Header("[Plane Selection]")]
    [SerializeField] private GameObject plane_selection_panel;
    [SerializeField] private GameObject[] stats;
    [SerializeField] private Button[] planeBtn; 

    private void Start()
    {
        mission_panel.SetActive(false);
        plane_selection_panel.SetActive(false);
        game_over.SetActive(false); 

        next_turn_btn.onClick.AddListener(NextTurn);
        accept_missionBtn.onClick.AddListener(PlaneSelection);
        reject_missionBtn.onClick.AddListener(RejectMission);
        //assign_mission_btn.onClick.AddListener(AssignMission); 

        for (int i = 0; i < 5; i++)
        {
            planeBtn[i].onClick.AddListener(AssignMission);

            stats[i].transform.GetChild(0).GetComponent<Text>().text = "Name: " + PlaneManager.Instance.GetPlaneType(i).GetPlaneName();
            stats[i].transform.GetChild(1).GetComponent<Text>().text = "Movement: " + PlaneManager.Instance.GetPlaneType(i).GetMovementCost().ToString() + " Tiles";
            stats[i].transform.GetChild(2).GetComponent<Text>().text = "Cost: $" + PlaneManager.Instance.GetPlaneType(i).GetCost().ToString() + "M";
            stats[i].transform.GetChild(3).GetComponent<Text>().text = "Crew cost: " + PlaneManager.Instance.GetPlaneType(i).GetCrewCost().ToString(); 
        }
    }

    private void Update()
    {
        turn_text.text = "Turn: " + GameManager.Instance.GetCurrentTurn().ToString();
        threat_level.fillAmount = GameManager.Instance.GetThreatLevel() / 100; 

        // If the player is currently reading/choosing a misson disable next turn button
        if (MissionManager.Instance.mission_choice)
        {
            next_turn_btn.interactable = false; 
        }
        else
        {
            next_turn_btn.interactable = true; 
        }
    }

    private void NextTurn()
    {
        GameManager.Instance.NextTurn(); 
    }

    private void AssignMission()
    {
        PlaneManager.Instance.AssignMissionToPlane(MissionManager.Instance.GetMission());
        plane_selection_panel.SetActive(false);
        // User has choosen a mission so allow next turn button active
        MissionManager.Instance.SetMissionChoice(false); 
    }

    public void MissionPanelActive(Mission _mission)
    {
        mission_panel.SetActive(true);

        mission_name.text = _mission.m_mission_name;
        mission_location.text = _mission.m_target_location.ToString();
        mission_description.text = _mission.m_description;
        mission_threat.text = "Threat level: " + _mission.m_threat_level.ToString(); 
    }

    public void PlaneSelection()
    {
        mission_panel.SetActive(false);
        plane_selection_panel.SetActive(true);
    }

    public void RejectMission()
    {
        MissionManager.Instance.MissionFail();
        MissionManager.Instance.ActiviateMission(); 
    }

    public void GameOver()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false); 
        }

        game_over.SetActive(true); 
    }
}
