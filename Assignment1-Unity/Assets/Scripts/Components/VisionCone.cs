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
    /// 

    public bool IsPlayerInVisionCone()
    {
        Transform player = GameController.GetPlayerObject().transform;
        Transform enemy = GameController.GetEnemyObject().transform;

        //creating a float that will hold the value of the arc facing forward relative to the enemy
        float enemyForwardAngle = Mathf.Atan2(enemy.up.y,enemy.up.x) * Mathf.Rad2Deg + 180;

        //We must convert this to Degrees because our AngleSweepInDegrees is, well, in Degrees 
        float fullVisionCone = Mathf.Atan2(enemy.up.y * enemy.position.x - enemy.up.x* enemy.position.y, enemy.up.x * enemy.position.x + enemy.up.y * enemy.position.y)*Mathf.Rad2Deg;


        if (ViewDistance >= GetDistanceToEnemy()) 
        {
            Debug.Log(Mathf.Abs(fullVisionCone));
            if(Mathf.Abs(fullVisionCone) <= AngleSweepInDegrees/2)
                return true;
        }
        return false;

    }


    //lifting this from the VectorToEnemy script as a helper method
    private float GetDistanceToEnemy()
    {
        //reference to relevant objects
        GameObject enemyPosition = GameController.GetEnemyObject();
        GameObject playerPosition = GameController.GetPlayerObject();

        //math to convert my Vector3 into a series of floats and calculate the distance between them
        float xSquared = Mathf.Pow((playerPosition.transform.position.x - enemyPosition.transform.position.x), 2);
        float ySquared = Mathf.Pow((playerPosition.transform.position.y - enemyPosition.transform.position.y), 2);
        float zSquared = Mathf.Pow((playerPosition.transform.position.z - enemyPosition.transform.position.z), 2);

        //Pythagorean theorem for the final distance
        float distance = Mathf.Sqrt(xSquared + ySquared + zSquared);

        //Debug.Log(distance);
        return distance;
    }
}
