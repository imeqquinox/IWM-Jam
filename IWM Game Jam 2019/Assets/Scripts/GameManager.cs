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

    private void Start()
    {
        
    }

    public void NextTurn()
    {
        m_turn_number++;

        PlaneManager.Instance.UpdatePlaneMovement(); 
    }

    public int GetCurrentTurn()
    {
        return m_turn_number; 
    }
}
