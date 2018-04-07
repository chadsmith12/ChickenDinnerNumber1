﻿using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace ChickenDinnerNumber1.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        #region Setting Constants

        private const string PubgApiSettingsKey = "settings_key";
        private static readonly string PubgApiKeyDefault = string.Empty;

        #endregion

        public static string PubgApiKey
        {
            get => AppSettings.GetValueOrDefault(PubgApiSettingsKey, PubgApiKeyDefault);
            set => AppSettings.AddOrUpdateValue(PubgApiSettingsKey, value);
        }

    }
}
