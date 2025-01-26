using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using UnityEngine;

namespace Io.AppMetrica.Editor {
    internal class AppMetricaSettings {
        
        private const string Filename = "ProjectSettings/AppMetricaSettings.xml";
        private static Dictionary<string, string> _inMemoryStorage;
        private static readonly object LockObject = new object();
        private static readonly FileSystemWatcher Watcher = new FileSystemWatcher(
            "ProjectSettings",
            "AppMetricaSettings.xml"
        );

        public AppMetricaSettings() {
            CreateFileIfNotExist();
            StartSettingsWatcher();
        }

        public void SetInt(string name, int value) {
            lock (LockObject) {
                LoadIfEmpty();
                _inMemoryStorage[name] = value.ToString();
                Save();
            }
        }

        public void SetBool(string name, bool value) {
            lock (LockObject) {
                LoadIfEmpty();
                _inMemoryStorage[name] = value.ToString();
                Save();
            }
        }

        public void SetFloat(string name, float value) {
            lock (LockObject) {
                LoadIfEmpty();
                _inMemoryStorage[name] = value.ToString(CultureInfo.InvariantCulture);
                Save();
            }
        }

        public void SetString(string name, string value) {
            lock (LockObject) {
                LoadIfEmpty();
                _inMemoryStorage[name] = value;
                Save();
            }
        }

        public int GetInt(string name, int defaultValue = 0) {
            LoadIfEmpty();
            return int.TryParse(GetString(name, defaultValue.ToString()), out var result) ? result : defaultValue;
        }

        public bool GetBool(string name, bool defaultValue = false) {
            LoadIfEmpty();
            return bool.TryParse(GetString(name, defaultValue.ToString()), out var result) ? result : defaultValue;
        }

        public float GetFloat(string name, float defaultValue = 0.0f) {
            LoadIfEmpty();
            return float.TryParse(GetString(name, defaultValue.ToString(CultureInfo.InvariantCulture)), out var result) ? result : defaultValue;
        }

        public string GetString(string name, string defaultValue = "") {
            lock (LockObject) {
                LoadIfEmpty();
                return _inMemoryStorage.GetValueOrDefault(name, defaultValue);
            }
        }
        
        internal void DisableWatcher() {
            if (Watcher != null) {
                Watcher.EnableRaisingEvents = false;
            }
        }
        
        internal void EnableWatcher() {
            if (Watcher != null) {
                Watcher.EnableRaisingEvents = true;
            }
        }

        private static void Load() {
            lock (LockObject) {
                try {
                    using (var reader = XmlReader.Create(Filename)) {
                        reader.ReadStartElement("appMetricaSettings");
                        while (reader.Read()) {
                            if (reader.NodeType == XmlNodeType.Element) {
                                var name = reader.GetAttribute("name");
                                var value = reader.GetAttribute("value");
                                if (name != null) _inMemoryStorage[name] = value;
                            }
                        }
                    }
                } catch (Exception e) {
                    Debug.LogException(e);
                }
            }
        }

        private static void LoadIfEmpty() {
            lock (LockObject) {
                if (_inMemoryStorage != null) return;
                _inMemoryStorage = new Dictionary<string, string>();
                Load();
            }
        }

        private static void Reload() {
            lock (LockObject) {
                _inMemoryStorage.Clear();
                Load();
            }
        }

        private static void Save() {
            lock (LockObject) {
                try {
                    using (var xmlWriter = XmlWriter.Create(Filename, new XmlWriterSettings() {
                               Encoding = new UTF8Encoding(),
                               Indent = true,
                               IndentChars = "  ",
                               NewLineChars = "\n",
                               NewLineHandling = NewLineHandling.Replace
                           })) {
                        xmlWriter.WriteStartElement("appMetricaSettings");
                        if (_inMemoryStorage != null) {
                            foreach (var key in _inMemoryStorage.Keys) {
                                var value = _inMemoryStorage[key];
                                xmlWriter.WriteStartElement("appMetricaSetting");

                                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value)) {
                                    xmlWriter.WriteAttributeString("name", key);
                                    xmlWriter.WriteAttributeString("value", value);
                                }

                                xmlWriter.WriteEndElement();
                            }
                        }

                        xmlWriter.WriteEndElement();
                    }
                }
                catch (Exception e) {
                    Debug.LogException(e);
                }
            }
        }
        
        private void CreateFileIfNotExist() {
            lock (LockObject) {
                if (!File.Exists(Filename)) {
                    Save();
                }
            }
        }
        
        private void StartSettingsWatcher() {
            Watcher.NotifyFilter = NotifyFilters.LastWrite;
            Watcher.EnableRaisingEvents = true;
            Watcher.Changed += (sender, eventArgs) => {
                Reload();
            };
        }
    }
}
