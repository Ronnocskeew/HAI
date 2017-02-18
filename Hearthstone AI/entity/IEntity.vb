Public Interface IEntity
    Property Number As Integer
    Property Name As String
    Function SetTag(Tag As String, Value As String, Line As String) As Boolean
    Function GetTag(Tag As String) As String
    Function GetValues() As String
End Interface
