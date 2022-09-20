using UnityEngine;
using System.Collections;

public class VectorToEnemy : MonoBehaviour
{

    /// <summary>
    /// Calculated vector from the player to enemy found by GameManager.GetEnemyObject
    /// </summary>
    /// <see cref="GameController.GetEnemyObject"/>
    /// <returns>The vector from the player to the enemy.</returns>
    /// 


    public Vector3 GetVectorToEnemy()
    {
        //reference to the Enemy and Player Objects
        GameObject enemyPosition = GameController.GetEnemyObject();
        GameObject playerPosition = GameController.GetPlayerObject();

        //calculates the Vector between the player and enemy, using player as the origin
        Vector3 vectorToEnemy = enemyPosition.transform.position - playerPosition.transform.position;
        //Debug.Log(vectorToEnemy);

        return vectorToEnemy;
    }

    /// <summary>
    /// Calculates the distance from the player to the enemy returned by GameManager.GetEnemyObject without using calls to magnitude.
    /// </summary>
    /// <see cref="GameController.GetEnemyObject"/>
    /// <returns>The scalar distance between the player and the enemy</returns>
    public float GetDistanceToEnemy()
    {
        //reference to relevant objects
        GameObject enemyPosition = GameController.GetEnemyObject();
        GameObject playerPosition = GameController.GetPlayerObject();

        //math for the positio
        float xSquared = Mathf.Pow(playerPosition.transform.position.x,2);
        float ySquared = Mathf.Pow(playerPosition.transform.position.y, 2);
        float zSquared = Mathf.Pow(playerPosition.transform.position.z, 2);

        float distance = Mathf.Sqrt(xSquared + ySquared + zSquared);

        Debug.Log(distance);
        return distance;
    }
    
}
