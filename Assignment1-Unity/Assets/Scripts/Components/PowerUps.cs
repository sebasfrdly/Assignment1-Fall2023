using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour
{
    public GameObject PowerUpPrefab;
    public int PowerUpCount = 3;
    public float PowerUpRadius = 1;

    /// <summary>
    /// Spawn a circle of PowerUpCount power up prefabs stored in PowerUpPrefab, evenly spaced, around the player with a radius of PowerUpRadius
    /// </summary>
    /// I need to divide the circumference of my circle by 3 in order to find 3 equal points on it
    /// <returns>An array of the spawned power ups, in counter clockwise order.</returns>
    public GameObject[] SpawnPowerUps()
    {
        //making it easier for myself by just grabbing the position from now on
        Vector3 player = GameController.GetPlayerObject().transform.position;
        var powerSpawn = new GameObject[PowerUpCount];

        //for loop to instantiate powerUps and determine their positions
        for(int i = 0; i < PowerUpCount;i++)
        {
            powerSpawn[i] = Instantiate<GameObject>(PowerUpPrefab);
            //calculating the positions of the powerup objects. Dividing circle into 3 points and finding them using the point on circle formula. Multiplying it by PowerUpRadius so it spawns x units around the player.
            powerSpawn[i].transform.position = player + new Vector3((Mathf.Cos((i*Mathf.PI*2)/PowerUpCount)*PowerUpRadius), (Mathf.Sin((i*Mathf.PI*2)/PowerUpCount))*PowerUpRadius);
        }

        return powerSpawn;
    }
}
