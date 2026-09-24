using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static int points;
    public Text textPoints;
    public Button buttonReiniciar;
    public GameObject CanvasDerrota;

    private void Start()
    {
        buttonReiniciar.onClick.AddListener(Reiniciar);
    }

    private void Update()
    {
        textPoints.text = "POINTS: " + points;
    }

    void Reiniciar()
    {
        SceneManager.LoadScene("VuforiaGame");
        Time.timeScale = 1;
    }

    public void Perdeu()
    {
        CanvasDerrota.SetActive(true);
    }

}
