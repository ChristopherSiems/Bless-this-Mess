using UnityEngine;
using UnityEngine.UI;

public class TaskScreen : MonoBehaviour
{
    public GameObject taskPanel;

    void Start()
    {
        taskPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            taskPanel.SetActive(!taskPanel.activeSelf);
        }
    }
}

