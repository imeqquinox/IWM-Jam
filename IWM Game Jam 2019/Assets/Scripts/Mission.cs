using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Spawn
{
    Washington
};

public enum Targets
{
    Moscow,
    Cuba,
    Berlin,
    London,
    Alaska,
    Afghanistan,
    NorthKorea
};

[CreateAssetMenu(fileName = "New Mission", menuName = "Mission")]
public class Mission : ScriptableObject
{
    public string m_mission_name;
    [TextArea]
    public string m_description; 
    public Spawn m_spawn_location;
    public Targets m_target_location;
    public float m_threat_level;
    public int m_crew;
    public int m_reward; 
}
