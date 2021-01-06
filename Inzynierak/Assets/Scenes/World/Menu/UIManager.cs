using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text xpText;
    [SerializeField] private Text levelText;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject board;

    private void Awake()
    {
        Assert.IsNotNull(xpText);
        Assert.IsNotNull(levelText);
        Assert.IsNotNull(menu);
    }


    private void Update()
    {
        updateLevel();
        updateXp();
    }

    public void updateLevel()
    {
        levelText.text = GameManager.Instance.CurrentPlayer.Lvl.ToString();
    }

    public void updateXp()
    {
        xpText.text = GameManager.Instance.CurrentPlayer.Xp + " / " + GameManager.Instance.CurrentPlayer.RequiredXp;
    }

    public void ActiveMenu()
    {
        menu.SetActive(true);
    }
    public void DeactiveMenu()
    {
        menu.SetActive(false);
    }
    public void ActiveBoard()
    {
        
        menu.SetActive(false);
        SceneManager.LoadScene("Board");
    }
    public void DeactiveBoard()
    {
        board.SetActive(false);
    }





}
