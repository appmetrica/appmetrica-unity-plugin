using UnityEditor;
using UnityEditor.Android;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Text;

namespace Io.AppMetrica.Editor {
    internal class ManifestProcessor : IPostGenerateGradleAndroidProject {
        private const string VERSION = "6.4.0";

        public int callbackOrder { get { return 0; } }
        
        public void OnPostGenerateGradleAndroidProject(string path) {
            var manifest = new AndroidManifest(Path.Combine(path, "src", "main", "AndroidManifest.xml"));
            manifest.SetMetaData("io.appmetrica.analytics.plugin_id", "unity-" + VERSION);
            manifest.Save();
        }
    }

    internal class AndroidManifest : XmlDocument {

        private string _path;
        protected XmlNamespaceManager nsMgr;
        public readonly string AndroidXmlNamespace = "http://schemas.android.com/apk/res/android";
    
        public AndroidManifest(string path) {
            _path = path;
            using (var reader = new XmlTextReader(_path)) {
                reader.Read();
                Load(reader);
            }
            nsMgr = new XmlNamespaceManager(NameTable);
            nsMgr.AddNamespace("android", AndroidXmlNamespace);
        }

        public void Save() {
            using (var writer = new XmlTextWriter(_path, new UTF8Encoding(false))) {
                writer.Formatting = Formatting.Indented;
                Save(writer);
            }
        }

        public void RemoveAllMetaData(string name) {
            var application = SelectSingleNode("/manifest/application") as XmlElement;
            var metaDatas = application.SelectNodes("meta-data");
            foreach (XmlElement metaData in metaDatas) {
                if (metaData.GetAttribute("android:name") == name) {
                    application.RemoveChild(metaData);
                }
            }
        }

        public void PutMetaData(string name, string value) {
            var metaData = CreateNode("element", "meta-data", "");
            metaData.Attributes.Append(CreateAndroidAttribute("name", name));
            metaData.Attributes.Append(CreateAndroidAttribute("value", value));

            var application = SelectSingleNode("/manifest/application") as XmlElement;
            application.AppendChild(metaData);
        }

        public void SetMetaData(string name, string value) {
            RemoveAllMetaData(name);
            PutMetaData(name, value);
        }

        private XmlAttribute CreateAndroidAttribute(string key, string value) {
            XmlAttribute attr = CreateAttribute("android", key, AndroidXmlNamespace);
            attr.Value = value;
            return attr;
        }
    }
}
