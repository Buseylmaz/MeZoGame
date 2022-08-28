using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class IntroScene : MonoBehaviour
{
    public GameObject textBox;
    public GameObject timeDisplay;
    public GameObject placeDisplay;

    void Start()
    {
        StartCoroutine(IntroBegin());
    }

    IEnumerator IntroBegin()
    {
        yield return new WaitForSeconds(4f);
        placeDisplay.SetActive(true);
        timeDisplay.SetActive(true);
        yield return new WaitForSeconds(4f);
        placeDisplay.SetActive(false);
        timeDisplay.SetActive(false);

        yield return new WaitForSeconds(1f);
        textBox.GetComponent<Text>().text = "Kim olduğumu nerede olduğumu bilmiyorum.";
        
        yield return new WaitForSeconds(3f);
        textBox.GetComponent<Text>().text = "Doğrusu hangi tarihteyiz onu da bilmiyorum..";
        
        yield return new WaitForSeconds(4f);
        textBox.GetComponent<Text>().text = "Tek hatırladığım hastane gibi bir yer ve doktorlar tarafından sürekli içirilen ilaçlar";

        yield return new WaitForSeconds(4f);
        textBox.GetComponent<Text>().text = "Peki bu öldürdüğüm canlılar nedir?";

        yield return new WaitForSeconds(4f);
        textBox.GetComponent<Text>().text = "Yaşayan tek canlı ben miyim? Acaba benden başka birileri var mı? ";

        yield return new WaitForSeconds(6f);
        textBox.GetComponent<Text>().text = "Mektup da okuduğuma göre güvenli bir bölge varmış.Peki ben güvenli bölgeyi bulabilecek miyim?";

        yield return new WaitForSeconds(5f);
        textBox.GetComponent<Text>().text = "";

        yield return new WaitForSeconds(20f);
        SceneManager.LoadScene(1);


    }
}
