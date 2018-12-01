using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CaptainDead : MonoBehaviour
{
    public GameObject longueVueUnused;
    public GameObject longueVueUsed;
    public GameObject capitaineDead;
    public GameObject capitaine;
    public GameObject inspecteur;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public DialogueTrigger capitaineDial;
    public DialogueTrigger inspecteurDial;
    public GameObject pierre;
    public Sprite inspecteurDroit;
    public Sprite pierreGauche;

    public void captainDead()
    {
        StartCoroutine(captainDeadEnum());
    }

    public IEnumerator captainDeadEnum()
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


        capitaineDial.SetSentence("Qu'est-ce que tu fais fiston!", false);
        yield return new WaitForSeconds(4);
        capitaineDial.ResetSentence();

        capitaineDial.SetSentence("C'est ridicule !", false);
        yield return new WaitForSeconds(2);
        capitaineDial.ResetSentence();

        capitaineDial.SetSentence("Pause ma lonque-vue!", false);
        yield return new WaitForSeconds(2);
        capitaineDial.ResetSentence();

        capitaineDial.SetSentence("NONNNNNNNNN!", false);
        yield return new WaitForSeconds(2);
        capitaineDial.ResetSentence();

        yield return new WaitForSeconds(0.5f);
        longueVueUnused.SetActive(false);
        longueVueUsed.SetActive(true);
        capitaine.SetActive(false);
        capitaineDead.SetActive(true);

        GameObject targetObjectinspecteur = new GameObject();
        targetObjectinspecteur.transform.position = new Vector3(-6f, 2.91f);
        inspecteur.GetComponent<Pathfinding.AIDestinationSetter>().target = targetObjectinspecteur.transform;

        yield return new WaitForSeconds(2);

        inspecteurDial.SetSentence("C'est fini Pierre!", false);
        inspecteur.GetComponent<Animator>().enabled = false;
        pierre.GetComponent<Animator>().enabled = false;
        inspecteur.GetComponent<SpriteRenderer>().sprite = inspecteurDroit;
        pierre.GetComponent<SpriteRenderer>().sprite = pierreGauche;
        yield return new WaitForSeconds(3);
        inspecteurDial.ResetSentence();
    }
}
