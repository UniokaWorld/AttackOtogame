using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suwaipu : MonoBehaviour
{
    private Vector3 touchStartPos;
    private Vector3 touchEndPos;
    string Direction;
    [SerializeField] GameObject gameOBJ;


    private void Start()
    {

    }
    void Flick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            touchStartPos = new Vector3(Input.mousePosition.x,
                                        Input.mousePosition.y,
                                        Input.mousePosition.z);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            touchEndPos = new Vector3(Input.mousePosition.x,
                                      Input.mousePosition.y,
                                      Input.mousePosition.z);
            GetDirection();
        }
    }

    void GetDirection()
    {
        float directionX = touchEndPos.x - touchStartPos.x;
        float directionY = touchEndPos.y - touchStartPos.y;

        if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
        {
            if (30 < directionX)
            {
                //右向きにフリック
                Direction = "right";
            }
            else if (-30 > directionX)
            {
                //左向きにフリック
                Direction = "left";
            }
        }
        gameOBJ.GetComponent<Move>().SuwaipuMove(Direction);
    }
    private void Update()
    {
        Flick();
    }
}
