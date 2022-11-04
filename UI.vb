Public Class UI
    Private f As String
    Private ext As String
    Private m As New Map
    Private lEME2i = -1
    Private lEMEPi = -1
    Private lTriggeri = -1
    Private lTriggerpi = -1
    Private lEPTHi = -1
    Private lEPTHpi = -1
    Private lEMSDi = -1
    Private lEMEFi = -1

    Private Sub LoadFile() Handles DarkButton1.Click
        ' Loads all regions of a given file into their respective classes, and from there into the UI
        Dim ofd As New OpenFileDialog With {.Filter = "Van Buren Data File|*.AMO;*.ARM;*.CON;*.CRT;*.DOR;*.INT;*.ITM;*.MAP;*.USE;*.VEG;*.WEA", .Multiselect = False, .ValidateNames = True}
        If ofd.ShowDialog = DialogResult.OK Then
            f = ofd.FileName
            ext = f.Substring(f.LastIndexOf("."), 4)
            Select Case ext
                Case ".amo"
                    MsgBox("Not yet implemented")
                Case ".arm"
                    MsgBox("Not yet implemented")
                Case ".con"
                    MsgBox("Not yet implemented")
                Case ".crt"
                    MsgBox("Not yet implemented")
                Case ".dor"
                    MsgBox("Not yet implemented")
                Case ".int"
                    MsgBox("Not yet implemented")
                Case ".itm"
                    MsgBox("Not yet implemented")
                Case ".map"
                    lEME2i = -1
                    lEMEPi = -1
                    lTriggeri = -1
                    lTriggerpi = -1
                    lEPTHi = -1
                    lEPTHpi = -1
                    lEMSDi = -1
                    lEMEFi = -1

                    m = New Map
                    m.EMAP = f.GetRegions("EMAP")(0).ToEMAPc
                    m.EME2 = (From x In f.GetRegions("EME2") Select x.ToEME2c).ToArray
                    m.EMEP = (From x In f.GetRegions("EMEP") Select x.ToEMEPc).ToArray
                    m.ECAM = f.GetRegions("ECAM")(0).ToECAMc
                    m.Triggers = f.GetTriggers
                    m.EPTH = (From x In f.GetRegions("EPTH") Select x.ToEPTHc).ToArray
                    m.EMSD = (From x In f.GetRegions("EMSD") Select x.ToEMSDc).ToArray()
                    m.EMNP = f.GetRegions("EMNP")(0)
                    m.EMEF = (From x In f.GetRegions("EMEF") Select x.ToEMEFc).ToArray()

                    EMAPToUI()
                    EME2cb.Items.Clear()
                    For Each EME2 In m.EME2
                        EME2cb.Items.Add(EME2.name)
                    Next
                    EME2cb.SelectedIndex = 0
                    EME2ToUI()
                    ECAMToUI()
                    EMEPcb.Items.Clear()
                    For i = 1 To m.EMEP.Length
                        EMEPcb.Items.Add(i)
                    Next
                    EMEPcb.SelectedIndex = 0
                    EMEPToUI()
                    Triggercb.Items.Clear()
                    Dim a = ""
                    For i = 1 To m.Triggers.Length
                        If m.Triggers(i - 1).ExTR.s = "S" Or m.Triggers(i - 1).ExTR.s = "T" Then a = $" ({m.Triggers(i - 1).ExTR.s})"
                        Triggercb.Items.Add($"{i}{a}")
                        a = ""
                    Next
                    Triggercb.SelectedIndex = 0
                    TriggerToUI()
                    EPTHcb.Items.Clear()
                    For i = 1 To m.EPTH.Length
                        EPTHcb.Items.Add($"{i} ({m.EPTH(i - 1).name})")
                    Next
                    EPTHcb.SelectedIndex = 0
                    EPTHToUI()
                    EMSDcb.Items.Clear()
                    For i = 1 To m.EMSD.Length
                        EMSDcb.Items.Add($"{i} ({m.EMSD(i - 1).s2.Replace(".psf", "")})")
                    Next
                    EMSDcb.SelectedIndex = 0
                    EMSDToUI()
                    EMEFcb.Items.Clear()
                    For i = 1 To m.EMEF.Length
                        EMEFcb.Items.Add($"{i} ({m.EMEF(i - 1).s2.Replace(".veg", "")})")
                    Next
                    EMEFcb.SelectedIndex = 0
                    EMEFToUI()
                Case ".use"
                    MsgBox("Not yet implemented")
                Case ".veg"
                    MsgBox("Not yet implemented")
                Case ".wea"
                    MsgBox("Not yet implemented")
            End Select
        End If
    End Sub
#Region "Load classes into UI"
    Private Sub EMAPToUI()
        EMAPcolp.BackColor = m.EMAP.col : EMAPcolp.FlatAppearance.MouseOverBackColor = m.EMAP.col : EMAPcolp.FlatAppearance.MouseDownBackColor = m.EMAP.col
        EMAPs1.Text = m.EMAP.s1.Replace(".8", "")
        EMAPs2.Text = m.EMAP.s2.Replace(".rle", "")
        EMAPs3.Text = m.EMAP.s3.Replace(".dds", "")
        EMAPilcb.Checked = m.EMAP.il
    End Sub
    Private Sub EME2ToUI() Handles EME2cb.SelectedIndexChanged
        If Not lEME2i = -1 Then
            UIToEME2(lEME2i)
        End If
        EME2n.Text = m.EME2(EME2cb.SelectedIndex).name
        EME2s1.Text = m.EME2(EME2cb.SelectedIndex).EEOV.s1
        EME2s2.Text = m.EME2(EME2cb.SelectedIndex).EEOV.s2
        EME2s3.Text = m.EME2(EME2cb.SelectedIndex).EEOV.s3.Replace(".amx", "")
        EME2s4.Text = m.EME2(EME2cb.SelectedIndex).EEOV.s4.Replace(".dds", "")
        EME2s5.Text = m.EME2(EME2cb.SelectedIndex).EEOV.s5.Replace(".veg", "")
        EME2x.Text = m.EME2(EME2cb.SelectedIndex).l.x
        EME2y.Text = m.EME2(EME2cb.SelectedIndex).l.y
        EME2z.Text = m.EME2(EME2cb.SelectedIndex).l.z
        EME2r.Text = m.EME2(EME2cb.SelectedIndex).l.r
        Dim dt As New DataTable
        dt.Columns.Add("item name", GetType(String))
        For Each item In m.EME2(EME2cb.SelectedIndex).EEOV.inv
            dt.Rows.Add(item)
        Next
        EME2dgv.DataSource = dt
        For Each col As DataGridViewColumn In EME2dgv.Columns
            col.MinimumWidth = EME2dgv.Width - 18
            col.Width = EME2dgv.Width - 18
        Next
        lEME2i = EME2cb.SelectedIndex
    End Sub
    Private Sub EMEPToUI() Handles EMEPcb.SelectedIndexChanged
        If Not lEMEPi = -1 Then
            UIToEMEP(lEMEPi)
        End If
        EMEPnud.Value = m.EMEP(EMEPcb.SelectedIndex).index
        EMEPx.Text = m.EMEP(EMEPcb.SelectedIndex).p.x
        EMEPy.Text = m.EMEP(EMEPcb.SelectedIndex).p.y
        EMEPz.Text = m.EMEP(EMEPcb.SelectedIndex).p.z
        EMEPr.Text = m.EMEP(EMEPcb.SelectedIndex).p.r
        lEMEPi = EMEPcb.SelectedIndex
    End Sub
    Private Sub ECAMToUI()
        ECAMx.Text = m.ECAM.p.x
        ECAMy.Text = m.ECAM.p.y
        ECAMz.Text = m.ECAM.p.z
        ECAMr.Text = m.ECAM.p.r
    End Sub
    Private Sub TriggerToUI() Handles Triggercb.SelectedIndexChanged
        If Not lTriggeri = -1 Then
            UIToTrigger(lTriggeri, lTriggerpi)
        End If
        Triggerpcb.Items.Clear()
        For i = 1 To m.Triggers(Triggercb.SelectedIndex).EMTR.r.Count
            Triggerpcb.Items.Add(i)
        Next
        Triggerpcb.SelectedIndex = 0
        Triggertcb.SelectedItem = m.Triggers(Triggercb.SelectedIndex).ExTR.type
        Select Case m.Triggers(Triggercb.SelectedIndex).ExTR.type
            Case "S", "T"
                Triggern.Enabled = True
                Triggern.Text = m.Triggers(Triggercb.SelectedIndex).ExTR.s
            Case "B"
                Triggern.Enabled = True
                Triggern.Text = m.Triggers(Triggercb.SelectedIndex).ExTR.index
        End Select
        lTriggeri = Triggercb.SelectedIndex
    End Sub
    Private Sub Triggerpcb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Triggerpcb.SelectedIndexChanged
        Triggerx.Text = m.Triggers(Triggercb.SelectedIndex).EMTR.r(Triggerpcb.SelectedIndex).x
        Triggery.Text = m.Triggers(Triggercb.SelectedIndex).EMTR.r(Triggerpcb.SelectedIndex).y
        Triggerz.Text = m.Triggers(Triggercb.SelectedIndex).EMTR.r(Triggerpcb.SelectedIndex).z
        lTriggerpi = Triggerpcb.SelectedIndex
    End Sub
    Private Sub EPTHToUI() Handles EPTHcb.SelectedIndexChanged
        If Not lEPTHi = -1 Then
            UIToEPTH(lEPTHi, lEPTHpi)
        End If
        EPTHpcb.Items.Clear()
        For i = 1 To m.EPTH(EPTHcb.SelectedIndex).p.Count
            EPTHpcb.Items.Add(i)
        Next
        EPTHpcb.SelectedIndex = 0
        EPTHn.Text = m.EPTH(EPTHcb.SelectedIndex).name
        lEPTHi = EPTHcb.SelectedIndex
    End Sub

    Private Sub EPTHpcb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles EPTHpcb.SelectedIndexChanged
        EPTHx.Text = m.EPTH(EPTHcb.SelectedIndex).p(EPTHpcb.SelectedIndex).x
        EPTHy.Text = m.EPTH(EPTHcb.SelectedIndex).p(EPTHpcb.SelectedIndex).y
        EPTHz.Text = m.EPTH(EPTHcb.SelectedIndex).p(EPTHpcb.SelectedIndex).z
        EPTHr.Text = m.EPTH(EPTHcb.SelectedIndex).p(EPTHpcb.SelectedIndex).r
        lEPTHpi = EPTHpcb.SelectedIndex
    End Sub
    Private Sub EMSDToUI() Handles EMSDcb.SelectedIndexChanged
        If Not lEMSDi = -1 Then
            UIToEMSD(lEMSDi)
        End If
        EMSDs1.Text = m.EMSD(EMSDcb.SelectedIndex).s1
        EMSDs2.Text = m.EMSD(EMSDcb.SelectedIndex).s2.Replace(".psf", "")
        EMSDx.Text = m.EMSD(EMSDcb.SelectedIndex).l.x
        EMSDy.Text = m.EMSD(EMSDcb.SelectedIndex).l.y
        EMSDz.Text = m.EMSD(EMSDcb.SelectedIndex).l.z
        lEMSDi = EMSDcb.SelectedIndex
    End Sub
    Private Sub EMEFToUI() Handles EMEFcb.SelectedIndexChanged
        If Not lEMEFi = -1 Then
            UIToEMEF(lEMEFi)
        End If
        EMEFs1.Text = m.EMEF(EMEFcb.SelectedIndex).s1
        EMEFs2.Text = m.EMEF(EMEFcb.SelectedIndex).s2.Replace(".veg", "")
        EMEFx.Text = m.EMEF(EMEFcb.SelectedIndex).l.x
        EMEFy.Text = m.EMEF(EMEFcb.SelectedIndex).l.y
        EMEFz.Text = m.EMEF(EMEFcb.SelectedIndex).l.z
        EMEFr.Text = m.EMEF(EMEFcb.SelectedIndex).l.r
        lEMEFi = EMEFcb.SelectedIndex
    End Sub
#End Region
#Region "Load UI into classes"
    Private Sub UIToEMAP()
        m.EMAP.col = EMAPcolp.BackColor
        m.EMAP.s1 = EMAPs1.Text & ".8"
        m.EMAP.s2 = EMAPs2.Text & ".rle"
        m.EMAP.s3 = EMAPs3.Text & ".dds"
        m.EMAP.il = EMAPilcb.Checked
    End Sub
    Private Sub UIToECAM()
        m.ECAM.p = New Point4(ECAMx.Text, ECAMz.Text, ECAMy.Text, ECAMr.Text)
    End Sub
    Private Sub UIToEMEF(i As Integer)
        m.EMEF(i).s1 = EMEFs1.Text
        m.EMEF(i).s2 = EMEFs2.Text & ".veg"
        m.EMEF(i).l = New Point4(EMEFx.Text, EMEFz.Text, EMEFy.Text, EMEFr.Text)
    End Sub
    Private Sub UIToEMSD(i As Integer)
        m.EMSD(i).s1 = EMSDs1.Text
        m.EMSD(i).s2 = EMSDs2.Text & ".psf"
        m.EMSD(i).l = New Point3(EMSDx.Text, EMSDz.Text, EMSDy.Text)
    End Sub
    Private Sub UIToEPTH(i As Integer, pi As Integer)
        m.EPTH(i).name = EPTHn.Text
        m.EPTH(i).p(pi).x = EPTHx.Text
        m.EPTH(i).p(pi).y = EPTHy.Text
        m.EPTH(i).p(pi).z = EPTHz.Text
        m.EPTH(i).p(pi).r = EPTHr.Text
    End Sub
    Private Sub UIToTrigger(i As Integer, pi As Integer)
        m.Triggers(i).ExTR.s = Triggern.Text
        m.Triggers(i).EMTR.r(pi) = New Point3(Triggerx.Text, Triggerz.Text, Triggery.Text)
    End Sub
    Private Sub UIToEMEP(i As Integer)
        m.EMEP(i).index = EMEPnud.Value
        m.EMEP(i).p = New Point4(EMEPx.Text, EMEPz.Text, EMEPy.Text, EMEPr.Text)
    End Sub
    Private Sub UIToEME2(i As Integer)
        m.EME2(i).name = EME2n.Text
        m.EME2(i).EEOV.s1 = EME2s1.Text
        m.EME2(i).EEOV.s2 = EME2s2.Text
        m.EME2(i).EEOV.s3 = EME2s3.Text & ".amx"
        m.EME2(i).EEOV.s4 = EME2s4.Text & ".dds"
        m.EME2(i).EEOV.s5 = EME2s5.Text & If(EME2s5.Text.Length > 0, ".veg", "")
        m.EME2(i).l = New Point4(EME2x.Text, EME2z.Text, EME2y.Text, EME2r.Text)
        Dim s = (From row As DataGridViewRow In EME2dgv.Rows Select row.Cells.Item(0).Value).Cast(Of String)().ToList()
        s.Remove(s.Last)
        m.EME2(i).EEOV.inv = s.ToArray()
    End Sub
#End Region
    Private Sub DataGridView1_ScrollChanged() Handles EME2dgv.Scroll
        EME2dsb.ScrollTo(EME2dgv.FirstDisplayedScrollingRowIndex / (EME2dgv.Rows.Count - EME2dgv.DisplayedRowCount(False)) * EME2dsb.Maximum)
    End Sub
    Private Sub DarkScrollBar1_Click(sender As Object, e As EventArgs) Handles EME2dsb.MouseDown
        Timer1.Start()
    End Sub
    Private Sub DarkScrollBar1_MouseUp(sender As Object, e As EventArgs) Handles EME2dsb.MouseUp
        Timer1.Stop()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        EME2dgv.FirstDisplayedScrollingRowIndex = EME2dsb.Value / EME2dsb.Maximum * (EME2dgv.Rows.Count - EME2dgv.DisplayedRowCount(False))
    End Sub

    Private Sub DarkButton2_Click(sender As Object, e As EventArgs) Handles EMAPslb.Click
        Dim cd As New ColorDialog With {.Color = m.EMAP.col, .FullOpen = True}
        If cd.ShowDialog() = DialogResult.OK Then
            EMAPcolp.BackColor = cd.Color : EMAPcolp.FlatAppearance.MouseDownBackColor = cd.Color : EMAPcolp.FlatAppearance.MouseOverBackColor = cd.Color
            m.EMAP.col = cd.Color
        End If
    End Sub

    Private Sub DarkButton3_Click(sender As Object, e As EventArgs) Handles MapSave.Click
        Dim sfd As New SaveFileDialog With {.Filter = $"Van Buren Data File|*{ext}", .ValidateNames = True, .DefaultExt = ext}
        If sfd.ShowDialog = DialogResult.OK Then
            UIToEMAP()
            UIToEME2(EME2cb.SelectedIndex)
            UIToEMEP(EMEPcb.SelectedIndex)
            UIToECAM()
            UIToTrigger(Triggercb.SelectedIndex, Triggerpcb.SelectedIndex)
            UIToEPTH(EPTHcb.SelectedIndex, EPTHpcb.SelectedIndex)
            UIToEMSD(EMSDcb.SelectedIndex)
            UIToEMEF(EMEFcb.SelectedIndex)
            Dim b As New List(Of Byte)
            b.AddRange(m.EMAP.ToEMAPb)
            b.AddRange(m.EME2.SelectMany(Function(x) x.ToEME2b()))
            b.AddRange(m.EMEP.SelectMany(Function(x) x.ToEMEPb()))
            b.AddRange(m.ECAM.ToECAMb())
            b.AddRange(m.Triggers.SelectMany(Function(x) x.ToTriggerB()))
            b.AddRange(m.EPTH.SelectMany(Function(x) x.ToEPTHb()))
            b.AddRange(m.EMSD.SelectMany(Function(x) x.ToEMSDb()))
            b.AddRange(m.EMNP)
            b.AddRange(m.EMEF.SelectMany(Function(x) x.ToEMEFb()))
            IO.File.WriteAllBytes(sfd.FileName, b.ToArray)
        End If
    End Sub

    Private Sub MyBase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EME2dgv.GridColor = AltUI.Config.ThemeProvider.Theme.Colors.GreySelection
        EME2dgv.BackgroundColor = AltUI.Config.ThemeProvider.BackgroundColour
        EME2dgv.DefaultCellStyle = New DataGridViewCellStyle With {.BackColor = AltUI.Config.ThemeProvider.BackgroundColour, .ForeColor = AltUI.Config.ThemeProvider.Theme.Colors.LightText, .SelectionBackColor = AltUI.Config.ThemeProvider.Theme.Colors.BlueSelection, .SelectionForeColor = AltUI.Config.ThemeProvider.Theme.Colors.LightText}
    End Sub

End Class