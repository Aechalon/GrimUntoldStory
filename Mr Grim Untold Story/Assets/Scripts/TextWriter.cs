using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextWriter : MonoBehaviour
{

    private static TextWriter instance;
    private List<textWriterSingle> txtWriteSingleList;



    private void Awake()
    {
        instance = this;
        txtWriteSingleList = new List<textWriterSingle>();  
    }
    public static void AddWriter_Static(Text uiText, string textToWrite, float tPC, bool inviChara)
    {
        instance.AddWriter(uiText, textToWrite, tPC, inviChara);
    }
    private void AddWriter(Text uiText, string textToWrite, float tPC, bool inviChara)
    {
        txtWriteSingleList.Add(new textWriterSingle(uiText, textToWrite, tPC, inviChara));
   
    }
    private void Update()
    {
            for (int i = 0; i < txtWriteSingleList.Count; i++)
            {
                bool destroyInstance = txtWriteSingleList[i].Update();
                if (destroyInstance)
                {
                    txtWriteSingleList.RemoveAt(i);
                    i--;
                }
                
               
            }

        
    }
    public class textWriterSingle
    {
        private Text uiText;
        private string textToWrite;
        private int characterIndex;
        private float tPC;
        private float timer;
        private bool inviCha;
        public textWriterSingle(Text uiText, string textToWrite, float tPC, bool inviChara) {


            this.uiText = uiText;
            this.textToWrite = textToWrite;
            this.tPC = tPC;
            this.inviCha = inviCha;
            characterIndex = 0;
        }
        

        public bool Update()
        {

                timer -= Time.deltaTime;
                while (timer <= 0f)
                {
                    timer += tPC;
                    characterIndex++;
                    string text = textToWrite.Substring(0, characterIndex);

                    if (inviCha)
                    {
                        text += "<color = #0000000" + textToWrite.Substring(characterIndex);
                    }
                    uiText.text = text;
                    if (characterIndex >= textToWrite.Length)
                    {
                        uiText = null;
                        return true;
                    }
                }
                return false;
            
        }
    }
     
}
