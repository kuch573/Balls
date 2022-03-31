using System;
using System.Collections;
using System.Collections.Generic;
using Balls;
using UnityEngine;
using Object = System.Object;
using Random = UnityEngine.Random;

public class BallManager : MonoBehaviour
{
    public List<GameObject> YellowBalls = new List<GameObject>();
    public List<Vector3> YellowBallsPosition = new List<Vector3>();
    public List<GameObject> DarkRedBalls = new List<GameObject>();
    
    private void Start()
    {
        BallChoose();
    }

    private IEnumerator CreateBall()
    {
        yield return new WaitForSeconds(5);
        BallChoose();
    }

    private void BallChoose()
    {
        int BallType = Random.Range(3, 3);
        if (BallType == 1)
        {
            CreateRedBall();
        }else if (BallType == 2)
        {
            CreateGrayBall();
        }else if (BallType == 3)
        {
            CreateBlueBall();
        }else if (BallType == 4)
        {
            CreateDarkRedBall();
        }

        StartCoroutine(CreateBall());
    }

    private void CreateGrayBall()
    {
        Instantiate(Resources.Load("Gray",typeof(GameObject)));
    }

    private void CreateBlueBall()
    {
        Instantiate(Resources.Load("Blue",typeof(GameObject)));
    }

    private void CreateDarkRedBall()
    {
        for (int i = 0; i < Random.Range(3, 5); i++)
        {
            GameObject ball =Instantiate(Resources.Load("DarkRed",typeof(GameObject))) as GameObject;
            DarkRedBalls.Add(ball);
        }
    }

    private void CreateRedBall()
    {
        Instantiate(Resources.Load("Red",typeof(GameObject)));
    }

    public void CreateYellowBall(Vector3 position, BlueBall blueBall)
    {
        GameObject yellowBall =Instantiate(Resources.Load("Yellow",typeof(GameObject)),position,Quaternion.identity) as GameObject;
        yellowBall.GetComponent<Yellow>().Constract(blueBall);
        YellowBalls.Add(yellowBall);
        YellowBallsPosition.Add(yellowBall.transform.position);
    }
}