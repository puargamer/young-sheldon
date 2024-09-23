using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton : MonoBehaviour
{
    public List<GameObject> BallList = new List<GameObject>();      //stores all balls

    public static Singleton instance;
    public TMP_Text text;

    public float pitch = 1;

    public AudioListener audioListener;

    private void Awake()
    {
        instance = this;
    }

    public void addtoList(GameObject ball)
    {
        BallList.Add(ball);
    }

    public void removeFromList(GameObject ball)
    {
        BallList.Remove(ball);
    }

    public GameObject selectRandomFromList(GameObject ball)       //returns a random ball that isn't a given ball
    {
        GameObject result = result = BallList[Random.Range(0, BallList.Count)];

        while (result == ball)
        {
            result = BallList[Random.Range(0,BallList.Count)];
        }

        return result;
    }

    private void Update()
    {
        text.text = "Ball Count " + BallList.Count;

        if (BallList.Count >= 3000)
        {
            SceneManager.LoadScene(0);
        }
    }
}
