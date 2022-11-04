<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits Altui.forms.darkForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.DarkButton1 = New AltUI.Controls.DarkButton()
        Me.EMAPgb = New AltUI.Controls.DarkGroupBox()
        Me.EMAPs3l = New AltUI.Controls.DarkLabel()
        Me.EMAPs2l = New AltUI.Controls.DarkLabel()
        Me.EMAPs1l = New AltUI.Controls.DarkLabel()
        Me.EMAPilcb = New AltUI.Controls.DarkCheckBox()
        Me.EMAPslb = New AltUI.Controls.DarkButton()
        Me.EMAPcolp = New System.Windows.Forms.Button()
        Me.EMAPs3 = New AltUI.Controls.DarkTextBox()
        Me.EMAPs2 = New AltUI.Controls.DarkTextBox()
        Me.EMAPs1 = New AltUI.Controls.DarkTextBox()
        Me.MapSave = New AltUI.Controls.DarkButton()
        Me.Mapgb = New AltUI.Controls.DarkGroupBox()
        Me.EME2gb = New AltUI.Controls.DarkGroupBox()
        Me.EME2r = New AltUI.Controls.DarkTextBox()
        Me.EME2rl = New AltUI.Controls.DarkLabel()
        Me.EME2cb = New AltUI.Controls.DarkComboBox()
        Me.EME2dsb = New AltUI.Controls.DarkScrollBar()
        Me.EME2s5l = New AltUI.Controls.DarkLabel()
        Me.EME2s4l = New AltUI.Controls.DarkLabel()
        Me.EME2s3l = New AltUI.Controls.DarkLabel()
        Me.EME2z = New AltUI.Controls.DarkTextBox()
        Me.EME2zl = New AltUI.Controls.DarkLabel()
        Me.EME2y = New AltUI.Controls.DarkTextBox()
        Me.EME2s5 = New AltUI.Controls.DarkTextBox()
        Me.EME2yl = New AltUI.Controls.DarkLabel()
        Me.EME2s4 = New AltUI.Controls.DarkTextBox()
        Me.EME2x = New AltUI.Controls.DarkTextBox()
        Me.EME2dgv = New System.Windows.Forms.DataGridView()
        Me.EME2xl = New AltUI.Controls.DarkLabel()
        Me.EME2s3 = New AltUI.Controls.DarkTextBox()
        Me.EME2s2 = New AltUI.Controls.DarkTextBox()
        Me.EME2s1 = New AltUI.Controls.DarkTextBox()
        Me.EME2n = New AltUI.Controls.DarkTextBox()
        Me.ECAMgb = New AltUI.Controls.DarkGroupBox()
        Me.ECAMr = New AltUI.Controls.DarkTextBox()
        Me.ECAMrl = New AltUI.Controls.DarkLabel()
        Me.ECAMzl = New AltUI.Controls.DarkLabel()
        Me.ECAMyl = New AltUI.Controls.DarkLabel()
        Me.ECAMxl = New AltUI.Controls.DarkLabel()
        Me.ECAMz = New AltUI.Controls.DarkTextBox()
        Me.ECAMy = New AltUI.Controls.DarkTextBox()
        Me.ECAMx = New AltUI.Controls.DarkTextBox()
        Me.EMEPgb = New AltUI.Controls.DarkGroupBox()
        Me.EMEPcb = New AltUI.Controls.DarkComboBox()
        Me.EMEPr = New AltUI.Controls.DarkTextBox()
        Me.EMEPrl = New AltUI.Controls.DarkLabel()
        Me.EMEPzl = New AltUI.Controls.DarkLabel()
        Me.EMEPyl = New AltUI.Controls.DarkLabel()
        Me.EMEPxl = New AltUI.Controls.DarkLabel()
        Me.EMEPepl = New AltUI.Controls.DarkLabel()
        Me.EMEPz = New AltUI.Controls.DarkTextBox()
        Me.EMEPy = New AltUI.Controls.DarkTextBox()
        Me.EMEPnud = New AltUI.Controls.DarkNumericUpDown()
        Me.EMEPx = New AltUI.Controls.DarkTextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.EMAPgb.SuspendLayout()
        Me.Mapgb.SuspendLayout()
        Me.EME2gb.SuspendLayout()
        CType(Me.EME2dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ECAMgb.SuspendLayout()
        Me.EMEPgb.SuspendLayout()
        CType(Me.EMEPnud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DarkButton1
        '
        Me.DarkButton1.FlatBottom = False
        Me.DarkButton1.FlatTop = False
        Me.DarkButton1.HoldColour = False
        Me.DarkButton1.Location = New System.Drawing.Point(12, 12)
        Me.DarkButton1.Name = "DarkButton1"
        Me.DarkButton1.Padding = New System.Windows.Forms.Padding(5)
        Me.DarkButton1.Size = New System.Drawing.Size(75, 23)
        Me.DarkButton1.TabIndex = 0
        Me.DarkButton1.Text = "Load File"
        '
        'EMAPgb
        '
        Me.EMAPgb.Controls.Add(Me.EMAPs3l)
        Me.EMAPgb.Controls.Add(Me.EMAPs2l)
        Me.EMAPgb.Controls.Add(Me.EMAPs1l)
        Me.EMAPgb.Controls.Add(Me.EMAPilcb)
        Me.EMAPgb.Controls.Add(Me.EMAPslb)
        Me.EMAPgb.Controls.Add(Me.EMAPcolp)
        Me.EMAPgb.Controls.Add(Me.EMAPs3)
        Me.EMAPgb.Controls.Add(Me.EMAPs2)
        Me.EMAPgb.Controls.Add(Me.EMAPs1)
        Me.EMAPgb.Location = New System.Drawing.Point(6, 22)
        Me.EMAPgb.Name = "EMAPgb"
        Me.EMAPgb.Size = New System.Drawing.Size(277, 139)
        Me.EMAPgb.TabIndex = 1
        Me.EMAPgb.TabStop = False
        Me.EMAPgb.Text = "EMAP"
        '
        'EMAPs3l
        '
        Me.EMAPs3l.AutoSize = True
        Me.EMAPs3l.Location = New System.Drawing.Point(242, 112)
        Me.EMAPs3l.Name = "EMAPs3l"
        Me.EMAPs3l.Size = New System.Drawing.Size(29, 15)
        Me.EMAPs3l.TabIndex = 14
        Me.EMAPs3l.Text = ".dds"
        '
        'EMAPs2l
        '
        Me.EMAPs2l.AutoSize = True
        Me.EMAPs2l.Location = New System.Drawing.Point(248, 83)
        Me.EMAPs2l.Name = "EMAPs2l"
        Me.EMAPs2l.Size = New System.Drawing.Size(23, 15)
        Me.EMAPs2l.TabIndex = 13
        Me.EMAPs2l.Text = ".rle"
        '
        'EMAPs1l
        '
        Me.EMAPs1l.AutoSize = True
        Me.EMAPs1l.Location = New System.Drawing.Point(255, 54)
        Me.EMAPs1l.Name = "EMAPs1l"
        Me.EMAPs1l.Size = New System.Drawing.Size(16, 15)
        Me.EMAPs1l.TabIndex = 12
        Me.EMAPs1l.Text = ".8"
        '
        'EMAPilcb
        '
        Me.EMAPilcb.AutoSize = True
        Me.EMAPilcb.Location = New System.Drawing.Point(164, 26)
        Me.EMAPilcb.Name = "EMAPilcb"
        Me.EMAPilcb.Offset = 1
        Me.EMAPilcb.Size = New System.Drawing.Size(107, 19)
        Me.EMAPilcb.TabIndex = 11
        Me.EMAPilcb.Text = "Ignore Lighting"
        '
        'EMAPslb
        '
        Me.EMAPslb.FlatBottom = False
        Me.EMAPslb.FlatTop = False
        Me.EMAPslb.HoldColour = False
        Me.EMAPslb.Location = New System.Drawing.Point(6, 22)
        Me.EMAPslb.Name = "EMAPslb"
        Me.EMAPslb.Padding = New System.Windows.Forms.Padding(5)
        Me.EMAPslb.Size = New System.Drawing.Size(122, 24)
        Me.EMAPslb.TabIndex = 9
        Me.EMAPslb.Text = "Set Lighting Colour"
        '
        'EMAPcolp
        '
        Me.EMAPcolp.BackColor = System.Drawing.Color.White
        Me.EMAPcolp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.EMAPcolp.FlatAppearance.BorderSize = 0
        Me.EMAPcolp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.EMAPcolp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.EMAPcolp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.EMAPcolp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.EMAPcolp.Location = New System.Drawing.Point(134, 22)
        Me.EMAPcolp.Name = "EMAPcolp"
        Me.EMAPcolp.Size = New System.Drawing.Size(24, 24)
        Me.EMAPcolp.TabIndex = 8
        Me.EMAPcolp.UseVisualStyleBackColor = False
        '
        'EMAPs3
        '
        Me.EMAPs3.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EMAPs3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EMAPs3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EMAPs3.Location = New System.Drawing.Point(6, 110)
        Me.EMAPs3.Name = "EMAPs3"
        Me.EMAPs3.Size = New System.Drawing.Size(230, 23)
        Me.EMAPs3.TabIndex = 2
        '
        'EMAPs2
        '
        Me.EMAPs2.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EMAPs2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EMAPs2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EMAPs2.Location = New System.Drawing.Point(6, 81)
        Me.EMAPs2.Name = "EMAPs2"
        Me.EMAPs2.Size = New System.Drawing.Size(236, 23)
        Me.EMAPs2.TabIndex = 1
        '
        'EMAPs1
        '
        Me.EMAPs1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EMAPs1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EMAPs1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EMAPs1.Location = New System.Drawing.Point(6, 52)
        Me.EMAPs1.Name = "EMAPs1"
        Me.EMAPs1.Size = New System.Drawing.Size(243, 23)
        Me.EMAPs1.TabIndex = 0
        '
        'MapSave
        '
        Me.MapSave.FlatBottom = False
        Me.MapSave.FlatTop = False
        Me.MapSave.HoldColour = False
        Me.MapSave.Location = New System.Drawing.Point(695, 372)
        Me.MapSave.Name = "MapSave"
        Me.MapSave.Padding = New System.Windows.Forms.Padding(5)
        Me.MapSave.Size = New System.Drawing.Size(75, 23)
        Me.MapSave.TabIndex = 10
        Me.MapSave.Text = "Save"
        '
        'Mapgb
        '
        Me.Mapgb.Controls.Add(Me.EME2gb)
        Me.Mapgb.Controls.Add(Me.ECAMgb)
        Me.Mapgb.Controls.Add(Me.EMEPgb)
        Me.Mapgb.Controls.Add(Me.EMAPgb)
        Me.Mapgb.Controls.Add(Me.MapSave)
        Me.Mapgb.Location = New System.Drawing.Point(12, 41)
        Me.Mapgb.Name = "Mapgb"
        Me.Mapgb.Size = New System.Drawing.Size(776, 401)
        Me.Mapgb.TabIndex = 2
        Me.Mapgb.TabStop = False
        Me.Mapgb.Text = ".map Editor"
        '
        'EME2gb
        '
        Me.EME2gb.Controls.Add(Me.EME2r)
        Me.EME2gb.Controls.Add(Me.EME2rl)
        Me.EME2gb.Controls.Add(Me.EME2cb)
        Me.EME2gb.Controls.Add(Me.EME2dsb)
        Me.EME2gb.Controls.Add(Me.EME2s5l)
        Me.EME2gb.Controls.Add(Me.EME2s4l)
        Me.EME2gb.Controls.Add(Me.EME2s3l)
        Me.EME2gb.Controls.Add(Me.EME2z)
        Me.EME2gb.Controls.Add(Me.EME2zl)
        Me.EME2gb.Controls.Add(Me.EME2y)
        Me.EME2gb.Controls.Add(Me.EME2s5)
        Me.EME2gb.Controls.Add(Me.EME2yl)
        Me.EME2gb.Controls.Add(Me.EME2s4)
        Me.EME2gb.Controls.Add(Me.EME2x)
        Me.EME2gb.Controls.Add(Me.EME2dgv)
        Me.EME2gb.Controls.Add(Me.EME2xl)
        Me.EME2gb.Controls.Add(Me.EME2s3)
        Me.EME2gb.Controls.Add(Me.EME2s2)
        Me.EME2gb.Controls.Add(Me.EME2s1)
        Me.EME2gb.Controls.Add(Me.EME2n)
        Me.EME2gb.Location = New System.Drawing.Point(6, 167)
        Me.EME2gb.Name = "EME2gb"
        Me.EME2gb.Size = New System.Drawing.Size(481, 191)
        Me.EME2gb.TabIndex = 13
        Me.EME2gb.TabStop = False
        Me.EME2gb.Text = "EME2"
        '
        'EME2r
        '
        Me.EME2r.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EME2r.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EME2r.ForeColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EME2r.Location = New System.Drawing.Point(193, 162)
        Me.EME2r.Name = "EME2r"
        Me.EME2r.Size = New System.Drawing.Size(84, 23)
        Me.EME2r.TabIndex = 25
        '
        'EME2rl
        '
        Me.EME2rl.AutoSize = True
        Me.EME2rl.Location = New System.Drawing.Point(177, 166)
        Me.EME2rl.Name = "EME2rl"
        Me.EME2rl.Size = New System.Drawing.Size(14, 15)
        Me.EME2rl.TabIndex = 26
        Me.EME2rl.Text = "R"
        '
        'EME2cb
        '
        Me.EME2cb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.EME2cb.FormattingEnabled = True
        Me.EME2cb.Location = New System.Drawing.Point(6, 22)
        Me.EME2cb.Name = "EME2cb"
        Me.EME2cb.Size = New System.Drawing.Size(271, 24)
        Me.EME2cb.TabIndex = 24
        '
        'EME2dsb
        '
        Me.EME2dsb.Location = New System.Drawing.Point(462, 50)
        Me.EME2dsb.Maximum = 500
        Me.EME2dsb.Name = "EME2dsb"
        Me.EME2dsb.Size = New System.Drawing.Size(18, 135)
        Me.EME2dsb.TabIndex = 14
        Me.EME2dsb.Text = "DarkScrollBar1"
        '
        'EME2s5l
        '
        Me.EME2s5l.AutoSize = True
        Me.EME2s5l.Location = New System.Drawing.Point(142, 164)
        Me.EME2s5l.Name = "EME2s5l"
        Me.EME2s5l.Size = New System.Drawing.Size(29, 15)
        Me.EME2s5l.TabIndex = 23
        Me.EME2s5l.Text = ".veg"
        '
        'EME2s4l
        '
        Me.EME2s4l.AutoSize = True
        Me.EME2s4l.Location = New System.Drawing.Point(142, 136)
        Me.EME2s4l.Name = "EME2s4l"
        Me.EME2s4l.Size = New System.Drawing.Size(29, 15)
        Me.EME2s4l.TabIndex = 22
        Me.EME2s4l.Text = ".dds"
        '
        'EME2s3l
        '
        Me.EME2s3l.AutoSize = True
        Me.EME2s3l.Location = New System.Drawing.Point(138, 109)
        Me.EME2s3l.Name = "EME2s3l"
        Me.EME2s3l.Size = New System.Drawing.Size(33, 15)
        Me.EME2s3l.TabIndex = 21
        Me.EME2s3l.Text = ".amx"
        '
        'EME2z
        '
        Me.EME2z.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EME2z.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EME2z.ForeColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EME2z.Location = New System.Drawing.Point(193, 134)
        Me.EME2z.Name = "EME2z"
        Me.EME2z.Size = New System.Drawing.Size(84, 23)
        Me.EME2z.TabIndex = 10
        '
        'EME2zl
        '
        Me.EME2zl.AutoSize = True
        Me.EME2zl.Location = New System.Drawing.Point(177, 138)
        Me.EME2zl.Name = "EME2zl"
        Me.EME2zl.Size = New System.Drawing.Size(14, 15)
        Me.EME2zl.TabIndex = 13
        Me.EME2zl.Text = "Z"
        '
        'EME2y
        '
        Me.EME2y.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EME2y.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EME2y.ForeColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EME2y.Location = New System.Drawing.Point(193, 106)
        Me.EME2y.Name = "EME2y"
        Me.EME2y.Size = New System.Drawing.Size(84, 23)
        Me.EME2y.TabIndex = 9
        '
        'EME2s5
        '
        Me.EME2s5.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EME2s5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EME2s5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EME2s5.Location = New System.Drawing.Point(6, 162)
        Me.EME2s5.Name = "EME2s5"
        Me.EME2s5.Size = New System.Drawing.Size(130, 23)
        Me.EME2s5.TabIndex = 18
        '
        'EME2yl
        '
        Me.EME2yl.AutoSize = True
        Me.EME2yl.Location = New System.Drawing.Point(177, 110)
        Me.EME2yl.Name = "EME2yl"
        Me.EME2yl.Size = New System.Drawing.Size(14, 15)
        Me.EME2yl.TabIndex = 12
        Me.EME2yl.Text = "Y"
        '
        'EME2s4
        '
        Me.EME2s4.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EME2s4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EME2s4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EME2s4.Location = New System.Drawing.Point(6, 134)
        Me.EME2s4.Name = "EME2s4"
        Me.EME2s4.Size = New System.Drawing.Size(130, 23)
        Me.EME2s4.TabIndex = 17
        '
        'EME2x
        '
        Me.EME2x.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EME2x.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EME2x.ForeColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EME2x.Location = New System.Drawing.Point(193, 78)
        Me.EME2x.Name = "EME2x"
        Me.EME2x.Size = New System.Drawing.Size(84, 23)
        Me.EME2x.TabIndex = 8
        '
        'EME2dgv
        '
        Me.EME2dgv.AllowUserToResizeColumns = False
        Me.EME2dgv.AllowUserToResizeRows = False
        Me.EME2dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.EME2dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.EME2dgv.ColumnHeadersVisible = False
        Me.EME2dgv.Location = New System.Drawing.Point(283, 50)
        Me.EME2dgv.MultiSelect = False
        Me.EME2dgv.Name = "EME2dgv"
        Me.EME2dgv.RowHeadersVisible = False
        Me.EME2dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.EME2dgv.RowTemplate.Height = 25
        Me.EME2dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.EME2dgv.Size = New System.Drawing.Size(196, 135)
        Me.EME2dgv.TabIndex = 19
        '
        'EME2xl
        '
        Me.EME2xl.AutoSize = True
        Me.EME2xl.Location = New System.Drawing.Point(177, 82)
        Me.EME2xl.Name = "EME2xl"
        Me.EME2xl.Size = New System.Drawing.Size(14, 15)
        Me.EME2xl.TabIndex = 11
        Me.EME2xl.Text = "X"
        '
        'EME2s3
        '
        Me.EME2s3.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EME2s3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EME2s3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EME2s3.Location = New System.Drawing.Point(6, 106)
        Me.EME2s3.Name = "EME2s3"
        Me.EME2s3.Size = New System.Drawing.Size(126, 23)
        Me.EME2s3.TabIndex = 16
        '
        'EME2s2
        '
        Me.EME2s2.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EME2s2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EME2s2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EME2s2.Location = New System.Drawing.Point(6, 78)
        Me.EME2s2.Name = "EME2s2"
        Me.EME2s2.Size = New System.Drawing.Size(165, 23)
        Me.EME2s2.TabIndex = 15
        '
        'EME2s1
        '
        Me.EME2s1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EME2s1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EME2s1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EME2s1.Location = New System.Drawing.Point(6, 50)
        Me.EME2s1.Name = "EME2s1"
        Me.EME2s1.Size = New System.Drawing.Size(165, 23)
        Me.EME2s1.TabIndex = 14
        '
        'EME2n
        '
        Me.EME2n.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EME2n.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EME2n.ForeColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EME2n.Location = New System.Drawing.Point(283, 23)
        Me.EME2n.Name = "EME2n"
        Me.EME2n.Size = New System.Drawing.Size(192, 23)
        Me.EME2n.TabIndex = 12
        '
        'ECAMgb
        '
        Me.ECAMgb.Controls.Add(Me.ECAMr)
        Me.ECAMgb.Controls.Add(Me.ECAMrl)
        Me.ECAMgb.Controls.Add(Me.ECAMzl)
        Me.ECAMgb.Controls.Add(Me.ECAMyl)
        Me.ECAMgb.Controls.Add(Me.ECAMxl)
        Me.ECAMgb.Controls.Add(Me.ECAMz)
        Me.ECAMgb.Controls.Add(Me.ECAMy)
        Me.ECAMgb.Controls.Add(Me.ECAMx)
        Me.ECAMgb.Location = New System.Drawing.Point(289, 25)
        Me.ECAMgb.Name = "ECAMgb"
        Me.ECAMgb.Size = New System.Drawing.Size(132, 136)
        Me.ECAMgb.TabIndex = 12
        Me.ECAMgb.TabStop = False
        Me.ECAMgb.Text = "ECAM"
        '
        'ECAMr
        '
        Me.ECAMr.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.ECAMr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ECAMr.ForeColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ECAMr.Location = New System.Drawing.Point(24, 106)
        Me.ECAMr.Name = "ECAMr"
        Me.ECAMr.Size = New System.Drawing.Size(102, 23)
        Me.ECAMr.TabIndex = 29
        '
        'ECAMrl
        '
        Me.ECAMrl.AutoSize = True
        Me.ECAMrl.Location = New System.Drawing.Point(6, 110)
        Me.ECAMrl.Name = "ECAMrl"
        Me.ECAMrl.Size = New System.Drawing.Size(14, 15)
        Me.ECAMrl.TabIndex = 30
        Me.ECAMrl.Text = "R"
        '
        'ECAMzl
        '
        Me.ECAMzl.AutoSize = True
        Me.ECAMzl.Location = New System.Drawing.Point(6, 83)
        Me.ECAMzl.Name = "ECAMzl"
        Me.ECAMzl.Size = New System.Drawing.Size(14, 15)
        Me.ECAMzl.TabIndex = 7
        Me.ECAMzl.Text = "Z"
        '
        'ECAMyl
        '
        Me.ECAMyl.AutoSize = True
        Me.ECAMyl.Location = New System.Drawing.Point(6, 55)
        Me.ECAMyl.Name = "ECAMyl"
        Me.ECAMyl.Size = New System.Drawing.Size(14, 15)
        Me.ECAMyl.TabIndex = 6
        Me.ECAMyl.Text = "Y"
        '
        'ECAMxl
        '
        Me.ECAMxl.AutoSize = True
        Me.ECAMxl.Location = New System.Drawing.Point(6, 26)
        Me.ECAMxl.Name = "ECAMxl"
        Me.ECAMxl.Size = New System.Drawing.Size(14, 15)
        Me.ECAMxl.TabIndex = 5
        Me.ECAMxl.Text = "X"
        '
        'ECAMz
        '
        Me.ECAMz.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.ECAMz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ECAMz.ForeColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ECAMz.Location = New System.Drawing.Point(24, 78)
        Me.ECAMz.Name = "ECAMz"
        Me.ECAMz.Size = New System.Drawing.Size(102, 23)
        Me.ECAMz.TabIndex = 3
        '
        'ECAMy
        '
        Me.ECAMy.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.ECAMy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ECAMy.ForeColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ECAMy.Location = New System.Drawing.Point(24, 50)
        Me.ECAMy.Name = "ECAMy"
        Me.ECAMy.Size = New System.Drawing.Size(102, 23)
        Me.ECAMy.TabIndex = 2
        '
        'ECAMx
        '
        Me.ECAMx.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.ECAMx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ECAMx.ForeColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ECAMx.Location = New System.Drawing.Point(24, 22)
        Me.ECAMx.Name = "ECAMx"
        Me.ECAMx.Size = New System.Drawing.Size(102, 23)
        Me.ECAMx.TabIndex = 0
        '
        'EMEPgb
        '
        Me.EMEPgb.Controls.Add(Me.EMEPcb)
        Me.EMEPgb.Controls.Add(Me.EMEPr)
        Me.EMEPgb.Controls.Add(Me.EMEPrl)
        Me.EMEPgb.Controls.Add(Me.EMEPzl)
        Me.EMEPgb.Controls.Add(Me.EMEPyl)
        Me.EMEPgb.Controls.Add(Me.EMEPxl)
        Me.EMEPgb.Controls.Add(Me.EMEPepl)
        Me.EMEPgb.Controls.Add(Me.EMEPz)
        Me.EMEPgb.Controls.Add(Me.EMEPy)
        Me.EMEPgb.Controls.Add(Me.EMEPnud)
        Me.EMEPgb.Controls.Add(Me.EMEPx)
        Me.EMEPgb.Location = New System.Drawing.Point(493, 22)
        Me.EMEPgb.Name = "EMEPgb"
        Me.EMEPgb.Size = New System.Drawing.Size(132, 194)
        Me.EMEPgb.TabIndex = 11
        Me.EMEPgb.TabStop = False
        Me.EMEPgb.Text = "EMEP"
        '
        'EMEPcb
        '
        Me.EMEPcb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.EMEPcb.FormattingEnabled = True
        Me.EMEPcb.Location = New System.Drawing.Point(6, 22)
        Me.EMEPcb.Name = "EMEPcb"
        Me.EMEPcb.Size = New System.Drawing.Size(120, 24)
        Me.EMEPcb.TabIndex = 27
        '
        'EMEPr
        '
        Me.EMEPr.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EMEPr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EMEPr.ForeColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EMEPr.Location = New System.Drawing.Point(24, 165)
        Me.EMEPr.Name = "EMEPr"
        Me.EMEPr.Size = New System.Drawing.Size(102, 23)
        Me.EMEPr.TabIndex = 27
        '
        'EMEPrl
        '
        Me.EMEPrl.AutoSize = True
        Me.EMEPrl.Location = New System.Drawing.Point(6, 168)
        Me.EMEPrl.Name = "EMEPrl"
        Me.EMEPrl.Size = New System.Drawing.Size(14, 15)
        Me.EMEPrl.TabIndex = 28
        Me.EMEPrl.Text = "R"
        '
        'EMEPzl
        '
        Me.EMEPzl.AutoSize = True
        Me.EMEPzl.Location = New System.Drawing.Point(6, 140)
        Me.EMEPzl.Name = "EMEPzl"
        Me.EMEPzl.Size = New System.Drawing.Size(14, 15)
        Me.EMEPzl.TabIndex = 7
        Me.EMEPzl.Text = "Z"
        '
        'EMEPyl
        '
        Me.EMEPyl.AutoSize = True
        Me.EMEPyl.Location = New System.Drawing.Point(6, 111)
        Me.EMEPyl.Name = "EMEPyl"
        Me.EMEPyl.Size = New System.Drawing.Size(14, 15)
        Me.EMEPyl.TabIndex = 6
        Me.EMEPyl.Text = "Y"
        '
        'EMEPxl
        '
        Me.EMEPxl.AutoSize = True
        Me.EMEPxl.Location = New System.Drawing.Point(6, 82)
        Me.EMEPxl.Name = "EMEPxl"
        Me.EMEPxl.Size = New System.Drawing.Size(14, 15)
        Me.EMEPxl.TabIndex = 5
        Me.EMEPxl.Text = "X"
        '
        'EMEPepl
        '
        Me.EMEPepl.AutoSize = True
        Me.EMEPepl.Location = New System.Drawing.Point(6, 55)
        Me.EMEPepl.Name = "EMEPepl"
        Me.EMEPepl.Size = New System.Drawing.Size(65, 15)
        Me.EMEPepl.TabIndex = 4
        Me.EMEPepl.Text = "Entry Point"
        '
        'EMEPz
        '
        Me.EMEPz.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EMEPz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EMEPz.ForeColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EMEPz.Location = New System.Drawing.Point(24, 136)
        Me.EMEPz.Name = "EMEPz"
        Me.EMEPz.Size = New System.Drawing.Size(102, 23)
        Me.EMEPz.TabIndex = 3
        '
        'EMEPy
        '
        Me.EMEPy.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EMEPy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EMEPy.ForeColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EMEPy.Location = New System.Drawing.Point(24, 107)
        Me.EMEPy.Name = "EMEPy"
        Me.EMEPy.Size = New System.Drawing.Size(102, 23)
        Me.EMEPy.TabIndex = 2
        '
        'EMEPnud
        '
        Me.EMEPnud.Location = New System.Drawing.Point(77, 52)
        Me.EMEPnud.Name = "EMEPnud"
        Me.EMEPnud.Size = New System.Drawing.Size(49, 23)
        Me.EMEPnud.TabIndex = 1
        '
        'EMEPx
        '
        Me.EMEPx.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EMEPx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EMEPx.ForeColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EMEPx.Location = New System.Drawing.Point(24, 78)
        Me.EMEPx.Name = "EMEPx"
        Me.EMEPx.Size = New System.Drawing.Size(102, 23)
        Me.EMEPx.TabIndex = 0
        '
        'Timer1
        '
        Me.Timer1.Interval = 5
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 454)
        Me.Controls.Add(Me.Mapgb)
        Me.Controls.Add(Me.DarkButton1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.EMAPgb.ResumeLayout(False)
        Me.EMAPgb.PerformLayout()
        Me.Mapgb.ResumeLayout(False)
        Me.EME2gb.ResumeLayout(False)
        Me.EME2gb.PerformLayout()
        CType(Me.EME2dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ECAMgb.ResumeLayout(False)
        Me.ECAMgb.PerformLayout()
        Me.EMEPgb.ResumeLayout(False)
        Me.EMEPgb.PerformLayout()
        CType(Me.EMEPnud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DarkButton1 As AltUI.Controls.DarkButton
    Friend WithEvents EMAPgb As AltUI.Controls.DarkGroupBox
    Friend WithEvents EMAPs3 As AltUI.Controls.DarkTextBox
    Friend WithEvents EMAPs2 As AltUI.Controls.DarkTextBox
    Friend WithEvents EMAPs1 As AltUI.Controls.DarkTextBox
    Friend WithEvents EMAPcolp As Button
    Friend WithEvents EMAPslb As AltUI.Controls.DarkButton
    Friend WithEvents MapSave As AltUI.Controls.DarkButton
    Friend WithEvents EMAPilcb As AltUI.Controls.DarkCheckBox
    Friend WithEvents Mapgb As AltUI.Controls.DarkGroupBox
    Friend WithEvents EMEPgb As AltUI.Controls.DarkGroupBox
    Friend WithEvents EMEPzl As AltUI.Controls.DarkLabel
    Friend WithEvents EMEPyl As AltUI.Controls.DarkLabel
    Friend WithEvents EMEPxl As AltUI.Controls.DarkLabel
    Friend WithEvents EMEPepl As AltUI.Controls.DarkLabel
    Friend WithEvents EMEPz As AltUI.Controls.DarkTextBox
    Friend WithEvents EMEPy As AltUI.Controls.DarkTextBox
    Friend WithEvents EMEPnud As AltUI.Controls.DarkNumericUpDown
    Friend WithEvents EMEPx As AltUI.Controls.DarkTextBox
    Friend WithEvents ECAMgb As AltUI.Controls.DarkGroupBox
    Friend WithEvents ECAMzl As AltUI.Controls.DarkLabel
    Friend WithEvents ECAMyl As AltUI.Controls.DarkLabel
    Friend WithEvents ECAMxl As AltUI.Controls.DarkLabel
    Friend WithEvents ECAMz As AltUI.Controls.DarkTextBox
    Friend WithEvents ECAMy As AltUI.Controls.DarkTextBox
    Friend WithEvents ECAMx As AltUI.Controls.DarkTextBox
    Friend WithEvents EME2gb As AltUI.Controls.DarkGroupBox
    Friend WithEvents EME2zl As AltUI.Controls.DarkLabel
    Friend WithEvents EME2n As AltUI.Controls.DarkTextBox
    Friend WithEvents EME2yl As AltUI.Controls.DarkLabel
    Friend WithEvents EME2x As AltUI.Controls.DarkTextBox
    Friend WithEvents EME2xl As AltUI.Controls.DarkLabel
    Friend WithEvents EME2y As AltUI.Controls.DarkTextBox
    Friend WithEvents EME2z As AltUI.Controls.DarkTextBox
    Friend WithEvents EME2dgv As DataGridView
    Friend WithEvents EME2s5 As AltUI.Controls.DarkTextBox
    Friend WithEvents EME2s4 As AltUI.Controls.DarkTextBox
    Friend WithEvents EME2s3 As AltUI.Controls.DarkTextBox
    Friend WithEvents EME2s2 As AltUI.Controls.DarkTextBox
    Friend WithEvents EME2s1 As AltUI.Controls.DarkTextBox
    Friend WithEvents EME2dsb As AltUI.Controls.DarkScrollBar
    Friend WithEvents Timer1 As Timer
    Friend WithEvents EMAPs3l As AltUI.Controls.DarkLabel
    Friend WithEvents EMAPs2l As AltUI.Controls.DarkLabel
    Friend WithEvents EMAPs1l As AltUI.Controls.DarkLabel
    Friend WithEvents EME2s5l As AltUI.Controls.DarkLabel
    Friend WithEvents EME2s4l As AltUI.Controls.DarkLabel
    Friend WithEvents EME2s3l As AltUI.Controls.DarkLabel
    Friend WithEvents EME2cb As AltUI.Controls.DarkComboBox
    Friend WithEvents EME2r As AltUI.Controls.DarkTextBox
    Friend WithEvents EME2rl As AltUI.Controls.DarkLabel
    Friend WithEvents EMEPr As AltUI.Controls.DarkTextBox
    Friend WithEvents EMEPrl As AltUI.Controls.DarkLabel
    Friend WithEvents EMEPcb As AltUI.Controls.DarkComboBox
    Friend WithEvents ECAMr As AltUI.Controls.DarkTextBox
    Friend WithEvents ECAMrl As AltUI.Controls.DarkLabel
End Class
