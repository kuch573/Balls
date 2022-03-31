using System;
using System.Collections.Generic;
using Balls;
using UnityEngine;

public class ObjectAction : MonoBehaviour
{
    public BallTypeId BallTypeId;

    private SpriteRenderer _sprite;

    
    
    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    public void Action()
    {
        if (BallTypeId == BallTypeId.RedBall)
        {
            GetComponent<RedBall>().OnTouch();
        }

        if (BallTypeId == BallTypeId.GrayBall)
        {
            GetComponent<GrayBall>().OnTouch();
        }

        if (BallTypeId == BallTypeId.DarkRedBall)
        {
            GetComponent<DarkRedBall>().OnTouch();
        }

        if (BallTypeId == BallTypeId.BlueBall)
        {
            GetComponent<BlueBall>().OnTouch();
        }
    }
}