using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Smartboard.ToolBoxItems
{
  // Cyotek ImageBox
  // Copyright (c) 2010-2011 Cyotek. All Rights Reserved.
  // http://cyotek.com

  // If you use this control in your applications, attribution or donations are welcome.

  /// <summary>
  /// Component for displaying images with support for scrolling and zooming.
  /// </summary>
  [DefaultProperty("Image")]
  public partial class ImageBox : ScrollableControl
  {
  #region  Private Class Member Declarations  

    private static readonly int MinZoom = 10;
    private static readonly int MaxZoom = 3500;

  #endregion  Private Class Member Declarations  

  #region  Private Member Declarations  

    private bool _allowClickZoom;
    private bool _autoCenter;
    private bool _autoPan;
    private BorderStyle _borderStyle;
    private int _dropShadowSize;
    private int _gridCellSize;
    private Color _gridColor;
    private Color _gridColorAlternate;
    private ImageBoxGridDisplayMode _gridDisplayMode;
    private ImageBoxGridScale _gridScale;
    private Bitmap _gridTile;
    private System.Drawing.Image _image;
    private ImageBoxBorderStyle _imageBorderStyle;
    private InterpolationMode _interpolationMode;
    private bool _invertMouse;
    private bool _isPanning;
    private bool _sizeToFit;
    private Point _startMousePosition;
    private Point _startScrollPosition;
    private TextureBrush _texture;
    private int _zoom;
    private int _zoomIncrement;

  #endregion  Private Member Declarations  

  #region  Public Constructors  

    /// <summary>
    ///  Initializes a new instance of the ImageBox class.
    /// </summary>
    public ImageBox()
    {
      InitializeComponent();

      this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
      this.SetStyle(ControlStyles.StandardDoubleClick, false);
      this.UpdateStyles();

      this.DropShadowSize = 3;
      this.ImageBorderStyle = ImageBoxBorderStyle.None;
      this.BackColor = Color.White;
      this.AutoSize = true;
      this.GridScale = ImageBoxGridScale.Small;
      this.GridDisplayMode = ImageBoxGridDisplayMode.Client;
      this.GridColor = Color.Gainsboro;
      this.GridColorAlternate = Color.White;
      this.GridCellSize = 8;
      this.BorderStyle = BorderStyle.Fixed3D;
      this.AutoPan = true;
      this.ZoomIncrement = 20;
      this.InterpolationMode = InterpolationMode.Default;
      this.AutoCenter = true;
      this.AllowClickZoom = true;
      this.ActualSize();
    }

  #endregion  Public Constructors  

  #region  Events  

    /// <summary>
    /// Occurs when the AllowClickZoom property is changed.
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler AllowClickZoomChanged;

    /// <summary>
    /// Occurs when the AutoCenter property is changed.
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler AutoCenterChanged;

    /// <summary>
    /// Occurs when the AutoPan property is changed.
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler AutoPanChanged;

    /// <summary>
    /// Occurs when the BorderStyle property is changed.
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler BorderStyleChanged;

    [Category("Property Changed")]
    public event EventHandler DropShadowSizeChanged;

    /// <summary>
    /// Occurs when the GridSizeCell property is changed.
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler GridCellSizeChanged;

    /// <summary>
    /// Occurs when the GridColorAlternate property is changed.
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler GridColorAlternateChanged;

    /// <summary>
    /// Occurs when the GridColor property is changed.
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler GridColorChanged;

    /// <summary>
    /// Occurs when the GridDisplayMode property is changed.
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler GridDisplayModeChanged;

    /// <summary>
    /// Occurs when the GridScale property is changed.
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler GridScaleChanged;

    [Category("Property Changed")]
    public event EventHandler ImageBorderStyleChanged;

    /// <summary>
    /// Occurs when the Image property is changed.
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ImageChanged;

    /// <summary>
    /// Occurs when the InterpolationMode property is changed.
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler InterpolationModeChanged;

    /// <summary>
    /// Occurs when the InvertMouse property is changed.
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler InvertMouseChanged;

    [Category("Property Changed")]
    public event EventHandler PanEnd;

    [Category("Property Changed")]
    public event EventHandler PanStart;

    /// <summary>
    /// Occurs when the SizeToFit property is changed.
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler SizeToFitChanged;

    /// <summary>
    /// Occurs when the Zoom property is changed.
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ZoomChanged;

    /// <summary>
    /// Occurs when the ZoomIncrement property is changed.
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ZoomIncrementChanged;

  #endregion  Events  

  #region  Overriden Properties  

    /// <summary>
    /// Specifies if the control should autosize to fit the image contents.
    /// </summary>
    /// <value></value>
    /// <returns><c>true</c> if enabled; otherwise, <c>false</c>.
    [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), DefaultValue(true)]
    public override bool AutoSize
    {
      get { return base.AutoSize; }
      set
      {
        if (base.AutoSize != value)
        {
          base.AutoSize = value;
          this.AdjustLayout();
        }
      }
    }

    /// <summary>
    /// Gets or sets the background color for the control.
    /// </summary>
    /// <value></value>
    /// <returns>
    /// A <see cref="T:System.Drawing.Color"/> that represents the background color of the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultBackColor"/> property.
    /// </returns>
    /// <PermissionSet>
    /// 	<IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
    /// </PermissionSet>
    [DefaultValue(typeof(Color), "White")]
    public override Color BackColor
    {
      get { return base.BackColor; }
      set { base.BackColor = value; }
    }

    /// <summary>
    /// Gets or sets the background image displayed in the control.
    /// </summary>
    /// <value></value>
    /// <returns>
    /// An <see cref="T:System.Drawing.Image"/> that represents the image to display in the background of the control.
    /// </returns>
    /// <PermissionSet>
    /// 	<IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
    /// </PermissionSet>
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Image BackgroundImage
    {
      get { return base.BackgroundImage; }
      set { base.BackgroundImage = value; }
    }

    /// <summary>
    /// Gets or sets the background image layout as defined in the <see cref="T:System.Windows.Forms.ImageLayout"/> enumeration.
    /// </summary>
    /// <value></value>
    /// <returns>
    /// One of the values of <see cref="T:System.Windows.Forms.ImageLayout"/> (<see cref="F:System.Windows.Forms.ImageLayout.Center"/> , <see cref="F:System.Windows.Forms.ImageLayout.None"/>, <see cref="F:System.Windows.Forms.ImageLayout.Stretch"/>, <see cref="F:System.Windows.Forms.ImageLayout.Tile"/>, or <see cref="F:System.Windows.Forms.ImageLayout.Zoom"/>). <see cref="F:System.Windows.Forms.ImageLayout.Tile"/> is the default value.
    /// </returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">
    /// The specified enumeration value does not exist.
    /// </exception>
    /// <PermissionSet>
    /// 	<IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
    /// </PermissionSet>
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override ImageLayout BackgroundImageLayout
    {
      get { return base.BackgroundImageLayout; }
      set { base.BackgroundImageLayout = value; }
    }

    /// <summary>
    /// Gets or sets the font of the text displayed by the control.
    /// </summary>
    /// <value></value>
    /// <returns>
    /// The <see cref="T:System.Drawing.Font"/> to apply to the text displayed by the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultFont"/> property.
    /// </returns>
    /// <PermissionSet>
    /// 	<IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
    /// 	<IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
    /// 	<IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/>
    /// 	<IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
    /// </PermissionSet>
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Font Font
    {
      get { return base.Font; }
      set { base.Font = value; }
    }

    /// <summary>
    /// This property is not relevant for this class.
    /// </summary>
    /// <value></value>
    /// <returns>
    /// The text associated with this control.
    /// </returns>
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override string Text
    {
      get { return base.Text; }
      set { base.Text = value; }
    }

  #endregion  Overriden Properties  

  #region  Public Overridden Methods  

    /// <summary>
    /// Retrieves the size of a rectangular area into which a control can be fitted.
    /// </summary>
    /// <param name="proposedSize">The custom-sized area for a control.</param>
    /// <returns>
    /// An ordered pair of type <see cref="T:System.Drawing.Size"/> representing the width and height of a rectangle.
    /// </returns>
    public override Size GetPreferredSize(Size proposedSize)
    {
      Size size;

      if (this.Image != null)
      {
        int width;
        int height;

        // get the size of the image
        width = this.ScaledImageWidth;
        height = this.ScaledImageHeight;

        // add an offset based on padding
        width += this.Padding.Horizontal;
        height += this.Padding.Vertical;

        // add an offset based on the border style
        width += this.GetBorderOffset() + this.GetImageBorderOffset();
        height += this.GetBorderOffset() + this.GetImageBorderOffset();

        size = new Size(width, height);
      }
      else
        size = base.GetPreferredSize(proposedSize);

      return size;
    }

  #endregion  Public Overridden Methods  

  #region  Protected Overridden Methods  

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (components != null)
          components.Dispose();

        if (_texture != null)
        {
          _texture.Dispose();
          _texture = null;
        }

        if (_gridTile != null)
        {
          _gridTile.Dispose();
          _gridTile = null;
        }
      }
      base.Dispose(disposing);
    }

    /// <summary>
    /// Determines whether the specified key is a regular input key or a special key that requires preprocessing.
    /// </summary>
    /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys"/> values.</param>
    /// <returns>
    /// true if the specified key is a regular input key; otherwise, false.
    /// </returns>
    protected override bool IsInputKey(Keys keyData)
    {
      bool result;

      if ((keyData & Keys.Right) == Keys.Right | (keyData & Keys.Left) == Keys.Left | (keyData & Keys.Up) == Keys.Up | (keyData & Keys.Down) == Keys.Down)
        result = true;
      else
        result = base.IsInputKey(keyData);

      return result;
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.BackColorChanged"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
    protected override void OnBackColorChanged(EventArgs e)
    {
      base.OnBackColorChanged(e);

      this.Invalidate();
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.DockChanged"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
    protected override void OnDockChanged(EventArgs e)
    {
      base.OnDockChanged(e);

      if (this.Dock != DockStyle.None)
        this.AutoSize = false;
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.KeyDown"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs"/> that contains the event data.</param>
    protected override void OnKeyDown(KeyEventArgs e)
    {
      base.OnKeyDown(e);

      switch (e.KeyCode)
      {
        case Keys.Left:
          this.AdjustScroll(-(e.Modifiers == Keys.None ? this.HorizontalScroll.SmallChange : this.HorizontalScroll.LargeChange), 0);
          break;
        case Keys.Right:
          this.AdjustScroll(e.Modifiers == Keys.None ? this.HorizontalScroll.SmallChange : this.HorizontalScroll.LargeChange, 0);
          break;
        case Keys.Up:
          this.AdjustScroll(0, -(e.Modifiers == Keys.None ? this.VerticalScroll.SmallChange : this.VerticalScroll.LargeChange));
          break;
        case Keys.Down:
          this.AdjustScroll(0, e.Modifiers == Keys.None ? this.VerticalScroll.SmallChange : this.VerticalScroll.LargeChange);
          break;
        case Keys.Home:
          this.ActualSize();
          break;
        case Keys.PageDown:
          this.ZoomIn();
          break;
        case Keys.PageUp:
          this.ZoomOut();
          break;
      }
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.MouseClick"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
    protected override void OnMouseClick(MouseEventArgs e)
    {
      if (this.AllowClickZoom && !this.IsPanning && !this.SizeToFit)
      {
        double oldZoomFactor;
        Rectangle oldViewport;
        Point oldPosition;

        oldZoomFactor = this.ZoomFactor;
        oldViewport = this.GetImageViewPort();
        oldPosition = this.AutoScrollPosition;

        if (e.Button == MouseButtons.Left && Control.ModifierKeys == Keys.None)
          this.ZoomIn();
        else if (e.Button == MouseButtons.Right || (e.Button == MouseButtons.Left && Control.ModifierKeys != Keys.None))
          this.ZoomOut();

        if (oldZoomFactor != this.ZoomFactor)
        {
          double newZoomFactor;
          int oldX;
          int oldY;
          int newX;
          int newY;

          newZoomFactor = this.ZoomFactor;
          oldX = (int)((e.X - oldViewport.X) / oldZoomFactor);
          oldY = (int)((e.Y - oldViewport.Y) / oldZoomFactor);

          oldX = oldPosition.X != 0 ? (int)(oldPosition.X / oldZoomFactor) : 0;
          oldY = oldPosition.Y != 0 ? (int)(oldPosition.Y / oldZoomFactor) : 0;

          AutoScrollPosition = new Point(oldX, oldY);

          newX = (int)(oldX * newZoomFactor);
          newY = (int)(oldY * newZoomFactor);

          //if (newZoomFactor < oldZoomFactor)
          //{
          //  newX = -newX;
          //  newY = -newY;
          //}

          //this.AdjustScroll(newX - oldX, newY - oldY);
        }
      }

      base.OnMouseClick(e);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);

      if (!this.Focused)
        this.Focus();
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);

      if (e.Button == MouseButtons.Left && this.AutoPan && this.Image != null)
      {
        if (!this.IsPanning)
        {
          _startMousePosition = e.Location;
          this.IsPanning = true;
        }

        if (this.IsPanning)
        {
          int x;
          int y;
          Point position;

          if (!this.InvertMouse)
          {
            x = -_startScrollPosition.X + (_startMousePosition.X - e.Location.X);
            y = -_startScrollPosition.Y + (_startMousePosition.Y - e.Location.Y);
          }
          else
          {
            x = -(_startScrollPosition.X + (_startMousePosition.X - e.Location.X));
            y = -(_startScrollPosition.Y + (_startMousePosition.Y - e.Location.Y));
          }

          position = new Point(x, y);

          this.UpdateScrollPosition(position);
        }
      }
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
    protected override void OnMouseUp(MouseEventArgs e)
    {
      base.OnMouseUp(e);

      if (this.IsPanning)
        this.IsPanning = false;
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.MouseWheel"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
    protected override void OnMouseWheel(MouseEventArgs e)
    {
      if (!this.SizeToFit)
      {
        int increment;

        if (Control.ModifierKeys == Keys.None)
          increment = this.ZoomIncrement;
        else
          increment = this.ZoomIncrement * 5;

        if (e.Delta < 0)
          increment = -increment;

        this.Zoom += increment;
      }
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.PaddingChanged"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
    protected override void OnPaddingChanged(System.EventArgs e)
    {
      base.OnPaddingChanged(e);
      this.AdjustLayout();
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"/> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data.</param>
    protected override void OnPaint(PaintEventArgs e)
    {
      Rectangle innerRectangle;

      // draw the borders
      switch (this.BorderStyle)
      {
        case BorderStyle.FixedSingle:
          ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, this.ForeColor, ButtonBorderStyle.Solid);
          break;
        case BorderStyle.Fixed3D:
          ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, Border3DStyle.Sunken);
          break;
      }

      innerRectangle = this.GetInsideViewPort();

      // draw the background
      using (SolidBrush brush = new SolidBrush(this.BackColor))
        e.Graphics.FillRectangle(brush, innerRectangle);

      if (_texture != null && this.GridDisplayMode != ImageBoxGridDisplayMode.None)
      {
        switch (this.GridDisplayMode)
        {
          case ImageBoxGridDisplayMode.Image:
            Rectangle fillRectangle;

            fillRectangle = this.GetImageViewPort();
            e.Graphics.FillRectangle(_texture, fillRectangle);

            if (!fillRectangle.Equals(innerRectangle))
            {
              fillRectangle.Inflate(1, 1);
              ControlPaint.DrawBorder(e.Graphics, fillRectangle, this.ForeColor, ButtonBorderStyle.Solid);
            }
            break;
          case ImageBoxGridDisplayMode.Client:
            e.Graphics.FillRectangle(_texture, innerRectangle);
            break;
        }
      }

      // draw the image
      if (this.Image != null)
      {
        this.DrawImageBorder(e.Graphics);
        this.DrawImage(e.Graphics);
      }

      base.OnPaint(e);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.ParentChanged"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
    protected override void OnParentChanged(System.EventArgs e)
    {
      base.OnParentChanged(e);
      this.AdjustLayout();
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.Resize"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
    protected override void OnResize(EventArgs e)
    {
      this.AdjustLayout();

      base.OnResize(e);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.ScrollableControl.Scroll"/> event.
    /// </summary>
    /// <param name="se">A <see cref="T:System.Windows.Forms.ScrollEventArgs"/> that contains the event data.</param>
    protected override void OnScroll(ScrollEventArgs se)
    {
      this.Invalidate();

      base.OnScroll(se);
    }

  #endregion  Protected Overridden Methods  

  #region  Public Methods  

    public void ActualSize()
    {
      if (this.SizeToFit)
        this.SizeToFit = false;

      this.Zoom = 100;
    }

    /// <summary>
    /// Gets the image view port.
    /// </summary>
    /// <returns></returns>
    public virtual Rectangle GetImageViewPort()
    {
      Rectangle viewPort;

      if (this.Image != null)
      {
        Rectangle innerRectangle;
        Point offset;

        innerRectangle = this.GetInsideViewPort();

        if (!this.HScroll && !this.VScroll) // if no scrolling is present, tinker the viewport so that the image and any applicable borders all fit inside
          innerRectangle.Inflate(-this.GetImageBorderOffset(), -this.GetImageBorderOffset());

        if (this.AutoCenter)
        {
          int x;
          int y;

          x = !this.HScroll ? (innerRectangle.Width - (this.ScaledImageWidth + this.Padding.Horizontal)) / 2 : 0;
          y = !this.VScroll ? (innerRectangle.Height - (this.ScaledImageHeight + this.Padding.Vertical)) / 2 : 0;

          offset = new Point(x, y);
        }
        else
          offset = Point.Empty;

        viewPort = new Rectangle(offset.X + innerRectangle.Left + this.Padding.Left, offset.Y + innerRectangle.Top + this.Padding.Top, innerRectangle.Width - (this.Padding.Horizontal + (offset.X * 2)), innerRectangle.Height - (this.Padding.Vertical + (offset.Y * 2)));
      }
      else
        viewPort = Rectangle.Empty;

      return viewPort;
    }

    /// <summary>
    /// Gets the inside view port, excluding any padding.
    /// </summary>
    /// <returns></returns>
    public Rectangle GetInsideViewPort()
    {
      return this.GetInsideViewPort(false);
    }

    /// <summary>
    /// Gets the inside view port.
    /// </summary>
    /// <param name="includePadding">if set to <c>true</c> [include padding].</param>
    /// <returns></returns>
    public virtual Rectangle GetInsideViewPort(bool includePadding)
    {
      int left;
      int top;
      int width;
      int height;
      int borderOffset;

      borderOffset = this.GetBorderOffset();
      left = borderOffset;
      top = borderOffset;
      width = this.ClientSize.Width - (borderOffset * 2);
      height = this.ClientSize.Height - (borderOffset * 2);

      if (includePadding)
      {
        left += this.Padding.Left;
        top += this.Padding.Top;
        width -= this.Padding.Horizontal;
        height -= this.Padding.Vertical;
      }

      return new Rectangle(left, top, width, height);
    }

    /// <summary>
    /// Gets the source image region.
    /// </summary>
    /// <returns></returns>
    public virtual Rectangle GetSourceImageRegion()
    {
      int sourceLeft;
      int sourceTop;
      int sourceWidth;
      int sourceHeight;
      Rectangle viewPort;
      Rectangle region;

      if (this.Image != null)
      {
        viewPort = this.GetImageViewPort();
        sourceLeft = (int)(-this.AutoScrollPosition.X / this.ZoomFactor);
        sourceTop = (int)(-this.AutoScrollPosition.Y / this.ZoomFactor);
        sourceWidth = (int)(viewPort.Width / this.ZoomFactor);
        sourceHeight = (int)(viewPort.Height / this.ZoomFactor);

        region = new Rectangle(sourceLeft, sourceTop, sourceWidth, sourceHeight);
      }
      else
        region = Rectangle.Empty;

      return region;
    }

    /// <summary>
    /// Converts the given client size point to represent a cordinate on the source image.
    /// </summary>
    /// <param name="point">The source point.</param>
    /// <returns>Point.Empty is the point could not be matched to the source image, otherwise the new translated point</returns>
    /// <remarks>If a match is made, the return will be offset by 1</remarks>
    public virtual Point PointToImage(Point point)
    {
      Rectangle viewport;
      int x;
      int y;

      viewport = this.GetImageViewPort();

      if (viewport.Contains(point))
      {
        if (this.AutoScrollPosition != Point.Empty)
          point = new Point(point.X - this.AutoScrollPosition.X, point.Y - this.AutoScrollPosition.Y);

        x = (((int)(point.X / this.ZoomFactor)) - viewport.X) + 1; // Add 1 to both X and Y to so that hovering over 0,0 will not return Point.Empty
        y = (((int)(point.Y / this.ZoomFactor)) - viewport.Y) + 1;
      }
      else
      {
        x = 0; // Return Point.Empty if we couldn't match
        y = 0;
      }

      return new Point(x, y);
    }

    /// <summary>
    /// Zoom's into the image
    /// </summary>
    public virtual void ZoomIn()
    {
      if (this.SizeToFit)
      {
        int previousZoom;

        previousZoom = this.Zoom;
        this.SizeToFit = false;
        this.Zoom = previousZoom; // Stop the zoom getting reset to 100% before calculating the new zoom
      }

      if (this.Zoom >= 100)
        this.Zoom = (int)Math.Round((double)(this.Zoom + 100) / 100) * 100;
      else if (this.Zoom >= 75)
        this.ActualSize();
      else
        this.Zoom = (int)(this.Zoom / 0.75F);
    }

    /// <summary>
    /// Zoom's out of the image
    /// </summary>
    public virtual void ZoomOut()
    {
      if (this.SizeToFit)
      {
        int previousZoom;

        previousZoom = this.Zoom;
        this.SizeToFit = false;
        this.Zoom = previousZoom; // Stop the zoom getting reset to 100% before calculating the new zoom
      }

      if (this.Zoom > 100 && this.Zoom <= 125)
        this.ActualSize();
      else if (this.Zoom > 100)
        this.Zoom = (int)Math.Round((double)(this.Zoom - 100) / 100) * 100;
      else
        this.Zoom = (int)(this.Zoom * 0.75F);
    }

    /// <summary>
    /// Zooms to the maximum size for displaying the entire image within the bounds of the control.
    /// </summary>
    public virtual void ZoomToFit()
    {
      if (this.Image != null)
      {
        Rectangle innerRectangle;
        double zoom;
        double aspectRatio;

        this.AutoScrollMinSize = Size.Empty;

        innerRectangle = this.GetInsideViewPort(true);

        if (this.Image.Width > this.Image.Height)
        {
          aspectRatio = ((double)innerRectangle.Width) / ((double)this.Image.Width);
          zoom = aspectRatio * 100.0;

          if (innerRectangle.Height < ((this.Image.Height * zoom) / 100.0))
          {
            aspectRatio = ((double)innerRectangle.Height) / ((double)this.Image.Height);
            zoom = aspectRatio * 100.0;
          }
        }
        else
        {
          aspectRatio = ((double)innerRectangle.Height) / ((double)this.Image.Height);
          zoom = aspectRatio * 100.0;

          if (innerRectangle.Width < ((this.Image.Width * zoom) / 100.0))
          {
            aspectRatio = ((double)innerRectangle.Width) / ((double)this.Image.Width);
            zoom = aspectRatio * 100.0;
          }
        }

        this.Zoom = (int)Math.Round(Math.Floor(zoom));
      }
    }

  #endregion  Public Methods  

  #region  Public Properties  

    /// <summary>
    /// Gets or sets a value indicating whether clicking the control with the mouse will automatically zoom in or out.
    /// </summary>
    /// <value><c>true</c> if clicking the control allows zooming; otherwise, <c>false</c>.</value>
    [DefaultValue(true), Category("Behavior")]
    public virtual bool AllowClickZoom
    {
      get { return _allowClickZoom; }
      set
      {
        if (_allowClickZoom != value)
        {
          _allowClickZoom = value;
          this.OnAllowClickZoomChanged(EventArgs.Empty);
        }
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the image is centered where possible.
    /// </summary>
    /// <value><c>true</c> if the image should be centered where possible; otherwise, <c>false</c>.</value>
    [DefaultValue(true), Category("Appearance")]
    public virtual bool AutoCenter
    {
      get { return _autoCenter; }
      set
      {
        if (_autoCenter != value)
        {
          _autoCenter = value;
          this.OnAutoCenterChanged(EventArgs.Empty);
        }
      }
    }

    /// <summary>
    /// Gets or sets if the mouse can be used to auto pan the control.
    /// </summary>
    /// <value><c>true</c> if the control can be auto panned; otherwise, <c>false</c>.</value>
    /// <remarks>If this property is set, the SizeToFit property cannot be used.</remarks>
    [DefaultValue(true), Category("Behavior")]
    public virtual bool AutoPan
    {
      get { return _autoPan; }
      set
      {
        if (_autoPan != value)
        {
          _autoPan = value;
          this.OnAutoPanChanged(EventArgs.Empty);

          if (value)
            this.SizeToFit = false;
        }
      }
    }

    /// <summary>
    /// Gets or sets the minimum size of the auto-scroll.
    /// </summary>
    /// <value></value>
    /// <returns>
    /// A <see cref="T:System.Drawing.Size"/> that determines the minimum size of the virtual area through which the user can scroll.
    /// </returns>
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new Size AutoScrollMinSize
    {
      get { return base.AutoScrollMinSize; }
      set { base.AutoScrollMinSize = value; }
    }

    /// <summary>
    /// Gets or sets the border style.
    /// </summary>
    /// <value>The border style.</value>
    [Category("Appearance"), DefaultValue(typeof(BorderStyle), "Fixed3D")]
    public virtual BorderStyle BorderStyle
    {
      get { return _borderStyle; }
      set
      {
        if (_borderStyle != value)
        {
          _borderStyle = value;
          this.OnBorderStyleChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance"), DefaultValue(3)]
    public virtual int DropShadowSize
    {
      get { return _dropShadowSize; }
      set
      {
        if (this.DropShadowSize != value)
        {
          _dropShadowSize = value;

          this.OnDropShadowSizeChanged(EventArgs.Empty);
        }
      }
    }

    /// <summary>
    /// Gets or sets the size of the grid cells.
    /// </summary>
    /// <value>The size of the grid cells.</value>
    [Category("Appearance"), DefaultValue(8)]
    public virtual int GridCellSize
    {
      get { return _gridCellSize; }
      set
      {
        if (_gridCellSize != value)
        {
          _gridCellSize = value;
          this.OnGridCellSizeChanged(EventArgs.Empty);
        }
      }
    }

    /// <summary>
    /// Gets or sets the color of primary cells in the grid.
    /// </summary>
    /// <value>The color of primary cells in the grid.</value>
    [Category("Appearance"), DefaultValue(typeof(Color), "Gainsboro")]
    public virtual Color GridColor
    {
      get { return _gridColor; }
      set
      {
        if (_gridColor != value)
        {
          _gridColor = value;
          this.OnGridColorChanged(EventArgs.Empty);
        }
      }
    }

    /// <summary>
    /// Gets or sets the color of alternate cells in the grid.
    /// </summary>
    /// <value>The color of alternate cells in the grid.</value>
    [Category("Appearance"), DefaultValue(typeof(Color), "White")]
    public virtual Color GridColorAlternate
    {
      get { return _gridColorAlternate; }
      set
      {
        if (_gridColorAlternate != value)
        {
          _gridColorAlternate = value;
          this.OnGridColorAlternateChanged(EventArgs.Empty);
        }
      }
    }

    /// <summary>
    /// Gets or sets the grid display mode.
    /// </summary>
    /// <value>The grid display mode.</value>
    [DefaultValue(ImageBoxGridDisplayMode.Client), Category("Appearance")]
    public virtual ImageBoxGridDisplayMode GridDisplayMode
    {
      get { return _gridDisplayMode; }
      set
      {
        if (_gridDisplayMode != value)
        {
          _gridDisplayMode = value;
          this.OnGridDisplayModeChanged(EventArgs.Empty);
        }
      }
    }

    /// <summary>
    /// Gets or sets the grid scale.
    /// </summary>
    /// <value>The grid scale.</value>
    [DefaultValue(typeof(ImageBoxGridScale), "Small"), Category("Appearance")]
    public virtual ImageBoxGridScale GridScale
    {
      get { return _gridScale; }
      set
      {
        if (_gridScale != value)
        {
          _gridScale = value;
          this.OnGridScaleChanged(EventArgs.Empty);
        }
      }
    }

    /// <summary>
    /// Gets or sets the image.
    /// </summary>
    /// <value>The image.</value>
    [Category("Appearance"), DefaultValue(null)]
    public virtual Image Image
    {
      get { return _image; }
      set
      {
        if (_image != value)
        {
          _image = value;
          this.OnImageChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance"), DefaultValue(typeof(ImageBoxBorderStyle), "None")]
    public virtual ImageBoxBorderStyle ImageBorderStyle
    {
      get { return _imageBorderStyle; }
      set
      {
        if (this.ImageBorderStyle != value)
        {
          _imageBorderStyle = value;

          this.OnImageBorderStyleChanged(EventArgs.Empty);
        }
      }
    }

    /// <summary>
    /// Gets or sets the interpolation mode.
    /// </summary>
    /// <value>The interpolation mode.</value>
    [DefaultValue(InterpolationMode.Default), Category("Appearance")]
    public virtual InterpolationMode InterpolationMode
    {
      get { return _interpolationMode; }
      set
      {
        if (value == InterpolationMode.Invalid)
          value = InterpolationMode.Default;

        if (_interpolationMode != value)
        {
          _interpolationMode = value;
          this.OnInterpolationModeChanged(EventArgs.Empty);
        }
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the mouse should be inverted when panning the control.
    /// </summary>
    /// <value><c>true</c> if the mouse should be inverted when panning the control; otherwise, <c>false</c>.</value>
    [DefaultValue(false), Category("Behavior")]
    public virtual bool InvertMouse
    {
      get { return _invertMouse; }
      set
      {
        if (_invertMouse != value)
        {
          _invertMouse = value;
          this.OnInvertMouseChanged(EventArgs.Empty);
        }
      }
    }

    /// <summary>
    /// Gets a value indicating whether this control is panning.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this control is panning; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
    public virtual bool IsPanning
    {
      get { return _isPanning; }
      protected set
      {
        if (_isPanning != value)
        {
          _isPanning = value;
          _startScrollPosition = this.AutoScrollPosition;

          if (value)
          {
            this.Cursor = Cursors.SizeAll;
            this.OnPanStart(EventArgs.Empty);
          }
          else
          {
            this.Cursor = Cursors.Default;
            this.OnPanEnd(EventArgs.Empty);
          }
        }
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the control should automatically size to fit the image contents.
    /// </summary>
    /// <value><c>true</c> if the control should size to fit the image contents; otherwise, <c>false</c>.</value>
    [DefaultValue(false), Category("Appearance")]
    public virtual bool SizeToFit
    {
      get { return _sizeToFit; }
      set
      {
        if (_sizeToFit != value)
        {
          _sizeToFit = value;
          this.OnSizeToFitChanged(EventArgs.Empty);

          if (value)
            this.AutoPan = false;
          else
            this.ActualSize();
        }
      }
    }

    [DefaultValue(100), Category("Appearance")]
    public virtual int Zoom
    {
      get { return _zoom; }
      set
      {
        if (value < ImageBox.MinZoom)
          value = ImageBox.MinZoom;
        else if (value > ImageBox.MaxZoom)
          value = ImageBox.MaxZoom;

        if (_zoom != value)
        {
          _zoom = value;
          this.OnZoomChanged(EventArgs.Empty);
        }
      }
    }

    /// <summary>
    /// Gets or sets the zoom increment.
    /// </summary>
    /// <value>The zoom increment.</value>
    [DefaultValue(20), Category("Behavior")]
    public virtual int ZoomIncrement
    {
      get { return _zoomIncrement; }
      set
      {
        if (_zoomIncrement != value)
        {
          _zoomIncrement = value;
          this.OnZoomIncrementChanged(EventArgs.Empty);
        }
      }
    }

  #endregion  Public Properties  

  #region  Private Methods  

    /// <summary>
    /// Gets the border offset.
    /// </summary>
    /// <returns></returns>
    private int GetBorderOffset()
    {
      int offset;

      switch (this.BorderStyle)
      {
        case BorderStyle.Fixed3D:
          offset = 2;
          break;
        case BorderStyle.FixedSingle:
          offset = 1;
          break;
        default:
          offset = 0;
          break;
      }

      return offset;
    }

    /// <summary>
    /// Initializes the grid tile.
    /// </summary>
    private void InitializeGridTile()
    {
      if (_texture != null)
        _texture.Dispose();

      if (_gridTile != null)
        _gridTile.Dispose();

      if (this.GridDisplayMode != ImageBoxGridDisplayMode.None && this.GridCellSize != 0)
      {
        _gridTile = this.CreateGridTileImage(this.GridCellSize, this.GridColor, this.GridColorAlternate);
        _texture = new TextureBrush(_gridTile);
      }

      this.Invalidate();
    }

  #endregion  Private Methods  

  #region  Protected Properties  

    /// <summary>
    /// Gets the height of the scaled image.
    /// </summary>
    /// <value>The height of the scaled image.</value>
    protected virtual int ScaledImageHeight
    { get { return this.Image != null ? (int)(this.Image.Size.Height * this.ZoomFactor) : 0; } }

    /// <summary>
    /// Gets the width of the scaled image.
    /// </summary>
    /// <value>The width of the scaled image.</value>
    protected virtual int ScaledImageWidth
    { get { return this.Image != null ? (int)(this.Image.Size.Width * this.ZoomFactor) : 0; } }

    /// <summary>
    /// Gets the zoom factor.
    /// </summary>
    /// <value>The zoom factor.</value>
    protected virtual double ZoomFactor
    { get { return (double)this.Zoom / 100; } }

  #endregion  Protected Properties  

  #region  Protected Methods  

    /// <summary>
    /// Adjusts the layout.
    /// </summary>
    protected virtual void AdjustLayout()
    {
      if (this.AutoSize)
        this.AdjustSize();
      else if (this.SizeToFit)
        this.ZoomToFit();
      else if (this.AutoScroll)
        this.AdjustViewPort();
      this.Invalidate();
    }

    /// <summary>
    /// Adjusts the scroll.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    protected virtual void AdjustScroll(int x, int y)
    {
      Point scrollPosition;

      scrollPosition = new Point(this.HorizontalScroll.Value + x, this.VerticalScroll.Value + y);

      this.UpdateScrollPosition(scrollPosition);
    }

    /// <summary>
    /// Adjusts the size.
    /// </summary>
    protected virtual void AdjustSize()
    {
      if (this.AutoSize && this.Dock == DockStyle.None)
        base.Size = base.PreferredSize;
    }

    /// <summary>
    /// Adjusts the view port.
    /// </summary>
    protected virtual void AdjustViewPort()
    {
      if (this.AutoScroll && this.Image != null)
        this.AutoScrollMinSize = new Size(this.ScaledImageWidth + this.Padding.Horizontal, this.ScaledImageHeight + this.Padding.Vertical);
    }

    /// <summary>
    /// Creates the grid tile image.
    /// </summary>
    /// <param name="cellSize">Size of the cell.</param>
    /// <param name="firstColor">The first color.</param>
    /// <param name="secondColor">Color of the second.</param>
    /// <returns></returns>
    protected virtual Bitmap CreateGridTileImage(int cellSize, Color firstColor, Color secondColor)
    {
      Bitmap result;
      int width;
      int height;
      float scale;

      // rescale the cell size
      switch (this.GridScale)
      {
        case ImageBoxGridScale.Medium:
          scale = 1.5F;
          break;
        case ImageBoxGridScale.Large:
          scale = 2;
          break;
        default:
          scale = 1;
          break;
      }

      cellSize = (int)(cellSize * scale);

      // draw the tile
      width = cellSize * 2;
      height = cellSize * 2;
      result = new Bitmap(width, height);
      using (Graphics g = Graphics.FromImage(result))
      {
        using (SolidBrush brush = new SolidBrush(firstColor))
          g.FillRectangle(brush, new Rectangle(0, 0, width, height));

        using (SolidBrush brush = new SolidBrush(secondColor))
        {
          g.FillRectangle(brush, new Rectangle(0, 0, cellSize, cellSize));
          g.FillRectangle(brush, new Rectangle(cellSize, cellSize, cellSize, cellSize));
        }
      }

      return result;
    }

    /// <summary>
    ///  Draws a drop shadow.
    /// </summary>
    /// <param name="g">        The graphics. </param>
    /// <param name="viewPort"> The view port. </param>
    protected virtual void DrawDropShadow(Graphics g, Rectangle viewPort)
    {
      Rectangle rightEdge;
      Rectangle bottomEdge;

      rightEdge = new Rectangle(viewPort.Right + 1, viewPort.Top + this.DropShadowSize, this.DropShadowSize, viewPort.Height);
      bottomEdge = new Rectangle(viewPort.Left + this.DropShadowSize, viewPort.Bottom + 1, viewPort.Width + 1, this.DropShadowSize);

      using (Brush brush = new SolidBrush(this.ForeColor))
        g.FillRectangles(brush, new Rectangle[] { rightEdge, bottomEdge });
    }

    /// <summary>
    /// Draws the image.
    /// </summary>
    /// <param name="g">The g.</param>
    protected virtual void DrawImage(Graphics g)
    {
      g.InterpolationMode = this.InterpolationMode;
      g.DrawImage(this.Image, this.GetImageViewPort(), this.GetSourceImageRegion(), GraphicsUnit.Pixel);
    }

    /// <summary>
    ///  Draws a border around the image.
    /// </summary>
    /// <param name="graphics"> The graphics. </param>
    protected virtual void DrawImageBorder(Graphics graphics)
    {
      if (this.ImageBorderStyle != ImageBoxBorderStyle.None)
      {
        Rectangle viewPort;

        graphics.SetClip(this.GetInsideViewPort()); // make sure the image border doesn't overwrite the control border

        viewPort = this.GetImageViewPort();
        viewPort = new Rectangle(viewPort.Left - 1, viewPort.Top - 1, viewPort.Width + 1, viewPort.Height + 1);

        using (Pen borderPen = new Pen(this.ForeColor))
        {
          graphics.DrawRectangle(borderPen, viewPort);

          if (this.ImageBorderStyle == ImageBoxBorderStyle.FixedSingleDropShadow)
            this.DrawDropShadow(graphics, viewPort);
        }

        graphics.ResetClip();
      }
    }

    /// <summary>
    /// Gets an offset based on the current image border style.
    /// </summary>
    /// <returns></returns>
    protected virtual int GetImageBorderOffset()
    {
      int offset;

      switch (this.ImageBorderStyle)
      {
        case ImageBoxBorderStyle.FixedSingle:
          offset = 1;
          break;
        case ImageBoxBorderStyle.FixedSingleDropShadow:
          offset = (this.DropShadowSize + 1);
          break;
        default:
          offset = 0;
          break;
      }

      return offset;
    }

    /// <summary>
    /// Raises the <see cref="E:AllowClickZoomChanged"/> event.
    /// </summary>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected virtual void OnAllowClickZoomChanged(EventArgs e)
    {
      if (this.AllowClickZoomChanged != null)
        this.AllowClickZoomChanged(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:AutoCenterChanged"/> event.
    /// </summary>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected virtual void OnAutoCenterChanged(EventArgs e)
    {
      this.Invalidate();

      if (this.AutoCenterChanged != null)
        this.AutoCenterChanged(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:AutoPanChanged"/> event.
    /// </summary>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected virtual void OnAutoPanChanged(EventArgs e)
    {
      if (this.AutoPanChanged != null)
        this.AutoPanChanged(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:BorderStyleChanged"/> event.
    /// </summary>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected virtual void OnBorderStyleChanged(EventArgs e)
    {
      this.AdjustLayout();

      if (this.BorderStyleChanged != null)
        this.BorderStyleChanged(this, e);
    }

    protected virtual void OnDropShadowSizeChanged(EventArgs e)
    {
      this.Invalidate();

      if (this.DropShadowSizeChanged != null)
        this.DropShadowSizeChanged(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:GridCellSizeChanged"/> event.
    /// </summary>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected virtual void OnGridCellSizeChanged(EventArgs e)
    {
      this.InitializeGridTile();

      if (this.GridCellSizeChanged != null)
        this.GridCellSizeChanged(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:GridColorAlternateChanged"/> event.
    /// </summary>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected virtual void OnGridColorAlternateChanged(EventArgs e)
    {
      this.InitializeGridTile();

      if (this.GridColorAlternateChanged != null)
        this.GridColorAlternateChanged(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:GridColorChanged"/> event.
    /// </summary>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected virtual void OnGridColorChanged(EventArgs e)
    {
      this.InitializeGridTile();

      if (this.GridColorChanged != null)
        this.GridColorChanged(this, e);

    }

    /// <summary>
    /// Raises the <see cref="E:GridDisplayModeChanged"/> event.
    /// </summary>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected virtual void OnGridDisplayModeChanged(EventArgs e)
    {
      this.InitializeGridTile();
      this.Invalidate();

      if (this.GridDisplayModeChanged != null)
        this.GridDisplayModeChanged(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:GridScaleChanged"/> event.
    /// </summary>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected virtual void OnGridScaleChanged(EventArgs e)
    {
      this.InitializeGridTile();

      if (this.GridScaleChanged != null)
        this.GridScaleChanged(this, e);
    }

    protected virtual void OnImageBorderStyleChanged(EventArgs e)
    {
      this.Invalidate();

      if (this.ImageBorderStyleChanged != null)
        this.ImageBorderStyleChanged(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:ImageChanged"/> event.
    /// </summary>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected virtual void OnImageChanged(EventArgs e)
    {
      this.AdjustLayout();

      if (this.ImageChanged != null)
        this.ImageChanged(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:InterpolationModeChanged"/> event.
    /// </summary>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected virtual void OnInterpolationModeChanged(EventArgs e)
    {
      this.Invalidate();

      if (this.InterpolationModeChanged != null)
        this.InterpolationModeChanged(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:InvertMouseChanged"/> event.
    /// </summary>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected virtual void OnInvertMouseChanged(EventArgs e)
    {
      if (this.InvertMouseChanged != null)
        this.InvertMouseChanged(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:PanEnd"/> event.
    /// </summary>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected virtual void OnPanEnd(EventArgs e)
    {
      if (this.PanEnd != null)
        this.PanEnd(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:PanStart"/> event.
    /// </summary>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected virtual void OnPanStart(EventArgs e)
    {
      if (this.PanStart != null)
        this.PanStart(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:SizeToFitChanged"/> event.
    /// </summary>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected virtual void OnSizeToFitChanged(EventArgs e)
    {
      this.AdjustLayout();

      if (this.SizeToFitChanged != null)
        this.SizeToFitChanged(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:ZoomChanged"/> event.
    /// </summary>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected virtual void OnZoomChanged(EventArgs e)
    {
      this.AdjustLayout();

      if (this.ZoomChanged != null)
        this.ZoomChanged(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:ZoomIncrementChanged"/> event.
    /// </summary>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected virtual void OnZoomIncrementChanged(EventArgs e)
    {
      if (this.ZoomIncrementChanged != null)
        this.ZoomIncrementChanged(this, e);
    }

    /// <summary>
    /// Updates the scroll position.
    /// </summary>
    /// <param name="position">The position.</param>
    protected virtual void UpdateScrollPosition(Point position)
    {
      this.AutoScrollPosition = position;
      this.Invalidate();
      this.OnScroll(new ScrollEventArgs(ScrollEventType.ThumbPosition, 0));
    }

  #endregion  Protected Methods  
  }
}
