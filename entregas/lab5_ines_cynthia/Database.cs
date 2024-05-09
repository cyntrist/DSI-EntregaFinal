using Lab5b_namespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Lab5c_namespace
{

    public class Database : MonoBehaviour
    {

        public static List<Individuo> getData()
        {

            List<Individuo> datos = new List<Individuo>();


            Individuo Yae = new Individuo("Yae Miko", "Electro");
            Individuo Arle = new Individuo("Arlecchino", "Pyro");
            Individuo Furina = new Individuo("Furina", "Hydro");
            Individuo Lynette = new Individuo("Lynette", "Anemo");

            Sprite y = Resources.Load<Sprite>("electro");
            Sprite a = Resources.Load<Sprite>("pyro");
            Sprite f = Resources.Load<Sprite>("hydro");
            Sprite l = Resources.Load<Sprite>("anemo");

            Yae.Icon = y;
            Arle.Icon = a;
            Furina.Icon = f;
            Lynette.Icon = l;

            datos.Add(Yae);
            datos.Add(Arle);    
            datos.Add(Furina);
            datos.Add(Lynette);

            return datos;

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


}