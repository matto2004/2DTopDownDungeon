using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private string char1Class;
    private Vector3 char1Pos = new Vector3(-5, 12.5f, 0);
    private string char2Class;
    private Vector3 char2Pos = new Vector3(-5, 12.5f, 0);
    private string char3Class;
    private Vector3 char3Pos = new Vector3(-5, 12.5f, 0);
    private GameObject Player;
    public InputField inputField;
    public GameObject Warning;
    private int charCreateNum;
    public GameObject Char1;
    public Text Char1Name;
    public GameObject Char1Empt;
    public Image Char1Img;
    public GameObject Char2;
    public Text Char2Name;
    public GameObject Char2Empt;
    public Image Char2Img;
    public GameObject Char3;
    public Text Char3Name;
    public GameObject Char3Empt;
    public Image Char3Img;

    public string Char1Class { get => char1Class; set => char1Class = value; }
    public Vector3 Char1Pos { get => char1Pos; set => char1Pos = value; }
    public string Char2Class { get => char2Class; set => char2Class = value; }
    public Vector3 Char2Pos { get => char2Pos; set => char2Pos = value; }
    public string Char3Class { get => char3Class; set => char3Class = value; }
    public Vector3 Char3Pos { get => char3Pos; set => char3Pos = value; }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    public void PlayGame1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Player.transform.position = char1Pos;
    }
    public void PlayGame2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Player.transform.position = char2Pos;
    } 
    public void PlayGame3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Player.transform.position = Char3Pos;
    }


    public void getChar1Class(string s)
    {
        char1Class = s;
    }
    public void getChar2Class(string s)
    {
        char2Class = s;
    }
    public void getChar3Class(string s)
    {
        char3Class = s;
    } public void setChar1Class(string s)
    {
        Player.GetComponent<PlayerStatManager>().charClass = char1Class;
    }
    public void setChar2Class(string s)
    {
        Player.GetComponent<PlayerStatManager>().charClass = char2Class;
    }
    public void setChar3Class(string s)
    {
        Player.GetComponent<PlayerStatManager>().charClass = char3Class;
    }

    public void setChatCreatNum(int i)
    {
        charCreateNum = i;
    }


   public void CreateChar()
    {
        if(inputField.text == "")
        {
            Warning.SetActive(true);
            return;
        }
        Player.GetComponent<PlayerStatManager>().Name = inputField.text;
        Player.GetComponent<PlayerStatManager>().charNum = charCreateNum;

        if(Player.GetComponent<PlayerStatManager>().charNum ==1)
        {
            Char1Img.sprite = Player.GetComponent<SpriteRenderer>().sprite;
            Char1Empt.SetActive(false);
            Char1.SetActive(true);
            Char1Name.text = Player.GetComponent<PlayerStatManager>().Name;


        } if(Player.GetComponent<PlayerStatManager>().charNum ==2)
        {
            Char2Img.sprite = Player.GetComponent<SpriteRenderer>().sprite;
            Char2Empt.SetActive(false);
            Char2.SetActive(true);
            Char2Name.text = Player.GetComponent<PlayerStatManager>().Name;
        }
        if (Player.GetComponent<PlayerStatManager>().charNum ==3)
        {
            Char3Img.sprite = Player.GetComponent<SpriteRenderer>().sprite;
            Char3Empt.SetActive(false);
            Char3.SetActive(true);
            Char3Name.text = Player.GetComponent<PlayerStatManager>().Name;
        }

        inputField.text ="";
    }

}
