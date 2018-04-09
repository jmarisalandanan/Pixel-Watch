using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

//Throwaway code
public class DashDisplay : MonoBehaviour {
    [SerializeField] private Image[] imageCounter;
    [SerializeField] private IntVariable dashCount;

    public void UpdateImageCounter()
    {
        for (int i = 0; i < imageCounter.Length; i++)
        {
            imageCounter[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < dashCount.localValue; i ++)
        {
            imageCounter[i].gameObject.SetActive(true);
        }
    }

}
