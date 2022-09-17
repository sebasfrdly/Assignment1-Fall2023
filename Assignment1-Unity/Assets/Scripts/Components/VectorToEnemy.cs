using UnityEngine;
using System.Collections;

public class VectorToEnemy : MonoBehaviour
{

    /// <summary>
    /// Calculated vector from the player to enemy found by GameManager.GetEnemyObject
    /// </summary>
    /// <see cref="GameController.GetEnemyObject"/>
    /// <returns>The vector from the player to the enemy.</returns>
    public Vector3 GetVectorToEnemy()
    {
        return Vector3.zero;
    }

    /// <summary>
    /// Calculates the distance from the player to the enemy returned by GameManager.GetEnemyObject without using calls to magnitude.
    /// </summary>
    /// <see cref="GameController.GetEnemyObject"/>
    /// <returns>The scalar distance between the player and the enemy</returns>
    public float GetDistanceToEnemy()
    {
        return 0;
    }
    
}
