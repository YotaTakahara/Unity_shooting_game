using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public LifePanel panel;
    public air air;
    public GameObject airPlane;
    public Text text;

    void Update()
    {
        int c = CalcScore();
        int ans = air.Life();
        text.text = "Score " + c + "m" + "  倒した敵の数" + air.point + "体";
        panel.UpdateLife(ans);
    }

    int CalcScore()
    {
        return (int) airPlane.transform.position.z;
    }
}