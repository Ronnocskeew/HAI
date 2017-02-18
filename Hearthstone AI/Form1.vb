﻿Imports System.IO
Imports System.Text.RegularExpressions
Public Class Form1
    Dim lines As List(Of String)
    Dim currLine As Integer = -1
    Dim LastEnt As BaseEntity
    Dim currentBlock As String
    Dim Entities As List(Of BaseEntity)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Entities = New List(Of BaseEntity)
        LastEnt = New BaseEntity(0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For i = 1 To 300
            ReadLine()
        Next
        ListBox1.Items.Clear()
        For Each Ent In Entities
            ListBox1.Items.Add("Ent" & Ent.Number)
        Next
    End Sub

    Private Sub ReadLine()
        currLine += 1
        If currLine >= lines.Count Then Return
        Dim Line As String = lines(currLine)
        Dim EntID As Integer
        If Regex.IsMatch(Line, "TAG_CHANGE|HIDE_ENTITY|BLOCK_START BlockType=PLAY|BLOCK_START BlockType=TRIGGER|FULL_ENTITY|SHOW_ENTITY") Then
            currentBlock = Regex.Match(Line, "TAG_CHANGE").Value
        End If
        If Regex.IsMatch(Line, "(?<=(ID|id|Entity)=)[0-9]+") Then
            'MsgBox(Line)
            EntID = CInt(Regex.Match(Line, "(?<=(ID|id|Entity)=)[0-9]+").Value)
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
            LastEnt.SetTag(Regex.Match(Line, "(?<=tag=)\S*").Value, Regex.Match(Line, "(?<=value=)\S*").Value, Line)
        End If
        If Regex.IsMatch(Line, "(?<=\S+)(?<!tag)(?<!value)=") Then
            Dim matches As MatchCollection = Regex.Matches(Line, "\S+(?<!tag)(?<!value)=\S*")
            For i = 0 To matches.Count - 1
                Dim tag As String = matches.Item(i).Value
                LastEnt.SetTag(tag.Substring(0, tag.IndexOf("=")), tag.Substring(1 + tag.IndexOf("=")), Line)
            Next
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        TextBox1.Text = Entities(ListBox1.SelectedIndex).GetValues
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim logFileStream As FileStream
        If CheckBox1.Checked Then
            logFileStream = New FileStream("W:\game installs\Hearthstone\Logs\Power.log", FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
        Else
            logFileStream = New FileStream("C:\Program Files (x86)\Hearthstone\Logs\Power.log", FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
        End If
        Dim logFileReader As StreamReader = New StreamReader(logFileStream)
        lines = New List(Of String)
        While logFileReader.EndOfStream = False
            lines.Add(logFileReader.ReadLine())
        End While
        'lines = File.ReadAllLines("C:\Program Files (x86)\Hearthstone\Logs\Power.log")
    End Sub

End Class