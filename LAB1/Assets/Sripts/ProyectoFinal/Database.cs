using Lab5b_namespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PF
{

    public class Database : MonoBehaviour
    {

        public static List<Individuo> getData()
        {

            List<Individuo> datos = new List<Individuo>();


            Individuo Yae = new Individuo("Yae Miko", "Electro");
            Individuo Arle = new Individuo("Arlecchino", "Pyro");
            Individuo Furina = new Individuo("Furina", "Hydro");
            Individuo Ei = new Individuo("Ei", "Electro");
            Individuo Candace = new Individuo("Candace", "Hydro");
            Individuo Dehya = new Individuo("Dehya", "Pyro");
            Individuo Ning = new Individuo("Ningguang", "Geo");
            Individuo Beidou = new Individuo("Beidou", "Electro");



            Arle.setStats(90, 2247, 19437, 805, 105);
            Furina.setStats(81, 1322, 31881, 707, 133);
            Ning.setStats(60, 435, 11563, 397, 34);
            Beidou.setStats(60, 506, 13855, 526, 117);
            Candace.setStats(60, 752, 9702, 565, 117);
            Dehya.setStats(50, 321, 13999, 352, 32);
            Ei.setStats(90, 1673, 18524, 876, 66);
            Yae.setStats(81, 1891, 15560, 760, 370);

            datos.Add(Yae);
            Yae.ID = 0;
            datos.Add(Arle);   
            Arle.ID = 1;
            datos.Add(Furina);
            Furina.ID = 2;
            datos.Add(Ning);
            Ning.ID = 3;
            datos.Add(Beidou);  
            Beidou.ID = 4;
            datos.Add(Candace);
            Candace.ID = 5;
            datos.Add(Dehya);
            Dehya.ID = 6;
            datos.Add(Ei);
            Ei.ID = 7;


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