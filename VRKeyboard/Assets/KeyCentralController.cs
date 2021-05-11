using UnityEngine;
using TMPro;
public class KeyCentralController : MonoBehaviour
{
	//this has to be an input field rather than a text element although the script can be easily modified to use text elements, which you can adjust inside the update method.	
    public TMP_InputField UIElement;
	//the current text that is being added too by keys
    public string text;
	
	//this entire section is dedicated to spawning a numpad
	//this one is the actual characters
    public char[,] numberList;
    [Header("GameObject placement")] 
    public GameObject keyPrefab;

    public Transform canvas;
    
    public float keyPositionCoefficient;

    public float keyPositionYintercept;

    public float keyPositionXintercept;
    
    [SerializeField]
    private bool spawnKeys;
    private void Start()
    {

		//if in the editor it is set up so that the keys are spawned in by script, spawn them
        if(spawnKeys)
        {
            SetupKeyboardUSNumbers(numberList,3);
        }
    }

    private void SetupKeyboardUSNumbers(char[,] layoutVar,int collumns)
    {
        
        //current collumn
		int collumn = 0;
        //curent row
		int row = 0;
        foreach (char currentProcChar in numberList)
        {
			//spawn in the key with its text set up based on the input array
            GameObject currentProcessingKey = Instantiate(keyPrefab,new Vector3(keyPositionXintercept+collumn*keyPositionCoefficient,keyPositionCoefficient+row*keyPositionCoefficient,0),Quaternion.identity,canvas);
			//set the variable in the key script on the just spawned key
			currentProcessingKey.GetComponent<Key>().key = currentProcChar;
			//give the key a reference to this script
            currentProcessingKey.GetComponent<Key>().main = this;
            //increment collumn
			collumn++;
            if (collumn > collumns-1)
            {
                collumn = 0;
                row++;
                if (row > 3)
                {
                    break;
                }
            }
        }
    }

    private void Update()
    {
        UIElement.text = text;
    }
}
