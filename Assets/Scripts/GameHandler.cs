using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance = null;

    public GameObject pnjRight;
    public float clock;
    public GameObject player;
    public GameObject skillMenu;

    private Canvas upgradeCanvas;
    private Canvas shopCanvas;
    private Text goldText;
    private Text timeText;
    private int gold;
    private int mins = 0;
    private int hours = 0;

    public static GameHandler Instance { get { return instance; } }

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(gameObject);

        
       }

    private void Start()
    {
        upgradeCanvas = GetComponent<Canvas>();
        shopCanvas = GetComponent<Canvas>();
        gold = PlayerPrefs.GetInt("Gold");
        goldText = GameObject.Find("GoldText").GetComponent<Text>();
        timeText = GameObject.Find("TimeText").GetComponent<Text>();
        goldText.text = "Gold: " + gold;
        clock = 4f;
        updateTime();
    }

    // Update is called once per frame
    void Update()
    {
        //Spawn un pnj a droite
        if (Input.GetKeyDown("space"))
        {
            Instantiate(pnjRight, new Vector3(3.2f, -0.5f, 0), Quaternion.identity); //Spawn un PNJ
            player.GetComponent<Player>().LooseHealth(10f); //Test de la vie
        }
        handleClock();
    }



    private void handleClick()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Player")
                    skillMenu.GetComponent<BuyUpgrades>().openMenu();
                
            }
        }
    }

    private void handleClock()
    {
        clock -= Time.deltaTime;
        if (clock <= 0)
        {
            mins += 10;
            if (mins >= 60)
            {
                hours += 1;
                if (hours >= 24)
                    hours = 0;
                mins = 0;
            }
            updateTime();
            clock = 2f;
        }
    }

    private void updateTime()
    {
        //Met à jour l'affichage de l'heure
        if (mins < 10 && hours < 10)
            timeText.text = "0" + hours + ":" + "0" + mins;
        else if (mins >= 10 && hours < 10)
            timeText.text = "0" + hours + ":" +  mins;
        else if (mins < 10 && hours >= 10)
            timeText.text = hours + ":" + "0" + mins;
    }

    public void addGold(int added)
    {

        TextFadeOut WingGoldText = GameObject.Find("WinGoldText").GetComponent<TextFadeOut>();

        //Rajoute un gold 
        if (!PlayerPrefs.HasKey("Gold"))
            PlayerPrefs.SetInt("Gold", 0);
        gold = PlayerPrefs.GetInt("Gold");
        gold += added;
        //Sauvegarde l'info
        PlayerPrefs.SetInt("Gold", gold);
        goldText.text = "Gold: " + gold;

        WingGoldText.GetComponent<Text>().text = "Gold +" + added;
        WingGoldText.FadeOut();

    }

    public void removeGold(int removed)
    {
        TextFadeOut LooseGoldText = GameObject.Find("LooseGoldText").GetComponent<TextFadeOut>();


        if (!PlayerPrefs.HasKey("Gold"))
            PlayerPrefs.SetInt("Gold", 0);
        gold = PlayerPrefs.GetInt("Gold");
        gold -= removed;
        //Sauvegarde l'info
        PlayerPrefs.SetInt("Gold", gold);
        goldText.text = "Gold: " + gold;

        LooseGoldText.GetComponent<Text>().text = "Gold +" + removed;
        LooseGoldText.FadeOut();

    }

    public int getGold()
    {
        return gold;
    }
}

