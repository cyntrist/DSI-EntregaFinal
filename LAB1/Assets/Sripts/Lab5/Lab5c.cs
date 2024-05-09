using Lab5b_namespace;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;




namespace Lab5c_namespace

{
    public class Lab5c : MonoBehaviour
    {

        List<Individuo> individuos;
        Individuo selectIndividuo;


        VisualElement tarjeta1;
        VisualElement tarjeta2;
        VisualElement tarjeta3;
        VisualElement tarjeta4;



        TextField input_name;
        TextField input_element;



        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            tarjeta1 = root.Q("plantilla1");
            tarjeta2 = root.Q("plantilla2");
            tarjeta3 = root.Q("plantilla3");
            tarjeta4 = root.Q("plantilla4");

            Debug.Log("tarjeta1");


            input_name = root.Q<TextField>("name_input");
            input_element = root.Q<TextField>("element_input");

            //individuos = Database.getData();


            VisualElement info = root.Q("plantilla1");
            info.RegisterCallback<ClickEvent>(SeleccionTarjeta);
            info = root.Q("plantilla2");
            info.RegisterCallback<ClickEvent>(SeleccionTarjeta);
            info = root.Q("plantilla3");
            info.RegisterCallback<ClickEvent>(SeleccionTarjeta);
            info = root.Q("plantilla4");
            info.RegisterCallback<ClickEvent>(SeleccionTarjeta);



            input_name.RegisterCallback<ChangeEvent<string>>(CambioNombre);
            input_element.RegisterCallback<ChangeEvent<string>>(CambioElemento);



            InitializeUI();
        }


        void CambioNombre(ChangeEvent<string> evt)
        {
            selectIndividuo.Nombre = evt.newValue;
        }


        void CambioElemento(ChangeEvent<string> evt)
        {
            selectIndividuo.Element = evt.newValue;

        }


        void SeleccionTarjeta(ClickEvent e)
        {
            VisualElement tarjeta = e.target as VisualElement;


            Label name = tarjeta.Q<Label>("name");
            Label el = tarjeta.Q<Label>("element");
            VisualElement i = tarjeta.Q<VisualElement>("click");

            selectIndividuo = new Individuo(" ", " ");

            Debug.Log(el.text);

            selectIndividuo.Nombre = name.text;
            selectIndividuo.Element = el.text;
           // selectIndividuo.Icon = i;

            input_name.SetValueWithoutNotify(selectIndividuo.Nombre);
            input_element.SetValueWithoutNotify(selectIndividuo.Element);
        }

        void InitializeUI()
        {
            Tarjeta tar1 = new Tarjeta(tarjeta1, individuos[0]);
            Tarjeta tar2 = new Tarjeta(tarjeta2, individuos[1]);
            Tarjeta tar3 = new Tarjeta(tarjeta3, individuos[2]);
            Tarjeta tar4 = new Tarjeta(tarjeta4, individuos[3]);

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
