using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player
{
    public Image panel;
    public Text text;
    public Button button;
}

[System.Serializable]
public class PlayerColor
{
    public Color panelColor;
    public Color textColor;
}
public class GameController : MonoBehaviour
{
    public Text[] buttonList;
    public Button[] buttonSpriteList;
    public string playerSide;

    public GameObject gameOverPanel , restartButton;
    public Text gameOverText;

    private int moveCount;

    public Player playerX;
    public Player playerO;
    public PlayerColor activePlayerColor;
    public PlayerColor inactivePlayerColor;
    public Sprite defualtImage;
    public Sprite imagComputer,XImage,OImage;
    public Image winImage;
    public GameObject Darwn;
    public GameObject endPanel;
    //public GameObject startInfo;
    public GameObject Choesemenu;
    public string computerSide;
    public bool playerMove;
    public float delay;
    private int value;

    void Awake()
    {
        gameOverPanel.SetActive(false);
        SetGameControllerRefrenceOnButton();
       
        moveCount = 0;
        restartButton.SetActive(false);
        playerMove = true;
        
    }
    void SetGameControllerRefrenceOnButton()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerRefrence(this);
            buttonSpriteList[i].GetComponentInParent<GridSpace>().SetGameControllerRefrence(this);
        }
         
    }

    void Update()
    {
        if (playerMove == false)
        {
            delay += delay * Time.deltaTime;
            if (delay >= 10)
            {
                value = Random.Range(0,buttonList.Length);
                if (buttonList[value].GetComponentInParent<Button>().interactable ==true)
                {
                    buttonSpriteList[value].GetComponent<Image>().sprite = imagComputer;
                    buttonList[value].text = GetComputerSide();
                    buttonList[value].GetComponentInParent<Button>().interactable = false;
                    EndTurn();
                }
            }

        }
    }
    public void SetStartingSide(string startingSide)
    {
        playerSide = startingSide;
        if (playerSide == "x")
        {
            computerSide = "o";
            SetPlayerColors(playerX,playerO);
        }
        else
        {
            computerSide = "x";
            SetPlayerColors(playerO,playerX);
        }
        StartGame();
    }
    private void StartGame()
    {
        SetBoardInteractable(true);
        SetPlayerButton(false);
        //startInfo.SetActive(false);
        Choesemenu.SetActive(false);
    }

    public string GetComputerSide()
    {
        return computerSide;
    }
    public string GetPlayerSide()
    {
        return playerSide;
    }
    public void EndTurn()
    {
        moveCount++;
        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide&& buttonList[2].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }

        else if (buttonList[0].text == computerSide && buttonList[1].text == computerSide && buttonList[2].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonList[3].text == computerSide && buttonList[4].text == computerSide && buttonList[5].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonList[6].text == computerSide && buttonList[7].text == computerSide && buttonList[8].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonList[0].text == computerSide && buttonList[3].text == computerSide && buttonList[6].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonList[1].text == computerSide && buttonList[4].text == computerSide && buttonList[7].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonList[2].text == computerSide && buttonList[5].text == computerSide && buttonList[8].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonList[0].text == computerSide && buttonList[4].text == computerSide && buttonList[8].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonList[2].text == computerSide && buttonList[4].text == computerSide && buttonList[6].text == computerSide)
        {
            GameOver(computerSide);
        }


        else if (moveCount>=9)
        {

            GameOver("draw");
        }
        else
        {
            ChangSide();
        }
       
    }

    void SetPlayerColors(Player newPlayer,Player oldPlayer)
    {
        newPlayer.panel.color = activePlayerColor.panelColor;
        newPlayer.text.color = activePlayerColor.textColor;
        oldPlayer.panel.color = inactivePlayerColor.panelColor;
        oldPlayer.text.color = inactivePlayerColor.textColor;
    }

    void GameOver( string winningPlayer)
    {
        SetBoardInteractable(false);
        if (winningPlayer == "draw")
        {

            SetGameResultPanel(Darwn);
            SetGameResultPanel(endPanel);
            SetplayerColorsInactive();
        }
        else
        {
            if (winningPlayer == "x")
            {
                print("xxx"+ winningPlayer);
                winImage.sprite = XImage;
            }
            else if (winningPlayer == "o")
            {
                print("oooo" + winningPlayer);
                winImage.sprite = OImage;
            }

            SetGameResultPanel(gameOverPanel);
            SetGameResultPanel(endPanel);
        }
        restartButton.SetActive(true);
    }

    void ChangSide()
    {
        //playerSide = (playerSide == "x") ? "o" : "x";
        playerMove = (playerMove == true) ? false : true;
        if (playerMove ==true)
        {
            SetPlayerColors(playerX,playerO);
        }
        else
        {
            SetPlayerColors(playerO,playerX);
        }
    }

    void SetGameResultPanel(GameObject panel)
    {
        panel.SetActive(true);
        
    }
    public void RestartGame()
    {
       
        moveCount = 0;
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        Darwn.SetActive(false);
        endPanel.SetActive(false);
        Choesemenu.SetActive(true);
        SetPlayerButton(true);
        SetplayerColorsInactive();
        //startInfo.SetActive(true);
        playerMove = true;
        delay = 10;
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonSpriteList[i].GetComponent<Image>().sprite = defualtImage;
            buttonList[i].text = "";
           
        }

        
        
    }
    
    void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }

    void SetPlayerButton(bool toggle)
    {
        playerX.button.interactable = toggle;
        playerO.button.interactable = toggle;
    }

    void SetplayerColorsInactive()
    {
        playerX.panel.color = inactivePlayerColor.panelColor;
        playerX.text.color = inactivePlayerColor.textColor;
        playerO.panel.color = inactivePlayerColor.panelColor;
        playerO.text.color = inactivePlayerColor.textColor;
    }
}
