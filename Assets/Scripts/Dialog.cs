using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dialog : MonoBehaviour
{
    public Text dialogContentText;
    public void Show(bool ishow){
        gameObject.SetActive(ishow);
    }
    public void SetDialogContent(string content){
        if(dialogContentText){
            dialogContentText.text = content;
        }
    }
}
