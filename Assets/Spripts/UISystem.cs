using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UISystem : MonoBehaviour
{
    [SerializeField] Transform T_heart0;
    [SerializeField] Transform T_heart1;
    [SerializeField] GameObject U_heart0;
    [SerializeField] GameObject U_heart1;
    [SerializeField] GameObject U_heart2;
    float shakePower = 1;

    int heart = 2;

    Vector3 moneyTextInitPos;
    Vector3 hoshiiTextInitPos;

    private void Start()
    {
        // 開始時の位置を取得
        moneyTextInitPos = T_heart0.position;
        hoshiiTextInitPos = T_heart1.position;
    }

    public void Damage()
    {
        switch (heart)
        {
            case 0:
                Destroy(U_heart0);
                Time.timeScale = 0;
                break;
            case 1:
                Destroy(U_heart1);
                break;
            case 2:
                Destroy(U_heart2);
                break;

        }
        heart--;
    }
    


    private void Update()
    {
        if(heart == 0)
        {
            T_heart0.position = moneyTextInitPos + Random.insideUnitSphere * 5;
        }else if (heart ==1)
        {
            T_heart0.position = moneyTextInitPos + Random.insideUnitSphere * 1;
            T_heart1.position = hoshiiTextInitPos + Random.insideUnitSphere * 1;
        }
        
        
    }
}
