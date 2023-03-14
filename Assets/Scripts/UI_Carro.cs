using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class UI_Carro : MonoBehaviour
{
    public Carro meuCarro;
    public TMP_Text nomeT;
    public TMP_Text voltaT;
    public TMP_Text posT;
    public TMP_Text VelT;
    public GameObject WinScreen;
    public TMP_Text[] Lugar = new TMP_Text[4];


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nomeT.text = meuCarro.name;
        voltaT.text = "Volta:" + meuCarro.volta.ToString();
        VelT.text = "Velocidade:" + meuCarro.GetComponent<NavMeshAgent>().speed.ToString() + "Km/h";
        posT.text = "Posição:" + meuCarro.pos.ToString();

        if (meuCarro.volta == 3)
        {
            Time.timeScale = 0;
            WinScreen.SetActive(true);
            Carro[] carros= GameObject.FindObjectsOfType<Carro>();
            for (int i = 0; i < Lugar.Length; i++)
            {
                Lugar[carros[i].pos -1].text= carros[i].name;
            }
        }

        
    }


}
