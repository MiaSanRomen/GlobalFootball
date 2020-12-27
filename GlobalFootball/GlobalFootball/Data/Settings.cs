using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GlobalFootball.Data
{
    [Serializable]
    public class Settings
    {
        public LanguageEnum Language = LanguageEnum.English;
        public bool MusicOn = true;

        private string _backColor = "#000000";
        public string BackColor
        {
            get { return _backColor; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                _backColor = value;
            }
        }
    }
}
