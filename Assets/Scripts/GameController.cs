using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    int m_rightCount = 0;
    public float timePerQuestion;
    float cur_time;
    private void Awake(){
        cur_time = timePerQuestion;
    }
    void Start(){
        UIManager.Ins.SetTimeText("00 : "+cur_time);
        CreateQuestion();
        StartCoroutine(TimeCountingDown());
    }
    public void CreateQuestion(){
        QuestionData qs = QuestionManager.Ins.GetRandomQuestion();
        if(qs != null){
            UIManager.Ins.SetQuestionText(qs.question);
            string[] wrong_answers = new string[]{qs.answerA,qs.answerB,qs.answerC};
            Debug.Log(qs.answerA);
            Debug.Log(qs.answerB);
            Debug.Log(qs.answerC);
            UIManager.Ins.ShuffleAnswer();
            var temp = UIManager.Ins.answerButtons;
            if(temp != null && temp.Length > 0){
                int wrong_answers_count = 0;
                for(int i = 0; i < temp.Length; i++){
                    int answer_id = i;

                    if(string.Compare(temp[i].tag,"Right_answer")==0){
                        Debug.Log("check_tag");
                        temp[i].SetAnswerText(qs.answer);
                    }
                    else{
                        temp[i].SetAnswerText(wrong_answers[wrong_answers_count]);
                        wrong_answers_count++;
                    }
                    temp[answer_id].btnComp.onClick.RemoveAllListeners();
                    temp[answer_id].btnComp.onClick.AddListener(()=>CheckRightAnswerEvent(temp[answer_id]));
                }
            }
        }
    }

    void CheckRightAnswerEvent(AnswerButton answer_button){
        if(answer_button.CompareTag("Right_answer")){
            Debug.Log("ban da tra loi dung");
            cur_time = timePerQuestion;
            UIManager.Ins.SetTimeText("00 : "+cur_time);
            m_rightCount++;
            if(m_rightCount >= QuestionManager.Ins.questions.Length){
                UIManager.Ins.dialog.SetDialogContent("Bạn đã chiến thắng !");
                UIManager.Ins.dialog.Show(true);
                AudioController.Ins.PlayWinSound();
                StopAllCoroutines();
            }
            else{
                AudioController.Ins.PlayRightSound();
                CreateQuestion();
            }
        }
        else {
            UIManager.Ins.dialog.SetDialogContent("Bạn đã thua cuộc !");
            UIManager.Ins.dialog.Show(true);
            AudioController.Ins.PlayLoseSound();
            Debug.Log("Bạn đã thua cuộc !");
            StopAllCoroutines();
        }
    }

    IEnumerator TimeCountingDown(){
        yield return new WaitForSeconds(1);
        if(cur_time>0){
            cur_time--;
            UIManager.Ins.SetTimeText("00 : "+cur_time);
            StartCoroutine(TimeCountingDown());
        }
        else{
            UIManager.Ins.dialog.SetDialogContent("Bạn đã hết thời gian !");
            UIManager.Ins.dialog.Show(true);
            Debug.Log("Bạn đã hết thời gian !");
            StopAllCoroutines();
            AudioController.Ins.PlayLoseSound();
        }
    }
    public void Replay(){
        SceneManager.LoadScene("Gameplay");
    }
    public void Exit(){
        Application.Quit();
    }
}
