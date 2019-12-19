using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{

    private Canvas shopCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        shopCanvas = this.GetComponent<Canvas>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void openMenu()
    {
        shopCanvas.enabled = true;
    }

    public void closeMenu()
    {
        shopCanvas.enabled = false;
    }




}
