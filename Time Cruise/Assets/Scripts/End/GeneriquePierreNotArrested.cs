using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GeneriquePierreNotArrested : MonoBehaviour
{

    public GameObject blackScreen;
    public GameObject capitaine;
    public GameObject pierre;
    public GameObject marie;
    public GameObject luigi;
    public GameObject julie;
    public GameObject jean;
    public GameObject isabelle;
    public GameObject paul;
    public GameObject detective;
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

        while (alpha < 1)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alpha += 0.02f;
            blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, alpha);
        }
        blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, 1);


        /*CAPITAINE*/
        text.text = "Le capitaine a survécu.";

        while (alphaText < 1)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText += 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
            capitaine.GetComponent<Image>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 1);
        capitaine.GetComponent<Image>().color = new Color(1, 1, 1, 1);

        yield return new WaitForSeconds(3);

        while (alphaText > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText -= 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
            capitaine.GetComponent<Image>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 0);
        capitaine.GetComponent<Image>().color = new Color(1, 1, 1, 0);

        yield return new WaitForSeconds(1);

        /*PIERRE*/

        text.text = "Pierre n'a pas été arrêté, et ne fut plus jamais impliqué dans quelques crimes qu'il soit.";

        while (alphaText < 1)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText += 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
            pierre.GetComponent<Image>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 1);
        pierre.GetComponent<Image>().color = new Color(1, 1, 1, 1);

        yield return new WaitForSeconds(3);

        while (alphaText > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText -= 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
            pierre.GetComponent<Image>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 0);
        pierre.GetComponent<Image>().color = new Color(1, 1, 1, 0);

        yield return new WaitForSeconds(1);

        /*JULIE*/

        text.text = "Julie continua un temps à cacher son homosexualité à ses parents.";

        while (alphaText < 1)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText += 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
            julie.GetComponent<Image>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 1);
        julie.GetComponent<Image>().color = new Color(1, 1, 1, 1);

        yield return new WaitForSeconds(3);

        while (alphaText > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText -= 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 0);

        text.text = "Après quelque temps elle partit, avec Marie, dans un pays plus tolérant. Sans l'aide financière de ses parents.";
        yield return new WaitForSeconds(1);

        while (alphaText < 1)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText += 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 1);

        yield return new WaitForSeconds(3);

        while (alphaText > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText -= 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
            julie.GetComponent<Image>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 0);
        julie.GetComponent<Image>().color = new Color(1, 1, 1, 0);

        yield return new WaitForSeconds(1);

        /*MARIE*/

        text.text = "Marie suivit Julie dans un autre pays.";

        while (alphaText < 1)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText += 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
            marie.GetComponent<Image>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 1);
        marie.GetComponent<Image>().color = new Color(1, 1, 1, 1);

        yield return new WaitForSeconds(3);

        while (alphaText > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText -= 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 0);

        text.text = "Elle continua à travailler pour de riche famille pour vivre.";
        yield return new WaitForSeconds(1);

        while (alphaText < 1)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText += 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 1);

        yield return new WaitForSeconds(3);

        while (alphaText > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText -= 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
            marie.GetComponent<Image>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 0);
        marie.GetComponent<Image>().color = new Color(1, 1, 1, 0);

        yield return new WaitForSeconds(1);


        /*JEAN*/

        text.text = "Jean continua d'essayer de se rapprocher de sa famille, et entretient une correspondance assidue avec Julie, Pierre et le Capitaine.";

        while (alphaText < 1)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText += 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
            jean.GetComponent<Image>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 1);
        jean.GetComponent<Image>().color = new Color(1, 1, 1, 1);

        yield return new WaitForSeconds(3);

        while (alphaText > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText -= 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
            jean.GetComponent<Image>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 0);
        jean.GetComponent<Image>().color = new Color(1, 1, 1, 0);

        yield return new WaitForSeconds(1);

        /*LUIGI*/

        text.text = "Luigi fut couvert de lauriers pour avoir récupéré l'argent de Pierre et fut promu.";

        while (alphaText < 1)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText += 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
            luigi.GetComponent<Image>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 1);
        luigi.GetComponent<Image>().color = new Color(1, 1, 1, 1);

        yield return new WaitForSeconds(3);

        while (alphaText > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText -= 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
            luigi.GetComponent<Image>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 0);
        luigi.GetComponent<Image>().color = new Color(1, 1, 1, 0);

        yield return new WaitForSeconds(1);



        /*PAUL*/

        text.text = "Paul aida Julie et Marie à quitter le pays, tout en leur envoyant le peut d'argent que Maurice ne lui escroque pas.";

        while (alphaText < 1)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText += 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
            paul.GetComponent<Image>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 1);
        paul.GetComponent<Image>().color = new Color(1, 1, 1, 1);

        yield return new WaitForSeconds(3);

        while (alphaText > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText -= 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 0);

        text.text = "En désespoir de cause, Paul déclara sa flamme à Isabelle.";
        yield return new WaitForSeconds(1);

        while (alphaText < 1)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText += 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 1);

        yield return new WaitForSeconds(3);

        while (alphaText > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText -= 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
            paul.GetComponent<Image>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 0);
        paul.GetComponent<Image>().color = new Color(1, 1, 1, 0);

        yield return new WaitForSeconds(1);

        /*ISABELLE*/

        text.text = "Isabelle étant encore engagé avec le Capitaine, elle refusa la demande de Paul.";

        while (alphaText < 1)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText += 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
            isabelle.GetComponent<Image>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 1);
        isabelle.GetComponent<Image>().color = new Color(1, 1, 1, 1);

        yield return new WaitForSeconds(3);

        while (alphaText > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText -= 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
            isabelle.GetComponent<Image>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 0);
        isabelle.GetComponent<Image>().color = new Color(1, 1, 1, 0);

        yield return new WaitForSeconds(1);

        /*DETECTIVE*/

        text.text = "Vous avez encore sauvé tout le monde, inspecteur.";

        while (alphaText < 1)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText += 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
            detective.GetComponent<Image>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 1);
        detective.GetComponent<Image>().color = new Color(1, 1, 1, 1);

        yield return new WaitForSeconds(3);

        while (alphaText > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText -= 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 0);

        text.text = "Encore une fois vous avez démontré votre réputation.";
        yield return new WaitForSeconds(1);

        while (alphaText < 1)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText += 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 1);

        yield return new WaitForSeconds(3);

        while (alphaText > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText -= 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 0);

        text.text = "Mais à quel prix?";
        yield return new WaitForSeconds(1);

        while (alphaText < 1)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText += 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 1);

        yield return new WaitForSeconds(3);

        while (alphaText > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            alphaText -= 0.02f;
            text.GetComponent<Text>().color = new Color(1, 1, 1, alphaText);
            detective.GetComponent<Image>().color = new Color(1, 1, 1, alphaText);
        }
        text.GetComponent<Text>().color = new Color(1, 1, 1, 0);
        detective.GetComponent<Image>().color = new Color(1, 1, 1, 0);

        yield return new WaitForSeconds(1);

    }
}
