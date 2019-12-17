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
    Iraq,
    NorthKorea
};

[CreateAssetMenu(fileName = "New Mission", menuName = "Mission")]
public class Mission : ScriptableObject
{
    public string m_mission_name;
    public Spawn m_spawn_location;
    public Targets m_target_location; 
}
