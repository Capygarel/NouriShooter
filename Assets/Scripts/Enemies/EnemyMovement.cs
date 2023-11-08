using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 40.0f;

    public enum Move { Forward, Left, Right, Backward , RandomMove}

    public Move basicMove;

    public float timeInterval = 2.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        print(basicMove);
        switch (basicMove)
        {
            case Move.Forward:
                Forward();
                break;

            case Move.Backward:
                Backward();
                break;

            case Move.Left:
                Left();
                break;

            case Move.Right:
                Right();
                break;

            case Move.RandomMove:
                if (timeInterval > 0)
                    timeInterval -= Time.deltaTime;
                else
                {
                    RandomMove();
                    timeInterval = 2.0f;
                }
                Forward();
                break;

        }
    }

    void Forward()
    {
        print("test");
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void Left()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void Right()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void Backward()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    void RandomMove()
    {
        int angleRotation = Random.Range(0, 360);
        transform.Rotate(new Vector3(0, angleRotation, 0));

    }
}
