using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plane", menuName = "Plane Stats")]
public class PlaneStats : ScriptableObject
{
    // In game stats 
    public string m_name; 
    public int m_movement;
    public int m_cost;
    public int m_crew_cost;

    // Factual stats 
    public float m_length;
    public float m_wingspan;
    public string m_enginetype;
    public float m_max_speed;
    public float m_service_ceiling;
    [TextArea]
    public string m_description; 
}
