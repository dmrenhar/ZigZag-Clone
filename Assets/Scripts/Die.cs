using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Die : MonoBehaviour
{
    public GameObject panel;
    public Text lastScore;

    public GameObject closeText;
    private void Start()
    {
        panel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            panel.SetActive(true);
            lastScore.text = "YOUR SCORE " + Ball.score.ToString();
            closeText.SetActive(false);
        }
    }
}
