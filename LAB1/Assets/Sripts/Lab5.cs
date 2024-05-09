using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Lab5 : MonoBehaviour
{
    VisualElement character_selector;
    VisualElement character_info;

    TextField input_nombre;

    TextField input_element;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        character_selector = root.Q("info");
        input_nombre = root.Q<TextField>("name_input");
        input_element = root.Q<TextField>("element_input");
        character_info = root.Q("info");

        character_info.RegisterCallback<ClickEvent>(SeleccionIndividuo);
        input_nombre.RegisterCallback<ChangeEvent<string>>(CambioNombre);
        input_element.RegisterCallback<ChangeEvent<string>> (CambioElemento);
        Debug.Log("hola");


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SeleccionIndividuo(ClickEvent evt)
    {
        string name = character_info.Q<Label>("name").text;
        string element = character_info.Q<Label>("element").text;

        input_nombre.SetValueWithoutNotify(name);
        input_element.SetValueWithoutNotify(element);


    }


    void CambioNombre(ChangeEvent<string> evt)
    {
        Label nombreLabel = character_info.Q<Label>("name");
        nombreLabel.text = evt.newValue;

        Debug.Log(nombreLabel);
    }

    void CambioElemento(ChangeEvent<string> evt)
    {
        Label nombreLabel = character_info.Q<Label>("element");
        nombreLabel.text = evt.newValue;
    }
}
