using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public bool xturn, oturn;
    public Sprite Ximg, Oimg;
    public int nummovesplayed;
    public Text Debugtext;
    public List<Image> images;
    public List<List<int>> Winconditions = new List<List<int>>

    {
        new List<int> { 0, 1, 2 }, new List<int> { 3, 4, 5 }, new List<int> { 6,7,8},
        new List<int> { 0, 3, 6 }, new List<int> { 1, 4, 7 }, new List<int> { 2,5,8},
        new List<int> { 0, 4, 8 }, new List<int> { 2, 4, 6 }


    };
    bool xwin, owin;
    public List<int> board = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    // Start is called before the first frame update
    void Start()
    {
        Debugtext.text = "X plays First";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTurnPlayed(Image img)
    {
        string imgname = "none";
        if (xturn)
        {
            img.sprite = Ximg;
            img.color = Color.white;
            img.raycastTarget = false;

            xturn = false;
            oturn = true;
            imgname = img.gameObject.name;
            board[int.Parse(imgname) - 1] = 1;

            nummovesplayed++;
            Debugtext.text = "O's turn";
            if (nummovesplayed > 4)
            {
                CheckWin();
            }

        }
        else if (oturn)
        {
            img.sprite = Oimg;
            img.color = Color.white;
            oturn = false;
            xturn = true;
            img.raycastTarget = false;
            imgname = img.gameObject.name;
            board[int.Parse(imgname) - 1] = -1;

            nummovesplayed++;
            Debugtext.text = "X's turn";
            if (nummovesplayed > 4)
            {
                CheckWin();
            }
        }
    }
    public void CheckWin()
    {
        foreach (var condition in Winconditions)
        {

            int x = 0; int o = 0;
            foreach (var item in condition)
            {
                if (board[item] == 0)
                {
                    break;
                }
                else if (board[item] == 1)
                {
                    x++;
                }
                else if (board[item] == -1)
                {
                    o++;
                }
            }
            if (x > 2)
            {
                xwin = true;
                Debugtext.text = "X wins";
                foreach (var img in images)
                {
                    img.raycastTarget = false;
                }
                break;
            }
            else if (o > 2)
            {
                owin = true;
                Debugtext.text = "O wins";
                foreach (var img in images)
                {
                    img.raycastTarget = false;
                }
                break;
            }

        }
    }
    public void Restart()
    {
        foreach (var img in images)
        {
            img.raycastTarget = true;
            img.sprite = null;
            img.color=Color.clear;
        }
        nummovesplayed = 0;
        board = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        xturn = true;
        oturn = false;
        xwin = false;owin = false;
        Debugtext.text = "X plays First";
    }
}