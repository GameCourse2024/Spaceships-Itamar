using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class ScreenWrap : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    [SerializeField] private float topSideofScreen;
    [SerializeField] private float bottomSideofScreen;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // screen position of object in pixel
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        // right side of screen
        float rightSideofScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        float leftSideofScreen = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).x;
   
        // check if player move to the sides    
        if (screenPos.x <= 0)
        {
            transform.position = new Vector2(rightSideofScreen, transform.position.y);
        }

        else if (screenPos.x >= Screen.width)
        {
            transform.position = new Vector2(leftSideofScreen, transform.position.y);
        }

        // if player tries to go below
        if (transform.position.y <= bottomSideofScreen)
        {
            transform.position = new Vector2(transform.position.x, bottomSideofScreen);
        }

        // if player tries to go up
        if(transform.position.y >= topSideofScreen)
        {
            transform.position = new Vector2(transform.position.x, topSideofScreen);
        } 
    }
}
