using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectController : MonoBehaviour {

    public GameObject menu;

    Text title;
    Text cost;

    string[] titleList = {"Burger Joint", "Hot Dog Stand", "Taco Fiesta", "Ice Cream Stand", "Sushi Grill", "Diner", "Indian Restaurant", "Fancy Restaurant"};
    int[] costList = { 100, 100, 200, 200, 400, 400, 500, 500};

    void Start()
    {
        Text[] texts = menu.GetComponentsInChildren<Text>();

        for (int i = 0; i < texts.Length; i++)
        {
            if (texts[i].name == "Title")
            {
                title = texts[i];
            }
            else if (texts[i].name == "Cost")
            {
                cost = texts[i];
            }
        }

        menu.SetActive(false);
    }

    public void openMenu (int pos)
    {
        menu.SetActive(true);
        title.text = titleList[pos];
        cost.text = "$" + costList[pos].ToString();
    }

    public void closeMenu ()
    {
        menu.SetActive(false);
    }

    public void playGame ()
    {
        SceneManager.LoadScene("BurgerLevel1");
    }
}
