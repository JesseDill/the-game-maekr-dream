using UnityEngine;

public class InvisibleSprite : MonoBehaviour
{

    SpriteRenderer sr;
    
    public bool gradual;
    public bool checkVisible;
    public float alphaRateUp; //rate at which alpha goes up SET IN UNITY
    public float alphaRateDown; //rate at which alpha goes down SET IN UNITY
    public float waitTime;

    float alpha;
    bool increasing;
    bool onVisible;


    // Start is called before the first frame update
    void Start()
    {
        alpha = 1f;
        increasing = false;
        sr = GetComponent<SpriteRenderer>();
        waitTime = waitTime * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkVisible == true)
        {
            onVisible = sr.isVisible;
        }

        if (gradual == true)
        {
            if (onVisible == false)
            {
                gradualTrans();                
            }

            if (onVisible == true)
            {
                Invoke("gradualTrans", waitTime);
            }
        }

        if(gradual == false)
        {
            if (onVisible == false)
            {
                if (alpha == 1f)
                {
                    Invoke("EditTrans", waitTime);
                }

                else if (alpha == 0f)
                {
                    EditTrans();
                }

                if (alpha == 1f)
                {
                    alpha = 0f;
                }

                else if (alpha == 0f)
                {
                    alpha = 1f;
                }
            }

            if(onVisible == true)
            {

            }

        }
    }

    void EditTrans()
    {

        sr.color = new Color(1, 1, 1, alpha);

    }

    void gradualTrans()
    {
        if (alpha > 1f)
        {
            increasing = false;
        }

        else if (alpha < 0f)
        {
            increasing = true;
        }

        if (increasing == false) //decreasing alpha
        {
            alpha -= alphaRateDown;
            sr.color = new Color(1, 1, 1, alpha);
        }

        else if (increasing == true) //increasing alpha
        {
            alpha += alphaRateUp;
            sr.color = new Color(1, 1, 1, alpha);
        }
    }
}
