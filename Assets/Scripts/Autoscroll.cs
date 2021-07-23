using UnityEngine;

public class Autoscroll : MonoBehaviour
{

    public GameObject auto; //for the empty gameobject called "Auto Scroll Point"

    public float xCamSpeed; //how far camera should move next frame (Set this in Unity)
    public float yCamSpeed; //^^^^^^^^^^
    public float xLastPos; //Last known position
    public float yLastPos; //^^^^^^^^^^^^
    public bool isXLimited; //is the x distance limited? set in unity
    public bool isYLimited; // ^^^^^^^^^
    public float xLimitVal; //at what value is it limited at?
    public float yLimitVal; //^^^^^^^^^^^
    public bool goingRight; //are we going in a positive direction or negative?

    // Update is called once per frame
    void FixedUpdate()
    {

        xLastPos = transform.position.x; //records last known x
        yLastPos = transform.position.y; //records last known y

        if(isXLimited == false && isYLimited == false)
        {
            auto.transform.Translate(xCamSpeed, yCamSpeed, 0);
        }

        else if(isXLimited == true && isYLimited == false)
        {
            if(goingRight == true)
            {
                if(xLastPos < xLimitVal)
                {
                    auto.transform.Translate(xCamSpeed, yCamSpeed, 0);
                }

                else if(xLastPos > xLimitVal)
                {
                    auto.transform.Translate(0, 0, 0);
                }
            }
            
            else if(goingRight == false)
            {
                if(xLastPos > xLimitVal)
                {
                    auto.transform.Translate(xCamSpeed, yCamSpeed, 0);
                }

                else if(xLastPos < xLimitVal)
                {
                    auto.transform.Translate(0, 0, 0);
                }
            }
        }

        else if(isXLimited == false && isYLimited == true)
        {
            if(goingRight == true)
            {
                if(yLastPos < yLimitVal)
                {
                    auto.transform.Translate(xCamSpeed, yCamSpeed, 0);
                }

                else if(yLastPos > yLimitVal)
                {
                    auto.transform.Translate(0, 0, 0);
                }
            }

            else if(goingRight == false)
            {
                if(yLastPos > yLimitVal)
                {
                    auto.transform.Translate(xCamSpeed, yCamSpeed, 0);
                }

                else if(yLastPos < yLimitVal)
                {
                    auto.transform.Translate(0, 0, 0);
                }
            }
        }

        //limits on both x and y movement need to be added
        else if(isXLimited == true && isYLimited == true)
        {
            if(goingRight == true)
            {
                
            }
        }
        
    }
}
