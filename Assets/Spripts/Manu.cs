using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manu : MonoBehaviour
{
    [SerializeField]GameObject MainUI;
    [SerializeField] GameObject kyoku;
    [SerializeField] GameObject setumeiUI;
    private AsyncOperation async;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

    }
    public void kyokuwoerabu()
    {
        MainUI.SetActive(false);
        kyoku.SetActive(true);

    }
    public void home()
    {
        kyoku.SetActive(false);
        MainUI.SetActive(true);
    }
    public void setumei()
    {
        MainUI.SetActive(false);
        setumeiUI.SetActive(true);
    }
    public void homeS()
    {
        setumeiUI.SetActive(false);
        MainUI.SetActive(true);
    }
    public void Unity()
    {
        StartCoroutine(Game());
    }

    IEnumerator Game()
    {

        var async = SceneManager.LoadSceneAsync("GameScene");

        async.allowSceneActivation = false;
        yield return new WaitForSeconds(1);
        async.allowSceneActivation = true;
    }
}
