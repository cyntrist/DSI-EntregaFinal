using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Lab5b_namespace
{

    public class Individuo : MonoBehaviour
    {

        public event Action Cambio;

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (nombre != value)
                {
                    nombre = value;
                    Cambio?.Invoke();
                }
            }
        }


        private string element;

        public string Element
        {
            get { return element; }
            set
            {
                if (element != value)
                {
                    element = value;
                    Cambio?.Invoke();
                }
            }
        }

        private Sprite icon;

        public Sprite Icon
        {
            get { return icon; }
            set
            {
                if(icon != value)
                {
                    icon = value;
                    Cambio?.Invoke();
                }
            }
        }


        private string icon_route;

        public string IconRoute
        {
            get { return icon_route; }
            set { 
                if(icon_route != value) { 
                    icon_route = value; 
                    Cambio?.Invoke(); }
            }
        }


        public Individuo(string nombre, string element)
        {
            this.nombre = nombre;
            this.element = element;
            icon = null;
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