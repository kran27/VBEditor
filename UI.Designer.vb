Imports System.ComponentModel
Imports AltUI.Controls
Imports AltUI.Forms
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class UI
    Inherits DarkForm

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()>
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
    Private components As IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New Container()
        Me.DarkButton1 = New DarkButton()
        Me.EMAPs3l = New DarkLabel()
        Me.EMAPs2l = New DarkLabel()
        Me.EMAPs1l = New DarkLabel()
        Me.EMAPilcb = New DarkCheckBox()
        Me.EMAPslb = New DarkButton()
        Me.EMAPs3 = New DarkTextBox()
        Me.EMAPs2 = New DarkTextBox()
        Me.EMAPs1 = New DarkTextBox()
        Me.MapSave = New DarkButton()
        Me.Mapgb = New DarkGroupBox()
        Me.Triggergb = New DarkGroupBox()
        Me.Triggerm = New DarkButton()
        Me.Triggertcb = New DarkComboBox()
        Me.Triggerp = New DarkButton()
        Me.Triggern = New DarkTextBox()
        Me.Triggerpcb = New DarkComboBox()
        Me.Triggercb = New DarkComboBox()
        Me.Triggerx = New DarkTextBox()
        Me.Triggerxl = New DarkLabel()
        Me.Triggery = New DarkTextBox()
        Me.Triggerz = New DarkTextBox()
        Me.EPTHGB = New DarkGroupBox()
        Me.EPTHm = New DarkButton()
        Me.EPTHr = New DarkTextBox()
        Me.EPTHp = New DarkButton()
        Me.EPTHn = New DarkTextBox()
        Me.EPTHpcb = New DarkComboBox()
        Me.EPTHcb = New DarkComboBox()
        Me.EPTHx = New DarkTextBox()
        Me.EPTHxl = New DarkLabel()
        Me.EPTHy = New DarkTextBox()
        Me.EPTHz = New DarkTextBox()
        Me.EMSDgb = New DarkGroupBox()
        Me.EMSDm = New DarkButton()
        Me.EMSDcb = New DarkComboBox()
        Me.EMSDp = New DarkButton()
        Me.EMSDs2l = New DarkLabel()
        Me.EMSDs1 = New DarkTextBox()
        Me.EMSDs2 = New DarkTextBox()
        Me.EMSDcl = New DarkLabel()
        Me.EMSDz = New DarkTextBox()
        Me.EMSDy = New DarkTextBox()
        Me.EMSDx = New DarkTextBox()
        Me.EME2gb = New DarkGroupBox()
        Me.EME2m = New DarkButton()
        Me.EME2p = New DarkButton()
        Me.EME2r = New DarkTextBox()
        Me.EME2cb = New DarkComboBox()
        Me.EME2dsb = New DarkScrollBar()
        Me.EME2s5l = New DarkLabel()
        Me.EME2s4l = New DarkLabel()
        Me.EME2s3l = New DarkLabel()
        Me.EME2z = New DarkTextBox()
        Me.EME2y = New DarkTextBox()
        Me.EME2s5 = New DarkTextBox()
        Me.EME2s4 = New DarkTextBox()
        Me.EME2x = New DarkTextBox()
        Me.EME2dgv = New DataGridView()
        Me.EME2cl = New DarkLabel()
        Me.EME2s3 = New DarkTextBox()
        Me.EME2s2 = New DarkTextBox()
        Me.EME2s1 = New DarkTextBox()
        Me.EME2n = New DarkTextBox()
        Me.EMEFgb = New DarkGroupBox()
        Me.EMEFm = New DarkButton()
        Me.EMEFr = New DarkTextBox()
        Me.EMEFp = New DarkButton()
        Me.EMEFcb = New DarkComboBox()
        Me.EMEFs2l = New DarkLabel()
        Me.EMEFs1 = New DarkTextBox()
        Me.EMEFs2 = New DarkTextBox()
        Me.EMEFxl = New DarkLabel()
        Me.EMEFz = New DarkTextBox()
        Me.EMEFy = New DarkTextBox()
        Me.EMEFx = New DarkTextBox()
        Me.ECAMgb = New DarkGroupBox()
        Me.ECAMr = New DarkTextBox()
        Me.ECAMcl = New DarkLabel()
        Me.ECAMz = New DarkTextBox()
        Me.ECAMy = New DarkTextBox()
        Me.ECAMx = New DarkTextBox()
        Me.EMAPgb = New DarkGroupBox()
        Me.EMEPgb = New DarkGroupBox()
        Me.EMEPm = New DarkButton()
        Me.EMEPp = New DarkButton()
        Me.EMEPcb = New DarkComboBox()
        Me.EMEPr = New DarkTextBox()
        Me.EMEPcl = New DarkLabel()
        Me.EMEPepl = New DarkLabel()
        Me.EMEPz = New DarkTextBox()
        Me.EMEPy = New DarkTextBox()
        Me.EMEPnud = New DarkNumericUpDown()
        Me.EMEPx = New DarkTextBox()
        Me.Timer1 = New Timer(Me.components)
        Me.DarkButton2 = New DarkButton()
        Me.Mapgb.SuspendLayout()
        Me.Triggergb.SuspendLayout()
        Me.EPTHGB.SuspendLayout()
        Me.EMSDgb.SuspendLayout()
        Me.EME2gb.SuspendLayout()
        CType(Me.EME2dgv, ISupportInitialize).BeginInit()
        Me.EMEFgb.SuspendLayout()
        Me.ECAMgb.SuspendLayout()
        Me.EMAPgb.SuspendLayout()
        Me.EMEPgb.SuspendLayout()
        CType(Me.EMEPnud, ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DarkButton1
        '
        Me.DarkButton1.BorderColour = Color.Empty
        Me.DarkButton1.CustomColour = False
        Me.DarkButton1.FlatBottom = False
        Me.DarkButton1.FlatTop = False
        Me.DarkButton1.Location = New Point(12, 12)
        Me.DarkButton1.Name = "DarkButton1"
        Me.DarkButton1.Padding = New Padding(5)
        Me.DarkButton1.Size = New Size(75, 23)
        Me.DarkButton1.TabIndex = 0
        Me.DarkButton1.Text = "Load File"
        '
        'EMAPs3l
        '
        Me.EMAPs3l.AutoSize = True
        Me.EMAPs3l.Location = New Point(265, 114)
        Me.EMAPs3l.Name = "EMAPs3l"
        Me.EMAPs3l.Size = New Size(29, 15)
        Me.EMAPs3l.TabIndex = 14
        Me.EMAPs3l.Text = ".dds"
        '
        'EMAPs2l
        '
        Me.EMAPs2l.AutoSize = True
        Me.EMAPs2l.Location = New Point(271, 85)
        Me.EMAPs2l.Name = "EMAPs2l"
        Me.EMAPs2l.Size = New Size(23, 15)
        Me.EMAPs2l.TabIndex = 13
        Me.EMAPs2l.Text = ".rle"
        '
        'EMAPs1l
        '
        Me.EMAPs1l.AutoSize = True
        Me.EMAPs1l.Location = New Point(278, 56)
        Me.EMAPs1l.Name = "EMAPs1l"
        Me.EMAPs1l.Size = New Size(16, 15)
        Me.EMAPs1l.TabIndex = 12
        Me.EMAPs1l.Text = ".8"
        '
        'EMAPilcb
        '
        Me.EMAPilcb.AutoSize = True
        Me.EMAPilcb.Location = New Point(187, 24)
        Me.EMAPilcb.Name = "EMAPilcb"
        Me.EMAPilcb.Offset = 1
        Me.EMAPilcb.Size = New Size(107, 19)
        Me.EMAPilcb.TabIndex = 11
        Me.EMAPilcb.Text = "Ignore Lighting"
        '
        'EMAPslb
        '
        Me.EMAPslb.BorderColour = Color.Empty
        Me.EMAPslb.CustomColour = False
        Me.EMAPslb.FlatBottom = False
        Me.EMAPslb.FlatTop = False
        Me.EMAPslb.Location = New Point(6, 22)
        Me.EMAPslb.Name = "EMAPslb"
        Me.EMAPslb.Padding = New Padding(5)
        Me.EMAPslb.Size = New Size(144, 24)
        Me.EMAPslb.TabIndex = 9
        Me.EMAPslb.Text = "Set Lighting Colour"
        '
        'EMAPs3
        '
        Me.EMAPs3.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EMAPs3.BorderStyle = BorderStyle.FixedSingle
        Me.EMAPs3.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EMAPs3.Location = New Point(6, 110)
        Me.EMAPs3.Name = "EMAPs3"
        Me.EMAPs3.Size = New Size(253, 23)
        Me.EMAPs3.TabIndex = 2
        '
        'EMAPs2
        '
        Me.EMAPs2.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EMAPs2.BorderStyle = BorderStyle.FixedSingle
        Me.EMAPs2.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EMAPs2.Location = New Point(6, 81)
        Me.EMAPs2.Name = "EMAPs2"
        Me.EMAPs2.Size = New Size(259, 23)
        Me.EMAPs2.TabIndex = 1
        '
        'EMAPs1
        '
        Me.EMAPs1.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EMAPs1.BorderStyle = BorderStyle.FixedSingle
        Me.EMAPs1.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EMAPs1.Location = New Point(6, 52)
        Me.EMAPs1.Name = "EMAPs1"
        Me.EMAPs1.Size = New Size(266, 23)
        Me.EMAPs1.TabIndex = 0
        '
        'MapSave
        '
        Me.MapSave.BorderColour = Color.Empty
        Me.MapSave.CustomColour = False
        Me.MapSave.FlatBottom = False
        Me.MapSave.FlatTop = False
        Me.MapSave.Location = New Point(174, 12)
        Me.MapSave.Name = "MapSave"
        Me.MapSave.Padding = New Padding(5)
        Me.MapSave.Size = New Size(75, 23)
        Me.MapSave.TabIndex = 10
        Me.MapSave.Text = "Save"
        '
        'Mapgb
        '
        Me.Mapgb.Controls.Add(Me.Triggergb)
        Me.Mapgb.Controls.Add(Me.EPTHGB)
        Me.Mapgb.Controls.Add(Me.EMSDgb)
        Me.Mapgb.Controls.Add(Me.EME2gb)
        Me.Mapgb.Controls.Add(Me.EMEFgb)
        Me.Mapgb.Controls.Add(Me.ECAMgb)
        Me.Mapgb.Controls.Add(Me.EMAPgb)
        Me.Mapgb.Controls.Add(Me.EMEPgb)
        Me.Mapgb.Location = New Point(12, 41)
        Me.Mapgb.Name = "Mapgb"
        Me.Mapgb.Size = New Size(924, 456)
        Me.Mapgb.TabIndex = 2
        Me.Mapgb.TabStop = False
        Me.Mapgb.Text = ".map Editor"
        '
        'Triggergb
        '
        Me.Triggergb.Controls.Add(Me.Triggerm)
        Me.Triggergb.Controls.Add(Me.Triggertcb)
        Me.Triggergb.Controls.Add(Me.Triggerp)
        Me.Triggergb.Controls.Add(Me.Triggern)
        Me.Triggergb.Controls.Add(Me.Triggerpcb)
        Me.Triggergb.Controls.Add(Me.Triggercb)
        Me.Triggergb.Controls.Add(Me.Triggerx)
        Me.Triggergb.Controls.Add(Me.Triggerxl)
        Me.Triggergb.Controls.Add(Me.Triggery)
        Me.Triggergb.Controls.Add(Me.Triggerz)
        Me.Triggergb.Location = New Point(618, 362)
        Me.Triggergb.Name = "Triggergb"
        Me.Triggergb.Size = New Size(300, 88)
        Me.Triggergb.TabIndex = 14
        Me.Triggergb.TabStop = False
        Me.Triggergb.Text = "Trigger"
        '
        'Triggerm
        '
        Me.Triggerm.BorderColour = Color.Empty
        Me.Triggerm.CustomColour = False
        Me.Triggerm.FlatBottom = False
        Me.Triggerm.FlatTop = False
        Me.Triggerm.Location = New Point(270, 0)
        Me.Triggerm.Name = "Triggerm"
        Me.Triggerm.Padding = New Padding(5)
        Me.Triggerm.Size = New Size(24, 24)
        Me.Triggerm.TabIndex = 46
        Me.Triggerm.Text = "-"
        '
        'Triggertcb
        '
        Me.Triggertcb.DrawMode = DrawMode.OwnerDrawVariable
        Me.Triggertcb.FormattingEnabled = True
        Me.Triggertcb.Items.AddRange(New Object() {"B", "S", "T"})
        Me.Triggertcb.Location = New Point(241, 28)
        Me.Triggertcb.Name = "Triggertcb"
        Me.Triggertcb.Size = New Size(53, 24)
        Me.Triggertcb.TabIndex = 38
        '
        'Triggerp
        '
        Me.Triggerp.BorderColour = Color.Empty
        Me.Triggerp.CustomColour = False
        Me.Triggerp.FlatBottom = False
        Me.Triggerp.FlatTop = False
        Me.Triggerp.Location = New Point(243, 0)
        Me.Triggerp.Name = "Triggerp"
        Me.Triggerp.Padding = New Padding(5)
        Me.Triggerp.Size = New Size(24, 24)
        Me.Triggerp.TabIndex = 45
        Me.Triggerp.Text = "+"
        '
        'Triggern
        '
        Me.Triggern.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Triggern.BorderStyle = BorderStyle.FixedSingle
        Me.Triggern.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.Triggern.Location = New Point(6, 29)
        Me.Triggern.Name = "Triggern"
        Me.Triggern.Size = New Size(229, 23)
        Me.Triggern.TabIndex = 36
        '
        'Triggerpcb
        '
        Me.Triggerpcb.DrawMode = DrawMode.OwnerDrawVariable
        Me.Triggerpcb.FormattingEnabled = True
        Me.Triggerpcb.Location = New Point(6, 58)
        Me.Triggerpcb.Name = "Triggerpcb"
        Me.Triggerpcb.Size = New Size(37, 24)
        Me.Triggerpcb.TabIndex = 35
        '
        'Triggercb
        '
        Me.Triggercb.DrawMode = DrawMode.OwnerDrawVariable
        Me.Triggercb.FormattingEnabled = True
        Me.Triggercb.Location = New Point(58, 0)
        Me.Triggercb.Name = "Triggercb"
        Me.Triggercb.Size = New Size(179, 24)
        Me.Triggercb.TabIndex = 0
        '
        'Triggerx
        '
        Me.Triggerx.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Triggerx.BorderStyle = BorderStyle.FixedSingle
        Me.Triggerx.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.Triggerx.Location = New Point(81, 59)
        Me.Triggerx.Name = "Triggerx"
        Me.Triggerx.Size = New Size(67, 23)
        Me.Triggerx.TabIndex = 29
        '
        'Triggerxl
        '
        Me.Triggerxl.AutoSize = True
        Me.Triggerxl.Location = New Point(49, 63)
        Me.Triggerxl.Name = "Triggerxl"
        Me.Triggerxl.Size = New Size(28, 15)
        Me.Triggerxl.TabIndex = 32
        Me.Triggerxl.Text = "XYZ"
        '
        'Triggery
        '
        Me.Triggery.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Triggery.BorderStyle = BorderStyle.FixedSingle
        Me.Triggery.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.Triggery.Location = New Point(154, 59)
        Me.Triggery.Name = "Triggery"
        Me.Triggery.Size = New Size(67, 23)
        Me.Triggery.TabIndex = 30
        '
        'Triggerz
        '
        Me.Triggerz.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Triggerz.BorderStyle = BorderStyle.FixedSingle
        Me.Triggerz.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.Triggerz.Location = New Point(227, 59)
        Me.Triggerz.Name = "Triggerz"
        Me.Triggerz.Size = New Size(67, 23)
        Me.Triggerz.TabIndex = 31
        '
        'EPTHGB
        '
        Me.EPTHGB.Controls.Add(Me.EPTHm)
        Me.EPTHGB.Controls.Add(Me.EPTHr)
        Me.EPTHGB.Controls.Add(Me.EPTHp)
        Me.EPTHGB.Controls.Add(Me.EPTHn)
        Me.EPTHGB.Controls.Add(Me.EPTHpcb)
        Me.EPTHGB.Controls.Add(Me.EPTHcb)
        Me.EPTHGB.Controls.Add(Me.EPTHx)
        Me.EPTHGB.Controls.Add(Me.EPTHxl)
        Me.EPTHGB.Controls.Add(Me.EPTHy)
        Me.EPTHGB.Controls.Add(Me.EPTHz)
        Me.EPTHGB.Location = New Point(618, 268)
        Me.EPTHGB.Name = "EPTHGB"
        Me.EPTHGB.Size = New Size(300, 88)
        Me.EPTHGB.TabIndex = 39
        Me.EPTHGB.TabStop = False
        Me.EPTHGB.Text = "EPTH"
        '
        'EPTHm
        '
        Me.EPTHm.BorderColour = Color.Empty
        Me.EPTHm.CustomColour = False
        Me.EPTHm.FlatBottom = False
        Me.EPTHm.FlatTop = False
        Me.EPTHm.Location = New Point(270, 0)
        Me.EPTHm.Name = "EPTHm"
        Me.EPTHm.Padding = New Padding(5)
        Me.EPTHm.Size = New Size(24, 24)
        Me.EPTHm.TabIndex = 44
        Me.EPTHm.Text = "-"
        '
        'EPTHr
        '
        Me.EPTHr.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EPTHr.BorderStyle = BorderStyle.FixedSingle
        Me.EPTHr.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EPTHr.Location = New Point(247, 59)
        Me.EPTHr.Name = "EPTHr"
        Me.EPTHr.Size = New Size(47, 23)
        Me.EPTHr.TabIndex = 37
        '
        'EPTHp
        '
        Me.EPTHp.BorderColour = Color.Empty
        Me.EPTHp.CustomColour = False
        Me.EPTHp.FlatBottom = False
        Me.EPTHp.FlatTop = False
        Me.EPTHp.Location = New Point(243, 0)
        Me.EPTHp.Name = "EPTHp"
        Me.EPTHp.Padding = New Padding(5)
        Me.EPTHp.Size = New Size(24, 24)
        Me.EPTHp.TabIndex = 43
        Me.EPTHp.Text = "+"
        '
        'EPTHn
        '
        Me.EPTHn.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EPTHn.BorderStyle = BorderStyle.FixedSingle
        Me.EPTHn.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EPTHn.Location = New Point(6, 30)
        Me.EPTHn.Name = "EPTHn"
        Me.EPTHn.Size = New Size(288, 23)
        Me.EPTHn.TabIndex = 36
        '
        'EPTHpcb
        '
        Me.EPTHpcb.DrawMode = DrawMode.OwnerDrawVariable
        Me.EPTHpcb.FormattingEnabled = True
        Me.EPTHpcb.Location = New Point(6, 58)
        Me.EPTHpcb.Name = "EPTHpcb"
        Me.EPTHpcb.Size = New Size(37, 24)
        Me.EPTHpcb.TabIndex = 35
        '
        'EPTHcb
        '
        Me.EPTHcb.DrawMode = DrawMode.OwnerDrawVariable
        Me.EPTHcb.FormattingEnabled = True
        Me.EPTHcb.Location = New Point(47, 0)
        Me.EPTHcb.Name = "EPTHcb"
        Me.EPTHcb.Size = New Size(190, 24)
        Me.EPTHcb.TabIndex = 0
        '
        'EPTHx
        '
        Me.EPTHx.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EPTHx.BorderStyle = BorderStyle.FixedSingle
        Me.EPTHx.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EPTHx.Location = New Point(88, 59)
        Me.EPTHx.Name = "EPTHx"
        Me.EPTHx.Size = New Size(47, 23)
        Me.EPTHx.TabIndex = 29
        '
        'EPTHxl
        '
        Me.EPTHxl.AutoSize = True
        Me.EPTHxl.Location = New Point(49, 63)
        Me.EPTHxl.Name = "EPTHxl"
        Me.EPTHxl.Size = New Size(35, 15)
        Me.EPTHxl.TabIndex = 32
        Me.EPTHxl.Text = "XYZR"
        '
        'EPTHy
        '
        Me.EPTHy.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EPTHy.BorderStyle = BorderStyle.FixedSingle
        Me.EPTHy.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EPTHy.Location = New Point(141, 59)
        Me.EPTHy.Name = "EPTHy"
        Me.EPTHy.Size = New Size(47, 23)
        Me.EPTHy.TabIndex = 30
        '
        'EPTHz
        '
        Me.EPTHz.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EPTHz.BorderStyle = BorderStyle.FixedSingle
        Me.EPTHz.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EPTHz.Location = New Point(194, 59)
        Me.EPTHz.Name = "EPTHz"
        Me.EPTHz.Size = New Size(47, 23)
        Me.EPTHz.TabIndex = 31
        '
        'EMSDgb
        '
        Me.EMSDgb.Controls.Add(Me.EMSDm)
        Me.EMSDgb.Controls.Add(Me.EMSDcb)
        Me.EMSDgb.Controls.Add(Me.EMSDp)
        Me.EMSDgb.Controls.Add(Me.EMSDs2l)
        Me.EMSDgb.Controls.Add(Me.EMSDs1)
        Me.EMSDgb.Controls.Add(Me.EMSDs2)
        Me.EMSDgb.Controls.Add(Me.EMSDcl)
        Me.EMSDgb.Controls.Add(Me.EMSDz)
        Me.EMSDgb.Controls.Add(Me.EMSDy)
        Me.EMSDgb.Controls.Add(Me.EMSDx)
        Me.EMSDgb.Location = New Point(618, 145)
        Me.EMSDgb.Name = "EMSDgb"
        Me.EMSDgb.Size = New Size(300, 117)
        Me.EMSDgb.TabIndex = 31
        Me.EMSDgb.TabStop = False
        Me.EMSDgb.Text = "EMSD"
        '
        'EMSDm
        '
        Me.EMSDm.BorderColour = Color.Empty
        Me.EMSDm.CustomColour = False
        Me.EMSDm.FlatBottom = False
        Me.EMSDm.FlatTop = False
        Me.EMSDm.Location = New Point(270, 0)
        Me.EMSDm.Name = "EMSDm"
        Me.EMSDm.Padding = New Padding(5)
        Me.EMSDm.Size = New Size(24, 24)
        Me.EMSDm.TabIndex = 42
        Me.EMSDm.Text = "-"
        '
        'EMSDcb
        '
        Me.EMSDcb.DrawMode = DrawMode.OwnerDrawVariable
        Me.EMSDcb.FormattingEnabled = True
        Me.EMSDcb.Location = New Point(51, 0)
        Me.EMSDcb.Name = "EMSDcb"
        Me.EMSDcb.Size = New Size(186, 24)
        Me.EMSDcb.TabIndex = 39
        '
        'EMSDp
        '
        Me.EMSDp.BorderColour = Color.Empty
        Me.EMSDp.CustomColour = False
        Me.EMSDp.FlatBottom = False
        Me.EMSDp.FlatTop = False
        Me.EMSDp.Location = New Point(243, 0)
        Me.EMSDp.Name = "EMSDp"
        Me.EMSDp.Padding = New Padding(5)
        Me.EMSDp.Size = New Size(24, 24)
        Me.EMSDp.TabIndex = 41
        Me.EMSDp.Text = "+"
        '
        'EMSDs2l
        '
        Me.EMSDs2l.AutoSize = True
        Me.EMSDs2l.Location = New Point(268, 63)
        Me.EMSDs2l.Name = "EMSDs2l"
        Me.EMSDs2l.Size = New Size(26, 15)
        Me.EMSDs2l.TabIndex = 27
        Me.EMSDs2l.Text = ".psf"
        '
        'EMSDs1
        '
        Me.EMSDs1.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EMSDs1.BorderStyle = BorderStyle.FixedSingle
        Me.EMSDs1.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EMSDs1.Location = New Point(6, 30)
        Me.EMSDs1.Name = "EMSDs1"
        Me.EMSDs1.Size = New Size(288, 23)
        Me.EMSDs1.TabIndex = 9
        '
        'EMSDs2
        '
        Me.EMSDs2.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EMSDs2.BorderStyle = BorderStyle.FixedSingle
        Me.EMSDs2.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EMSDs2.Location = New Point(6, 59)
        Me.EMSDs2.Name = "EMSDs2"
        Me.EMSDs2.Size = New Size(256, 23)
        Me.EMSDs2.TabIndex = 8
        '
        'EMSDcl
        '
        Me.EMSDcl.AutoSize = True
        Me.EMSDcl.Location = New Point(6, 92)
        Me.EMSDcl.Name = "EMSDcl"
        Me.EMSDcl.Size = New Size(28, 15)
        Me.EMSDcl.TabIndex = 5
        Me.EMSDcl.Text = "XYZ"
        '
        'EMSDz
        '
        Me.EMSDz.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EMSDz.BorderStyle = BorderStyle.FixedSingle
        Me.EMSDz.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EMSDz.Location = New Point(213, 88)
        Me.EMSDz.Name = "EMSDz"
        Me.EMSDz.Size = New Size(81, 23)
        Me.EMSDz.TabIndex = 3
        '
        'EMSDy
        '
        Me.EMSDy.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EMSDy.BorderStyle = BorderStyle.FixedSingle
        Me.EMSDy.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EMSDy.Location = New Point(126, 88)
        Me.EMSDy.Name = "EMSDy"
        Me.EMSDy.Size = New Size(81, 23)
        Me.EMSDy.TabIndex = 2
        '
        'EMSDx
        '
        Me.EMSDx.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EMSDx.BorderStyle = BorderStyle.FixedSingle
        Me.EMSDx.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EMSDx.Location = New Point(39, 88)
        Me.EMSDx.Name = "EMSDx"
        Me.EMSDx.Size = New Size(81, 23)
        Me.EMSDx.TabIndex = 0
        '
        'EME2gb
        '
        Me.EME2gb.Controls.Add(Me.EME2m)
        Me.EME2gb.Controls.Add(Me.EME2p)
        Me.EME2gb.Controls.Add(Me.EME2r)
        Me.EME2gb.Controls.Add(Me.EME2cb)
        Me.EME2gb.Controls.Add(Me.EME2dsb)
        Me.EME2gb.Controls.Add(Me.EME2s5l)
        Me.EME2gb.Controls.Add(Me.EME2s4l)
        Me.EME2gb.Controls.Add(Me.EME2s3l)
        Me.EME2gb.Controls.Add(Me.EME2z)
        Me.EME2gb.Controls.Add(Me.EME2y)
        Me.EME2gb.Controls.Add(Me.EME2s5)
        Me.EME2gb.Controls.Add(Me.EME2s4)
        Me.EME2gb.Controls.Add(Me.EME2x)
        Me.EME2gb.Controls.Add(Me.EME2dgv)
        Me.EME2gb.Controls.Add(Me.EME2cl)
        Me.EME2gb.Controls.Add(Me.EME2s3)
        Me.EME2gb.Controls.Add(Me.EME2s2)
        Me.EME2gb.Controls.Add(Me.EME2s1)
        Me.EME2gb.Controls.Add(Me.EME2n)
        Me.EME2gb.Location = New Point(6, 167)
        Me.EME2gb.Name = "EME2gb"
        Me.EME2gb.Size = New Size(606, 283)
        Me.EME2gb.TabIndex = 13
        Me.EME2gb.TabStop = False
        Me.EME2gb.Text = "EME2"
        '
        'EME2m
        '
        Me.EME2m.BorderColour = Color.Empty
        Me.EME2m.CustomColour = False
        Me.EME2m.FlatBottom = False
        Me.EME2m.FlatTop = False
        Me.EME2m.Location = New Point(333, 0)
        Me.EME2m.Name = "EME2m"
        Me.EME2m.Padding = New Padding(5)
        Me.EME2m.Size = New Size(24, 24)
        Me.EME2m.TabIndex = 28
        Me.EME2m.Text = "-"
        '
        'EME2p
        '
        Me.EME2p.BorderColour = Color.Empty
        Me.EME2p.CustomColour = False
        Me.EME2p.FlatBottom = False
        Me.EME2p.FlatTop = False
        Me.EME2p.Location = New Point(306, 0)
        Me.EME2p.Name = "EME2p"
        Me.EME2p.Padding = New Padding(5)
        Me.EME2p.Size = New Size(24, 24)
        Me.EME2p.TabIndex = 27
        Me.EME2p.Text = "+"
        '
        'EME2r
        '
        Me.EME2r.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EME2r.BorderStyle = BorderStyle.FixedSingle
        Me.EME2r.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EME2r.Location = New Point(241, 254)
        Me.EME2r.Name = "EME2r"
        Me.EME2r.Size = New Size(59, 23)
        Me.EME2r.TabIndex = 25
        '
        'EME2cb
        '
        Me.EME2cb.DrawMode = DrawMode.OwnerDrawVariable
        Me.EME2cb.FormattingEnabled = True
        Me.EME2cb.Location = New Point(49, 0)
        Me.EME2cb.Name = "EME2cb"
        Me.EME2cb.Size = New Size(251, 24)
        Me.EME2cb.TabIndex = 24
        '
        'EME2dsb
        '
        Me.EME2dsb.Location = New Point(582, 30)
        Me.EME2dsb.Maximum = 500
        Me.EME2dsb.Name = "EME2dsb"
        Me.EME2dsb.Size = New Size(18, 247)
        Me.EME2dsb.TabIndex = 14
        Me.EME2dsb.Text = "DarkScrollBar1"
        '
        'EME2s5l
        '
        Me.EME2s5l.AutoSize = True
        Me.EME2s5l.Location = New Point(271, 204)
        Me.EME2s5l.Name = "EME2s5l"
        Me.EME2s5l.Size = New Size(29, 15)
        Me.EME2s5l.TabIndex = 23
        Me.EME2s5l.Text = ".veg"
        '
        'EME2s4l
        '
        Me.EME2s4l.AutoSize = True
        Me.EME2s4l.Location = New Point(271, 175)
        Me.EME2s4l.Name = "EME2s4l"
        Me.EME2s4l.Size = New Size(29, 15)
        Me.EME2s4l.TabIndex = 22
        Me.EME2s4l.Text = ".dds"
        '
        'EME2s3l
        '
        Me.EME2s3l.AutoSize = True
        Me.EME2s3l.Location = New Point(267, 146)
        Me.EME2s3l.Name = "EME2s3l"
        Me.EME2s3l.Size = New Size(33, 15)
        Me.EME2s3l.TabIndex = 21
        Me.EME2s3l.Text = ".amx"
        '
        'EME2z
        '
        Me.EME2z.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EME2z.BorderStyle = BorderStyle.FixedSingle
        Me.EME2z.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EME2z.Location = New Point(176, 254)
        Me.EME2z.Name = "EME2z"
        Me.EME2z.Size = New Size(59, 23)
        Me.EME2z.TabIndex = 10
        '
        'EME2y
        '
        Me.EME2y.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EME2y.BorderStyle = BorderStyle.FixedSingle
        Me.EME2y.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EME2y.Location = New Point(111, 254)
        Me.EME2y.Name = "EME2y"
        Me.EME2y.Size = New Size(59, 23)
        Me.EME2y.TabIndex = 9
        '
        'EME2s5
        '
        Me.EME2s5.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EME2s5.BorderStyle = BorderStyle.FixedSingle
        Me.EME2s5.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EME2s5.Location = New Point(6, 200)
        Me.EME2s5.Name = "EME2s5"
        Me.EME2s5.Size = New Size(259, 23)
        Me.EME2s5.TabIndex = 18
        '
        'EME2s4
        '
        Me.EME2s4.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EME2s4.BorderStyle = BorderStyle.FixedSingle
        Me.EME2s4.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EME2s4.Location = New Point(6, 171)
        Me.EME2s4.Name = "EME2s4"
        Me.EME2s4.Size = New Size(259, 23)
        Me.EME2s4.TabIndex = 17
        '
        'EME2x
        '
        Me.EME2x.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EME2x.BorderStyle = BorderStyle.FixedSingle
        Me.EME2x.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EME2x.Location = New Point(46, 254)
        Me.EME2x.Name = "EME2x"
        Me.EME2x.Size = New Size(59, 23)
        Me.EME2x.TabIndex = 8
        '
        'EME2dgv
        '
        Me.EME2dgv.AllowUserToResizeColumns = False
        Me.EME2dgv.AllowUserToResizeRows = False
        Me.EME2dgv.BorderStyle = BorderStyle.None
        Me.EME2dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.EME2dgv.ColumnHeadersVisible = False
        Me.EME2dgv.Location = New Point(306, 30)
        Me.EME2dgv.MultiSelect = False
        Me.EME2dgv.Name = "EME2dgv"
        Me.EME2dgv.RowHeadersVisible = False
        Me.EME2dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.EME2dgv.RowTemplate.Height = 25
        Me.EME2dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.EME2dgv.Size = New Size(293, 247)
        Me.EME2dgv.TabIndex = 19
        '
        'EME2cl
        '
        Me.EME2cl.AutoSize = True
        Me.EME2cl.Location = New Point(6, 258)
        Me.EME2cl.Name = "EME2cl"
        Me.EME2cl.Size = New Size(35, 15)
        Me.EME2cl.TabIndex = 11
        Me.EME2cl.Text = "XYZR"
        '
        'EME2s3
        '
        Me.EME2s3.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EME2s3.BorderStyle = BorderStyle.FixedSingle
        Me.EME2s3.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EME2s3.Location = New Point(6, 142)
        Me.EME2s3.Name = "EME2s3"
        Me.EME2s3.Size = New Size(255, 23)
        Me.EME2s3.TabIndex = 16
        '
        'EME2s2
        '
        Me.EME2s2.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EME2s2.BorderStyle = BorderStyle.FixedSingle
        Me.EME2s2.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EME2s2.Location = New Point(6, 88)
        Me.EME2s2.Name = "EME2s2"
        Me.EME2s2.Size = New Size(294, 23)
        Me.EME2s2.TabIndex = 15
        '
        'EME2s1
        '
        Me.EME2s1.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EME2s1.BorderStyle = BorderStyle.FixedSingle
        Me.EME2s1.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EME2s1.Location = New Point(6, 59)
        Me.EME2s1.Name = "EME2s1"
        Me.EME2s1.Size = New Size(294, 23)
        Me.EME2s1.TabIndex = 14
        '
        'EME2n
        '
        Me.EME2n.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EME2n.BorderStyle = BorderStyle.FixedSingle
        Me.EME2n.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EME2n.Location = New Point(6, 30)
        Me.EME2n.Name = "EME2n"
        Me.EME2n.Size = New Size(294, 23)
        Me.EME2n.TabIndex = 12
        '
        'EMEFgb
        '
        Me.EMEFgb.Controls.Add(Me.EMEFm)
        Me.EMEFgb.Controls.Add(Me.EMEFr)
        Me.EMEFgb.Controls.Add(Me.EMEFp)
        Me.EMEFgb.Controls.Add(Me.EMEFcb)
        Me.EMEFgb.Controls.Add(Me.EMEFs2l)
        Me.EMEFgb.Controls.Add(Me.EMEFs1)
        Me.EMEFgb.Controls.Add(Me.EMEFs2)
        Me.EMEFgb.Controls.Add(Me.EMEFxl)
        Me.EMEFgb.Controls.Add(Me.EMEFz)
        Me.EMEFgb.Controls.Add(Me.EMEFy)
        Me.EMEFgb.Controls.Add(Me.EMEFx)
        Me.EMEFgb.Location = New Point(618, 22)
        Me.EMEFgb.Name = "EMEFgb"
        Me.EMEFgb.Size = New Size(300, 117)
        Me.EMEFgb.TabIndex = 40
        Me.EMEFgb.TabStop = False
        Me.EMEFgb.Text = "EMEF"
        '
        'EMEFm
        '
        Me.EMEFm.BorderColour = Color.Empty
        Me.EMEFm.CustomColour = False
        Me.EMEFm.FlatBottom = False
        Me.EMEFm.FlatTop = False
        Me.EMEFm.Location = New Point(270, 0)
        Me.EMEFm.Name = "EMEFm"
        Me.EMEFm.Padding = New Padding(5)
        Me.EMEFm.Size = New Size(24, 24)
        Me.EMEFm.TabIndex = 30
        Me.EMEFm.Text = "-"
        '
        'EMEFr
        '
        Me.EMEFr.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EMEFr.BorderStyle = BorderStyle.FixedSingle
        Me.EMEFr.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EMEFr.Location = New Point(237, 88)
        Me.EMEFr.Name = "EMEFr"
        Me.EMEFr.Size = New Size(57, 23)
        Me.EMEFr.TabIndex = 40
        '
        'EMEFp
        '
        Me.EMEFp.BorderColour = Color.Empty
        Me.EMEFp.CustomColour = False
        Me.EMEFp.FlatBottom = False
        Me.EMEFp.FlatTop = False
        Me.EMEFp.Location = New Point(243, 0)
        Me.EMEFp.Name = "EMEFp"
        Me.EMEFp.Padding = New Padding(5)
        Me.EMEFp.Size = New Size(24, 24)
        Me.EMEFp.TabIndex = 29
        Me.EMEFp.Text = "+"
        '
        'EMEFcb
        '
        Me.EMEFcb.DrawMode = DrawMode.OwnerDrawVariable
        Me.EMEFcb.FormattingEnabled = True
        Me.EMEFcb.Location = New Point(48, 0)
        Me.EMEFcb.Name = "EMEFcb"
        Me.EMEFcb.Size = New Size(189, 24)
        Me.EMEFcb.TabIndex = 39
        '
        'EMEFs2l
        '
        Me.EMEFs2l.AutoSize = True
        Me.EMEFs2l.Location = New Point(265, 63)
        Me.EMEFs2l.Name = "EMEFs2l"
        Me.EMEFs2l.Size = New Size(29, 15)
        Me.EMEFs2l.TabIndex = 27
        Me.EMEFs2l.Text = ".veg"
        '
        'EMEFs1
        '
        Me.EMEFs1.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EMEFs1.BorderStyle = BorderStyle.FixedSingle
        Me.EMEFs1.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EMEFs1.Location = New Point(6, 30)
        Me.EMEFs1.Name = "EMEFs1"
        Me.EMEFs1.Size = New Size(288, 23)
        Me.EMEFs1.TabIndex = 9
        '
        'EMEFs2
        '
        Me.EMEFs2.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EMEFs2.BorderStyle = BorderStyle.FixedSingle
        Me.EMEFs2.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EMEFs2.Location = New Point(6, 59)
        Me.EMEFs2.Name = "EMEFs2"
        Me.EMEFs2.Size = New Size(253, 23)
        Me.EMEFs2.TabIndex = 8
        '
        'EMEFxl
        '
        Me.EMEFxl.AutoSize = True
        Me.EMEFxl.Location = New Point(6, 92)
        Me.EMEFxl.Name = "EMEFxl"
        Me.EMEFxl.Size = New Size(35, 15)
        Me.EMEFxl.TabIndex = 5
        Me.EMEFxl.Text = "XYZR"
        '
        'EMEFz
        '
        Me.EMEFz.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EMEFz.BorderStyle = BorderStyle.FixedSingle
        Me.EMEFz.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EMEFz.Location = New Point(174, 88)
        Me.EMEFz.Name = "EMEFz"
        Me.EMEFz.Size = New Size(57, 23)
        Me.EMEFz.TabIndex = 3
        '
        'EMEFy
        '
        Me.EMEFy.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EMEFy.BorderStyle = BorderStyle.FixedSingle
        Me.EMEFy.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EMEFy.Location = New Point(111, 88)
        Me.EMEFy.Name = "EMEFy"
        Me.EMEFy.Size = New Size(57, 23)
        Me.EMEFy.TabIndex = 2
        '
        'EMEFx
        '
        Me.EMEFx.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EMEFx.BorderStyle = BorderStyle.FixedSingle
        Me.EMEFx.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EMEFx.Location = New Point(48, 88)
        Me.EMEFx.Name = "EMEFx"
        Me.EMEFx.Size = New Size(57, 23)
        Me.EMEFx.TabIndex = 0
        '
        'ECAMgb
        '
        Me.ECAMgb.Controls.Add(Me.ECAMr)
        Me.ECAMgb.Controls.Add(Me.ECAMcl)
        Me.ECAMgb.Controls.Add(Me.ECAMz)
        Me.ECAMgb.Controls.Add(Me.ECAMy)
        Me.ECAMgb.Controls.Add(Me.ECAMx)
        Me.ECAMgb.Location = New Point(312, 22)
        Me.ECAMgb.Name = "ECAMgb"
        Me.ECAMgb.Size = New Size(300, 47)
        Me.ECAMgb.TabIndex = 12
        Me.ECAMgb.TabStop = False
        Me.ECAMgb.Text = "ECAM"
        '
        'ECAMr
        '
        Me.ECAMr.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.ECAMr.BorderStyle = BorderStyle.FixedSingle
        Me.ECAMr.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ECAMr.Location = New Point(236, 17)
        Me.ECAMr.Name = "ECAMr"
        Me.ECAMr.Size = New Size(57, 23)
        Me.ECAMr.TabIndex = 29
        '
        'ECAMcl
        '
        Me.ECAMcl.AutoSize = True
        Me.ECAMcl.Location = New Point(6, 22)
        Me.ECAMcl.Name = "ECAMcl"
        Me.ECAMcl.Size = New Size(35, 15)
        Me.ECAMcl.TabIndex = 5
        Me.ECAMcl.Text = "XYZR"
        '
        'ECAMz
        '
        Me.ECAMz.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.ECAMz.BorderStyle = BorderStyle.FixedSingle
        Me.ECAMz.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ECAMz.Location = New Point(173, 17)
        Me.ECAMz.Name = "ECAMz"
        Me.ECAMz.Size = New Size(57, 23)
        Me.ECAMz.TabIndex = 3
        '
        'ECAMy
        '
        Me.ECAMy.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.ECAMy.BorderStyle = BorderStyle.FixedSingle
        Me.ECAMy.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ECAMy.Location = New Point(110, 17)
        Me.ECAMy.Name = "ECAMy"
        Me.ECAMy.Size = New Size(57, 23)
        Me.ECAMy.TabIndex = 2
        '
        'ECAMx
        '
        Me.ECAMx.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.ECAMx.BorderStyle = BorderStyle.FixedSingle
        Me.ECAMx.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ECAMx.Location = New Point(47, 17)
        Me.ECAMx.Name = "ECAMx"
        Me.ECAMx.Size = New Size(57, 23)
        Me.ECAMx.TabIndex = 0
        '
        'EMAPgb
        '
        Me.EMAPgb.Controls.Add(Me.EMAPs3l)
        Me.EMAPgb.Controls.Add(Me.EMAPs2l)
        Me.EMAPgb.Controls.Add(Me.EMAPs1l)
        Me.EMAPgb.Controls.Add(Me.EMAPilcb)
        Me.EMAPgb.Controls.Add(Me.EMAPslb)
        Me.EMAPgb.Controls.Add(Me.EMAPs3)
        Me.EMAPgb.Controls.Add(Me.EMAPs2)
        Me.EMAPgb.Controls.Add(Me.EMAPs1)
        Me.EMAPgb.Location = New Point(6, 22)
        Me.EMAPgb.Name = "EMAPgb"
        Me.EMAPgb.Size = New Size(300, 139)
        Me.EMAPgb.TabIndex = 1
        Me.EMAPgb.TabStop = False
        Me.EMAPgb.Text = "EMAP"
        '
        'EMEPgb
        '
        Me.EMEPgb.Controls.Add(Me.EMEPm)
        Me.EMEPgb.Controls.Add(Me.EMEPp)
        Me.EMEPgb.Controls.Add(Me.EMEPcb)
        Me.EMEPgb.Controls.Add(Me.EMEPr)
        Me.EMEPgb.Controls.Add(Me.EMEPcl)
        Me.EMEPgb.Controls.Add(Me.EMEPepl)
        Me.EMEPgb.Controls.Add(Me.EMEPz)
        Me.EMEPgb.Controls.Add(Me.EMEPy)
        Me.EMEPgb.Controls.Add(Me.EMEPnud)
        Me.EMEPgb.Controls.Add(Me.EMEPx)
        Me.EMEPgb.Location = New Point(312, 75)
        Me.EMEPgb.Name = "EMEPgb"
        Me.EMEPgb.Size = New Size(300, 86)
        Me.EMEPgb.TabIndex = 11
        Me.EMEPgb.TabStop = False
        Me.EMEPgb.Text = "EMEP"
        '
        'EMEPm
        '
        Me.EMEPm.BorderColour = Color.Empty
        Me.EMEPm.CustomColour = False
        Me.EMEPm.FlatBottom = False
        Me.EMEPm.FlatTop = False
        Me.EMEPm.Location = New Point(270, 0)
        Me.EMEPm.Name = "EMEPm"
        Me.EMEPm.Padding = New Padding(5)
        Me.EMEPm.Size = New Size(24, 24)
        Me.EMEPm.TabIndex = 30
        Me.EMEPm.Text = "-"
        '
        'EMEPp
        '
        Me.EMEPp.BorderColour = Color.Empty
        Me.EMEPp.CustomColour = False
        Me.EMEPp.FlatBottom = False
        Me.EMEPp.FlatTop = False
        Me.EMEPp.Location = New Point(243, 0)
        Me.EMEPp.Name = "EMEPp"
        Me.EMEPp.Padding = New Padding(5)
        Me.EMEPp.Size = New Size(24, 24)
        Me.EMEPp.TabIndex = 29
        Me.EMEPp.Text = "+"
        '
        'EMEPcb
        '
        Me.EMEPcb.DrawMode = DrawMode.OwnerDrawVariable
        Me.EMEPcb.FormattingEnabled = True
        Me.EMEPcb.Location = New Point(49, 0)
        Me.EMEPcb.Name = "EMEPcb"
        Me.EMEPcb.Size = New Size(188, 24)
        Me.EMEPcb.TabIndex = 27
        '
        'EMEPr
        '
        Me.EMEPr.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EMEPr.BorderStyle = BorderStyle.FixedSingle
        Me.EMEPr.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EMEPr.Location = New Point(237, 57)
        Me.EMEPr.Name = "EMEPr"
        Me.EMEPr.Size = New Size(57, 23)
        Me.EMEPr.TabIndex = 27
        '
        'EMEPcl
        '
        Me.EMEPcl.AutoSize = True
        Me.EMEPcl.Location = New Point(6, 61)
        Me.EMEPcl.Name = "EMEPcl"
        Me.EMEPcl.Size = New Size(35, 15)
        Me.EMEPcl.TabIndex = 5
        Me.EMEPcl.Text = "XYZR"
        '
        'EMEPepl
        '
        Me.EMEPepl.AutoSize = True
        Me.EMEPepl.Location = New Point(6, 32)
        Me.EMEPepl.Name = "EMEPepl"
        Me.EMEPepl.Size = New Size(65, 15)
        Me.EMEPepl.TabIndex = 4
        Me.EMEPepl.Text = "Entry Point"
        '
        'EMEPz
        '
        Me.EMEPz.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EMEPz.BorderStyle = BorderStyle.FixedSingle
        Me.EMEPz.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EMEPz.Location = New Point(174, 57)
        Me.EMEPz.Name = "EMEPz"
        Me.EMEPz.Size = New Size(57, 23)
        Me.EMEPz.TabIndex = 3
        '
        'EMEPy
        '
        Me.EMEPy.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EMEPy.BorderStyle = BorderStyle.FixedSingle
        Me.EMEPy.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EMEPy.Location = New Point(111, 57)
        Me.EMEPy.Name = "EMEPy"
        Me.EMEPy.Size = New Size(57, 23)
        Me.EMEPy.TabIndex = 2
        '
        'EMEPnud
        '
        Me.EMEPnud.Location = New Point(77, 28)
        Me.EMEPnud.Name = "EMEPnud"
        Me.EMEPnud.Size = New Size(49, 23)
        Me.EMEPnud.TabIndex = 1
        '
        'EMEPx
        '
        Me.EMEPx.BackColor = Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.EMEPx.BorderStyle = BorderStyle.FixedSingle
        Me.EMEPx.ForeColor = Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.EMEPx.Location = New Point(49, 57)
        Me.EMEPx.Name = "EMEPx"
        Me.EMEPx.Size = New Size(57, 23)
        Me.EMEPx.TabIndex = 0
        '
        'Timer1
        '
        Me.Timer1.Interval = 5
        '
        'DarkButton2
        '
        Me.DarkButton2.BorderColour = Color.Empty
        Me.DarkButton2.CustomColour = False
        Me.DarkButton2.FlatBottom = False
        Me.DarkButton2.FlatTop = False
        Me.DarkButton2.Location = New Point(93, 12)
        Me.DarkButton2.Name = "DarkButton2"
        Me.DarkButton2.Padding = New Padding(5)
        Me.DarkButton2.Size = New Size(75, 23)
        Me.DarkButton2.TabIndex = 11
        Me.DarkButton2.Text = "New File"
        '
        'UI
        '
        Me.AutoScaleDimensions = New SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(948, 509)
        Me.Controls.Add(Me.DarkButton2)
        Me.Controls.Add(Me.Mapgb)
        Me.Controls.Add(Me.DarkButton1)
        Me.Controls.Add(Me.MapSave)
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = false
        Me.Name = "UI"
        Me.Text = "Van Buren Editor"
        Me.TransparencyKey = Color.FromArgb(CType(CType(31,Byte),Integer), CType(CType(31,Byte),Integer), CType(CType(32,Byte),Integer))
        Me.Mapgb.ResumeLayout(false)
        Me.Triggergb.ResumeLayout(false)
        Me.Triggergb.PerformLayout
        Me.EPTHGB.ResumeLayout(false)
        Me.EPTHGB.PerformLayout
        Me.EMSDgb.ResumeLayout(false)
        Me.EMSDgb.PerformLayout
        Me.EME2gb.ResumeLayout(false)
        Me.EME2gb.PerformLayout
        CType(Me.EME2dgv,ISupportInitialize).EndInit
        Me.EMEFgb.ResumeLayout(false)
        Me.EMEFgb.PerformLayout
        Me.ECAMgb.ResumeLayout(false)
        Me.ECAMgb.PerformLayout
        Me.EMAPgb.ResumeLayout(false)
        Me.EMAPgb.PerformLayout
        Me.EMEPgb.ResumeLayout(false)
        Me.EMEPgb.PerformLayout
        CType(Me.EMEPnud,ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents DarkButton1 As DarkButton
    Friend WithEvents EMAPs3 As DarkTextBox
    Friend WithEvents EMAPs2 As DarkTextBox
    Friend WithEvents EMAPs1 As DarkTextBox
    Friend WithEvents EMAPslb As DarkButton
    Friend WithEvents MapSave As DarkButton
    Friend WithEvents EMAPilcb As DarkCheckBox
    Friend WithEvents Mapgb As DarkGroupBox
    Friend WithEvents EMEPgb As DarkGroupBox
    Friend WithEvents EMEPcl As DarkLabel
    Friend WithEvents EMEPepl As DarkLabel
    Friend WithEvents EMEPz As DarkTextBox
    Friend WithEvents EMEPy As DarkTextBox
    Friend WithEvents EMEPnud As DarkNumericUpDown
    Friend WithEvents EMEPx As DarkTextBox
    Friend WithEvents ECAMgb As DarkGroupBox
    Friend WithEvents ECAMz As DarkTextBox
    Friend WithEvents ECAMy As DarkTextBox
    Friend WithEvents ECAMx As DarkTextBox
    Friend WithEvents EME2n As DarkTextBox
    Friend WithEvents EME2x As DarkTextBox
    Friend WithEvents EME2y As DarkTextBox
    Friend WithEvents EME2z As DarkTextBox
    Friend WithEvents EME2dgv As DataGridView
    Friend WithEvents EME2s5 As DarkTextBox
    Friend WithEvents EME2s4 As DarkTextBox
    Friend WithEvents EME2s3 As DarkTextBox
    Friend WithEvents EME2s2 As DarkTextBox
    Friend WithEvents EME2s1 As DarkTextBox
    Friend WithEvents EME2dsb As DarkScrollBar
    Friend WithEvents Timer1 As Timer
    Friend WithEvents EMAPs3l As DarkLabel
    Friend WithEvents EMAPs2l As DarkLabel
    Friend WithEvents EMAPs1l As DarkLabel
    Friend WithEvents EME2s5l As DarkLabel
    Friend WithEvents EME2s4l As DarkLabel
    Friend WithEvents EME2s3l As DarkLabel
    Friend WithEvents EME2cb As DarkComboBox
    Friend WithEvents EME2r As DarkTextBox
    Friend WithEvents EMEPr As DarkTextBox
    Friend WithEvents EMEPcb As DarkComboBox
    Friend WithEvents ECAMr As DarkTextBox
    Friend WithEvents EPTHGB As DarkGroupBox
    Friend WithEvents EPTHr As DarkTextBox
    Friend WithEvents EPTHn As DarkTextBox
    Friend WithEvents EPTHpcb As DarkComboBox
    Friend WithEvents EPTHcb As DarkComboBox
    Friend WithEvents EPTHx As DarkTextBox
    Friend WithEvents EPTHxl As DarkLabel
    Friend WithEvents EPTHy As DarkTextBox
    Friend WithEvents EPTHz As DarkTextBox
    Friend WithEvents EMSDgb As DarkGroupBox
    Friend WithEvents EMSDcb As DarkComboBox
    Friend WithEvents EMSDs2l As DarkLabel
    Friend WithEvents EMSDs1 As DarkTextBox
    Friend WithEvents EMSDs2 As DarkTextBox
    Friend WithEvents EMSDcl As DarkLabel
    Friend WithEvents EMSDz As DarkTextBox
    Friend WithEvents EMSDy As DarkTextBox
    Friend WithEvents EMSDx As DarkTextBox
    Friend WithEvents EMEFgb As DarkGroupBox
    Friend WithEvents EMEFcb As DarkComboBox
    Friend WithEvents EMEFs2l As DarkLabel
    Friend WithEvents EMEFs1 As DarkTextBox
    Friend WithEvents EMEFs2 As DarkTextBox
    Friend WithEvents EMEFxl As DarkLabel
    Friend WithEvents EMEFz As DarkTextBox
    Friend WithEvents EMEFy As DarkTextBox
    Friend WithEvents EMEFx As DarkTextBox
    Friend WithEvents EMEFr As DarkTextBox
    Friend WithEvents Triggergb As DarkGroupBox
    Friend WithEvents Triggertcb As DarkComboBox
    Friend WithEvents Triggern As DarkTextBox
    Friend WithEvents Triggerpcb As DarkComboBox
    Friend WithEvents Triggercb As DarkComboBox
    Friend WithEvents Triggerx As DarkTextBox
    Friend WithEvents Triggerxl As DarkLabel
    Friend WithEvents Triggery As DarkTextBox
    Friend WithEvents Triggerz As DarkTextBox
    Friend WithEvents EME2gb As DarkGroupBox
    Friend WithEvents EME2cl As DarkLabel
    Friend WithEvents ECAMcl As DarkLabel
    Friend WithEvents EMAPgb As DarkGroupBox
    Friend WithEvents EME2m As DarkButton
    Friend WithEvents EME2p As DarkButton
    Friend WithEvents EMEPm As DarkButton
    Friend WithEvents EMEPp As DarkButton
    Friend WithEvents EMEFm As DarkButton
    Friend WithEvents EMEFp As DarkButton
    Friend WithEvents EMSDm As DarkButton
    Friend WithEvents EMSDp As DarkButton
    Friend WithEvents Triggerm As DarkButton
    Friend WithEvents Triggerp As DarkButton
    Friend WithEvents EPTHm As DarkButton
    Friend WithEvents EPTHp As DarkButton
    Friend WithEvents DarkButton2 As DarkButton
End Class
