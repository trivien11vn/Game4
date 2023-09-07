using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class UIManager : MonoBehaviour
{
    public static UIManager Ins;
    public Text timeText;
    public Text questionText;
    public Dialog dialog;
    public AnswerButton[] answerButtons;

    private void Awake(){
        MakeSingleton();
    }
    private void Start(){
        // ShuffleAnswer();
    }
    public void SetTimeText(string content){
        if(timeText){
            timeText.text = content;
        }
    }
    
    public void SetQuestionText(string content){
        if(questionText){
            questionText.text = content;
        }
    }

    public void ShuffleAnswer(){
        if(answerButtons != null && answerButtons.Length > 0){
            for(int i = 0; i < answerButtons.Length;i++){
                if(answerButtons[i]){
                    answerButtons[i].tag = "Untagged";
                }
            }
            int random = Random.Range(0,answerButtons.Length);
            if(answerButtons[random]){
                Debug.Log("a");
                Debug.Log(answerButtons.Length);
                Debug.Log(random);
                Debug.Log("b");
                answerButtons[random].tag = "Right_answer";
            }
        }
    }
    public void MakeSingleton(){
        if(Ins == null){
            Ins = this;
        }
        else{
            Destroy(gameObject);
        }
    }
}
