using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins_Potli_Managment : MonoBehaviour
{
    public bool IsWhiteEgaleCoinsBag;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -100)
            Destroy(gameObject);
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (IsWhiteEgaleCoinsBag)
        {
            UiManager.inst.Investment_pnl.SetActive(true);
            Destroy(gameObject);


        }
        else
        {
            int Bonus = GameManager.inst.Bonus();

            GameManager.TotalCoins += Bonus;

            GameManager.inst.EarningCoinsShow(transform.position + Vector3.up * 2, Bonus);

            Destroy(gameObject);
        }
    }
}
