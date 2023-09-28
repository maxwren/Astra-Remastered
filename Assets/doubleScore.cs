using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleScore : MonoBehaviour
{
    [SerializeField] GameObject gameObj;
    Vector2 scoreScale0;
    Vector2 scoreScale2;

    float scaleX = 0f;
    float scaleY = 0f;

    Vector2 sizingScale;
    void Start()
    {
        scoreScale0 = new Vector3(0, 0, 0);
        scoreScale2 = new Vector3(2, 2, 0);
        gameObj.transform.localScale = scoreScale0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Boost.shouldWeDisplayDoubleScore)
        {
            if (gameObj.transform.localScale.x < scoreScale2.x)
            {
                scaleX += 0.01f;
                scaleY += 0.01f;
                sizingScale = new Vector2(scaleX, scaleY);
                gameObj.transform.localScale = sizingScale;
            }
        }
        if (!Boost.shouldWeDisplayDoubleScore)
        {
            if (gameObj.transform.localScale.x > scoreScale0.x)
            {
                scaleX -= 0.01f;
                scaleY -= 0.01f;
                sizingScale = new Vector2(scaleX, scaleY);
                gameObj.transform.localScale = sizingScale;
            }
            gameObj.transform.localScale = scoreScale0;
            //IT WORKS
        }
    }
}
