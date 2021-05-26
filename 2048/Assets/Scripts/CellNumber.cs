using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellNumber : MonoBehaviour
{
    [SerializeField] private Text txtNumber;
    [SerializeField] private Color[] colors = new Color[12];

    public void SettingCell(int i)
    {
        string s = i + "";
        txtNumber.text = s;
        gameObject.tag = s;
        SetColor(s);
    }
    public void SettingCell(string s)
    {
        txtNumber.text = s;
        gameObject.tag = s;
        SetColor(s);
    }

    void SetColor(string s)
    {
        if (s.Equals("2")) gameObject.GetComponent<Image>().color = colors[0];
        if (s.Equals("4")) gameObject.GetComponent<Image>().color = colors[1];
        if (s.Equals("8")) gameObject.GetComponent<Image>().color = colors[2];
        if (s.Equals("16")) gameObject.GetComponent<Image>().color = colors[3];
        if (s.Equals("32")) gameObject.GetComponent<Image>().color = colors[4];
        if (s.Equals("64")) gameObject.GetComponent<Image>().color = colors[5];
        if (s.Equals("128")) gameObject.GetComponent<Image>().color = colors[6];
        if (s.Equals("256")) gameObject.GetComponent<Image>().color = colors[7];
        if (s.Equals("512")) gameObject.GetComponent<Image>().color = colors[8];
        if (s.Equals("1024")) gameObject.GetComponent<Image>().color = colors[9];
        if (s.Equals("2048")) gameObject.GetComponent<Image>().color = colors[10];
        if (s.Equals("4098")) gameObject.GetComponent<Image>().color = colors[11];

    }

    public void UpdateStatus()
    {
        if (gameObject.CompareTag("2"))
        {
            SettingCell(4);
            return;
        }
        if (gameObject.CompareTag("4"))
        {
            SettingCell(8);
            return;
        }
        if (gameObject.CompareTag("8"))
        {
            SettingCell(16);
            return;
        }
        if (gameObject.CompareTag("16"))
        {
            SettingCell(32);
            return;
        }
        if (gameObject.CompareTag("32"))
        {
            SettingCell(64);
            return;
        }
        if (gameObject.CompareTag("64"))
        {
            SettingCell(128);
            return;
        }
        if (gameObject.CompareTag("128"))
        {
            SettingCell(256);
            return;
        }
        if (gameObject.CompareTag("256"))
        {
            SettingCell(512);
            return;
        }
        if (gameObject.CompareTag("512"))
        {
            SettingCell(1024);
            return;
        }
        if (gameObject.CompareTag("1024"))
        {
            SettingCell(2048);
            return;
        }
        if (gameObject.CompareTag("2048"))
        {
            SettingCell(4096);
            return;
        }
    }
}
