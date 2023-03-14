using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Carro : MonoBehaviour
{
    private NavMeshAgent Car;
    public GameObject Destiny;
    public List<GameObject> Destinos1;
    public int rota = 0;
    public List<GameObject> Destinos2;
    public int ponteiro;
    public int pos = 1;
    public List<GameObject> TodosCarros;
    public float posDistancia = 0;


    public int volta;
    // Start is called before the first frame update
    void Start()
    {
        Car = GetComponent<NavMeshAgent>();
        ponteiro = 0;
        rota = Random.Range(1, 3);
        if (rota == 1)
        {
            Destiny = Destinos1[0];
        }
        else
        {
            Destiny = Destinos2[0];
        }

    }


   
    void Update()
    {
        

        DefinePos();
        if (rota == 1)
        {

            
            Car.SetDestination(Destiny.transform.position);
            
            float distancia = Vector3.Distance(transform.position, Destiny.transform.position);
            if (distancia < 5)
            {

                if (Destinos1[ponteiro].gameObject.tag == "Lento")
                {
                    Car.speed = Random.Range(20, 30);
                }
                else if (Destinos1[ponteiro].gameObject.tag == "Medio")
                {
                    Car.speed = Random.Range(30, 40);
                }
                else if (Destinos1[ponteiro].gameObject.tag == "Rapido")
                {
                    Car.speed = Random.Range(40, 50);
                }

                
                ponteiro++;
                if (ponteiro > Destinos1.Count - 1)
                {
                    ponteiro = 0;
                    rota = Random.Range(1, 3);
                }
                Destiny = Destinos1[ponteiro];


               
                int pontAtual = ponteiro - 1;
                if (pontAtual < 0) { pontAtual = Destinos1.Count - 1; }
                MinhaDistancia(Destinos1[pontAtual].transform.position);


            }
        }
        if (rota == 2)
        {

            
            Car.SetDestination(Destiny.transform.position);
           
            float distancia2 = Vector3.Distance(transform.position, Destiny.transform.position);
            if (distancia2 < 5)
            {

                if (Destinos2[ponteiro].gameObject.tag == "Lento")
                {
                    Car.speed = Random.Range(20, 30);
                }
                else if (Destinos2[ponteiro].gameObject.tag == "Medio")
                {
                    Car.speed = Random.Range(30, 40);
                }
                else if (Destinos2[ponteiro].gameObject.tag == "Rapido")
                {
                    Car.speed = Random.Range(40, 50);
                }

              
                ponteiro++;
              
                if (ponteiro > Destinos2.Count - 1)
                {
                    ponteiro = 0;
                    rota = Random.Range(1, 3);
                }
                Destiny = Destinos2[ponteiro];

                
                int pontAtual = ponteiro - 1;
                if (pontAtual < 0) { pontAtual = Destinos2.Count - 1; }
                MinhaDistancia(Destinos2[pontAtual].transform.position);
            }
        }
    }




    private void OnTriggerEnter(Collider passou)
    {
        if (passou.gameObject.tag == "Bandeira")
        {
            volta++;
        }
    }


    void DefinePos()
    {
        pos = 1;
        for (int i = 0; i < TodosCarros.Count; i++)
        {
            if (TodosCarros[i].GetComponent<Carro>().posDistancia > posDistancia)
            {
                pos++;
            }
        }
    }

    void MinhaDistancia(Vector3 ponteiroAnterio)
    {

        float disPont = Vector3.Distance(ponteiroAnterio, transform.position);

        posDistancia = (volta * 100000) + (ponteiro * 1000) + disPont;
    }
}