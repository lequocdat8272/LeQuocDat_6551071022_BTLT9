using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace KeHoachDaNgoai.Controls;

public class WeatherIconControl : Control
{
    private int _weatherCode = -1;
    private bool _hasData = false;

    public WeatherIconControl()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.SupportsTransparentBackColor |
                 ControlStyles.UserPaint, true);

        BackColor = Color.Transparent;
        Size = new Size(110, 90);
    }

    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public int WeatherCode
    {
        get => _weatherCode;
        set
        {
            _weatherCode = value;
            _hasData = value >= 0;
            Invalidate();
        }
    }

    public void ClearIcon()
    {
        _weatherCode = -1;
        _hasData = false;
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        if (!_hasData)
        {
            DrawDefaultIcon(g);
            return;
        }

        // Mapping rules according to requirement:
        // 0 = Trời quang
        // 1-3 = Có mây
        // 45, 48 = Sương mù
        // 51-67 và 80-82 = Mưa
        // 95-99 = Dông
        if (_weatherCode == 0)
        {
            DrawClearSun(g);
        }
        else if (_weatherCode >= 1 && _weatherCode <= 3)
        {
            DrawCloudy(g);
        }
        else if (_weatherCode == 45 || _weatherCode == 48)
        {
            DrawFog(g);
        }
        else if ((_weatherCode >= 51 && _weatherCode <= 67) || (_weatherCode >= 80 && _weatherCode <= 82))
        {
            DrawRain(g);
        }
        else if (_weatherCode >= 95 && _weatherCode <= 99)
        {
            DrawThunderstorm(g);
        }
        else
        {
            DrawCloudy(g);
        }
    }

    private void DrawClearSun(Graphics g)
    {
        float cx = Width / 2f;
        float cy = Height / 2f;
        float r = Math.Min(Width, Height) * 0.24f;

        using var sunBrush = new SolidBrush(Color.FromArgb(245, 158, 11)); // Amber
        using var rayPen = new Pen(Color.FromArgb(245, 158, 11), 3f) { StartCap = LineCap.Round, EndCap = LineCap.Round };

        // Sun rays
        int rayCount = 8;
        float rayStart = r + 4;
        float rayEnd = r + 12;

        for (int i = 0; i < rayCount; i++)
        {
            double angle = i * (Math.PI * 2 / rayCount);
            float x1 = cx + (float)(Math.Cos(angle) * rayStart);
            float y1 = cy + (float)(Math.Sin(angle) * rayStart);
            float x2 = cx + (float)(Math.Cos(angle) * rayEnd);
            float y2 = cy + (float)(Math.Sin(angle) * rayEnd);
            g.DrawLine(rayPen, x1, y1, x2, y2);
        }

        // Sun circle
        g.FillEllipse(sunBrush, cx - r, cy - r, r * 2, r * 2);
    }

    private GraphicsPath CreateCloudPath(float x, float y, float w, float h)
    {
        var path = new GraphicsPath();
        float baseH = h * 0.42f;
        float baseY = y + h - baseH;

        // Bottom pill/rounded rectangle
        path.AddArc(x, baseY, baseH, baseH, 90, 180);
        path.AddArc(x + w - baseH, baseY, baseH, baseH, 270, 180);

        // Top arcs (fluffy bumps)
        float r1 = w * 0.30f;
        float r2 = w * 0.42f;
        path.AddArc(x + w * 0.16f, y + h * 0.22f, r1, r1, 160, 140);
        path.AddArc(x + w * 0.38f, y, r2, r2, 180, 160);

        path.CloseFigure();
        return path;
    }

    private void DrawCloudy(Graphics g)
    {
        float w = Width * 0.65f;
        float h = Height * 0.45f;
        float x = (Width - w) / 2f;
        float y = (Height - h) / 2f;

        using var path = CreateCloudPath(x, y, w, h);
        using var brush = new SolidBrush(Color.FromArgb(226, 232, 240));
        using var pen = new Pen(Color.FromArgb(30, 41, 59), 3f) { LineJoin = LineJoin.Round };

        g.FillPath(brush, path);
        g.DrawPath(pen, path);
    }

    private void DrawFog(Graphics g)
    {
        float w = Width * 0.65f;
        float h = Height * 0.35f;
        float x = (Width - w) / 2f;
        float y = Height * 0.15f;

        using (var path = CreateCloudPath(x, y, w, h))
        using (var brush = new SolidBrush(Color.FromArgb(241, 245, 249)))
        using (var pen = new Pen(Color.FromArgb(100, 116, 139), 2.5f))
        {
            g.FillPath(brush, path);
            g.DrawPath(pen, path);
        }

        // Fog lines
        using var fogPen = new Pen(Color.FromArgb(148, 163, 184), 3.5f) { StartCap = LineCap.Round, EndCap = LineCap.Round };
        g.DrawLine(fogPen, Width * 0.22f, Height * 0.65f, Width * 0.78f, Height * 0.65f);
        g.DrawLine(fogPen, Width * 0.30f, Height * 0.77f, Width * 0.70f, Height * 0.77f);
        g.DrawLine(fogPen, Width * 0.25f, Height * 0.89f, Width * 0.75f, Height * 0.89f);
    }

    private void DrawRain(Graphics g)
    {
        // Dark outline cloud matching the mockup image
        float w = Width * 0.68f;
        float h = Height * 0.46f;
        float x = (Width - w) / 2f;
        float y = Height * 0.12f;

        using (var path = CreateCloudPath(x, y, w, h))
        using (var pen = new Pen(Color.FromArgb(20, 20, 25), 3.8f) { LineJoin = LineJoin.Round })
        using (var brush = new SolidBrush(Color.White))
        {
            g.FillPath(brush, path);
            g.DrawPath(pen, path);
        }

        // Diagonal rain drops exactly as shown in the screenshot
        using var dropPen = new Pen(Color.FromArgb(20, 20, 25), 3.2f) { StartCap = LineCap.Round, EndCap = LineCap.Round };

        float[,] drops = new float[,]
        {
            { Width * 0.32f, Height * 0.66f, Width * 0.30f, Height * 0.82f },
            { Width * 0.45f, Height * 0.68f, Width * 0.43f, Height * 0.84f },
            { Width * 0.58f, Height * 0.66f, Width * 0.56f, Height * 0.82f },
            { Width * 0.71f, Height * 0.68f, Width * 0.69f, Height * 0.84f }
        };

        for (int i = 0; i < 4; i++)
        {
            g.DrawLine(dropPen, drops[i, 0], drops[i, 1], drops[i, 2], drops[i, 3]);
        }
    }

    private void DrawThunderstorm(Graphics g)
    {
        float w = Width * 0.68f;
        float h = Height * 0.46f;
        float x = (Width - w) / 2f;
        float y = Height * 0.12f;

        using (var path = CreateCloudPath(x, y, w, h))
        using (var brush = new SolidBrush(Color.FromArgb(71, 85, 105)))
        using (var pen = new Pen(Color.FromArgb(15, 23, 42), 3.5f) { LineJoin = LineJoin.Round })
        {
            g.FillPath(brush, path);
            g.DrawPath(pen, path);
        }

        // Lightning bolt
        using var boltBrush = new SolidBrush(Color.FromArgb(250, 204, 21)); // Yellow
        PointF[] boltPoints = new PointF[]
        {
            new PointF(Width * 0.50f, Height * 0.56f),
            new PointF(Width * 0.42f, Height * 0.74f),
            new PointF(Width * 0.51f, Height * 0.74f),
            new PointF(Width * 0.44f, Height * 0.94f),
            new PointF(Width * 0.60f, Height * 0.70f),
            new PointF(Width * 0.52f, Height * 0.70f),
        };
        g.FillPolygon(boltBrush, boltPoints);

        // Rain drops on sides
        using var dropPen = new Pen(Color.FromArgb(56, 189, 248), 2.8f) { StartCap = LineCap.Round, EndCap = LineCap.Round };
        g.DrawLine(dropPen, Width * 0.30f, Height * 0.68f, Width * 0.27f, Height * 0.82f);
        g.DrawLine(dropPen, Width * 0.72f, Height * 0.68f, Width * 0.69f, Height * 0.82f);
    }

    private void DrawDefaultIcon(Graphics g)
    {
        float w = Width * 0.60f;
        float h = Height * 0.40f;
        float x = (Width - w) / 2f;
        float y = (Height - h) / 2f;

        using var path = CreateCloudPath(x, y, w, h);
        using var pen = new Pen(Color.FromArgb(203, 213, 225), 2.5f) { DashStyle = DashStyle.Dash };
        g.DrawPath(pen, path);
    }
}
