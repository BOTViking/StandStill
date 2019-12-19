using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instance = null;

    private float health;
    private float maxHealth = 1000; 
    private float mental;
    private float maxMental = 1000;

    public Image healthBar;
    public Image mentalBar;
    public Sprite darkSprite;
    public Sprite normalSprite;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        checkUnlockedSkills();
        health = maxHealth;
        mental = maxMental;
        healthBar.fillAmount = health / maxHealth;
    }

    private void checkUnlockedSkills()
    {
        if (SkillTreeReader.Instance.IsSkillUnlocked(3))
            Unlock2();
        else if (SkillTreeReader.Instance.IsSkillUnlocked(1))
            Unlock1();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LooseHealth(float hpLost)
    {
        health -= hpLost;
        if (health <= 0)
            health = 0;
        healthBar.fillAmount = health/ maxHealth;
    }

    public void LooseMental(float mentalLost)
    {
        mental -= mentalLost;
        if (mental <= 0)
            mental = 0;
        mentalBar.fillAmount = mental / maxMental;
    }

    private void OnMouseOver()
    {
        GetComponent<SpriteRenderer>().sprite = darkSprite;
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().sprite = normalSprite;
    }

    public void Unlock1()
    {
        maxHealth = 1500;
    }
 
    public void Unlock2()
    {
        maxHealth = 2500;
    }
}
