Imports System.IO
Imports System.Text.RegularExpressions
Public Class cardParser
    Dim gameBoard As New board
    Dim lines As List(Of String)
    Dim currLine As Integer = 0
    Dim LastEnt As BaseEntity
    Dim currentBlock As String
    Dim Entities As List(Of BaseEntity)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Entities = New List(Of BaseEntity)
        lines = New List(Of String)
        LastEnt = New BaseEntity(0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'ReadAllLines()
        'ParseNewLines()
        'CreateBoard()
        'DisplayEntInfo()

        Timer1.Interval = 1000
        If Timer1.Enabled = True Then
            Timer1.Stop()
            Button1.Text = "Turn On Timer"
        Else
            Timer1.Start()
            Button1.Text = "Turn Off Timer"
        End If

    End Sub

    Private Sub ParseLine(Line As String)
        'MsgBox("Parsing: " & Line)
        Dim EntID As Integer
        If Regex.IsMatch(Line, "CREATE_GAME") Then
            Entities = New List(Of BaseEntity)
        End If
        Dim BlockSearch As String = "TAG_CHANGE|HIDE_ENTITY|BLOCK_START BlockType=PLAY|BLOCK_START BlockType=ATTACK|BLOCK_START BlockType=TRIGGER|FULL_ENTITY|SHOW_ENTITY"
        If Regex.IsMatch(Line, BlockSearch) Then
            currentBlock = Regex.Match(Line, BlockSearch).Value
        End If
        TextBox3.Text = currentBlock
        Dim IntNumber As String = "(?<=(ID|id|Entity)=)[0-9]+"
        If Regex.IsMatch(Line, IntNumber) Then
            EntID = CInt(Regex.Match(Line, IntNumber).Value)
            Dim EntFound As Boolean
            For Each ent In Entities
                If ent.Number = EntID Then
                    LastEnt = ent
                    EntFound = True
                End If
            Next
            If EntFound = False Then
                LastEnt = New BaseEntity(EntID)
                Entities.Add(LastEnt)
            End If
        End If
        If Regex.IsMatch(Line, "tag=") And Regex.IsMatch(Line, "value=") Then
            LastEnt.SetTag(Regex.Match(Line, "(?<=tag=)\S*").Value, Regex.Match(Line, "(?<=value=)\S*").Value, Line.Split(") -")(1))
        End If
        If Regex.IsMatch(Line, "(?<=\S+)(?<!tag)(?<!value)=") Then
            Dim matches As MatchCollection = Regex.Matches(Line, "\S+(?<!tag)(?<!value)=\S*")
            For i = 0 To matches.Count - 1
                Dim tag As String = matches.Item(i).Value
                LastEnt.SetTag(tag.Substring(0, tag.IndexOf("=")), tag.Substring(1 + tag.IndexOf("=")), Line.Split(") -")(1))
            Next
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Try
            TextBox1.Text = Entities(ListBox1.SelectedIndex).GetValues
        Catch

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        gameBoard.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ReadAllLines()
        ParseNewLines()
        CreateBoard()
        DisplayEntInfo()
    End Sub

    Private Sub DisplayEntInfo()
        ListBox1.Items.Clear()
        For Each Ent In Entities
            ListBox1.Items.Add("Ent" & Ent.Number)
        Next
    End Sub

    Private Sub CreateBoard()
        gameBoard.currentGame.playerHand.Clear()
        gameBoard.currentGame.playerBoard.Clear()
        For Each ent In Entities
            If ent.GetTag("zone") = "PLAY" Then
                'TextBox2.Text = TextBox2.Text & ent.Number & vbNewLine
                gameBoard.currentGame.playerBoard.Add(ent)
            End If
            If ent.GetTag("zone") = "HAND" Then
                gameBoard.currentGame.playerHand.Add(ent)
            End If
        Next
        gameBoard.render()
    End Sub

    Private Sub ParseNewLines()
        'MsgBox(currLine & " " & lines.Count())
        While currLine < lines.Count()
            ParseLine(lines(currLine))
            currLine += 1
            Label1.Text = currLine
        End While
    End Sub

    Private Sub ReadAllLines()
        Dim logFileStream As FileStream
        If CheckBox1.Checked Then
            logFileStream = New FileStream("W:\game installs\Hearthstone\Logs\Power.log", FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
        Else
            logFileStream = New FileStream("C:\Program Files (x86)\Hearthstone\Logs\Power.log", FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
            'logFileStream = New FileStream("C:\Users\Connor\Documents\TestDocument.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
        End If
        Dim logFileReader As StreamReader = New StreamReader(logFileStream)
        For i = 1 To currLine
            logFileReader.ReadLine()
        Next
        While logFileReader.EndOfStream = False
            Dim Line As String = logFileReader.ReadLine()
            lines.Add(Line)
            'TextBox4.Text = TextBox4.Text & Line & vbNewLine
        End While
    End Sub
End Class
