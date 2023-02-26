using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSystem : MonoBehaviour
{

    public GameObject craftinScreenUI;
    public GameObject toolsScreenUI;
    public GameObject craftBtnActive;
    public GameObject axeHealteBar;
    public GameObject axe;
    public Item wood;
    public Item rock;

    

    public Button toolsBTN;
    public Button craftBtn;
     
    public Text AxeReqStock1, AxeReqStock2;

    public static  bool isOpen;


    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        toolsBTN.onClick.AddListener(ToolsBtn);
        craftBtn.onClick.AddListener(CraftBtn);
    }

    // Update is called once per frame
    void Update()
    {
        CraftingScreen();
        MenuPause();
        AxerReq();
    }

    void CraftingScreen()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (craftinScreenUI && isOpen)
            {
                craftinScreenUI.SetActive(false);
                isOpen = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                craftinScreenUI.SetActive(true);
                toolsScreenUI.SetActive(false);
                isOpen = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void ToolsBtn()
    {
        craftinScreenUI.SetActive(false);
        toolsScreenUI.SetActive(true);
    }

    public void CraftBtn()
    {
        Axe.Healt = 500;
        for (int i = 0; i < 3; i++)
        {
            InventoryManager.Instance.Remover(rock);
            InventoryManager.Instance.Remover(wood);
            InventoryManager.Instance.ItemsCouner();
            AxeReqStock1.text = InventoryManager.Instance.woodAmount.text;
            AxeReqStock2.text = InventoryManager.Instance.stoneAmount.text;
        }
      

        axeHealteBar.SetActive(true);
        axe.SetActive(true);
    }

    void MenuPause()
    {
        if (isOpen)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    void AxerReq()
    {
       
        AxeReqStock1.text = InventoryManager.Instance.woodAmount.text;
        AxeReqStock2.text = InventoryManager.Instance.stoneAmount.text;

        if (float.Parse(AxeReqStock1.text) >= 3f && float.Parse(AxeReqStock2.text) >= 3f)
        {
            craftBtnActive.SetActive(true);
        }
        else
        {
            craftBtnActive.SetActive(false);
        }
    }
}
