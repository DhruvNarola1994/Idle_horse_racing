using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsManager : MonoBehaviour
{
    public static PrefabsManager inst;

    public GameObject Hores;
    public GameObject Big_Hores;
    public GameObject Black_Hores;
    public GameObject Fast_Hores;

    public GameObject Bonus_Coin;
    public GameObject CoinsBlast;


    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
