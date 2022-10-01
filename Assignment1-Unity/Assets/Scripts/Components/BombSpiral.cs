using UnityEngine;
using System.Collections;

public class BombSpiral : MonoBehaviour
{
    public GameObject BombPrefab;
    [Range(5, 25)]
    public float SpiralAngleInDegrees = 10;
    public int BombCount = 10;
    public float StartRadius = 1;
    public float EndRadius = 3;

    /// <summary>
    /// Spawns spirals of BombPrefab game objects around the player. Create BombCount number of bombs 
    /// around the player, with each bomb being spaced SpiralAngleInDegrees apart from the next. The spiral 
    /// starts at StartRadius away from the player and ends at EndRadius away from the player.
    /// </summary>
    /// <returns>An array of the spawned bombs</returns>
    public GameObject[] SpawnBombSpiral()
    {
        //getting reference tot he player's position and creating a new array
        var player = GameController.GetPlayerObject().transform.position;
        var bombSpiral = new GameObject[BombCount];

        float spiralAngleInRadians = BombSpiralInRadians();

        //using a float in this for loop in order to keep my math accurate
        for(int i = 0; i < BombCount; i++)
        {
            //instantiate the bombs
            bombSpiral[i] = Instantiate<GameObject>(BombPrefab);
            /*same Formula as PowerupSpawn (point on a circle) this time we will use a Mathf.Lerp so that we don't go through the entire radius
             * We need to convert i from an int into a float so that the Lerp does not return an integer, and so that the Vectors return properly
             */
            bombSpiral[i].transform.position = player + new Vector3(Mathf.Cos(((float)i * spiralAngleInRadians)*Mathf.Lerp(StartRadius, EndRadius, i /BombCount)), Mathf.Sin((float)i * spiralAngleInRadians) * Mathf.Lerp(StartRadius, EndRadius, i / BombCount));
        }
        var bombDistance = Vector3.Distance(player, bombSpiral[9].transform.position);

        Debug.Log(bombDistance);

        return bombSpiral;
    }

    //just creating this helper method to modulate some code. For Maximum accuracy we need the angle in Radians
    float BombSpiralInRadians()
    {
        float SpiralAngleInRadians = SpiralAngleInDegrees * Mathf.Deg2Rad;

        return SpiralAngleInRadians;
    }
    
}
