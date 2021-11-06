using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;
using Random = UnityEngine.Random;


public class GlassPaneManager : MonoBehaviour
{
    private GameObject[] glassPanes;
    private MeshRenderer color;
    private int counter;
    private Color defaultColor;
    [SerializeField] private float time;
    private bool isDefaultColor; 
    private float aux;
    

    // Start is called before the first frame update
    void Start()
    {
        aux = time;
        counter = 0;
        isDefaultColor = true;
        glassPanes = GameObject.FindGameObjectsWithTag("GlassPane");
        defaultColor = glassPanes[0].GetComponent<MeshRenderer>().material.color;
        GlassPaneRandom();
    }

    // Update is called once per frame
   void Update()
    {
        if (glassPanes != null)
        {
            
            if (time <= 0)
            {
                if (counter <= 13)
                {
                    if (!glassPanes[counter].GetComponent<GlassPaneCharacteristics>().isFragile())
                    {
                        ChangeGlassPaneColorHint(counter);
                    }
                  

                    counter++;
                    time = aux;
                }
                else
                {
                    if (isDefaultColor)
                    {
                        SetDefaultColor();
                        isDefaultColor = false;
                    }
                }
            }
            else
            {
                time -= Time.deltaTime;
            }
        }

    }

    public void GlassPaneRandom()
    {
        for (int i = 0; i < 14; i += 2)
        {


         
            bool randomBool = Random.value>0.5f;
            glassPanes[i].GetComponent<GlassPaneCharacteristics>().Setfragile(randomBool);
            glassPanes[i + 1].GetComponent<GlassPaneCharacteristics>().Setfragile(!randomBool);


        }

    }

    public void ChangeGlassPaneColorHint(int index)
    {
        color = glassPanes[counter].GetComponent<MeshRenderer>();
        color.material.SetColor("_Color", Color.green);
        
    }

    public void SetDefaultColor()
    {
        for (int i = 0; i <= 13; i++)
        {
            color = glassPanes[i].GetComponent<MeshRenderer>();
            color.material.SetColor("_Color",defaultColor);
            color = null;
        }
    }
}
