using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject cellNum;
    [SerializeField] private Transform[] transforms;
    [SerializeField] private UIController uiCtr;

    private Transform[,] allCells = new Transform[4,4];
    private bool[,] checks = new bool[4,4];
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        int t = 0;
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                allCells[i, j] = transforms[t];
                checks[i, j] = false;
                t++;
            }
        }
        uiCtr.SetScore(score);
        uiCtr.SetBestScoreTxt(GetBestScore());
        SpawnCellNumber();
    }

    // Update is called once per frame
    void Update()
    {
        //UI
        uiCtr.SetScore(score);
        if (IsLose())
        {
            Debug.Log("lose");
            uiCtr.ActiveGameOverPanel(true);
            uiCtr.SetGameOverScoreTxt(score);
            if (score < GetBestScore())
                uiCtr.SetGameOverBestScore("BEST SCORE : " + GetBestScore());
            else
            {
                uiCtr.SetGameOverBestScore("NEW BEST SCORE !");
                SetBestScore(score);
            }
        }

        //Input
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveDown();
        }
    }
    public void MoveRight()
    {
        bool isSpawn = false;
        for (int i = 3; i > -1; i--)
        {
            for (int j = 3; j > 0; j--)
            {
                if (!checks[i, j])
                {
                    for (int k = j - 1; k > -1; k--)
                    {
                        if (checks[i, k])
                        {
                            int t = allCells[i, j].childCount;
                            int r = allCells[i, k].childCount;
                            checks[i, j] = true;
                            checks[i, k] = false;
                            Instantiate(allCells[i, k].GetChild(r-1).gameObject, allCells[i, j]);
                            allCells[i, k].GetChild(r-1).gameObject.SetActive(false);
                            isSpawn = true;
                            j++;
                            break;
                        }
                    }
                }
                else
                {
                    for (int k = j - 1; k > -1; k--)
                    {
                        if (checks[i, k])
                        {
                            int t = allCells[i, j].childCount;
                            int r = allCells[i, k].childCount;
                            if (allCells[i, j].GetChild(t-1).gameObject.CompareTag(
                                allCells[i, k].GetChild(r-1).gameObject.tag))
                            {
                                allCells[i, j].GetChild(t-1).gameObject.SendMessage("UpdateStatus");
                                checks[i, k] = false;
                                allCells[i, k].GetChild(r-1).gameObject.SetActive(false);
                                isSpawn = true;
                            }
                            break;
                        }
                    }
                }
            }
        }
        UpdateCells();
        if (isSpawn)
        SpawnCellNumber();
    }
    public void MoveLeft()
    {
        bool isSpawn = false;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (!checks[i, j])
                {
                    for (int k = j + 1; k < 4; k++)
                    {
                        if (checks[i, k])
                        {
                            int t = allCells[i, j].childCount;
                            int r = allCells[i, k].childCount;
                            checks[i, j] = true;
                            checks[i, k] = false;
                            isSpawn = true;
                            Instantiate(allCells[i, k].GetChild(r - 1).gameObject, allCells[i, j]);
                            allCells[i, k].GetChild(r - 1).gameObject.SetActive(false);
                            j--;
                            break;
                        }
                    }
                }
                else
                {
                    for (int k = j + 1; k < 4; k++)
                    {
                        if (checks[i, k])
                        {
                            int t = allCells[i, j].childCount;
                            int r = allCells[i, k].childCount;
                            if (allCells[i, j].GetChild(t - 1).gameObject.CompareTag(
                                allCells[i, k].GetChild(r - 1).gameObject.tag))
                            {
                                allCells[i, j].GetChild(t - 1).gameObject.SendMessage("UpdateStatus");
                                checks[i, k] = false;
                                isSpawn = true;
                                allCells[i, k].GetChild(r - 1).gameObject.SetActive(false);
                            }
                            break;
                        }
                    }
                }
            }
        }
        UpdateCells();
        if(isSpawn)
        SpawnCellNumber();
    }
    public void MoveDown()
    {
        bool isSpawn = false;
        for (int i = 3; i > -1; i--)
        {
            for (int j = 3; j > 0; j--)
            {
                if (!checks[j, i])
                {
                    for (int k = j - 1; k > -1; k--)
                    {
                        if (checks[k, i])
                        {
                            int t = allCells[j, i].childCount;
                            int r = allCells[k, i].childCount;
                            checks[j, i] = true;
                            checks[k, i] = false;
                            Instantiate(allCells[k, i].GetChild(r - 1).gameObject, allCells[j, i]);
                            allCells[k, i].GetChild(r - 1).gameObject.SetActive(false);
                            isSpawn = true;
                            j++;
                            break;
                        }
                    }
                }
                else
                {
                    for (int k = j - 1; k > -1; k--)
                    {
                        if (checks[k, i])
                        {
                            int t = allCells[j, i].childCount;
                            int r = allCells[k, i].childCount;
                            if (allCells[j, i].GetChild(t - 1).gameObject.CompareTag(
                                allCells[k, i].GetChild(r - 1).gameObject.tag))
                            {
                                allCells[j, i].GetChild(t - 1).gameObject.SendMessage("UpdateStatus");
                                checks[k, i] = false;
                                allCells[k, i].GetChild(r - 1).gameObject.SetActive(false);
                                isSpawn = true;
                            }
                            break;
                        }
                    }
                }
            }
        }
        UpdateCells();
        if(isSpawn)
        SpawnCellNumber();
    }
    public void MoveUp()
    {
        bool isSpawn = false;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (!checks[j, i])
                {
                    for (int k = j + 1; k < 4; k++)
                    {
                        if (checks[k, i])
                        {
                            int t = allCells[j, i].childCount;
                            int r = allCells[k, i].childCount;
                            checks[j, i] = true;
                            checks[k, i] = false;
                            Instantiate(allCells[k, i].GetChild(r - 1).gameObject, allCells[j, i]);
                            isSpawn = true;
                            allCells[k, i].GetChild(r - 1).gameObject.SetActive(false);
                            j--;
                            break;
                        }
                    }
                }
                else
                {
                    for (int k = j + 1; k < 4; k++)
                    {
                        if (checks[k, i])
                        {
                            int t = allCells[j, i].childCount;
                            int r = allCells[k, i].childCount;
                            if (allCells[j, i].GetChild(t - 1).gameObject.CompareTag(
                                allCells[k, i].GetChild(r - 1).gameObject.tag))
                            {
                                allCells[j, i].GetChild(t - 1).gameObject.SendMessage("UpdateStatus");
                                checks[k, i] = false;
                                allCells[k, i].GetChild(r - 1).gameObject.SetActive(false);
                                isSpawn = true;
                            }
                            break;
                        }
                    }
                }
            }
        }
        UpdateCells();
        if(isSpawn)
        SpawnCellNumber();
    }
    public void UpdateCells()
    {
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                if (allCells[i, j].childCount > 2 || (checks[i, j] == false&&allCells[i,j].childCount>0))
                {
                    Destroy(allCells[i, j].GetChild(0).gameObject);
                }
            }
        }
    }
    public void SpawnCellNumber()
    {
        FindSpawnPosition:
        int i = Random.Range(0, 4);
        int j = Random.Range(0, 4);
        if (checks[i, j]) goto FindSpawnPosition;
        Transform spawnPos = allCells[i, j];
        checks[i, j] = true;
        float chanceNumber = Random.Range(0f, 1f);
        if (chanceNumber < 0.75f)
        {
            GameObject gobj = Instantiate(cellNum, spawnPos);
            gobj.SendMessage("SettingCell", 2);
            score += 2;
        }
        else
        {
            GameObject gobj = Instantiate(cellNum, spawnPos);
            gobj.SendMessage("SettingCell", 4);
            score += 4;
        }
    }
    public bool IsLose()
    {
        if (IsFull())
        {
            foreach (Transform traf in transforms)
            {
                if (traf.gameObject.GetComponent<Cell>().Check()) return false;
            }
            return true;
        }
        
        return false;
    }
    bool IsFull()
    {
        foreach(bool che in checks)
        {
            if (che==false) return false;
        }
        return true;
    }
    public int GetBestScore()
    {
        return PlayerPrefs.GetInt("HightScore", 0);
    }
    public void SetBestScore(int score)
    {
        PlayerPrefs.SetInt("HightScore", score);
    }
    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
