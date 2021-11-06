using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassPaneCharacteristics : MonoBehaviour
{
    // Start is called before the first frame update
    private bool fragile = false;
    
    public bool isFragile()
    {
        return fragile; 
    }

    public void Setfragile(bool fr)
    {
        fragile = fr;
    }
    
} 
