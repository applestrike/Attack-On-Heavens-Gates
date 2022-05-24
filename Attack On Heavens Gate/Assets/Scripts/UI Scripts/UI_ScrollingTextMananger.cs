using System.Collections.Generic;
using UnityEngine;

public class UI_ScrollingTextMananger : MonoBehaviour
{
    #region Singleton
    private static UI_ScrollingTextMananger _instance;

    public static UI_ScrollingTextMananger Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    public GameObject queueParent;

    public List<GameObject> textMessagesList = new List<GameObject>();

    public int queueChildCount;
    public float showTextRate;
    float nextCheck;

    private void Update()
    {
        ShowTexts();
    }
    public void CreateText(string _text, Color textColor, GameObject position)
    {
        GameObject newText = Instantiate(UI_Manager.Instance.scrollingTextPrefab, position.transform);
        newText.GetComponent<UI_ScrollingText>().SetText(_text, textColor);
        newText.transform.SetParent(queueParent.transform);
        AddTextMessageToQueue(newText);
    }

    void ShowTexts()
    {
        if (queueParent.transform.childCount > 0)
        {
            if (Time.time > nextCheck)
            {
                nextCheck = Time.time + showTextRate;
                SpawnTexts(0);
            }
        }
    }

    void SpawnTexts(int index)
    {
        textMessagesList[index].transform.SetParent(UI_Manager.Instance.scrollingTextSpacer.transform);
        textMessagesList.Remove(textMessagesList[0]);
        textMessagesList.RemoveAll(s => s == null);
    }

    void AddTextMessageToQueue(GameObject newText)
    {
        textMessagesList.Add(newText);
    }

    public void RemoveFromList(GameObject oldText)
    {
        textMessagesList.Remove(oldText);
    }
}
