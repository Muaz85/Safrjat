using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    // Start is called before the first frame update
    public Button button;
    public Text buttonText;
    public string playerSide;
    public Sprite imageX, imageO;


    private GameController gameController;

    private void Start()
    {
        gameController.XImage = imageX;
        gameController.OImage = imageO;
    }

    public void SetSpace()
    {
        if (gameController.playerMove == true)
        {
            if (gameController.playerSide == "x")
            {
                button.GetComponent<Image>().sprite = imageX;
                gameController.imagComputer = imageO;


            }
            else if (gameController.playerSide == "o")
            {
                button.GetComponent<Image>().sprite = imageO;
                gameController.imagComputer = imageX;
            }
            

            buttonText.text = gameController.GetPlayerSide();
            button.interactable = false;
            gameController.EndTurn();
        }
    }

    public void SetGameControllerRefrence(GameController controller)
    {
        gameController = controller;
       

    }
}
