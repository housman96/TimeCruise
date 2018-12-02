using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GeneriqueCaptainDead : MonoBehaviour
{
    public GameObject blackScreen;
    public GameObject capitaine;
    //public GameObject pierre;
    //public GameObject marie;
    //public GameObject luigi;
    //public GameObject julie;
    //public GameObject jean;
    //public GameObject isabelle;
    //public GameObject paul;
    //public GameObject detective;
    public Text text;

    public void launchGenerique()
    {
        StartCoroutine(generique());
    }

    public IEnumerator generique()
    {
        yield return new WaitForSeconds(1);


        float alpha = 0;
        float alphaText = 0;
        //float alphaPerso = 0;

        while (alpha < 1)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alpha += 0.02f;
            blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, alpha);
        }
        blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, 1);


        /*CAPITAINE*/
        text.text = "Le capitaine n'a pas survecu à ses blessures.";

        while (alphaText < 1)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText += 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
            capitaine.GetComponent<Image>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 1);
        capitaine.GetComponent<Image>().color = new Color(1, 1, 1, 1);

    }
}
