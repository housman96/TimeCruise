using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PierreArrested : MonoBehaviour
{

    public GameObject longueVueUnused;
    public GameObject longueVueUsed;
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
    public UnityEvent generique;


    public void launchPierreArrested()
    {
        StartCoroutine(pierreArrested());
    }

    public IEnumerator pierreArrested()
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

        capitaineDial.SetSentence("Qu'est-ce que tu fais fiston!", false);
        yield return new WaitForSeconds(4);
        capitaineDial.ResetSentence();

        capitaineDial.SetSentence("C'est ridicule !", false);
        yield return new WaitForSeconds(2);
        capitaineDial.ResetSentence();

        capitaineDial.SetSentence("Pause ma lonque-vue!", false);
        yield return new WaitForSeconds(2);
        capitaineDial.ResetSentence();

        yield return new WaitForSeconds(0.5f);
        longueVueUnused.SetActive(false);
        longueVueUsed.SetActive(true);

        GameObject targetObjectinspecteur = new GameObject();
        targetObjectinspecteur.transform.position = new Vector3(-6f, 2.91f);
        inspecteur.GetComponent<Pathfinding.AIDestinationSetter>().target = targetObjectinspecteur.transform;

        yield return new WaitForSeconds(2);
        inspecteur.GetComponent<Animator>().enabled = false;
        pierre.GetComponent<Animator>().enabled = false;

        inspecteur.GetComponent<SpriteRenderer>().sprite = inspecteurDroit;
        pierre.GetComponent<SpriteRenderer>().sprite = pierreGauche;


        inspecteurDial.SetSentence("C'est fini Pierre!", false);
        yield return new WaitForSeconds(3);
        inspecteurDial.ResetSentence();

        generique.Invoke();
    }
}
