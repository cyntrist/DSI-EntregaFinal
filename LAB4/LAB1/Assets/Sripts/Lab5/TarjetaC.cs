using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;



namespace Lab5b_namespace
{
    public class TarjetaC : MonoBehaviour
    {

        Individuo miIndividuo;

        VisualElement tarjetaroot;


        Label nombreLabel;
        Label elementLabel;


        public TarjetaC(VisualElement tarjetaroot, Individuo ind)
        {
            this.tarjetaroot = tarjetaroot;
            this.miIndividuo = ind;


            nombreLabel = tarjetaroot.Q<Label>("name");
            elementLabel = tarjetaroot.Q<Label>("element");
            tarjetaroot.userData = miIndividuo;

            tarjetaroot
                .Query(className: "tarjeta")
                .Descendents<VisualElement>()
                .ForEach(elem => elem.pickingMode = PickingMode.Ignore);

            UpdateUI();

            miIndividuo.Cambio += UpdateUI;
        }


        void UpdateUI()
        {
            nombreLabel.text = miIndividuo.Nombre;
            elementLabel.text = miIndividuo.Element;
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
