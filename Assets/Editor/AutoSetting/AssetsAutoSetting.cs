using System.IO;
using UnityEditor;
using UnityEngine;

namespace CustomTool
{
    /// <summary>
    /// 对音频做初始化设置
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

            Debug.Log("音频资源参数设置完成");
        }
    }

    /// <summary>
    /// 对图片做初始化设置
    /// </summary>
    public class AssetsAutoSetting : AssetPostprocessor
    {
        /// <summary>
        /// 主要优化对图片占用的内存以及图片占用的内存影响图片的加载速度
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
            Debug.Log("图片资源参数设置完成");
        }

        /// <summary>
        /// IO流读取图片
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
        /// 获取Texture的最长边长度
        /// </summary>
        /// <param name="texture"></param>
        /// <returns></returns>
        private int GetLongSide(Texture2D texture)
        {
            return texture.width > texture.height ? texture.width : texture.height;
        }
    }
}
