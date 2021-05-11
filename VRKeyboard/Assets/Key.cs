using TMPro;
using UnityEngine;

public class Key : MonoBehaviour
{
	//this is the "boss" of all the keys
    public KeyCentralController main;
    //this is the character that this particular key will talk about
    public char key;
    [SerializeField]
    private TMP_InputField text;
    //this function will be triggered when the UI element is triggered
    public void TriggerOnClick()
    {
        if (key.ToString() == "d")
        {
            main.text = main.text.Remove(main.text.Length - 1, 1);
        }
        else
        {
            main.text = main.text + key;
        }
    }
}
