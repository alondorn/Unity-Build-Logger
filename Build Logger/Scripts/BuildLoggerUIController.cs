using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AlonDorn.BuildLogger
{
    public class BuildLoggerUIController : MonoBehaviour
    {

        [SerializeField] Text _logUIText;

        BuildLogger _buildLogger;

        private void Awake()
        {
            if (_logUIText == null)
            {
                _logUIText = GetComponent<Text>();
                if (_logUIText == null)
                {
                    Debug.Log("BuildLogger: logUIText field is empty.");
                    return;
                } 
            }
            _buildLogger = new BuildLogger(_logUIText);
        }


        public void ClearLogText()
        {
            if (_buildLogger != null)
            {
                _buildLogger.ClearLogText();
            }
        }

        private void OnDestroy()
        {
            if (_buildLogger != null)
            {
                _buildLogger.Dispose();
                _buildLogger = null;
            }
        }


    }
}
