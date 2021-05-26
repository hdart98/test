using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text bestScoreTxt;
    [SerializeField] private Text scoreTxt;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text gameOverScoreTxt;
    [SerializeField] private Text gameOverBestScoreTxt;

    public void SetBestScoreTxt(int bestScore)
    {
        bestScoreTxt.text = bestScore.ToString();
    }

    public void SetScore(int score)
    {
        scoreTxt.text = score.ToString();
    }

    public void ActiveGameOverPanel(bool active)
    {
        gameOverPanel.SetActive(active);
    }

    public void SetGameOverScoreTxt(int score)
    {
        gameOverScoreTxt.text = score.ToString();
    }

    public void SetGameOverBestScore(string txt)
    {
        gameOverBestScoreTxt.text = txt;
    }
}
