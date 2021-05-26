using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    [SerializeField] private float minDistanceSwipe;
    [SerializeField] private float maxSwipeTime;
    [SerializeField] private GameController gameController;

    private float swipeStartTime;
    private float swipeEndTime;
    private float swipeTime;
    private float swipeDistance;

    private Vector2 swipeStartPosition;
    private Vector2 swipeEndPosition;

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                swipeStartTime = Time.time;
                swipeStartPosition = touch.position;
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                swipeEndTime = Time.time;
                swipeEndPosition = touch.position;
                swipeTime = swipeEndTime - swipeStartTime;
                swipeDistance = Mathf.Abs((swipeEndPosition - swipeStartPosition).magnitude);
                if(swipeTime < maxSwipeTime && swipeDistance > minDistanceSwipe)
                {
                    float x = swipeEndPosition.x - swipeStartPosition.x;
                    float y = swipeEndPosition.y - swipeStartPosition.y;
                    if (Mathf.Abs(x) > Mathf.Abs(y))
                    {
                        if (x > 0) gameController.MoveRight();
                        else gameController.MoveLeft();
                    } else
                    {
                        if (y > 0) gameController.MoveUp();
                        else gameController.MoveDown();
                    }
                }
            }
        }
    }
}
