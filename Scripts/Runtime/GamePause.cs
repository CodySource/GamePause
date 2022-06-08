using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CodySource
{
    public class GamePause : MonoBehaviour
    {

        #region PROPERTIES

        /// <summary>
        /// Singleton
        /// </summary>
        public static GamePause instance { get; private set; } = null;

        /// <summary>
        /// Whether or not the game is currently paused
        /// </summary>
        public static bool isPaused { get; private set; } = false;

        /// <summary>
        /// Triggered whenever the game is pause
        /// </summary>
        public UnityEvent onPause = new UnityEvent();

        /// <summary>
        /// Triggered whenever the game is resumed
        /// </summary>
        public UnityEvent onResume = new UnityEvent();

        /// <summary>
        /// Triggered whenever the pause state is toggled
        /// </summary>
        public UnityEvent<bool> onPauseToggle = new UnityEvent<bool>();

        #endregion

        #region PUBLIC METHODS

        /// <summary>
        /// Pause the game
        /// </summary>
        public static void Pause()
        {
            isPaused = true;
            instance?.onPause?.Invoke();
        }

        /// <summary>
        /// Resume the game
        /// </summary>
        public static void Resume()
        {
            isPaused = false;
            instance?.onResume?.Invoke();
        }

        /// <summary>
        /// Toggle the pause state and return whether it is paused or not
        /// </summary>
        public static bool TogglePause()
        {
            isPaused = !isPaused;
            bool r = isPaused;
            instance?.onPauseToggle?.Invoke(r);
            return r;
        }

        #endregion

        #region PRIVATE METHODS

        /// <summary>
        /// Set the singleton instance
        /// </summary>
        private void Awake() => instance = instance ?? this;

        #endregion

    }
}