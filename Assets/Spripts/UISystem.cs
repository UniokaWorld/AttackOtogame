using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UISystem : MonoBehaviour
{
    [SerializeField] Transform T_heart0;
    [SerializeField] Transform T_heart1;
    [SerializeField] GameObject U_heart0;
    [SerializeField] GameObject U_heart1;
    [SerializeField] GameObject U_heart2;
    float shakePower = 1;

    int heart = 2;
    int hearthyozi = 0;
    int drink = 0;

    Vector3 moneyTextInitPos;
    Vector3 hoshiiTextInitPos;
    [SerializeField] GameObject GameManager;

    [SerializeField] GameObject move;

    [SerializeField] GameObject GameUI;
    [SerializeField] GameObject OverUI;
    [SerializeField] GameObject CriaUI;

    [SerializeField] GameObject Drink;
    [SerializeField] GameObject Life;
    [SerializeField] GameObject Rank;
    Text drinkT;
    Text LifeT;
    Text RankT;
    private AudioSource sound01;


    private void Start()
    {
        // 開始時の位置を取得
        moneyTextInitPos = T_heart0.position;
        hoshiiTextInitPos = T_heart1.position;
        this.drinkT = Drink.GetComponent<Text>();
        this.LifeT = Life.GetComponent<Text>();
        this.RankT = Rank.GetComponent<Text>();
        sound01 = GetComponent<AudioSource>();
    }

    public void Damage()
    {
        switch (heart)
        {
            case 0:
                Destroy(U_heart0);
                move.GetComponent<Move>().NowBool();
                GameManager.GetComponent<GameManager>().OUT();
                Owata(0);
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
    public void DrinkKazu()
    {
        drink++;
    }

    public void Owata(int a)
    {
        if (a == 0)
        {
            GameUI.SetActive(false);
            OverUI.SetActive(true);
        }
        else
        {
            GameUI.SetActive(false);
            CriaUI.SetActive(true);
            hearthyozi = heart + 1;
            RANK(hearthyozi, drink);
            this.LifeT.text = hearthyozi.ToString();
            this.drinkT.text = drink.ToString();
            sound01.PlayOneShot(sound01.clip);
        }
    }
    public void GameBTN()
    {
        StartCoroutine(Game());
    }

    public void MenuBTN()
    {
        StartCoroutine(Menu());
    }

    IEnumerator Game()
    {

        var async = SceneManager.LoadSceneAsync("GameScene");

        async.allowSceneActivation = false;
        yield return new WaitForSeconds(1);
        async.allowSceneActivation = true;
    }

    IEnumerator Menu()
    {

        var async = SceneManager.LoadSceneAsync("Menu");

        async.allowSceneActivation = false;
        yield return new WaitForSeconds(1);
        async.allowSceneActivation = true;
    }

    void RANK(int a,int b)
    {
        int goke = (a * 10) + (b * 5);
        if (goke == 65)
        {
            this.RankT.text = "S";
        }else if(goke >= 55)
        {
            this.RankT.text = "A";
        }else if(goke >= 45)
        {
            this.RankT.text = "B";
        }
        else if(goke >= 35)
        {
            this.RankT.text = "C";
        }else if(goke >= 25)
        {
            this.RankT.text = "D";
        }
        else
        {
            this.RankT.text = "E";
        }
    }

}
