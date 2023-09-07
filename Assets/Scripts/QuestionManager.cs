using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager Ins;
    public QuestionData[] questions;
    List<QuestionData> m_questions;
    QuestionData m_curQuestion;

    private void Awake(){
        m_questions = questions.ToList();
        MakeSingleton();
    }
    public QuestionData CurQuestion { get => m_curQuestion; set => m_curQuestion = value; }
    

    public QuestionData GetRandomQuestion(){
        if(m_questions != null && m_questions.Count > 0){
            int random = Random.Range(0, m_questions.Count);
            m_curQuestion = m_questions[random];
            m_questions.RemoveAt(random);    
        } 
        return m_curQuestion;
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
