using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunKiiUNETThingy
{
    public class Config
    {
        public string keysite { get; set; }

        public bool titleGame { get; set; }
        public bool titleDemo { get; set; }
        public bool titleGameDlc { get; set; }
        public bool titleGameUpdate { get; set; }
        public bool titleSysApp { get; set; }
        public bool titleSysData { get; set; }
        public bool titleBackTitle { get; set; }

        public bool regJpn { get; set; }
        public bool regUsa { get; set; }
        public bool regEur { get; set; }
        public bool regChn { get; set; }
        public bool regKor { get; set; }
        public bool regTwn { get; set; }
        public bool regUnk { get; set; }

        public bool patchDemoTimeLimit { get; set; }
        public bool patchDlcUnlock { get; set; }

        public bool appAutoUpdateTitlekeys { get; set; }
        public bool appAutoLoadData { get; set; }

        public bool appDlIgnoreExistingContentFiles { get; set; }
        public bool appDlGroupDlsIntoSubfolders { get; set; }

        private const string CONFIG_KEYSITE = "keysite";

        private const string CONFIG_TITLE_GAME = "titleGame";
        private const string CONFIG_TITLE_DEMO = "titleDemo";
        private const string CONFIG_TITLE_DLC = "titleGameDlc";
        private const string CONFIG_TITLE_UPDATE = "titleGameUpdate";
        private const string CONFIG_TITLE_SYSAPP = "titleSysApp";
        private const string CONFIG_TITLE_SYSDATA = "titleSysData";
        private const string CONFIG_TITLE_BACKTITLE = "titleBackTitle";

        private const string CONFIG_REG_JPN = "regJpn";
        private const string CONFIG_REG_USA = "regUsa";
        private const string CONFIG_REG_EUR = "regEur";
        private const string CONFIG_REG_CHN = "regChn";
        private const string CONFIG_REG_KOR = "regKor";
        private const string CONFIG_REG_TWN = "regTwn";
        private const string CONFIG_REG_UNK = "regUnk";

        private const string CONFIG_PATCH_DEMO = "patchDemoTimeLimit";
        private const string CONFIG_PATCH_DLC = "patchDlcUnlock";

        private const string CONFIG_APP_AUTOUPDATE_TITLEKEYS = "appAutoUpdateTitlekeys";
        private const string CONFIG_APP_AUTOLOAD_DATA = "appAutoLoadData";

        private const string CONFIG_DL_IGNORE_EXISTING = "appDlIgnoreExistingContentFiles";
        private const string CONFIG_DL_GROUP_TITLES = "appDlGroupDlsIntoSubfolders";

        private const string BLANK_CONFIG = @"{""keysite"": """"}";

        public Config()
        {

            keysite = "";

            titleGame = true;
            titleDemo = true;
            titleGameDlc = true;
            titleGameUpdate = true;
            titleSysApp = true;
            titleSysData = true;
            titleBackTitle = true;

            regJpn = true;
            regUsa = true;
            regEur = true;
            regChn = true;
            regKor = true;
            regTwn = true;
            regUnk = true;

            patchDemoTimeLimit = true;
            patchDlcUnlock = true;

            appAutoUpdateTitlekeys = false;
            appAutoLoadData = false;
            appDlIgnoreExistingContentFiles = true;
            appDlGroupDlsIntoSubfolders = false;
        }

        public Config
            (
            string _keysite,
            bool _titleGame,
            bool _titleDemo,
            bool _titleGameDlc,
            bool _titleGameUpdate,
            bool _titleSysApp,
            bool _titleSysData,
            bool _titleBackTitle,
            bool _regJpn,
            bool _regUsa,
            bool _regEur,
            bool _regChn,
            bool _regKor,
            bool _regTwn,
            bool _regUnk,
            bool _patchDemoTimeLimit,
            bool _patchDlcUnlock,
            bool _appAutoUpdateTitlekeys,
            bool _appAutoLoadData,
            bool _appDlIgnoreExistingContentFiles,
            bool _appDlGroupDlsIntoSubfolders
            )
        {
            keysite = _keysite;

            titleGame = _titleGame;
            titleDemo = _titleDemo;
            titleGameDlc = _titleGameDlc;
            titleGameUpdate = _titleGameUpdate;
            titleSysApp = _titleSysApp;
            titleSysData = _titleSysData;
            titleBackTitle = _titleBackTitle;

            regJpn = _regJpn;
            regUsa = _regUsa;
            regEur = _regEur;
            regChn = _regChn;
            regKor = _regKor;
            regTwn = _regTwn;
            regUnk = _regUnk;

            patchDemoTimeLimit = _patchDemoTimeLimit;
            patchDlcUnlock = _patchDlcUnlock;

            appAutoUpdateTitlekeys = _appAutoUpdateTitlekeys;
            appAutoLoadData = _appAutoLoadData;

            appDlIgnoreExistingContentFiles = _appDlIgnoreExistingContentFiles;
            appDlGroupDlsIntoSubfolders = _appDlGroupDlsIntoSubfolders;
        }

        public Config(string fileName)
        {
            dynamic config;

            try
            {
                config = Utils.GetJsonObject(File.ReadAllText(fileName));

                // Check keysite has data
                if (config[CONFIG_KEYSITE] != null)
                    keysite = config[CONFIG_KEYSITE];
                else
                    keysite = "";

                // Check selection configs have data
                if (config[CONFIG_TITLE_GAME] != null)
                    titleGame = config[CONFIG_TITLE_GAME];
                else
                    titleGame = true;

                if (config[CONFIG_TITLE_DEMO] != null)
                    titleDemo = config[CONFIG_TITLE_DEMO];
                else
                    titleDemo = true;

                if (config[CONFIG_TITLE_DLC] != null)
                    titleGameDlc = config[CONFIG_TITLE_DLC];
                else
                    titleGameDlc = true;

                if (config[CONFIG_TITLE_UPDATE] != null)
                    titleGameUpdate = config[CONFIG_TITLE_UPDATE];
                else
                    titleGameUpdate = true;

                if (config[CONFIG_TITLE_SYSAPP] != null)
                    titleSysApp = config[CONFIG_TITLE_SYSAPP];
                else
                    titleSysApp = true;

                if (config[CONFIG_TITLE_SYSDATA] != null)
                    titleSysData = config[CONFIG_TITLE_SYSDATA];
                else
                    titleSysData = true;

                if (config[CONFIG_TITLE_BACKTITLE] != null)
                    titleBackTitle = config[CONFIG_TITLE_BACKTITLE];
                else
                    titleBackTitle = true;

                // Check region configs have data
                if (config[CONFIG_REG_JPN] != null)
                    regJpn = config[CONFIG_REG_JPN];
                else
                    regJpn = true;

                if (config[CONFIG_REG_USA] != null)
                    regUsa = config[CONFIG_REG_USA];
                else
                    regUsa = true;

                if (config[CONFIG_REG_EUR] != null)
                    regEur = config[CONFIG_REG_EUR];
                else
                    regEur = true;

                if (config[CONFIG_REG_CHN] != null)
                    regChn = config[CONFIG_REG_CHN];
                else
                    regChn = true;

                if (config[CONFIG_REG_KOR] != null)
                    regKor = config[CONFIG_REG_KOR];
                else
                    regKor = true;

                if (config[CONFIG_REG_TWN] != null)
                    regTwn = config[CONFIG_REG_TWN];
                else
                    regTwn = true;
                if (config[CONFIG_REG_UNK] != null)
                    regUnk = config[CONFIG_REG_UNK];
                else
                    regUnk = true;

                // Check patch configs have data
                if (config[CONFIG_PATCH_DEMO] != null)
                    patchDemoTimeLimit = config[CONFIG_PATCH_DEMO];
                else
                    patchDemoTimeLimit = true;

                if (config[CONFIG_PATCH_DLC] != null)
                    patchDlcUnlock = config[CONFIG_PATCH_DLC];
                else
                    patchDlcUnlock = true;

                // Check app configs have data

                if (config[CONFIG_APP_AUTOUPDATE_TITLEKEYS] != null)
                    appAutoUpdateTitlekeys = config[CONFIG_APP_AUTOUPDATE_TITLEKEYS];
                else
                    appAutoUpdateTitlekeys = false;

                if (config[CONFIG_APP_AUTOLOAD_DATA] != null)
                    appAutoLoadData = config[CONFIG_APP_AUTOLOAD_DATA];
                else
                    appAutoLoadData = false;

                if (config[CONFIG_DL_IGNORE_EXISTING] != null)
                    appDlIgnoreExistingContentFiles = config[CONFIG_DL_IGNORE_EXISTING];
                else
                    appDlIgnoreExistingContentFiles = true;

                if (config[CONFIG_DL_GROUP_TITLES] != null)
                    appDlGroupDlsIntoSubfolders = config[CONFIG_DL_GROUP_TITLES];
                else
                    appDlGroupDlsIntoSubfolders = false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveToFile(string fileName)
        {
            try
            {
                File.WriteAllText(Environment.CurrentDirectory + "\\" + fileName, this.ToJson());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
