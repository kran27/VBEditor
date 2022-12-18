Imports System.Runtime.CompilerServices
Imports System.Text

Friend Module Functions

#Region "Byte array to Class"

    ' Functions to convert from F3-readable byte arrays extracted from files, into easily-manipulatable custom classes
    <Extension>
    Public Function ToEMAPc(ByRef b As Byte()) As EMAPc
        Dim s1o = 18 : Dim s1l = b(s1o - 2)
        Dim s2o = s1o + s1l + 2 : Dim s2l = b(s2o - 2)
        Dim s3o = s2o + s2l + 2 : Dim s3l = b(s3o - 2)
        Return New EMAPc With {
            .s1 = Encoding.ASCII.GetString(b, s1o, s1l),
            .s2 = Encoding.ASCII.GetString(b, s2o, s2l),
            .s3 = Encoding.ASCII.GetString(b, s3o, s3l),
            .col = Color.FromArgb(b(s3o + s3l + 2), b(s3o + s3l + 3), b(s3o + s3l + 4)),
            .il = b(4) = 0,
            .le = b(s3o + s3l)
        }
    End Function

    <Extension>
    Public Function ToEMTRc(ByRef b As Byte()) As EMTRc
        Dim l As New List(Of Point3)
        For i = 20 To b.Length - 1 Step 12
            l.Add(New Point3(BitConverter.ToSingle(b, i), BitConverter.ToSingle(b, i + 4), BitConverter.ToSingle(b, i + 8)))
        Next
        Return New EMTRc With {
            .n = b(12),
            .r = l
        }
    End Function

    <Extension>
    Public Function ToExTRc(ByRef b As Byte()) As ExTRc
        Dim type = Encoding.ASCII.GetString(b.Skip(1).Take(1).ToArray())
        Return New ExTRc With {
            .type = type,
            .s = If(type = "B", b(12), Encoding.ASCII.GetString(b.Skip(14).Take(b(12)).ToArray()))
            }
    End Function

    <Extension>
    Public Function ToECAMc(ByRef b As Byte()) As ECAMc
        Return New ECAMc With {
            .p =
                New Point4(BitConverter.ToSingle(b, 12), BitConverter.ToSingle(b, 16), BitConverter.ToSingle(b, 20),
                           BitConverter.ToSingle(b, 24))
        }
    End Function

    <Extension>
    Public Function ToEMEPc(ByRef b As Byte()) As EMEPc
        Return New EMEPc With {
            .index = b(12),
            .p =
                New Point4(BitConverter.ToSingle(b, 73), BitConverter.ToSingle(b, 77), BitConverter.ToSingle(b, 81),
                           BitConverter.ToSingle(b, 105))
        }
    End Function

    <Extension>
    Public Function ToEMEFc(ByRef b As Byte()) As EMEFc
        Return New EMEFc With {
            .s1 = Encoding.ASCII.GetString(b.Skip(14).Take(b(12)).ToArray()),
            .l =
                New Point4(BitConverter.ToSingle(b, 14 + b(12)), BitConverter.ToSingle(b, 18 + b(12)),
                           BitConverter.ToSingle(b, 22 + b(12)), BitConverter.ToSingle(b, 26 + b(12))),
            .s2 = Encoding.ASCII.GetString(b.Skip(41 + b(12)).Take(b(39 + b(12))).ToArray())
                        }
    End Function

    <Extension>
    Public Function ToEMSDc(ByRef b As Byte()) As EMSDc
        Return New EMSDc With {
            .s1 = Encoding.ASCII.GetString(b.Skip(14).Take(b(12)).ToArray()),
            .s2 = Encoding.ASCII.GetString(b.Skip(28 + b(12)).Take(b(26 + b(12))).ToArray()),
            .l =
                New Point3(BitConverter.ToSingle(b, 14 + b(12)), BitConverter.ToSingle(b, 18 + b(12)),
                           BitConverter.ToSingle(b, 22 + b(12)))
        }
    End Function

    <Extension>
    Public Function ToEPTHc(ByRef b As Byte()) As EPTHc
        Dim l As New List(Of Point4)
        For i = 18 + b(12) To b.Length - 1 Step 24
            l.Add(New Point4(BitConverter.ToSingle(b, i), BitConverter.ToSingle(b, i + 4),
                             BitConverter.ToSingle(b, i + 8), BitConverter.ToSingle(b, i + 12)))
        Next
        Return New EPTHc With {
            .name = Encoding.ASCII.GetString(b.Skip(14).Take(b(12)).ToArray()),
            .p = l
        }
    End Function

    <Extension>
    Public Function ToEME2c(ByRef b As Byte()) As EME2c
        Dim cl = b.Locate(Encoding.ASCII.GetBytes("EEOV"))(0)
        Return New EME2c With {
            .name = Encoding.ASCII.GetString(b, 14, b(12)),
            .l =
                New Point4(BitConverter.ToSingle(b, 14 + b(12)), BitConverter.ToSingle(b, 18 + b(12)),
                           BitConverter.ToSingle(b, 22 + b(12)), BitConverter.ToSingle(b, 26 + b(12))),
            .EEOV = b.Skip(cl).Take(BitConverter.ToInt32(b, cl + 8)).ToArray().ToEEOVc
        }
    End Function

    <Extension>
    Public Function ToEEOVc(ByRef b As Byte()) As EEOVc
        Dim s1o = 14 : Dim s1l = b(s1o - 2)
        Dim s2o = s1o + s1l + 13 : Dim s2l = b(s2o - 2)
        Dim s3o = s2o + s2l + 2 : Dim s3l = b(s3o - 2)
        Dim s4o = s3o + s3l + 11 : Dim s4l = b(s4o - 2)
        Dim s5o = s4o + s4l + 3

        Dim ps4 = b(s4o + s4l)

        If ps4 = 2 Then
            s5o += 2
        End If

        Dim s5l = b(s5o - 2)
        If s5l = 1 Then s5l = 0

        Dim inv = New List(Of String)
        Dim io = s5o + s5l + 6
        Dim itemN As String
        For i = io To b.Length - 1
            Try : itemN = Encoding.ASCII.GetString(b.Skip(io).Take(b(io - 2)).ToArray()) : Catch : Exit For : End Try
            If Not itemN.Length = 0 Then inv.Add(itemN)
            io += b(io - 2) + 2
        Next

        Return New EEOVc With {
            .s1 = Encoding.ASCII.GetString(b.Skip(s1o).Take(s1l).ToArray()),
            .s2 = Encoding.ASCII.GetString(b.Skip(s2o).Take(s2l).ToArray()),
            .s3 = Encoding.ASCII.GetString(b.Skip(s3o).Take(s3l).ToArray()),
            .s4 = Encoding.ASCII.GetString(b.Skip(s4o).Take(s4l).ToArray()),
            .s5 = If(ps4 > 0, Encoding.ASCII.GetString(b.Skip(s5o).Take(s5l).ToArray()), ""),
            .ps4 = ps4,
            .inv = inv.ToArray()
        }
    End Function

    <Extension>
    Public Function ToEEN2c(ByRef b As Byte()) As EEN2c
        Dim cl = b.Locate(Encoding.ASCII.GetBytes("EEOV"))(0)
        Dim s1o = 14 : Dim s1l = b(s1o - 2)
        Dim s2o = s1o + s1l + 2 : Dim s2l = b(s2o - 2)
        Dim s3o = s2o + s2l + 2 : Dim s3l = b(s3o - 2)
        Return New EEN2c() With {
            .skl = Encoding.ASCII.GetString(b, s1o, s1l),
            .invtex = Encoding.ASCII.GetString(b, s2o, s2l),
            .acttex = Encoding.ASCII.GetString(b, s3o, s3l),
            .sel = b(s3o + s3l + 1),
            .EEOV = b.Skip(cl).Take(BitConverter.ToInt32(b, cl + 8)).ToArray().ToEEOVc
            }
    End Function

    <Extension>
    Public Function ToGENTc(ByRef b As Byte()) As GENTc
        Return New GENTc() With {
            .HoverSR = BitConverter.ToInt32(b, 12),
                        .LookSR = BitConverter.ToInt32(b, 16),
        .NameSR = BitConverter.ToInt32(b, 20),
        .UnkwnSR = BitConverter.ToInt32(b, 24),
        .MaxHealth = BitConverter.ToInt32(b, 36),
        .StartHealth = BitConverter.ToInt32(b, 40)
            }
    End Function

    <Extension>
    Public Function ToGCHRc(ByRef b As Byte()) As GCHRc
        Return New GCHRc() With {
            .name = Encoding.ASCII.GetString(b, 14, b(12))
            }
    End Function

    <Extension>
    Public Function ToGWAMc(ByRef b As Byte()) As GWAMc
        Return New GWAMc() With {
            .Anim = BitConverter.ToInt32(b, 12),
            .DmgType = BitConverter.ToInt32(b, 16),
            .ShotsFired = BitConverter.ToInt32(b, 20),
            .Range = BitConverter.ToInt32(b, 36),
            .MinDmg = BitConverter.ToInt32(b, 48),
            .MaxDmg = BitConverter.ToInt32(b, 52),
            .AP = BitConverter.ToInt32(b, 62),
            .NameSR = BitConverter.ToInt32(b, 72),
            .VegName = Encoding.ASCII.GetString(b, 78, b(76))
        }
    End Function

    <Extension>
    Public Function ToGCREc(b As Byte()) As GCREc

#Region "Offsets, Lengths"

        Dim sl = b(72) * 8 ' Skills added length
        Dim cl = b(76 + sl) * 8 ' Characters added length
        Dim tl = b(80 + sl + cl) * 4 ' Traits added length
        Dim tsl = b(84 + sl + cl + tl) * 4 ' Tag Skills added length
        Dim po = 94 + sl + cl + tl + tsl ' Portrait String offset
        Dim pl = b(92 + sl + cl + tl + tsl) ' Portrait String Length
        Dim Heamo = 131 + sl + cl + tl + tsl + pl
        Dim Heato = Heamo + 2 + b(Heamo - 2)
        Dim Haimo = Heato + 2 + b(Heato - 2)
        Dim Haito = Haimo + 2 + b(Haimo - 2)
        Dim Ponmo = Haito + 2 + b(Haito - 2)
        Dim Ponto = Ponmo + 2 + b(Ponmo - 2)
        Dim Musmo = Ponto + 2 + b(Ponto - 2)
        Dim Musto = Musmo + 2 + b(Musmo - 2)
        Dim Beamo = Musto + 2 + b(Musto - 2)
        Dim Beato = Beamo + 2 + b(Beamo - 2)
        Dim Eyemo = Beato + 2 + b(Beato - 2)
        Dim Eyeto = Eyemo + 2 + b(Eyemo - 2)
        Dim Bodmo = Eyeto + 2 + b(Eyeto - 2)
        Dim Bodto = Bodmo + 2 + b(Bodmo - 2)
        Dim Hanmo = Bodto + 2 + b(Bodto - 2)
        Dim Hanto = Hanmo + 2 + b(Hanmo - 2)
        Dim Feemo = Hanto + 2 + b(Hanto - 2)
        Dim Feeto = Feemo + 2 + b(Feemo - 2)
        Dim Bacmo = Feeto + 2 + b(Feeto - 2)
        Dim Bacto = Bacmo + 2 + b(Bacmo - 2)
        Dim Shomo = Bacto + 2 + b(Bacto - 2)
        Dim Shoto = Shomo + 2 + b(Shomo - 2)
        Dim Vanmo = Shoto + 2 + b(Shoto - 2)
        Dim Vanto = Vanmo + 2 + b(Vanmo - 2)
        Dim psl = sl + cl + tl + tsl + pl + b(Heamo - 2) + b(Heato - 2) + b(Haimo - 2) + b(Haito - 2) + b(Ponmo - 2) + b(Ponto - 2) + b(Musmo - 2) + b(Musto - 2) + b(Beamo - 2) + b(Beato - 2) + b(Eyemo - 2) + b(Eyeto - 2) + b(Bodmo - 2) + b(Bodto - 2) + b(Hanmo - 2) + b(Hanto - 2) + b(Feemo - 2) + b(Feeto - 2) + b(Bacmo - 2) + b(Bacto - 2) + b(Shomo - 2) + b(Shoto - 2) + b(Vanmo - 2) + b(Vanto - 2)

#End Region

#Region "Build Sections"

        Dim gl = b.Locate(Encoding.ASCII.GetBytes("GWAM"))
        Dim tr = New List(Of Integer)
        Dim io = 84 + cl + sl
        For i = 0 To b(80 + cl + sl) - 1
            tr.Add(b(io))
            io += 4
        Next
        Dim ts = New List(Of Integer)
        io = 84 + sl + cl + tl
        For i = 1 To b(84 + sl + cl + tl)
            ts.Add(b(io))
            io += 4
        Next
        Dim skills = New List(Of Skill)
        io = 76
        For i = 0 To b(72) - 1
            skills.Add(New Skill(b(io), b(io + 4)))
            io += 8
        Next

        Dim inv = New List(Of String)
        io = 279 + psl
        Dim itemN = ""
        For i = 0 To b(io - 6) - 1
            Try : itemN = Encoding.ASCII.GetString(b.Skip(io).Take(b(io - 2)).ToArray()) : Catch : Exit For : End Try
            If Not itemN.Length = 0 Then inv.Add(itemN)
            io += b(io - 2) + 2
        Next

#End Region

        Dim il = inv.Sum(Function(x) x.Length + 2)
        Return New GCREc() With {
            .Special = New Integer() {b(12), b(16), b(20), b(24), b(28), b(32), b(36)},
            .Age = b(56),
            .Skills = skills,
            .Traits = tr,
            .TagSkills = ts,
            .PortStr = Encoding.ASCII.GetString(b, po, pl),
            .Hea =
                New Socket(Encoding.ASCII.GetString(b, Heamo, b(Heamo - 2)),
                           Encoding.ASCII.GetString(b, Heato, b(Heato - 2))),
            .Hai = New Socket(Encoding.ASCII.GetString(b, Haimo, b(Haimo - 2)),
                           Encoding.ASCII.GetString(b, Haito, b(Haito - 2))),
            .Pon = New Socket(Encoding.ASCII.GetString(b, Ponmo, b(Ponmo - 2)),
                           Encoding.ASCII.GetString(b, Ponto, b(Ponto - 2))),
            .Mus = New Socket(Encoding.ASCII.GetString(b, Musmo, b(Musmo - 2)),
                           Encoding.ASCII.GetString(b, Musto, b(Musto - 2))),
            .Bea = New Socket(Encoding.ASCII.GetString(b, Beamo, b(Beamo - 2)),
                              Encoding.ASCII.GetString(b, Beato, b(Beato - 2))),
            .Eye = New Socket(Encoding.ASCII.GetString(b, Eyemo, b(Eyemo - 2)),
                              Encoding.ASCII.GetString(b, Eyeto, b(Eyeto - 2))),
            .Bod = New Socket(Encoding.ASCII.GetString(b, Bodmo, b(Bodmo - 2)),
                              Encoding.ASCII.GetString(b, Bodto, b(Bodto - 2))),
            .Han = New Socket(Encoding.ASCII.GetString(b, Hanmo, b(Hanmo - 2)),
                              Encoding.ASCII.GetString(b, Hanto, b(Hanto - 2))),
            .Fee = New Socket(Encoding.ASCII.GetString(b, Feemo, b(Feemo - 2)),
                              Encoding.ASCII.GetString(b, Feeto, b(Feeto - 2))),
            .Bac = New Socket(Encoding.ASCII.GetString(b, Bacmo, b(Bacmo - 2)),
                              Encoding.ASCII.GetString(b, Bacto, b(Bacto - 2))),
            .Sho = New Socket(Encoding.ASCII.GetString(b, Shomo, b(Shomo - 2)),
                              Encoding.ASCII.GetString(b, Shoto, b(Shoto - 2))),
            .Van = New Socket(Encoding.ASCII.GetString(b, Vanmo, b(Vanmo - 2)),
                              Encoding.ASCII.GetString(b, Vanto, b(Vanto - 2))),
            .Inventory = inv.ToArray(),
            .GWAM = (From i In gl Select b.Skip(i).Take(BitConverter.ToInt32(b, i + 8)).ToArray().ToGWAMc()).ToList()
            }
    End Function

    <Extension>
    Private Function ReadChunk(ByRef b As Byte(), offset As Integer) As _2MWTChunk
        Dim p3 = New Point3(BitConverter.ToSingle(b, offset), BitConverter.ToSingle(b, offset + 4), BitConverter.ToSingle(b, offset + 8))
        Dim s = Encoding.ASCII.GetString(b, offset + 14, b(offset + 12))
        Dim p2 = New Point2(BitConverter.ToSingle(b, offset + 14 + s.Length), BitConverter.ToSingle(b, offset + 18 + s.Length))
        Return New _2MWTChunk(s, p3, p2)
    End Function

    <Extension>
    Public Function To2MWTc(ByRef b As Byte()) As _2MWTc
        Dim cl = New List(Of _2MWTChunk)
        Dim io = 158 + b(12)
        For i = 1 To BitConverter.ToInt32(b, 154 + b(12))
            cl.Add(b.ReadChunk(io))
            io += b(io + 12) + 22
        Next
        Return New _2MWTc With {
            .mpf = Encoding.ASCII.GetString(b, 14, b(12)),
            .frozen = b(29 + b(12)) = 0,
            .dark = b(27 + b(12)) = 0,
            .chunks = cl
            }
    End Function

#End Region

#Region ".stf Stuff"

    Public Function STFToTXT(b As Byte()) As List(Of String)
        b.PreParse()
        Dim s As New List(Of String)
        Dim oi = 12
        Dim li = 16
        For i = 0 To BitConverter.ToInt32(b, 8) - 1
            s.Add(Encoding.ASCII.GetString(b, BitConverter.ToInt32(b, oi), BitConverter.ToInt32(b, li)))
            oi += 16
            li += 16
        Next
        Return s
    End Function

    Public Function TXTToSTF(s As String()) As Byte()
        Dim b As New List(Of Byte)
        b.AddRange(New Byte() {3, 0, 0, 0, 1, 0, 0, 0})
        b.AddRange(BitConverter.GetBytes(s.Length))
        Dim o = s.Length * 16 + 12
        For i = 0 To s.Length - 1
            b.AddRange(BitConverter.GetBytes(o))
            b.AddRange(BitConverter.GetBytes(s(i).Length))
            b.AddRange(New Byte() {&H7E, &HE3, &H3, &H0, &H0, &H0, &H0, &H0})
            o += s(i).Length
        Next
        b.AddRange(s.ToFixedBytes())
        Return b.ToArray()
    End Function

    ' Replace CrLf with "|~" and replace "–" with "-"
    <Extension>
    Public Sub PreParse(ByRef b As Byte())
        Dim strStart = BitConverter.ToInt32(b, 12)
        Dim l = b.Locate(New Byte() {&HD, &HA})
        For Each m In l
            If m >= strStart Then
                b.OverwriteBytes(m, New Byte() {&H7C, &H7E})
            End If
        Next
        l = b.Locate(New Byte() {&H96})
        For Each m In l
            If m >= strStart Then
                b.OverwriteBytes(m, New Byte() {&H2D})
            End If
        Next
    End Sub

    ' Turn the string array into the chunk of bytes, replacing "|~" with CrLf
    <Extension>
    Public Function ToFixedBytes(ByRef s As String()) As Byte()
        Dim bl = New List(Of Byte)
        For Each stri In s
            bl.AddRange(Encoding.ASCII.GetBytes(stri))
        Next
        Dim b = bl.ToArray()
        Dim l = b.Locate(New Byte() {&H7C, &H7E})
        For Each m In l
            b.OverwriteBytes(m, New Byte() {&HD, &HA})
        Next
        Return b
    End Function

#End Region

#Region "Byte array search"

    ' Code for finding location of given byte array within another
    Private ReadOnly Empty(-1) As Integer

    <Extension>
    Public Function Locate(ByVal self() As Byte, ByVal candidate() As Byte) As Integer()
        If IsEmptyLocate(self, candidate) Then
            Return Empty
        End If
        Dim list As New List(Of Integer)()
        Dim i As Integer = 0
        Do While i < self.Length
            If Not IsMatch(self, i, candidate) Then
                i += 1
                Continue Do
            End If
            list.Add(i)
            i += 1
        Loop
        Return If(list.Count = 0, Empty, list.ToArray())
    End Function

    Private Function IsMatch(ByVal array() As Byte, ByVal position As Integer, ByVal candidate() As Byte) As Boolean
        If candidate.Length > (array.Length - position) Then
            Return False
        End If
        For i As Integer = 0 To candidate.Length - 1
            If array(position + i) <> candidate(i) Then
                Return False
            End If
        Next i
        Return True
    End Function

    Private Function IsEmptyLocate(ByVal array() As Byte, ByVal candidate() As Byte) As Boolean
        Return array Is Nothing OrElse candidate Is Nothing OrElse array.Length = 0 OrElse candidate.Length = 0 OrElse candidate.Length > array.Length
    End Function

#End Region

    ' Finds all locations of a given header, reads size, copies that section into byte array, puts array in list.
    <Extension>
    Public Function GetRegions(f As String, hs As String) As List(Of Byte())
        Dim file = IO.File.ReadAllBytes(f)
        Dim hn = Encoding.ASCII.GetBytes(hs)
        Dim hc = file.Locate(hn)
        Return _
            (From l In hc Let tl = BitConverter.ToInt32(file, l + 8)
             Select file.Skip(l).Take(tl).ToArray()).ToList()
    End Function

    ' Finds all triggers for .map files, and the subsequent trigger info chunk
    <Extension>
    Public Function GetTriggers(f As String) As List(Of Trigger)
        Dim file = IO.File.ReadAllBytes(f)
        Dim hc = file.Locate(Encoding.ASCII.GetBytes("EMTR"))
        Return _
            (From l In hc Let tl = BitConverter.ToInt32(file, l + 8) Let h1 = file.Skip(l).Take(tl).ToArray()
             Let h2 = file.Skip(l + tl).Take(file(l + tl + 8)).ToArray
             Select New Trigger With {.EMTR = h1.ToEMTRc, .ExTR = h2.ToExTRc}).ToList()
    End Function

    ' Writes from "newBytes" into "b", starting at the given index
    <Extension>
    Public Sub OverwriteBytes(ByRef b As Byte(), startIndex As Integer, newBytes As Byte())
        Buffer.BlockCopy(newBytes, 0, b, startIndex, newBytes.Length)
    End Sub

    ' Convert DataGridView Rows to string array using LINQ
    <Extension>
    Public Function ToStringArray(r As DataGridViewRowCollection) As String()
        Return (From row As DataGridViewRow In r Where TypeOf row.Cells.Item(0).Value Is String Select row.Cells.Item(0).Value).Cast(Of String)().ToArray()
    End Function

End Module