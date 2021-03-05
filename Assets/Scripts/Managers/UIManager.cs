namespace redd096
{
    using UnityEngine;
    using UnityEngine.UI;

    [AddComponentMenu("redd096/MonoBehaviours/UI Manager")]
    public class UIManager : MonoBehaviour
    {
        [Header("Menu")]
        [SerializeField] GameObject pauseMenu = default;
        [SerializeField] GameObject endMenu = default;

        [Header("End Text")]
        [SerializeField] Text endText = default;
        [SerializeField] string winString = "YOU WON!";
        [SerializeField] string loseString = "YOU LOST...";

        void Start()
        {
            //by default, hide
            PauseMenu(false);
            EndMenu(false, true);
        }

        public void PauseMenu(bool active)
        {
            if (pauseMenu == null)
            {
                Debug.LogWarning("There is no pause menu");
                return;
            }

            //active or deactive pause menu
            pauseMenu.SetActive(active);
        }

        public void EndMenu(bool active, bool win)
        {
            //be sure pause menu is deactivated
            if (active)
            {
                PauseMenu(false);

                //set text
                endText.text = win ? winString : loseString;
            }

            //active or deactive
            endMenu.SetActive(active);
        }
    }
}