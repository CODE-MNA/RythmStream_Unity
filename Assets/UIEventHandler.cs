using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class UIEventHandler : MonoBehaviour
{

    public UnityEvent<string> startAsPlayerClicked;
    public UnityEvent<string> startAsMakerClicked;
    VisualElement root;

    void Start()
    {
        
    }

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        Button btnPlayer = root.Q<Button>("btnStartAsPlayer");
        Button btnMaker = root.Q<Button>("btnStartAsMaker");
        TextField textField = root.Q<TextField>("txtRoomName");

        btnMaker.clicked += () => startAsMakerClicked?.Invoke(textField.text);
        btnPlayer.clicked += () => startAsPlayerClicked?.Invoke(textField.text);




    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
