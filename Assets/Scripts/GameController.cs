using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Text healthText;

    public int maxHealth;

    public Image winPanel;
    public Image losePanel;
    public Image pausePanel;
    public Image hotkeyPanel;

    public string nextLevelName;

    public List<CustomerOrderController> customerList { get; set; }

    int health;
    int totalCustomers = 0;
    int customersServed = 0;

    void Start()
    {
        health = maxHealth;
        customerList = new List<CustomerOrderController>();

        winPanel.gameObject.SetActive(false);
        losePanel.gameObject.SetActive(false);
        pausePanel.gameObject.SetActive(false);
        hotkeyPanel.gameObject.SetActive(false);

        CustomerSpawnPoint[] spawnPoints = FindObjectsOfType<CustomerSpawnPoint>();
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            totalCustomers += spawnPoints[i].customerOrders.Count;
        }
    }

    void Update()
    {
        healthText.text = "Health: " + health;

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            pauseGame();
        }
    }

    void OnEnable()
    {
        EventManager.StartListening("CustomerLeft", decreaseHealth);
    }

    void OnDisable()
    {
        EventManager.StopListening("CustomerLeft", decreaseHealth);
    }

    void decreaseHealth() 
    {
        health--;
        if (health <= 0) 
        {
            loseGame();
        }
    }

    public void sendBurger(Stack<string> toppings) 
    {
        List<string> toppingArray = new List<string>(toppings.ToArray());
        toppingArray.Reverse();

        for (int i = 0; i < customerList.Count; i++) 
        {
            List<string> orderToppings = customerList[i].currentOrder.ingredients;
            if (toppingsMatch(toppingArray, orderToppings)) 
            {
                CustomerOrderController customerToDestroy = customerList[i];
                customerList.Remove(customerToDestroy);
                Destroy(customerToDestroy.gameObject);
                customersServed++;
                if (customersServed >= totalCustomers)
                {
                    winGame();
                }
                break;
            }
        }
    }

    public void nextLevel()
    {
        if(nextLevelName != "None")
        {
            SceneManager.LoadScene(nextLevelName);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void restart()
    {
        CustomerSpawnPoint[] spawnPoints = FindObjectsOfType<CustomerSpawnPoint>();
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPoints[i].restart();
        }
        health = maxHealth;
        resume();
        losePanel.gameObject.SetActive(false);

        customerList = new List<CustomerOrderController>();

        CustomerMover[] customersToDelete = FindObjectsOfType<CustomerMover>();
        for (int i = 0; i < customersToDelete.Length; i++) 
        {
            Destroy(customersToDelete[i].gameObject);
        }
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void pauseGame()
    {
        pausePanel.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void resume()
    {
        pausePanel.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void openHotKeyPanel()
    {
        hotkeyPanel.gameObject.SetActive(true);
    }

    public void closeHotKeyPanel()
    {
        hotkeyPanel.gameObject.SetActive(false);
    }

    void winGame() 
    {
        winPanel.gameObject.SetActive(true);
    }

    void loseGame() 
    {
        losePanel.gameObject.SetActive(true);
    }

    bool toppingsMatch(List<string> order, List<string> burger) 
    {
        if(order.Count != burger.Count) 
        {
            return false;
        }

        for (int i = 0; i < order.Count; i++) 
        {
            if (order[i] != burger[i]) 
            {
                return false;
            }
        }
        return true;
    }

    string toString(string[] array) 
    {
        string ret = "";

        for (int i = 0; i < array.Length; i++) 
        {
            ret += array[i] + ", ";
        }

        return ret;
    }
}
