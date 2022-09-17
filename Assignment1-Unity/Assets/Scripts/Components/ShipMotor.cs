using UnityEngine;
using System.Collections;

public class ShipMotor : MonoBehaviour
{
    public float AccelerationTime = 1;
    public float DecelerationTime = 1;
    public float MaxSpeed = 1;

    /// <summary>
    /// Move the ship using it's transform only based on the current input vector. Do not use rigid bodies.
    /// </summary>
    /// <param name="input">The input from the player. The possible range of values for x and y are from -1 to 1.</param>
    public void HandleMovementInput( Vector2 input )
    {

    }
    
}
