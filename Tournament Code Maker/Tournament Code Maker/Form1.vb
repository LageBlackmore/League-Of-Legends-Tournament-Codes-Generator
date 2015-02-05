Public Class Form1
    'By Saeed Suleiman 
    'All Rights Reserved 2014 Saeed Suleiman (C)
    'This is not a promotion code generator !!!!
    'For Help Contact Me At halearn@gmail.com 

    Dim gamepass As String
    Dim gamename As String
    Dim map As String
    Dim mode As String
    Dim report As String
    Dim spec As String
    Dim teamsize As String


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = "" Then
                MsgBox("Input A Game Name")
            Else
                gamename = TextBox1.Text
                gamepass = TextBox2.Text
                If SR.Checked = True Then
                    map = "map11"
                ElseIf HA.Checked = True Then
                    map = "map12"
                ElseIf CS.Checked = True Then
                    map = "map8"
                ElseIf TT.Checked = True Then
                    map = "map10"
                End If

                If BP.Checked = True Then
                    mode = "pick1"
                ElseIf AR.Checked = True Then
                    mode = "pick4"
                ElseIf TD.Checked = True Then
                    mode = "pick6"
                ElseIf DM.Checked = True Then
                    mode = "pick2"
                End If

                If AllowAll.Checked = True Then
                    spec = "specALL"
                ElseIf AllowLobby.Checked = True Then
                    spec = "specLOBBYONLY"
                ElseIf AllowNoOne.Checked = True Then
                    spec = "specNONE"
                End If
                teamsize = "team" & NumericUpDown1.Value
                If TextBox3.Text = "" Then
                    report = "http:\/\/website.com\/gamereport\/"
                Else
                    report = TextBox3.Text
                End If
                Dim id As String = TextBox6.Text
                Dim basepart As String = "{""name"":""" & gamename & """,""extra"":"",""password"":""" & gamepass & """,""report"":""" & report & """}"
                Dim basepart2 As String = "{""name"":""" & gamename & """,""extra"":""" & id & """,""password"":""" & gamepass & """,""report"":""" & report & """}"

                Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(basepart2)
                Dim base64 As String = System.Convert.ToBase64String(byt)
                Dim finalcode As String = "pvpnet://lol/customgame/joinorcreate/" & map & "/" & mode & "/" & teamsize & "/" & spec & "/" & base64
                TextBox4.Text = finalcode
                My.Computer.Clipboard.Clear()
                My.Computer.Clipboard.SetText(finalcode)
                MsgBox("Code Has Been Generated And Copied To Your Clipboard")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub TT_CheckedChanged(sender As Object, e As EventArgs) Handles TT.CheckedChanged
        If TT.Checked = True Then
            NumericUpDown1.Value = 3
            NumericUpDown1.Maximum = 3
        Else
            NumericUpDown1.Maximum = 5
            NumericUpDown1.Value = 5
        End If
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Label10.Text = "Map :"
            Label11.Text = "Game Mode :"
            Label12.Text = "Team Size :"
            Label13.Text = "Spectator Mode :"
            Label14.Text = "Game Name :"
            Label15.Text = "Game Password :"
            Label16.Text = "Game ID :"
            Label17.Text = "Organizers Website :"
            Dim code = TextBox5.Text
            code = code.Substring(37, code.Length - 37)
            Dim parts = code.Split("/")
            Dim map1 As String = parts(0)
            Dim pick As String = parts(1)
            Dim team As String = parts(2)
            Dim spec1 As String = parts(3)
            Dim bytecode As String = parts(4)

            Dim b As Byte() = Convert.FromBase64String(bytecode)
            Dim json As String = System.Text.Encoding.UTF8.GetString(b)
            Dim parts2 = json.Split(",")
            Dim name As String = parts2(0)
            Dim name2 = name.Split(":")
            name = name2(1)
            name = name.Substring(1, name.Length - 2)
            Dim id As String = parts2(1)
            Dim id2 = id.Split(":")
            id = id2(1)
            id = id.Substring(1, id.Length - 2)
            Dim report As String = parts2(3)
            report = report.Remove(0, 10)
            report = report.Remove(report.Length - 3, 3)


            If map1 = "map1" Then map1 = "Summoners Rift (OLD (Removed))"
            If map1 = "map10" Then map1 = "Twisted Treeline"
            If map1 = "map11" Then map1 = "Summoners Rift (New (Beta))"
            If map1 = "map8" Then map1 = "Crystal Scar"
            If map1 = "map12" Then map1 = "Howling Abyss"

            If pick = "pick1" Then pick = "Blind Pick"
            If pick = "pick2" Then pick = "Draft Mode"
            If pick = "pick4" Then pick = "All Random"
            If pick = "pick6" Then pick = "Tournament Draft"

            team = team.Remove(0, 4)

            If spec1 = "specALL" Then spec1 = "Anyone Can Spectate"
            If spec1 = "specNONE" Then spec1 = "No One Can Spectate"
            If spec1 = "specLOBBYONLY" Then spec1 = "Only The People In The Lobby Can Spectate"
            Dim pass As String = parts2(2)
            Dim pass2 = pass.Split(":")
            pass = pass2(1).Substring(1, pass2(1).Length - 2)

            Label10.Text = Label10.Text & " " & map1
            Label11.Text = Label11.Text & " " & pick
            Label12.Text = Label12.Text & " " & team & " Player"
            Label13.Text = Label13.Text & " " & spec1
            Label14.Text = Label14.Text & " " & name
            Label15.Text = Label15.Text & " " & pass
            Label16.Text = Label16.Text & " " & id
            Label17.Text = Label17.Text & " " & report


        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Computer.Clipboard.Clear()
        My.Computer.Clipboard.SetText(TextBox4.Text)
    End Sub
End Class
