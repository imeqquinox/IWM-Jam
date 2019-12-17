using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Locations
{
    // Class of geo-locations based of 2D grid
    private static Vector2 m_washington = new Vector2(9, 15);
    private static Vector2 m_moscow = new Vector2(18, 16);
    private static Vector2 m_cuba = new Vector2(8, 12);
    private static Vector2 m_berlin = new Vector2(16, 15);
    private static Vector2 m_london = new Vector2(14, 15);
    private static Vector2 m_alaska = new Vector2(3, 18);
    private static Vector2 m_afghanistan = new Vector2(20, 14);
    private static Vector2 m_north_korea = new Vector2(26, 15);

    public static Vector2 GetLocation(string _location_name)
    {
        switch (_location_name)
        {
            case "Washington":
                return m_washington;

            case "Moscow":
                return m_moscow;

            case "Cuba":
                return m_cuba;

            case "Berlin":
                return m_berlin;

            case "London":
                return m_london;

            case "Alaska":
                return m_alaska;

            case "Afghanistan":
                return m_afghanistan;

            case "NorthKorea":
                return m_north_korea;

            default:
                return Vector2.zero; 
        }
    }
}
