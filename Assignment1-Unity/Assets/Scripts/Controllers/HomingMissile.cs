using UnityEngine;
using System.Collections;

public class HomingMissile : MonoBehaviour
{
    public float ForwardSpeed = 1;
    public float RotateSpeedInDeg = 45;

    private Vector3 targetRotation;
    private Vector3 targetMovement;
    Vector3 enemyPosition;

    private void Awake()
    {
        targetMovement = new Vector3(0, ForwardSpeed,0);
        targetRotation = new Vector3(0, 0, RotateSpeedInDeg);
    }
    // In Update, you should rotate and move the missile to rotate it towards the player.  It should move forward with ForwardSpeed and rotate at RotateSpeedInDeg.
    void Update()
    {
        enemyPosition = GameController.GetEnemyObject().transform.position;

        FindRotationAngle();

        if(GetDistanceToEnemy() >= 0.01)
        {
            transform.Translate(targetMovement*Time.deltaTime);
        }

    }
    private float GetDistanceToEnemy()
    {
        //reference to relevant objects
        GameObject enemyPosition = GameController.GetEnemyObject();

        //math to convert my Vector3 into a series of floats and calculate the distance between them
        float xSquared = Mathf.Pow((transform.position.x - enemyPosition.transform.position.x), 2);
        float ySquared = Mathf.Pow((transform.position.y - enemyPosition.transform.position.y), 2);
        float zSquared = Mathf.Pow((transform.position.z - enemyPosition.transform.position.z), 2);

        //Pythagorean theorem for the final distance
        float distance = Mathf.Sqrt(xSquared + ySquared + zSquared);

        //Debug.Log(distance);
        return distance;
    }

    //this changes the missile angle so that we can rotate to the enemy
    public void FindRotationAngle()
    {
        var enemyDirection = enemyPosition - transform.position;

        float missileCone = Mathf.Atan2(transform.up.y * enemyDirection.x - transform.up.x * enemyDirection.y, transform.up.y * enemyDirection.x + transform.up.x * enemyDirection.y)*Mathf.Rad2Deg;
        if(missileCone >=1)
        {
            transform.Rotate(-targetRotation*Time.deltaTime);
        }
        else if (missileCone <= 1)
        {
            transform.Rotate(targetRotation * Time.deltaTime);
        }

    }
}
