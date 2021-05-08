using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public bool gameView;

    public Transform worldView;
    

    void Start()
    {
        gameView = true;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            gameView = false;
        }

        if(Input.GetKeyUp(KeyCode.M))
        {
            gameView = true;
        }
    }
    
    void FixedUpdate(){

        if(gameView)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
            transform.rotation = target.rotation;
            transform.LookAt(target);
            
        }
        else
        {
            transform.position = worldView.position;
            transform.rotation = worldView.rotation;
        }
        
    }
    

}
