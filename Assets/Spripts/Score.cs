using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] GameObject Text;
    [SerializeField] GameObject gameobject;
    Text targetText;
    int dori = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.targetText = Text.GetComponent<Text>();
        this.targetText.text = "x"+dori.ToString() + "/7";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Note")
        {
            Destroy(other.gameObject);
            gameobject.GetComponent<UISystem>().Damage();
        }

        if (other.gameObject.tag == "Dori")
        {
            dori++;
            Destroy(other.gameObject);
            this.targetText.text ="x"+ dori.ToString()+"/7";
            gameobject.GetComponent<UISystem>().DrinkKazu();
        }
    }
}
