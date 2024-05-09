using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;



namespace Lab5b_namespace 
{

    public class Tarjeta : MonoBehaviour
    {
        Individuo miIndividuo;

        VisualElement tarjetaroot;


        Label nombreLabel;
        Label elementLabel;
        VisualElement icon;


        public Tarjeta(VisualElement tarjetaroot, Individuo ind)
        {
            this.tarjetaroot = tarjetaroot;
            this.miIndividuo = ind;


            nombreLabel = tarjetaroot.Q<Label>("name");
            elementLabel = tarjetaroot.Q<Label>("element");
            //icon = tarjetaroot.Q<VisualElement>("click");

            UpdateUI();

            miIndividuo.Cambio += UpdateUI;
        }


        void UpdateUI()
        {
            nombreLabel.text = miIndividuo.Nombre;
            elementLabel.text = miIndividuo.Element;
            //icon.style.backgroundImage = new StyleBackground(miIndividuo.Icon);
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
