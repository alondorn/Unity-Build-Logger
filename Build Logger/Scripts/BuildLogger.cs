using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AlonDorn.BuildLogger
{
    public class BuildLogger : IDisposable
    {
        private Text _logUIText;


        public BuildLogger(Text logUIText)
        {
            _logUIText = logUIText;
            Application.logMessageReceived += OnLogReceived;
        }


        void OnLogReceived(string condition, string stackTrace, LogType type)
        {
            if (_logUIText == null || !_logUIText.IsActive())
            {
                return;
            }

            string logColor;
            switch (type)
            {
                case LogType.Error:
                    logColor = "#FF0000"; //red
                    break;
                case LogType.Warning:
                    logColor = "#FFEF00"; //yellow
                    break;
                default:
                    logColor = "#FFFFFF"; //white
                    break;
            }
            string openMarkUp = $"<color={logColor}>";
            string closeMarkUp = $"</color>";
            string finalText = $"{openMarkUp}- {condition} - {type.ToString()}{closeMarkUp}";// - {stackTrace}

            _logUIText.text += finalText + "\n\n";
        }



        public void ClearLogText()
        {
            _logUIText.text = "";
        }


        public void Dispose()
        {
            Application.logMessageReceived -= OnLogReceived;
            _logUIText = null;
        }
    }
}
