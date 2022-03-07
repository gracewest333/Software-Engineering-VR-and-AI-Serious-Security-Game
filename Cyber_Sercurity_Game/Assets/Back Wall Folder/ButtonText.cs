using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonText : MonoBehaviour
{
    public Canvas WarningsCanvas;
    public Canvas ShopCanvas;
    public Canvas ManualCanvas;
    public Canvas TutorialCanvas;


    public Button Warnings;
    public Button Shop;
    public Button Manual;
    public Button Tutorial;

    public void Start()
    {


        Warnings.onClick.AddListener(ActivateWarnings);
        Shop.onClick.AddListener(ActivateShop);
        Manual.onClick.AddListener(ActivateManual);
        Tutorial.onClick.AddListener(ActivateTutorial);

    }

    public void ActivateWarnings()
    {
        WarningsCanvas.gameObject.SetActive(true);
        ShopCanvas.gameObject.SetActive(false);
        ManualCanvas.gameObject.SetActive(false);
        TutorialCanvas.gameObject.SetActive(false);
    }

    public void ActivateShop()
    {
        WarningsCanvas.gameObject.SetActive(false);
        ShopCanvas.gameObject.SetActive(true);
        ManualCanvas.gameObject.SetActive(false);
        TutorialCanvas.gameObject.SetActive(false);
    }

    public void ActivateManual()
    {
        WarningsCanvas.gameObject.SetActive(false);
        ShopCanvas.gameObject.SetActive(false);
        ManualCanvas.gameObject.SetActive(true);
        TutorialCanvas.gameObject.SetActive(false);
    }

    public void ActivateTutorial()
    {
        WarningsCanvas.gameObject.SetActive(false);
        ShopCanvas.gameObject.SetActive(false);
        ManualCanvas.gameObject.SetActive(false);
        TutorialCanvas.gameObject.SetActive(true);
    }
}
