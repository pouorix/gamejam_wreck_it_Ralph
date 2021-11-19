using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class brickPlacerLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabs;
    public float minX;
    public float maxX;
    public float timerMaxTime;
    private float currentTimerValue;
    public Text Score;
    public GameObject parent;
    public GameObject deathMenu;
    public GameObject ralph1;
    public GameObject ralph2;
    void Start()
    {
        currentTimerValue = timerMaxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!deathMenu.activeSelf)
        {
            if (currentTimerValue > 0)
            {
                currentTimerValue -= Time.deltaTime;
            }
            else
            {
                ralph1.SetActive(!ralph1.activeSelf);
                ralph2.SetActive(!ralph2.activeSelf);
                GameObject newObject = Instantiate(prefabs, new Vector3(GetRandomPrefabInitialX(), 30, transform.position.z), Quaternion.identity) as GameObject;
                newObject.transform.SetParent(parent.transform);
                newObject.transform.position = new Vector3(GetRandomPrefabInitialX(), 0.2f, 0);
                //newObject.transform.localScale = new Vector3(1, 1, 1);
                UpdateTimerValueBasedOnScore();

                // reset timer
                currentTimerValue = timerMaxTime;
            }
        }

    }
    private void UpdateTimerValueBasedOnScore()
    {
        Debug.Log(int.Parse(Score.text));
        if (int.Parse(Score.text) % 8 ==0 && int.Parse(Score.text)!=0)
        {
            timerMaxTime -= 0.1f;

            if (timerMaxTime < 0.35f)
                timerMaxTime = 0.35f;
        }
    }
    float GetRandomPrefabInitialX()
    {
        return UnityEngine.Random.Range(minX, maxX);
    }

}
