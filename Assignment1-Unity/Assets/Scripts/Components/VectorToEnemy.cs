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

        //math to convert my Vector3 into a series of floats and calculate the distance between them
        float xSquared = Mathf.Pow((playerPosition.transform.position.x - enemyPosition.transform.position.x),2);
        float ySquared = Mathf.Pow((playerPosition.transform.position.y - enemyPosition.transform.position.y), 2);
        float zSquared = Mathf.Pow((playerPosition.transform.position.z - enemyPosition.transform.position.z), 2);

        //Pythagorean theorem for the final distance
        float distance = Mathf.Sqrt(xSquared + ySquared + zSquared);

        Debug.Log(distance);
        return distance;
    }
    
}
