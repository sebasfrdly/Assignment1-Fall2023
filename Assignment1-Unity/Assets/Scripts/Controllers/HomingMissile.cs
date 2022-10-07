using UnityEngine;
using System.Collections;

public class HomingMissile : MonoBehaviour
{
    public float ForwardSpeed = 1;
    public float RotateSpeedInDeg = 45;

    //using Quaternions because Euler angles are not allowed
    //private Quaternion targetRotation;
    private float targetRotation;
    // In Update, you should rotate and move the missile to rotate it towards the player.  It should move forward with ForwardSpeed and rotate at RotateSpeedInDeg.
    // Do not use the RotateTowards or LookAt methods.
    void Update()
    {
        Vector3 enemyPosition = GameController.GetEnemyObject().transform.position;
        
        //shows the direction that the missile needs to travel.
        var direction = transform.position - enemyPosition;


        //moves the missile to the targeted position
        transform.position -= (direction*ForwardSpeed*Time.deltaTime);

        //transform.Rotate(new Vector3(0,direction.y*RotateSpeedInDeg*Time.deltaTime,0));

    }
}
