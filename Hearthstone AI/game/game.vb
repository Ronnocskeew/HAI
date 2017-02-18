Public Class game
    Public playerHand As New List(Of IEntity)
    Public playerMana As New Integer
    Public playerBoard As New List(Of IEntity)
    Public playerHealth As New Integer
    Public playerPowerUsed As New Boolean

    Public enemyHand As New List(Of IEntity)
    Public enemyMana As New Integer
    Public enemyBoard As New List(Of IEntity)
    Public enemyHealth As New Integer
    Public enemyPowerUsed As New Boolean

    Public Sub clearBoard()
        playerHand.Clear()
        playerBoard.Clear()
        enemyHand.Clear()
        enemyBoard.Clear()
    End Sub
End Class
