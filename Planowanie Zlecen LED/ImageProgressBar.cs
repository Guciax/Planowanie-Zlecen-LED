using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Planowanie_Zlecen_LED
{
    public class ImageProgressBar
    {
        private static Color GetFillColor(float progress)
        {
            if (progress < 0.15) return Color.FromArgb(255, 192, 57, 43);
            if (progress < 0.30) return Color.FromArgb(255, 230, 126, 34);
            if (progress < 0.45) return Color.FromArgb(255, 241, 196, 15);
            if (progress < 0.6) return Color.FromArgb(255, 22, 160, 133);
            if (progress < 0.6) return Color.FromArgb(255, 39, 174, 96);
            return Color.FromArgb(255, 46, 204, 113);
        }

        private static Color ColorFromHex(string value)
        {
            return System.Drawing.ColorTranslator.FromHtml(value);
        }

        public static void CreateProgressbar2(float progress, int amount, DataGridViewImageCell cell, MST.MES.Colors.PaletteStruct clr)
        {
            Bitmap imageBar = new Bitmap(cell.Size.Width, cell.Size.Height);
            int borderWidth = 2;
            Rectangle cellBounds = new Rectangle(0, 0, cell.Size.Width, cell.Size.Height);
            Rectangle insideBorder = new Rectangle(borderWidth, borderWidth, cellBounds.Width - borderWidth * 2, cellBounds.Height - borderWidth * 2);
            if (progress > 1)
            {
                progress = 1;
            }
            int progressLength = (int)Math.Round(progress * (insideBorder.Width), 0);
            Rectangle progressRectangle = new Rectangle(insideBorder.X, insideBorder.Y, progressLength, insideBorder.Height);
            Rectangle backgroundRectangle = new Rectangle(progressRectangle.X + progressRectangle.Width + 1, insideBorder.Y, insideBorder.Width - progressLength - 1, insideBorder.Height);

            Color borderColor = clr.dark;
            Color progressColor = clr.mainLighter;
            Color backgroundColor = clr.ultraLight;

            Brush cellBorderBrush = new SolidBrush(borderColor);
            Brush progressBrush = new SolidBrush(progressColor);
            Brush cellBackgroundBrush = new SolidBrush(backgroundColor);

            Font font = new Font(FontFamily.GenericSansSerif, 10);
            string progressText = $"{Math.Round(progress * 100, 1)}% - {amount}szt.";

            using (Graphics g = Graphics.FromImage(imageBar))
            {
                var textDimension = g.MeasureString(progressText, font);
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                //border
                g.Clear(borderColor);
                //progress
                g.FillRectangle(progressBrush, progressRectangle);
                //background
                if (progress < 1)
                {
                    g.FillRectangle(cellBackgroundBrush, backgroundRectangle);
                }
                g.DrawString(progressText, font, new SolidBrush(Color.Black), new Point(cellBounds.Width / 2 - (int)textDimension.Width / 2, cell.Size.Height / 2 - (int)textDimension.Height / 2));
            }

            cell.Value = imageBar;
        }

        public static void CreateProgressbar(float progress, int amount, DataGridViewImageCell cell)
        {
            Bitmap imageBar = new Bitmap(cell.Size.Width, cell.Size.Height);
            int border = 2;
            Pen borderPen = new Pen(Color.Black);
            Rectangle borderBounds = new Rectangle(border, border, imageBar.Width - 2 * border, imageBar.Height - 2 * border);
            int borderR = 2;

            if (progress > 1) { progress = 1; }

            int progressLength = (int)Math.Round(progress * (imageBar.Width - 4 * border), 0);
            Brush fillColor = new SolidBrush(GetFillColor(progress));
            Rectangle fillBounds = new Rectangle(border * 2, border * 2, progressLength, imageBar.Height - 4 * border);
            int fillR = 2;

            Font font = new Font(FontFamily.GenericSansSerif, 8);
            string progressText = $"{Math.Round(progress * 100, 1)}% ({amount}szt.)";

            using (Graphics g = Graphics.FromImage(imageBar))
            {
                var textDimension = g.MeasureString(progressText, font);
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                g.Clear(Color.White);
                DrawRoundedRectangle(g, borderPen, borderBounds, borderR);
                FillRoundedRectangle(g, fillColor, fillBounds, fillR);
                g.DrawString(progressText, font, new SolidBrush(Color.Black), new Point(borderBounds.Width / 2 - (int)textDimension.Width / 2, cell.Size.Height / 2 - (int)textDimension.Height / 2));
            }

            cell.Value = imageBar;
        }

        private static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc
            path.AddArc(arc, 180, 90);

            // top right arc
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        private static void DrawRoundedRectangle(Graphics graphics, Pen pen, Rectangle bounds, int cornerRadius)
        {
            if (graphics == null)
                throw new ArgumentNullException("graphics");
            if (pen == null)
                throw new ArgumentNullException("pen");

            using (GraphicsPath path = RoundedRect(bounds, cornerRadius))
            {
                graphics.DrawPath(pen, path);
            }
        }

        private static void FillRoundedRectangle(Graphics graphics, Brush brush, Rectangle bounds, int cornerRadius)
        {
            if (graphics == null)
                throw new ArgumentNullException("graphics");
            if (brush == null)
                throw new ArgumentNullException("brush");

            using (GraphicsPath path = RoundedRect(bounds, cornerRadius))
            {
                graphics.FillPath(brush, path);
            }
        }
    }
}