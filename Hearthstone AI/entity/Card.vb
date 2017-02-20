Public Class Card
    Public Taunt As Boolean
    Public DivineShield As Boolean
    Public Health As Integer
    Public Attack As Integer
    Public Cost As Integer
    Public Spell As Boolean
    Public CardID As String
    Public EntID As Integer
    Public StartingEnt As IEntity

    Sub New(ByRef StartEnt As IEntity)
        StartingEnt = StartEnt
        EntID = StartEnt.Number
    End Sub


End Class
