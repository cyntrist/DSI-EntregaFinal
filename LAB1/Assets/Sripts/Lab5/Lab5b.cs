using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


namespace Lab5b_namespace
{

    public class Lab5b : MonoBehaviour
    {

        VisualElement info;

        TextField input_name;
        TextField input_element;
        VisualElement input_Icon;


        Individuo individuoPrueba;


        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            info = root.Q("plantilla1");
            input_name = root.Q<TextField>("name_input");
            input_element = root.Q<TextField>("element_input");
            input_Icon = root.Q<VisualElement>("icon_view");

            individuoPrueba = new Individuo("Peruere", "Arlecchino");


            //Tarjeta tarjetaPrueba = new Tarjeta(info, individuoPrueba);

            input_name.RegisterCallback<ChangeEvent<string>>(CambioNombre);
            input_element.RegisterCallback<ChangeEvent<string>>(CambioElemento);
            //input_Icon.RegisterCallback<ChangeEvent<Sprite>>(CambioIcono);


            input_name.SetValueWithoutNotify(individuoPrueba.Nombre);
            input_element.SetValueWithoutNotify(individuoPrueba.Element);
           // input_Icon.SetValueWithoutNotify(individuoPrueba.Icon);

        }

        void CambioNombre(ChangeEvent<string> evt)
        {
            individuoPrueba.Nombre = evt.newValue;
        }

        void CambioElemento(ChangeEvent<string> evt)
        {
            individuoPrueba.Element = evt.newValue;
        }

        void CambioIcono(ChangeEvent<Sprite> evt)
        {
            individuoPrueba.Icon = evt.newValue;
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
