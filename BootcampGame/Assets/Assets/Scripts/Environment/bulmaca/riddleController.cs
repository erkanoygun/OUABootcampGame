using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class riddleController : MonoBehaviour
{

    public GameObject[] riddlePieceGo = new GameObject[8];
    public bool[] riddlePiece = new bool[8];
    public bool done;
    private void Start()
    {
        for (int i = 0; i < riddlePiece.Length; i++)
        {
            riddlePiece[i] = riddlePieceGo[i].GetComponent<dragObj>().done;
        }
        
    }
    public void riddleCheck()
    {
        done = true;
        for (int i = 0; i < riddlePiece.Length; i++)
        {
            riddlePiece[i] = riddlePieceGo[i].GetComponent<dragObj>().done;
            if (  riddlePiece[i] == false){

                done = false;
            }
        }
    }
}
