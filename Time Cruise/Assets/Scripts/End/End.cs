using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour
{

    public GameObject inspecteur;
    public GameObject capitaine;
    public GameObject pierre;
    public GameObject tapis;
    public GameObject key;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public DialogueTrigger capitaineDial;
    public DialogueTrigger pierreDial;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(end());
    }

    public IEnumerator end()
    {
        yield return new WaitForSeconds(1);

        /*CACHER SOUS LE TAPIS*/

        GameObject targetObjectCapitaine = new GameObject();
        targetObjectCapitaine.transform.position = new Vector3(-0.24f, 2.1f);
        capitaine.GetComponent<Pathfinding.AIDestinationSetter>().target = targetObjectCapitaine.transform;

        yield return new WaitForSeconds(1);

        tapis.SetActive(false);
        yield return new WaitForSeconds(1);
        key.SetActive(true);
        yield return new WaitForSeconds(1);
        key.SetActive(false);
        tapis.SetActive(true);

        yield return new WaitForSeconds(1);

        capitaineDial.SetSentence("Et voilà personne n'ira la chercher ici.");
        yield return new WaitForSeconds(5);
        capitaineDial.ResetSentence();

        capitaineDial.SetSentence("Ho inspecteur, je ne vous avez pas vu.");
        yield return new WaitForSeconds(5);
        capitaineDial.ResetSentence();

        capitaineDial.SetSentence("Pouvez vous sortir s'il-vous-plait? Mon fils ne devrait pas tarder.");
        yield return new WaitForSeconds(5);
        capitaineDial.ResetSentence();

        GameObject targetObjectinspecteur = new GameObject();
        targetObjectinspecteur.transform.position = new Vector3(-14.5f, 5.4f);
        inspecteur.GetComponent<Pathfinding.AIDestinationSetter>().target = targetObjectinspecteur.transform;

        GameObject targetObjectPierre = new GameObject();
        targetObjectPierre.transform.position = new Vector3(-3f, 2.1f);
        pierre.GetComponent<Pathfinding.AIDestinationSetter>().target = targetObjectPierre.transform;

        yield return new WaitForSeconds(3);
        pierreDial.SetSentence("Bonjour Inspecteur.", false);
        yield return new WaitForSeconds(3);
        pierreDial.ResetSentence();


        float alpha = 0;
        while (alpha < 1)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alpha += 0.02f;
            button1.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
            button2.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
            button3.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
            button1.GetComponentInChildren<Text>().color = new Color(0.2f, 0.2f, 0.2f, alpha);
            button2.GetComponentInChildren<Text>().color = new Color(0.2f, 0.2f, 0.2f, alpha);
            button3.GetComponentInChildren<Text>().color = new Color(0.2f, 0.2f, 0.2f, alpha);
        }
        button1.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        button2.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        button3.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        button1.GetComponentInChildren<Text>().color = new Color(0.2f, 0.2f, 0.2f, 1);
        button2.GetComponentInChildren<Text>().color = new Color(0.2f, 0.2f, 0.2f, 1);
        button3.GetComponentInChildren<Text>().color = new Color(0.2f, 0.2f, 0.2f, 1);

    }

}
