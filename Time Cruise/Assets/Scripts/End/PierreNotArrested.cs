using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class PierreNotArrested : MonoBehaviour
{

    public GameObject capitaine;
    public GameObject inspecteur;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public DialogueTrigger capitaineDial;
    public DialogueTrigger inspecteurDial;
    public Sprite captainGauche;
    public GameObject pierre;
    public Sprite inspecteurDroit;
    public Sprite pierreGauche;

    public void launchPierreNotArrested()
    {
        StartCoroutine(pierreNotArrested());
    }

    public IEnumerator pierreNotArrested()
    {

        float alpha = 1;
        while (alpha > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alpha -= 0.02f;
            button1.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
            button2.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
            button3.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
            button1.GetComponentInChildren<Text>().color = new Color(0.2f, 0.2f, 0.2f, alpha);
            button2.GetComponentInChildren<Text>().color = new Color(0.2f, 0.2f, 0.2f, alpha);
            button3.GetComponentInChildren<Text>().color = new Color(0.2f, 0.2f, 0.2f, alpha);
        }
        button1.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        button2.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        button3.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        button1.GetComponentInChildren<Text>().color = new Color(0.2f, 0.2f, 0.2f, 0);
        button2.GetComponentInChildren<Text>().color = new Color(0.2f, 0.2f, 0.2f, 0);
        button3.GetComponentInChildren<Text>().color = new Color(0.2f, 0.2f, 0.2f, 0);

        capitaine.GetComponent<Animator>().enabled = false;
        capitaine.GetComponent<SpriteRenderer>().sprite = captainGauche;


        GameObject targetObjectinspecteur = new GameObject();
        targetObjectinspecteur.transform.position = new Vector3(-6f, 2.91f);
        inspecteur.GetComponent<Pathfinding.AIDestinationSetter>().target = targetObjectinspecteur.transform;

        yield return new WaitForSeconds(2);

        inspecteurDial.SetSentence("Pierre pouvez vous venir quelques secondes, j'ai quelque chose à vous dire avant que vous ne parliez à votre père.", false);
        inspecteur.GetComponent<Animator>().enabled = false;
        pierre.GetComponent<Animator>().enabled = false;
        inspecteur.GetComponent<SpriteRenderer>().sprite = inspecteurDroit;
        pierre.GetComponent<SpriteRenderer>().sprite = pierreGauche;
        yield return new WaitForSeconds(6);
        inspecteurDial.ResetSentence();
    }
}
