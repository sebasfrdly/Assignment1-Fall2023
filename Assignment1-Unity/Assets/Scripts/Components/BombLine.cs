using UnityEngine;
using System.Collections;

public class BombLine : MonoBehaviour
{

    public GameObject BombPrefab;
    public int BombCount;
    public float BombSpacing;

    /// <summary>
    /// Spawn a line of instantiated BombPrefabs behind the player ship. There should be BombCount bombs placed with BombSpacing amount of space between them.
    /// </summary>
    /// <returns>An array containing all the bomb objects</returns>
    public GameObject[] SpawnBombs()
    {
        GameObject player = GameController.GetPlayerObject();
        //creating the array that I need to return
        var bombLine = new GameObject[BombCount];

        //instantiates the bombs and sets the positions. 
        for(int i = 0; i < BombCount; i++)
        {
            bombLine[i] = Instantiate<GameObject>(BombPrefab);
            bombLine[i].transform.position = player.transform.position - (player.transform.up* BombSpacing) * (i+1);   
        }

        return bombLine;
    }
    
}
