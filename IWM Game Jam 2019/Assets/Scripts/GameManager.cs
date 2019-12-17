using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private UIManager ui_manager; 

    private int m_turn_number = 1;
    private float m_threat_level = 0; 

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

    private void Update()
    {
        // If threat level is 100 or over, gameover 
        if (m_threat_level >= 100)
        {
            ui_manager.GameOver(); 
        }
    }

    public void NextTurn()
    {
        m_turn_number++;

        PlaneManager.Instance.UpdatePlaneMovement();
        
        if (m_turn_number % 3 == 0)
        {
            MissionManager.Instance.ActiviateMission(); 
        }
    }

    // Getters 
    public int GetCurrentTurn()
    {
        return m_turn_number; 
    }

    public float GetThreatLevel()
    {
        return m_threat_level; 
    }

    // Setter 
    public void SetThreatLevel(float value)
    {
        m_threat_level += value; 
    }
}
