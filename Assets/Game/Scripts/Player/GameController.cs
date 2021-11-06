using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Canvas finScreen;
    [SerializeField] private Canvas inGameScreen;
    [SerializeField] private Text winText;
    [SerializeField] private Text loseText;
    [SerializeField] private GameObject game;
    [SerializeField] private float time;
   

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 80)
        {
            inGameScreen.gameObject.SetActive(false);
            finScreen.gameObject.SetActive(true);
            loseText.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        GameObject pane = other.gameObject;
        if (pane.CompareTag("GlassPane"))
        {
            if (pane.GetComponent<GlassPaneCharacteristics>().isFragile())
            {
             
                pane.SetActive(false);
            

            }
            
        }

        if (pane.CompareTag("FinishPlatform"))
        {
            inGameScreen.gameObject.SetActive(false);
            finScreen.gameObject.SetActive(true);
            winText.gameObject.SetActive(true);
      
        }
    }

 
}
