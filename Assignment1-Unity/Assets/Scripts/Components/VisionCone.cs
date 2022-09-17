using UnityEngine;
using System.Collections;

public class VisionCone : MonoBehaviour
{

    public float AngleSweepInDegrees = 60;
    public float ViewDistance = 3;

    /// <summary>
    /// Calculates whether the player is inside the vision cone of an enemy as defined by the AngleSweepIndegrees
    /// and ViewDistance varilables. Do not use any magnitude or Distance methods.  You may use any of the previous
    /// methods you have written.
    /// </summary>
    /// <see cref="GameController"/>
    /// <returns>Whether the player is within the enemy's vision cone.</returns>
    public bool IsPlayerInVisionCone()
    {
        return false;
    }
    
}
