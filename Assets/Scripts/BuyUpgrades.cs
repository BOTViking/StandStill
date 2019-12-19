using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyUpgrades : MonoBehaviour
{
    private Canvas upgradeCanvas;

    // Start is called before the first frame update
    void Start()
    {
        upgradeCanvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openMenu()
    {
        upgradeCanvas.enabled = true;
    }

    public void closeMenu()
    {
        upgradeCanvas.enabled = false;
    }

    public void buyUpgrade1()
    {
        if (!SkillTreeReader.Instance.IsSkillUnlocked(1))
        {
            if (SkillTreeReader.Instance.UnlockSkill(1))
            {
                Player.instance.Unlock1();
                GameHandler.instance.removeGold(10);
            }
            else
            {
                //Not enough money
            }
        }
    }
}
