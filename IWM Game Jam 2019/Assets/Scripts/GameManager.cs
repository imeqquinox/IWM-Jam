using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int m_turn_number = 1;

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

    public void NextTurn()
    {
        m_turn_number++;

        PlaneManager.Instance.UpdatePlaneMovement();
        
        if (m_turn_number % 3 == 0)
        {
            MissionManager.Instance.ActiviateMission(); 
        }
    }

    public int GetCurrentTurn()
    {
        return m_turn_number; 
    }
}
