using System.IO;
using UnityEditor;
using UnityEngine;

namespace CustomTool
{
    /// <summary>
    /// ����Ƶ����ʼ������
    /// </summary>
    public class AudioAutoSetting:AssetPostprocessor
    {
        public void OnPreprocessAudio()
        {
            AudioImporterSampleSettings settings = new AudioImporterSampleSettings();
            settings.loadType = AudioClipLoadType.Streaming;

            AudioImporter importer = (AudioImporter)assetImporter;
            importer.preloadAudioData = false;
            importer.defaultSampleSettings = settings;

            Debug.Log("��Ƶ��Դ�����������");
        }
    }

    /// <summary>
    /// ��ͼƬ����ʼ������
    /// </summary>
    public class AssetsAutoSetting : AssetPostprocessor
    {
        /// <summary>
        /// ��Ҫ�Ż���ͼƬռ�õ��ڴ��Լ�ͼƬռ�õ��ڴ�Ӱ��ͼƬ�ļ����ٶ�
        /// </summary>
        public void OnPreprocessTexture()
        {
            TextureImporter importer = (TextureImporter)assetImporter;
            Texture2D texture = GetTexture();
            int maxSide = GetLongSide(texture);
            int maxSize = 0;
            if(maxSide < 50)
            {
                maxSize = 32;
            }
            else if(maxSide < 100)
            {
                maxSize = 64;
            }
            else if(maxSide < 150)
            {
                maxSize = 128;
            }
            else if(maxSide < 300)
            {
                maxSize = 256;
            }
            else if(maxSide < 600)
            {
                maxSize = 512;
            }
            else
            {
                maxSize = 1024;
            }
            importer.maxTextureSize = maxSize;
            Debug.Log("ͼƬ��Դ�����������");
        }

        /// <summary>
        /// IO����ȡͼƬ
        /// </summary>
        private Texture2D GetTexture()
        {
            FileStream stream = new FileStream(assetPath, FileMode.Open);
            stream.Seek(0, SeekOrigin.Begin);
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, (int)stream.Length);
            stream.Close();
            stream.Dispose();
            stream = null;

            Texture2D t = new Texture2D(1, 1);
            t.LoadImage(bytes);
            return t;
        }

        /// <summary>
        /// ��ȡTexture����߳���
        /// </summary>
        /// <param name="texture"></param>
        /// <returns></returns>
        private int GetLongSide(Texture2D texture)
        {
            return texture.width > texture.height ? texture.width : texture.height;
        }
    }
}
