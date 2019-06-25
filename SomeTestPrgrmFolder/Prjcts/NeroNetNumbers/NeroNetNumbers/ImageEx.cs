using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using Image = System.Drawing.Image;

namespace NeroNetNumbers
{
    public static class ImageEx
    {
        /// <summary>
        /// Программа на основе нейронной сети, 
        /// определяет символы от 0 - 9.
        /// </summary>

        public static int[,] ToByte(this Image img) // перобразование картинки в массив из единиц и нулей. 
            // где 0 это белый цвет а 1 черный
        {
            //TODO: переделать на определение красного цвета, для анализа символа доктора (красный крест)
            var bmp = new Bitmap(img);
            int[,] mass = new int[bmp.Width, bmp.Height];

            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width;x++)
                {
                    var IsWhite = bmp.GetPixel(x, y).R >= 230 && bmp.GetPixel(x, y).G >= 230 && bmp.GetPixel(x, y).B >= 230;
                    mass[x, y] = IsWhite ? 0 : 1; 
                }
            }
            return mass;

        }

        public static Image ToImage (this int [,] img) // обратно конвертируем двоичный код в изображение но уже черно белое
        {
            
            var bmp = new Bitmap(img.GetLength(0), img.GetLength(1));
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    bmp.SetPixel(x, y, img[x, y] == 1 ? Color.Black : Color.White);
                }
            }

            return (Image)bmp;
        }

        public static int[,] СutNumber(this int[,] bytes) // обрезаем цифру для распознания
        {
            var r = getRect(bytes);
            var mass = new int[r.Width, r.Height];
            for (int y = 0; y < mass.GetLength(1); y++)
            {
                for (int x = 0; x < mass.GetLength(0); x++)
                {
                    mass[x, y] = bytes[x + r.X, y + r.Y];
                }
            }
            return mass;
        }

        public static Image ScaleImage(this Image source, int width, int height)// Масштабирование картинки до заданного размера.
        {
            
            /// <summary>
            /// Масштабирование картинки до заданного размера.
            /// </summary>
            /// <param name="source"> Исходное изображение. </param>
            /// <param name="width"> Ширина целевого изображения. </param>
            /// <param name="height"> Высота целевого изображения. </param>
            /// <returns> Масштабированное изображение. </returns>
            Image dest = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(dest))
            {
                gr.FillRectangle(Brushes.White, 0, 0, width, height); //Очищаем экран
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                float srcwidth = source.Width;
                float srcheight = source.Height;
                float dstwidth = width;
                float dstheight = height;

                if (srcwidth <= dstwidth && srcheight <= dstheight)  // Исходное изображение меньше целевого
                {
                    int left = (width - source.Width) / 2;
                    int top = (height - source.Height) / 2;
                    gr.DrawImage(source, left, top, source.Width, source.Height);
                }
                else if (srcwidth / srcheight > dstwidth / dstheight)  // Пропорции исходного изображения более широкие
                {
                    float cy = srcheight / srcwidth * dstwidth;
                    float top = ((float)dstheight - cy) / 2.0f;
                    if (top < 1.0f) top = 0;
                    gr.DrawImage(source, 0, top, dstwidth, cy);
                }
                else  // Пропорции исходного изображения более узкие
                {
                    float cx = srcwidth / srcheight * dstheight;
                    float left = ((float)dstwidth - cx) / 2.0f;
                    if (left < 1.0f) left = 0;
                    gr.DrawImage(source, left, 0, cx, dstheight);
                }

                return dest;
            }

        } // 

        public static int[,] ToInput(this Image source , int width, int height)
        {
            return source.ToByte().СutNumber().ToImage().ScaleImage(width,height).ToByte();
        }

        private static Rectangle GetRect(int[,] bytes)
        {
          //  var img = new Bitmap(Image.FromFile(@"C:\1.jpg"));

            int x1 = 10;
            int x2 = 50;
            int y1 = 10;
            int y2 = 50;

            int width = x2 - x1 + 1;
            int height = y2 - y1 + 1;

            var result = new Bitmap(width, height);

            for (int i = x1; i <= x2; i++)
                for (int j = y1; j <= y2; j++)
                    result.SetPixel(i - x1, j - y1, img.GetPixel(i, j));

            result.Save(@"C:\2.jpg")
        }
    }
}

