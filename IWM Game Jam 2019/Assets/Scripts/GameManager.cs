using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private UIManager ui_manager; 

    private int m_turn_number = 1;
    private float m_threat_level = 0;
    private int m_crew = 15;
    private int m_money = 150; 

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

    public void Exit()
    {
        Application.Quit(); 
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

    public int GetCrew()
    {
        return m_crew; 
    }

    public int GetMoney()
    {
        return m_money; 
    }

    // Setter 
    public void AddThreatLevel(float value)
    {
        m_threat_level += value; 
    }

    public void AddCrew(int value)
    {
        m_crew += value;  
    }

    public void AddMoney(int value)
    {
        m_money += value;
    }

    public void SubCrew(int value)
    {
        m_crew -= value; 
    }

    public void SubMoney(int value)
    {
        m_money -= value; 
    }
}
