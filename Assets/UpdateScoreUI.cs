using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UpdateScoreUI : MonoBehaviour
{
    ScoreManager scoreManager;
    VisualElement root;

    [SerializeField]
    UIDocument doc;


    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        root = doc.rootVisualElement;
          Label lbl =  root.Q<Label>("lblScore");



        scoreManager.OnScoreChange += (score) =>
        {
            lbl.text = "Score : " + scoreManager.Score.ToString();

            
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
