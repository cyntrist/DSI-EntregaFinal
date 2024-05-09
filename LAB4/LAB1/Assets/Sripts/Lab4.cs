using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class Lab4 : MonoBehaviour
{

    private void OnEnable()
    {
        VisualElement rootve = GetComponent<UIDocument>().rootVisualElement;


        VisualElement cunty = rootve.Q<VisualElement>("obj");

        Debug.Log(cunty.name);


        // TEXTO ENRIQUECIDO
        Label txt = cunty.Q<Label>("cunt");

        // Debug.Log(txt.name);
        cunty.style.backgroundColor = UnityEngine.Color.white;

        txt.text = @" <rotate=""45""> cuntiness </rotate>
        ";


        // PSEUDO CLASE EN LAB2


        // TEMPLATES CON PSEUDOCLASES

        VisualElement base1 = rootve.Q<VisualElement>("base");

       // VisualElement art1 = base.Q<VisualElement>("artif");

        // carga la pseudoclase
        VisualTreeAsset asset1 = Resources.Load<VisualTreeAsset>("Lab4/ArtifactsTemplate");

        // instancia la pseudoclase +  adicion a artifacts
        VisualElement artifactInstance = asset1.Instantiate();

       // artifactInstance.transform.position = new Vector3(200, 200,20);

        base1.Add(artifactInstance);


        Sprite flower = Resources.Load<Sprite>("thunderingfury");

        VisualElement flowerART = artifactInstance.Q("artif");
        flowerART.style.backgroundImage = new StyleBackground(flower);

        //Debug.Log(artifactInstance.transform.position);




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


//public class Lab4d : VisualElement
//{


//}

//public new class UxmlFactory : UxmlFactory<Lab4d, UxmlTraits> { };

//public new class UxmlTraits1 : VisualElement.UxmlTraits
//{

//}
