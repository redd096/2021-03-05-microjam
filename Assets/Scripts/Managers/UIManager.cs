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

        void Start()
        {
            //by default, hide
            PauseMenu(false);
            EndMenu(false);
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

        public void EndMenu(bool active)
        {
            //be sure pause menu is deactivated
            if (active)
                PauseMenu(false);

            //active or deactive
            endMenu.SetActive(active);
        }
    }
}