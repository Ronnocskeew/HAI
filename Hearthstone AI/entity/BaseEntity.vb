Imports Hearthstone_AI

Class BaseEntity
    Implements IEntity

    Public Property Number As Integer Implements IEntity.Number
    Public Property Name As String Implements IEntity.Name
    Private Tags As Dictionary(Of String, String)
    Private Lines As Dictionary(Of String, String)
    Sub New(Num As Integer)
        Number = Num
        Tags = New Dictionary(Of String, String)
        Lines = New Dictionary(Of String, String)
        Name = "Unknown"
    End Sub

    Public Function SetTag(Tag As String, Value As String, Line As String) As Boolean Implements IEntity.SetTag
        If Tags.ContainsKey(Tag.ToUpper) = False Then
            Tags.Add(Tag.ToUpper, Value)
            Lines.Add(Tag.ToUpper, Line)
            Return False
        Else
            Tags(Tag.ToUpper) = Value
            Lines(Tag.ToUpper) = Line
            Return False
        End If
    End Function

    Public Function GetTag(Tag As String) As String Implements IEntity.GetTag
        If Tags.ContainsKey(Tag.ToUpper) = True Then
            Return Tags(Tag.ToUpper)
        End If
        Return ""
    End Function

    Public Function GetValues() As String Implements IEntity.GetValues
        Dim Out As String = ""
        For Each Tag In Tags
            Out &= Tag.Key & " " & Tag.Value & " " & Lines(Tag.Key) & vbNewLine
        Next
        Return Out
    End Function
End Class