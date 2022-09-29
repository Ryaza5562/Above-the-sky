using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI Field;
    private int Score = 0;

    private void Awake()
    {
        Field = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Field.text = Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore() 
    {
        Score += 1;
        Field.text = Score.ToString();
    }
}
