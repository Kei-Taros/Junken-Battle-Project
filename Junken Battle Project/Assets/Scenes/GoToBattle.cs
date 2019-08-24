using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToBattle : MonoBehaviour
{
    public void PushThisButton()
    {
        SceneManager.LoadScene("BattleScene");
    }


}