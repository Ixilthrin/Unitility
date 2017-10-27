using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{

    float boundaryDistance = 8.0f;
    float speed = 5f;
    float previousTime = 0;
    state myState = state.happy;
    Vector3 direction = new Vector3(1.0f, 0, 0);

    enum state
    {
        scared,
        happy
    }

    // Use this for initialization
    void Start()
    {
        previousTime = Time.realtimeSinceStartup;
    }
	
    // Update is called once per frame
    void Update()
    {
        var currentTime = Time.realtimeSinceStartup;
        var deltaTime = currentTime - previousTime;
        previousTime = currentTime;

        var currentDistanceFromCenter = Mathf.Sqrt(transform.position.x * transform.position.x + transform.position.z * transform.position.z);

        if (currentDistanceFromCenter > boundaryDistance) 
        {
            direction = new Vector3(-transform.position.x, 0, -transform.position.z);
            direction.Normalize();
            myState = state.scared;
        } else if (myState == state.happy && Random.value < .03) 
        {
            var changeX = Random.value;
            var changeZ = Random.value;
            if (Random.value > .5)
                changeX = -changeX;
            if (Random.value > .5)
                changeZ = -changeZ;
            direction = new Vector3(changeX, 0, changeZ);
            direction.Normalize();

        } else if (myState == state.scared && currentDistanceFromCenter < .5f) 
        {
            var changeX = Random.value;
            var changeZ = Random.value;
            if (Random.value > .5)
                changeX = -changeX;
            if (Random.value > .5)
                changeZ = -changeZ;
            direction = new Vector3(changeX, 0, changeZ);
            Debug.Log(changeZ);
            direction.Normalize();
            myState = state.happy;
        }

        if (myState == state.happy)
            speed = 2f;
        else
            speed = 10f;
        
        transform.Translate(direction.x * speed * deltaTime, 0, direction.z * speed * deltaTime);
    }
}
