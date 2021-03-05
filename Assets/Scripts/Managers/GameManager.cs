namespace redd096
{
    using UnityEngine;

    [AddComponentMenu("redd096/Singletons/Game Manager")]
    [DefaultExecutionOrder(-100)]
    public class GameManager : Singleton<GameManager>
    {
        [Header("Velocity to consider stopped Rigidbody")]
        public float velocitySleepingRigidbody = 0.5f;

        public UIManager uiManager { get; private set; }
        public Player player { get; private set; }
        public LevelManager levelManager { get; private set; }

        protected override void SetDefaults()
        {
            //get references
            uiManager = FindObjectOfType<UIManager>();
            player = FindObjectOfType<Player>();
            levelManager = FindObjectOfType<LevelManager>();
        }

        private void Update()
        {
            //only in scenes with player
            if(player != null)
            {
                //if press escape, pause or resume
                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    if (Time.timeScale > 0)
                        SceneLoader.instance.PauseGame();
                    else
                        SceneLoader.instance.ResumeGame();
                }
            }
        }
    }
}