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
        If Tags.ContainsKey(Tag) = False Then
            Tags.Add(Tag, Value)
            Lines.Add(Tag, Line)
            Return False
        Else
            Tags(Tag) = Value
            Lines(Tag) = Line
            Return False
        End If
    End Function

    Public Function GetValues() As String Implements IEntity.GetValues
        Dim Out As String = ""
        For Each Tag In Tags
            Out &= Tag.Key & " " & Tag.Value & " " & Lines(Tag.Key) & vbNewLine
        Next
        Return Out
    End Function
End Class