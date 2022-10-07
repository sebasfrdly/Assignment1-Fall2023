using UnityEngine;
using System.Collections;

public class ShipMotor : MonoBehaviour
{
    public float AccelerationTime = 1;
    public float DecelerationTime = 1;
    public float MaxSpeed = 1;

    public Vector2 updatedPlayerPosition = new Vector2();

    /// <summary>
    /// Move the ship using it's transform only based on the current input vector. Do not use rigid bodies.
    /// </summary>
    /// <param name="input">The input from the player. The possible range of values for x and y are from -1 to 1.</param>
    public void HandleMovementInput( Vector2 input )
    {
        //reference to player and camera (remember that camera helps with movement)
        GameObject player = GameController.GetPlayerObject();
        Camera camera = GameController.GetCamera();

        //get reference to the Camera's direction and convert the input to that

        //make sure that input actually is being pressed Vector 
        if(input == Vector2.zero)
        {
            // Input being 0 means that there is nothing more to be added and we need to stop
            updatedPlayerPosition = Vector2.Lerp(updatedPlayerPosition, camera.transform.TransformDirection(input), DecelerationTime *Time.deltaTime);
;       }
        else
        {
            //we use TransformDirection in order to make sure the inputs are consistent
            updatedPlayerPosition = Vector2.Lerp(updatedPlayerPosition, camera.transform.TransformDirection(input), AccelerationTime * Time.deltaTime);
        }
        //makes the player's position the new lerped position
        player.transform.position += (Vector3)updatedPlayerPosition * MaxSpeed * Time.deltaTime; 
        
    }
    
}
