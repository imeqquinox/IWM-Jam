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
    }
}
